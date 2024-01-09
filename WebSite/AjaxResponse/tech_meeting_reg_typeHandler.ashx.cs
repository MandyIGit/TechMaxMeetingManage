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
    /// tech_meeting_reg_typeHandler 的摘要说明
    /// </summary>
    public class tech_meeting_reg_typeHandler : PageBaseHandler
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
            tech_meeting_reg_type info = new tech_meeting_reg_type();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.Id = int.Parse(requst.QueryString["id"].ToString());
            }

            int result = tech_meeting_reg_typeManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                string content = "删除ID为" + info.Id + "的参会类型！";
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
            tech_meeting_reg_type info = new tech_meeting_reg_type();

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
            if (requst.Form["ch_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'类型名称(中文)不能为空！'}");
                return;
            }
            if (requst.Form["begin_time"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'开始时间不能为空！'}");
                return;
            }
            if (requst.Form["end_time"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'结束时间不能为空！'}");
                return;
            }
            if (requst.Form["money"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'价格不能为空！'}");
                return;
            }

            info.Id = int.Parse(requst.Form["id"].ToString());
            info.Ch_name = requst.Form["ch_name"].ToString();
            info.En_name = requst.Form["en_name"].ToString();
            info.Begin_time = DateTime.Parse(requst.Form["begin_time"].ToString());
            info.End_time = DateTime.Parse(requst.Form["end_time"].ToString());
            info.Money = decimal.Parse(requst.Form["money"].ToString());
            info.Use_type = int.Parse(requst.Form["use_type"].ToString());
            info.Use_location = int.Parse(requst.Form["use_location"].ToString());
            info.Isupload = int.Parse(requst.Form["Isupload"].ToString());

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(requst.Form["mid"].ToString());
            if (meeting != null)
            {
                info.Mid = meeting.mid;
                info.Mtype_id = meeting.mtype_id;
            }

            int result = tech_meeting_reg_typeManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                string content = "编辑ID为" + info.Id + "的参会类型！";
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
            tech_meeting_reg_type info = new tech_meeting_reg_type();

            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["ch_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'类型名称(中文)不能为空！'}");
                return;
            }
            if (requst.Form["begin_time"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'开始时间不能为空！'}");
                return;
            }
            if (requst.Form["end_time"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'结束时间不能为空！'}");
                return;
            }
            if (requst.Form["money"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'价格不能为空！'}");
                return;
            }

            info.Ch_name = requst.Form["ch_name"].ToString();
            info.En_name = requst.Form["en_name"].ToString();
            info.Begin_time = DateTime.Parse(requst.Form["begin_time"].ToString());
            info.End_time = DateTime.Parse(requst.Form["end_time"].ToString());
            info.Money = decimal.Parse(requst.Form["money"].ToString());
            info.Use_type = int.Parse(requst.Form["use_type"].ToString());
            info.Use_location = int.Parse(requst.Form["use_location"].ToString());
            info.Isupload = int.Parse(requst.Form["Isupload"].ToString());

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(requst.Form["mid"].ToString());
            if (meeting != null)
            {
                info.Mid = meeting.mid;
                info.Mtype_id = meeting.mtype_id;
            }

            int result = tech_meeting_reg_typeManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                string content = "添加ID为" + result + "的参会类型！";
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