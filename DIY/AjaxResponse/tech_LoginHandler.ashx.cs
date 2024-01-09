using BLL;
using Common;
using Common.DEncrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace DIY.AjaxResponse
{
    /// <summary>
    /// tech_LoginHandler 的摘要说明
    /// </summary>
    public class tech_LoginHandler : PageBaseHandler, IReadOnlySessionState
    {

        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
            requst = context.Request;
            response = context.Response;
            string type = requst.QueryString["type"];
            switch (type)
            {
                case "mlogin":
                    MidLogin();
                    break;
                case "ulogin":
                    SystemLogin();
                    break;
                case "LogOut":
                    LogOut();
                    break;
                case "LogOutManager":
                    LogOutManager();
                    break;
            }

        }

        /// <summary>
        /// 登录
        /// </summary>
        private void SystemLogin()
        {
            string login_name = Convert.ToString(requst.Form["login_name"]);
            string login_pwd = DESEncrypt.Encrypt(Convert.ToString(requst.Form["login_pwd"]));
            string code = Convert.ToString(requst.Form["code"]);
            tech_project_manager info = tech_project_managerManager.Instance.Login(login_name, login_pwd);
            string img_code = HttpContext.Current.Session["ValidateCode"].ToString();
            if (img_code.Trim().ToLower() == code.Trim().ToLower())
            {
                if (info != null && info.mobile != "")
                {
                    Common.WebCommon.SetManagerCookie(WebCommon.MANAGER_KEY, info.id.ToString(), DESEncrypt.Encrypt(info.full_name), login_name, login_pwd, info.mobile);
                    response.Write("OK");
                }
                else
                {
                    response.Write("用户名或密码错误！");
                }
            }
            else
            {
                response.Write("code_error");
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void MidLogin()
        {
            StringBuilder sb = new StringBuilder();
            string mid = requst.Form["mmid"];
            string pwd = requst.Form["mpwd"];

            string code = requst.Form["mcode"];

            sb.Append("{");
            if (HttpContext.Current.Session["ValidateCode"] != null)
            {
                string VCode = HttpContext.Current.Session["ValidateCode"].ToString();
                if (VCode.Trim().ToLower() == code.Trim().ToLower())
                {
                    tech_meeting model = tech_meetingManager.Instance.MeetingLogin(mid, pwd);
                    if (model != null)
                    {
                        Common.WebCommon.SetMeetingCookie(WebCommon.MEETING_KEY, model.mid, model.mtype_id);                        

                        sb.AppendFormat("'result':'{0}',", 0);
                        sb.Append("'user':[{");
                        sb.AppendFormat("'mid':'{0}','mtype_id':'{1}'", model.mid, model.mtype_id);
                        sb.Append("}]");

                        string content = mid + "登录自助建站！";
                        operating_record(content);
                    }
                    else
                    {
                        sb.AppendFormat("'result':'{0}'", -1);      //帐号或者密码错误，请重新输入
                    }
                }
                else
                {
                    sb.AppendFormat("'result':'{0}'", -2);      //验证码错误，请重新输入
                }
            }
            else
            {
                sb.AppendFormat("'result':'{0}'", -3);      //验证码失效，请重新刷新
            }            
            sb.Append("}");
            response.Write(sb.ToString());

        }
        /// <summary>
        /// 退出
        /// </summary>
        public void LogOut()
        {
            string content = WebCommon.GetCookie(WebCommon.MEETING_KEY, 0).Split('=')[1] + "退出自助建站！";
            operating_record(content);
            Common.WebCommon.RemoveCookie(WebCommon.MEETING_KEY);
        }

        public void LogOutManager()
        {
            Common.WebCommon.RemoveCookie(WebCommon.MEETING_KEY);
            Common.WebCommon.RemoveCookie(WebCommon.MANAGER_KEY);
        }
    }
}