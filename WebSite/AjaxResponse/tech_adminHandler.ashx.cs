using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using BLL;
using Common;
using Model;
using System.Data;
using System.Text.RegularExpressions;
using System.Text;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_adminHandler 的摘要说明
    /// </summary>
    public class tech_adminHandler : IHttpHandler, IReadOnlySessionState
    {
        HttpRequest requst;
        HttpResponse response;
        private string mid = Common.ConfigHelper.GetConfigString("Mcode");
        private string mtype_id = Common.ConfigHelper.GetConfigString("MType");

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            requst = context.Request;
            response = context.Response;

            string type = requst.QueryString["type"];

            switch (type)
            {
                case "AdminLogin":
                    AdminLogin();
                    break;
                case "AddAdmin":
                    AddAdmin();
                    break;
                case "EditAdmin":
                    EditAdmin();
                    break;
                case "AdminDel":
                    AdminDel();
                    break;
                case "editPwd":
                    editPwd();
                    break;
                case "GetYanZhengMa":
                    GetYanZhengMa();
                    break;
                case "CheckYanZhengMa":
                    CheckYanZhengMa();
                    break;
            }
        }

        private void CheckYanZhengMa()
        {
            string mobile = requst.Form["mobile"];
            int yanzhengma = Convert.ToInt32(requst.Form["yanzhengma"]);
            tech_yanzhengma info = new tech_yanzhengma();
            info.mobile = mobile;
            info.yanzhengma = yanzhengma;
            DataTable dt = tech_yanzhengmaManager.Instance.GetTech_yanzhengma(info);
            if (dt.Rows.Count > 0)
            {
                tech_yanzhengma model = tech_yanzhengmaManager.Instance.getModel(mobile, yanzhengma);
                if (model != null && model.yanzhengma > 0 && model.yanzhengma == yanzhengma)
                {
                    tech_yanzhengmaManager.Instance.Operation(model, "del_yanzhengma");
                    Common.WebCommon.SetCookie(WebCommon.MOBLIE_KEY, info.mobile);
                    response.Write("success");
                }
                else
                {
                    response.Write("failed");
                }
            }
            else
            {
                response.Write("failed");
            }
        }

        private void GetYanZhengMa()
        {
            string mobile = requst.Form["mobile"];

            tech_yanzhengma info_del = new tech_yanzhengma();
            info_del.mobile = mobile;
            tech_yanzhengmaManager.Instance.Operation(info_del, "del_yanzhengma");

            Random random = new Random();
            int code = random.Next(1000, 9999);
            tech_yanzhengma info_add = new tech_yanzhengma();
            info_add.mobile = mobile;
            info_add.yanzhengma = code;
            int add_result = tech_yanzhengmaManager.Instance.Operation(info_add, "add_yanzhengma");
            if (add_result > 0)
            {
                string content = string.Empty;
                content = string.Format("验证码为：{0}，请输入后进行验证。", code);
                string result = SendMsg(mobile, content);
                if (result == "suc_ok")
                    response.Write("{result:'succ',msg:'短信已发送，请注意查收'}");
                else
                    response.Write("{result:'fail',msg:'短信发送失败，请稍后重试'}");
            }
            else
            {
                response.Write("{result:'fail',msg:'验证码生成失败，请重新发送'}");
            }

        }

        private void editPwd()
        {
            if (requst.Form["admin_code"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'用户编码不能为空！'}");
                return;
            }
            if (requst.Form["oldPwd"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'原密码不能为空！'}");
                return;
            }
            if (requst.Form["newPwd"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'新密码不能为空！'}");
                return;
            }

            string oldPwd = Common.DEncrypt.DESEncrypt.Encrypt(Convert.ToString(requst.Form["oldPwd"]));
            string oldPwdRe = WebCommon.GetCookie(WebCommon.ADMIN_KEY, 3).Split('=')[1];
            if (oldPwdRe != oldPwd)
            {
                response.Write("{result:'fail',msg:'原密码不正确！'}");
                return;
            }

            tech_admin info = new tech_admin();
            info.Admin_code = int.Parse(requst.Form["admin_code"].ToString());
            info.Login_name = requst.Form["login_name"].ToString();
            info.Login_pwd = Common.DEncrypt.DESEncrypt.Encrypt(Convert.ToString(requst.Form["newPwd"]));

            int result = tech_adminManager.Instance.Operation(info, "edit_admin");
            if (result > 0)
            {
                tech_operating_record operating_record = new tech_operating_record();
                operating_record.Admin_code = info.Admin_code;
                operating_record.Record_content = "修改密码！";
                operating_record.Operating_user = info.Login_name;
                operating_record.IP_Addr = requst.ServerVariables.Get("Remote_Addr").ToString();
                operating_record.Host_name = requst.ServerVariables.Get("Remote_Host").ToString();
                operating_record.Mid = mid;
                operating_record.Mtype_id = mtype_id;
                tech_operating_recordManager.Instance.Operating(operating_record, "add_msg");

                response.Write("{result:'succ',msg:'修改成功，请重新登录！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'编辑失败！'}");
                return;
            }

        }

        private void AdminDel()
        {
            tech_admin info = new tech_admin();

            if (requst.QueryString["deviceID"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'用户编码不能为空！'}");
                return;
            }

            info.Admin_code = Convert.ToInt32(requst.QueryString["deviceID"]);

            int result = tech_adminManager.Instance.Operation(info, "delete_system");
            if (result > 0)
            {
                tech_operating_record operating_record = new tech_operating_record();
                operating_record.Admin_code = info.Admin_code;
                operating_record.Record_content = "删除账户！";
                operating_record.Operating_user = info.Login_name;
                operating_record.IP_Addr = requst.ServerVariables.Get("Remote_Addr").ToString();
                operating_record.Host_name = requst.ServerVariables.Get("Remote_Host").ToString();
                operating_record.Mid = mid;
                operating_record.Mtype_id = mtype_id;
                tech_operating_recordManager.Instance.Operating(operating_record, "add_msg");

                response.Write("{result:'succ',msg:'删除成功！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'删除失败！'}");
                return;
            }
        }

        private void EditAdmin()
        {
            tech_admin info = new tech_admin();

            if (requst.Form["admin_code"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'用户编码不能为空！'}");
                return;
            }
            if (requst.Form["admin_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'姓名不能为空！'}");
                return;
            }
            if (requst.Form["login_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'登录ID不能为空！'}");
                return;
            }
            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }

            info.Admin_code = Convert.ToInt32(requst.Form["admin_code"]);
            info.Admin_name = Convert.ToString(requst.Form["admin_name"]);
            info.Login_name = Convert.ToString(requst.Form["login_name"]);
            info.Gender = Convert.ToInt32(requst.Form["gender"]);
            info.Phone = Convert.ToString(requst.Form["phone"]);
            info.Address = Convert.ToString(requst.Form["address"]);
            info.Admin_type = Convert.ToInt32(requst.Form["admin_type"]);
            info.Remark = Convert.ToString(requst.Form["remark"]);
            if (!string.IsNullOrEmpty(requst.Form["login_pwd"]))
            {
                string RegexStr = "^(?![a-zA-Z]+$)(?![A-Z0-9]+$)(?![A-Z\\W_!@#$%^&*`~()-+=]+$)(?![a-z0-9]+$)(?![a-z\\W_!@#$%^&*`~()-+=]+$)(?![0-9\\W_!@#$%^&*`~()-+=]+$)[a-zA-Z0-9\\W_!@#$%^&*`~()-+=]{8,30}$";

                if (!Regex.IsMatch(requst.Form["login_pwd"].ToString(), RegexStr))
                {
                    response.Write("{result:'fail',msg:'密码必须是大写字母，小写字母，数字，特殊字符”四项中的至少三项且不少于8位！'}");
                    return;
                }
                info.Login_pwd = Common.DEncrypt.DESEncrypt.Encrypt(Convert.ToString(requst.Form["login_pwd"]));
            }

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(requst.Form["mid"].ToString());
            if (meeting != null)
            {
                info.Mid = meeting.mid;
                info.Mtype_id = meeting.mtype_id;
            }


            int result = tech_adminManager.Instance.Operation(info, "edit_admin");
            if (result > 0)
            {
                tech_operating_record operating_record = new tech_operating_record();
                operating_record.Admin_code = info.Admin_code;
                operating_record.Record_content = "编辑管理员资料！";
                operating_record.Operating_user = info.Login_name;
                operating_record.IP_Addr = requst.ServerVariables.Get("Remote_Addr").ToString();
                operating_record.Host_name = requst.ServerVariables.Get("Remote_Host").ToString();
                operating_record.Mid = mid;
                operating_record.Mtype_id = mtype_id;
                tech_operating_recordManager.Instance.Operating(operating_record, "add_msg");

                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'编辑失败！'}");
                return;
            }
        }

        private void AddAdmin()
        {
            tech_admin info = new tech_admin();

            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["admin_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'姓名不能为空！'}");
                return;
            }
            if (requst.Form["login_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'登录ID不能为空！'}");
                return;
            }
            if (requst.Form["login_pwd"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'密码不能为空！'}");
                return;
            }

            info.Admin_name = Convert.ToString(requst.Form["admin_name"]);
            info.Login_name = Convert.ToString(requst.Form["login_name"]);
            info.Login_pwd = Common.DEncrypt.DESEncrypt.Encrypt(Convert.ToString(requst.Form["login_pwd"]));
            info.Gender = Convert.ToInt32(requst.Form["gender"]);
            info.Phone = Convert.ToString(requst.Form["phone"]);
            info.Address = Convert.ToString(requst.Form["address"]);
            info.Admin_type = Convert.ToInt32(requst.Form["admin_type"]);
            info.Remark = Convert.ToString(requst.Form["remark"]);

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(requst.Form["mid"].ToString());
            if (meeting != null)
            {
                info.Mid = meeting.mid;
                info.Mtype_id = meeting.mtype_id;
            }

            int result = tech_adminManager.Instance.Operation(info, "add_admin");
            if (result > 0)
            {
                string admin_code = WebCommon.GetCookie(WebCommon.ADMIN_KEY, 4).Split('=')[1];
                string admin_name = WebCommon.GetCookie(WebCommon.ADMIN_KEY, 2).Split('=')[1];
                tech_operating_record operating_record = new tech_operating_record();
                operating_record.Admin_code = int.Parse(admin_code);
                operating_record.Operating_user = admin_name;
                operating_record.Record_content = "添加ID为"+ result + "的管理员！";
                operating_record.IP_Addr = requst.ServerVariables.Get("Remote_Addr").ToString();
                operating_record.Host_name = requst.ServerVariables.Get("Remote_Host").ToString();
                operating_record.Mid = mid;
                operating_record.Mtype_id = mtype_id;
                tech_operating_recordManager.Instance.Operating(operating_record, "add_msg");

                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'添加失败！'}");
                return;
            }

        }

        #region 管理员登录
        /// <summary>
        /// 管理员登录
        /// </summary>
        protected void AdminLogin()
        {            
            tech_admin info = new tech_admin();
            info.Login_name = Convert.ToString(requst.Form["loginName"]);
            info.Login_pwd = Common.DEncrypt.DESEncrypt.Encrypt(Convert.ToString(requst.Form["loginPwd"]));

            string code = requst.Form["vcode"];
            string VCode = HttpContext.Current.Session["ValidateCode"].ToString();
            if (VCode.Trim().ToLower() != code.Trim().ToLower())
            {
                response.Write("{result:0,msg:'验证码错误'}");
            }
            else
            {
                tech_admin adminInfo = tech_adminManager.Instance.Login(info.Login_name, info.Login_pwd);
                if (adminInfo != null)
                {
                    if (adminInfo.ErrorTimes < 5 || DateTime.Now.Subtract(adminInfo.LastErrorDateTime).Minutes > 30)
                    {
                        info.ErrorTimes = 0;
                        int errResult = tech_adminManager.Instance.Operation(info, "record_err_times_clear");

                        int log_time = tech_adminManager.Instance.Operation(info, "record_log_time");

                        tech_operating_record operating_record = new tech_operating_record();
                        operating_record.Admin_code = adminInfo.Admin_code;
                        operating_record.Record_content = "登录系统！";
                        operating_record.Operating_user = adminInfo.Login_name;
                        operating_record.IP_Addr = requst.ServerVariables.Get("Remote_Addr").ToString();
                        operating_record.Host_name = requst.ServerVariables.Get("Remote_Host").ToString();
                        operating_record.Mid = mid;
                        operating_record.Mtype_id = mtype_id;
                        tech_operating_recordManager.Instance.Operating(operating_record, "add_msg");

                        Common.WebCommon.SetCookie(WebCommon.ADMIN_KEY, adminInfo.Admin_type.ToString(), HttpUtility.UrlEncode(adminInfo.Admin_name), adminInfo.Login_name, adminInfo.Login_pwd, adminInfo.Admin_code.ToString());
                        response.Write("{result:1}");
                    }
                    else
                    {
                        response.Write("{result:0,msg:'登录失败！账号已被锁定！请30分钟后再试！'}");
                    }
                }
                else
                {
                    DataTable dt = tech_adminManager.Instance.GetTech_admin(info, "select_admin_name");
                    if (dt.Rows.Count > 0)
                    {
                        int infoError = int.Parse(dt.Rows[0]["ErrorTimes"].ToString());
                        infoError++;

                        if (infoError > 5)
                        {
                            tech_operating_record operating_record = new tech_operating_record();
                            operating_record.Admin_code = int.Parse(dt.Rows[0]["admin_code"].ToString());
                            operating_record.Record_content = "账户已被锁定！";
                            operating_record.Operating_user = dt.Rows[0]["login_name"].ToString();
                            operating_record.IP_Addr = requst.ServerVariables.Get("Remote_Addr").ToString();
                            operating_record.Host_name = requst.ServerVariables.Get("Remote_Host").ToString();
                            operating_record.Mid = mid;
                            operating_record.Mtype_id = mtype_id;
                            tech_operating_recordManager.Instance.Operating(operating_record, "add_msg");

                            response.Write("{result:0,msg:'您登录错误次数太多了，账户已被锁定！请30分钟后再试！'}");
                            return;
                        }
                        else
                        {
                            info.ErrorTimes = infoError;
                            info.LastErrorDateTime = DateTime.Now;
                            int errResult = tech_adminManager.Instance.Operation(info, "record_err_time");

                            tech_operating_record operating_record = new tech_operating_record();
                            operating_record.Admin_code = int.Parse(dt.Rows[0]["admin_code"].ToString());
                            operating_record.Record_content = "登录失败！";
                            operating_record.Operating_user = dt.Rows[0]["login_name"].ToString();
                            operating_record.IP_Addr = requst.ServerVariables.Get("Remote_Addr").ToString();
                            operating_record.Host_name = requst.ServerVariables.Get("Remote_Host").ToString();
                            operating_record.Mid = mid;
                            operating_record.Mtype_id = mtype_id;
                            tech_operating_recordManager.Instance.Operating(operating_record, "add_msg");
                        }
                    }                    
                    response.Write("{result:0,msg:'帐号或密码错误'}");
                }
            }
        }
        #endregion

        /// <summary>
        /// 发送短信
        /// 创建人员：靳海云
        /// 创建日期：2013/7/8 
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <param name="content">内容</param>
        protected string SendMsg(string phone, string content)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"<?xml version='1.0' standalone='yes'?>");
            sb.Append("<techmax>");
            sb.Append("<techmax_sms>");
            sb.AppendFormat("<mobile>{0}</mobile>", phone);
            sb.AppendFormat("<msg>{0}</msg>", content);
            sb.AppendFormat("<mid>{0}</mid>", Common.ConfigHelper.GetConfigString("Mcode"));
            sb.AppendFormat("<signature>{0}</signature>", Common.ConfigHelper.GetConfigString("signature"));
            sb.Append("</techmax_sms>");
            sb.Append(" </techmax>");
            return new WebSite.TechMaxSms.SMSWebService().sendSms(sb.ToString());
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