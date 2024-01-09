using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Common;
using Model;
using System.Data;
using Common.DEncrypt;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// email_templateHandler 的摘要说明
    /// </summary>
    public class email_templateHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            requst = context.Request;
            response = context.Response;
            string type = requst.QueryString["type"];
            switch (type)
            {
                case "add":
                    Add();
                    break;
                case "edit":
                    Edit();
                    break;
                case "del":
                    Del();
                    break;
            }
        }

        private void Del()
        {
            email_template info = new email_template();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.Id = int.Parse(requst.QueryString["id"].ToString());
            }

            int result = email_templateManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                string content = "删除ID为" + info.Id + "的邮件模板！";
                operating_record(content);

                response.Write("{result:'succ',msg:'删除成功！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'删除失败！'}");
                return;
            }
        }

        private void Edit()
        {
            email_template info = new email_template();

            if (requst.Form["id"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'ID不能为空！'}");
                return;
            }
            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["tp_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'模板名称不能为空！'}");
                return;
            }
            if (requst.Form["tel"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'秘书处电话不能为空！'}");
                return;
            }
            if (requst.Form["email"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'秘书处邮箱不能为空！'}");
                return;
            }
            if (requst.Form["web_url"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'大会网址不能为空！'}");
                return;
            }

            info.Id = int.Parse(requst.Form["id"].ToString());
            info.Tp_name = requst.Form["tp_name"].ToString();
            info.Tp_content = requst.Form["tp_content"].ToString();
            info.Tel = requst.Form["tel"].ToString();
            info.Fax = requst.Form["fax"].ToString();
            info.Email = requst.Form["email"].ToString();
            info.Web_url = requst.Form["web_url"].ToString();

            if (!string.IsNullOrEmpty(requst.Form["m_p_content_ch"].ToString()))
                info.M_p_content_ch = DESEncrypt.Encrypt(requst.Form["m_p_content_ch"].ToString());
            else
                info.M_p_content_ch = "";

            if (!string.IsNullOrEmpty(requst.Form["m_p_content_en"].ToString()))
                info.M_p_content_en = DESEncrypt.Encrypt(requst.Form["m_p_content_en"].ToString());
            else
                info.M_p_content_en = "";

            if (!string.IsNullOrEmpty(requst.Form["h_p_content_ch"].ToString()))
                info.H_p_content_ch = DESEncrypt.Encrypt(requst.Form["h_p_content_ch"].ToString());
            else
                info.H_p_content_ch = "";

            if (!string.IsNullOrEmpty(requst.Form["h_p_content_en"].ToString()))
                info.H_p_content_en = DESEncrypt.Encrypt(requst.Form["h_p_content_en"].ToString());
            else
                info.H_p_content_en = "";

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(requst.Form["mid"].ToString());
            if (meeting != null)
            {
                info.Mid = meeting.mid;
                info.Mtype_id = meeting.mtype_id;
            }

            int result = email_templateManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                string content = "修改ID为" + info.Id + "的邮件模板！";
                operating_record(content);

                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'编辑失败！'}");
                return;
            }
        }

        private void Add()
        {
            email_template info = new email_template();

            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["tp_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'模板名称不能为空！'}");
                return;
            }
            if (requst.Form["tel"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'秘书处电话不能为空！'}");
                return;
            }
            if (requst.Form["email"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'秘书处邮箱不能为空！'}");
                return;
            }
            if (requst.Form["web_url"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'大会网址不能为空！'}");
                return;
            }

            info.Tp_name = requst.Form["tp_name"].ToString();
            info.Tp_content = requst.Form["tp_content"].ToString();
            info.Tel = requst.Form["tel"].ToString();
            info.Fax = requst.Form["fax"].ToString();
            info.Email = requst.Form["email"].ToString();
            info.Web_url = requst.Form["web_url"].ToString();

            if (!string.IsNullOrEmpty(requst.Form["m_p_content_ch"].ToString()))
                info.M_p_content_ch = DESEncrypt.Encrypt(requst.Form["m_p_content_ch"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["m_p_content_en"].ToString()))
                info.M_p_content_en = DESEncrypt.Encrypt(requst.Form["m_p_content_en"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["h_p_content_ch"].ToString()))
                info.H_p_content_ch = DESEncrypt.Encrypt(requst.Form["h_p_content_ch"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["h_p_content_en"].ToString()))
                info.H_p_content_en = DESEncrypt.Encrypt(requst.Form["h_p_content_en"].ToString());

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(requst.Form["mid"].ToString());
            if (meeting != null)
            {
                info.Mid = meeting.mid;
                info.Mtype_id = meeting.mtype_id;
            }

            int result = email_templateManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                string content = "添加ID为" + result + "的邮件模板！";
                operating_record(content);

                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'添加失败！'}");
                return;
            }

        }

    }
}