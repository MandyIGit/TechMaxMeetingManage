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
    /// tech_published_formHandler 的摘要说明
    /// </summary>
    public class tech_published_formHandler : PageBaseHandler
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
            tech_published_form info = new tech_published_form();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.P_id = int.Parse(requst.QueryString["id"].ToString());
            }

            int result = tech_published_formManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                string content = "删除pid为" + info.P_id + "的学术论文发表形式！";
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
            tech_published_form info = new tech_published_form();

            if (requst.Form["p_id"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'ID不能为空！'}");
                return;
            }
            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["p_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'发表形式名称不能为空！'}");
                return;
            }

            info.P_id = int.Parse(requst.Form["p_id"].ToString());
            info.P_name = requst.Form["p_name"].ToString();
            info.App_type = int.Parse(requst.Form["app_type"].ToString());

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(requst.Form["mid"].ToString());
            if (meeting != null)
            {
                info.Mid = meeting.mid;
                info.Mtype_id = meeting.mtype_id;
            }

            int result = tech_published_formManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                string content = "编辑pid为" + info.P_id + "的学术论文发表形式！";
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
            tech_published_form info = new tech_published_form();

            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["p_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'发表形式名称不能为空！'}");
                return;
            }

            info.P_name = requst.Form["p_name"].ToString();
            info.App_type = int.Parse(requst.Form["app_type"].ToString());            

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(requst.Form["mid"].ToString());
            if (meeting != null)
            {
                info.Mid = meeting.mid;
                info.Mtype_id = meeting.mtype_id;
            }

            int result = tech_published_formManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                string content = "添加pid为" + result + "的学术论文发表形式！";
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