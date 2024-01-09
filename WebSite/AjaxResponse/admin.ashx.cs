using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using BLL;
using Common;
using Model;


namespace WebSite.AjaxResponse
{
    /// <summary>
    /// admin 的摘要说明
    /// </summary>
    public class admin : IHttpHandler, IRequiresSessionState
    {
        HttpRequest requst;
        HttpResponse response;
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            requst = context.Request;
            response = context.Response;

            string type = requst.QueryString["type"];

            switch (type)
            {
                case "Login":
                    Login();
                    break;
                case "editPwd":
                    EditPwd();
                    break;
            }

        }

        protected void EditPwd()
        {
            string adminID = requst["adminID"];
            string oldPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(requst["oldPwd"], "md5");
            string newPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(requst["newPwd"], "md5");

            Admins admin = AdminManager.Instance.GetAdminByID(int.Parse(adminID));
            if (admin != null)
            {
                string oldPwdRe = admin.Login_Pwd.ToUpper();
                if (oldPwd == oldPwdRe)
                {
                    admin.Admin_ID = int.Parse(adminID);
                    admin.Login_Pwd = newPwd;
                    int result = AdminManager.Instance.Operation(admin, "Edit");
                    if (result > 0)
                    {
                        response.Write("{result:'succ'}");
                        return;
                    }
                    else
                    {
                        response.Write("{result:'fail',msg:'密码修改失败！'}");
                        return;
                    }
                }
                else
                {
                    response.Write("{result:'fail',msg:'原密码不正确，请重新输入！'}");
                    return;
                }
            }

        }
        protected void Login()
        {
            string login_name = requst["loginName"];
            string login_pwd = FormsAuthentication.HashPasswordForStoringInConfigFile(requst["loginPwd"], "md5").Trim();
            //string code = requst.Form["checkWord"];
            //string checkWord = HttpContext.Current.Session["ValidateCode"].ToString();
            //if (checkWord.Trim().ToLower() == code.Trim().ToLower())
            //{
                bool isexsit = AdminManager.Instance.IsUserExist(login_name);
                if (!isexsit)
                {
                    //用户不存在
                    response.Write("{result:'fail',from:'loginName',msg:'用户不存在'}");
                    return;
                }

                int result = AdminManager.Instance.UserLogin(login_name, login_pwd);
                if (result>0)
                {
                    Admins admins = AdminManager.Instance.GetAdminByID(result);
                    if(admins != null)
                    {
                        AdminManager.Instance.Operation(new Admins { Admin_ID = result, lastLogin_Time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) }, "UpDateLastLoginTime");

                        WebCommon.SetCookie(WebCommon.ADMIN_KEY, admins.Admin_ID + "|" + HttpUtility.UrlEncode(admins.Admin_Name) + "|" + HttpUtility.UrlEncode(admins.Login_Name) + "|" + admins.Phone, true);
                        //登录成功
                        response.Write("{result:'succ'}");
                    }
                    else
                    {
                        response.Write("{result:'fail',from:'passWord',msg:'系统发生错误'}");
                    }
                }
                else
                {
                    response.Write("{result:'fail',from:'passWord',msg:'帐号或密码错误'}");
                }
            //}
            //else { response.Write("{result:'fail',from:'checkWord',msg:'验证码错误'}"); }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}