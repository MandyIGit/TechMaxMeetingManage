using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Common;
using Model;
using System.Data;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_meeting_type 的摘要说明
    /// </summary>
    public class tech_meeting_typeHandler : PageBaseHandler
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
            tech_meeting_type info = new tech_meeting_type();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.Mtype_id = requst.QueryString["id"].ToString();
            }
            
            int result = tech_meeting_typeManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                string content = "删除Mtype_id为" + info.Mtype_id + "的会议类型！";
                operating_record(content);

                response.Write("{result:'succ',msg:'删除成功！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'编辑失败！'}");
                return;
            }
        }

        private void Edit()
        {
            tech_meeting_type info = new tech_meeting_type();
            info.Mtype_id = requst.Form["mtype_id"].ToString();
            info.Mtype_name = requst.Form["mtype_name"].ToString();
            info.Mtype_memo = requst.Form["mtype_memo"].ToString();
            info.V_sid = Convert.ToInt32(requst.Form["v_sid"].ToString());

            if (requst.Form["mtype_id"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'类型编码不能为空！'}");
                return;
            }
            if (requst.Form["mtype_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'类型名称不能为空！'}");
                return;
            }

            int result = tech_meeting_typeManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                string content = "编辑Mtype_id为" + info.Mtype_id + "的会议类型！";
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
            tech_meeting_type info = new tech_meeting_type();
            info.Mtype_id = requst.Form["mtype_id"].ToString();
            info.Mtype_name = requst.Form["mtype_name"].ToString();
            info.Mtype_memo = requst.Form["mtype_memo"].ToString();
            info.V_sid = Convert.ToInt32(requst.Form["v_sid"].ToString());

            if (requst.Form["mtype_id"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'类型编码不能为空！'}");
                return;
            }
            if (requst.Form["mtype_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'类型名称不能为空！'}");
                return;
            }
            int i = tech_meeting_typeManager.Instance.Operation(info, "isExtTypeName");
            if (i > 0)
            {
                response.Write("{result:'fail',msg:'类型名称已存在，请更换名称！'}");
                return;
            }
            int result = tech_meeting_typeManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                string content = "添加Mtype_id为" + result + "的会议类型！";
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