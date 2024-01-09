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
    /// tech_meetingHandler 的摘要说明
    /// </summary>
    public class tech_meetingHandler : PageBaseHandler
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
            tech_meeting info = new tech_meeting();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.mid = requst.QueryString["id"].ToString();
            }
            
            int result = tech_meetingManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                string content = "删除mid为" + info.mid + "的会议！";
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
            tech_meeting info = new tech_meeting();

            if (requst.Form["mtype_id"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议类别不能为空！'}");
                return;
            }
            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["mname"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议名称不能为空！'}");
                return;
            }
            if (requst.Form["address"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'开会地点不能为空！'}");
                return;
            }
            if (requst.Form["begindate"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议开始时间不能为空！'}");
                return;
            }
            if (requst.Form["enddate"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议结束时间不能为空！'}");
                return;
            }

            info.mtype_id = requst.Form["mtype_id"].ToString();
            info.mid = requst.Form["mid"].ToString();
            info.mname = requst.Form["mname"].ToString();
            info.address = requst.Form["address"].ToString();
            info.begindate = DateTime.Parse(requst.Form["begindate"].ToString());
            info.enddate = DateTime.Parse(requst.Form["enddate"].ToString());
            //info.mcontact = requst.Form["mcontact"].ToString();
            //info.mcontactmblie = requst.Form["mcontactmblie"].ToString();
            info.project_manager_id = int.Parse(requst.Form["project_manager_id"].ToString());

            info.reguser = int.Parse(requst.Form["reguser"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["reguserdate"].ToString()))
                info.reguserdate = DateTime.Parse(requst.Form["reguserdate"].ToString());

            info.article = int.Parse(requst.Form["article"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["articledate"].ToString()))
                info.articledate = DateTime.Parse(requst.Form["articledate"].ToString());

            info.reguser = int.Parse(requst.Form["reguser"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["reguserdate"].ToString()))
                info.reguserdate = DateTime.Parse(requst.Form["reguserdate"].ToString());

            info.lodging = int.Parse(requst.Form["lodging"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["lodgingdate"].ToString()))
                info.lodgingdate = DateTime.Parse(requst.Form["lodgingdate"].ToString());

            info.reviewers = int.Parse(requst.Form["reviewers"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["reviewersdate"].ToString()))
                info.reviewersdate = Convert.ToDateTime(requst.Form["reviewersdate"].ToString());

            if (!string.IsNullOrEmpty(requst.Form["meetingcheckin_date"].ToString()))
                info.meetingcheckin_date = Convert.ToDateTime(requst.Form["meetingcheckin_date"]);

            if (!string.IsNullOrEmpty(requst.Form["regenddate"].ToString()))
                info.regenddate = Convert.ToDateTime(requst.Form["regenddate"]);

            if (!string.IsNullOrEmpty(requst.Form["m_website"].ToString()) && requst.Form["m_website"].ToString() != "http://")
                info.m_website = requst.Form["m_website"].ToString();

            if (!string.IsNullOrEmpty(requst.Form["m_img"].ToString()) && requst.Form["m_img"].ToString() != "http://")
                info.m_img = requst.Form["m_img"];

            info.is_live = int.Parse(requst.Form["is_live"].ToString());
            info.is_playBack = int.Parse(requst.Form["is_playBack"].ToString());
            info.is_recommend = int.Parse(requst.Form["is_recommend"].ToString());
            info.is_xsh_show = int.Parse(requst.Form["is_xsh_show"].ToString());
            info.is_weizhankaitong = int.Parse(requst.Form["is_weizhankaitong"].ToString());

            int result = tech_meetingManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                string content = "编辑mid为" + info.mid + "的会议！";
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

        private void Add()
        {
            tech_meeting info = new tech_meeting();

            if (requst.Form["mtype_id"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议类别不能为空！'}");
                return;
            }
            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["mname"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议名称不能为空！'}");
                return;
            }
            if (requst.Form["address"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'开会地点不能为空！'}");
                return;
            }
            if (requst.Form["begindate"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议开始时间不能为空！'}");
                return;
            }
            if (requst.Form["enddate"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议结束时间不能为空！'}");
                return;
            }
            int i = tech_meetingManager.Instance.Operation(info, "isExtMName");
            if (i > 0)
            {
                response.Write("{result:'fail',msg:'会议名称已存在，请更换名称！'}");
                return;
            }

            info.mtype_id = requst.Form["mtype_id"].ToString();
            info.mid = requst.Form["mid"].ToString();
            info.mname = requst.Form["mname"].ToString();
            info.address = requst.Form["address"].ToString();
            info.begindate = DateTime.Parse(requst.Form["begindate"].ToString());
            info.enddate = DateTime.Parse(requst.Form["enddate"].ToString());
            //info.mcontact = requst.Form["mcontact"].ToString();
            //info.mcontactmblie = requst.Form["mcontactmblie"].ToString();
            info.project_manager_id = int.Parse(requst.Form["project_manager_id"].ToString());

            info.reguser = int.Parse(requst.Form["reguser"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["reguserdate"].ToString()))
                info.reguserdate = DateTime.Parse(requst.Form["reguserdate"].ToString());

            info.article = int.Parse(requst.Form["article"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["articledate"].ToString()))
                info.articledate = DateTime.Parse(requst.Form["articledate"].ToString());

            info.reguser = int.Parse(requst.Form["reguser"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["reguserdate"].ToString()))
                info.reguserdate = DateTime.Parse(requst.Form["reguserdate"].ToString());

            info.lodging = int.Parse(requst.Form["lodging"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["lodgingdate"].ToString()))
                info.lodgingdate = DateTime.Parse(requst.Form["lodgingdate"].ToString());

            info.reviewers = int.Parse(requst.Form["reviewers"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["reviewersdate"].ToString()))
                info.reviewersdate = Convert.ToDateTime(requst.Form["reviewersdate"].ToString());

            if (!string.IsNullOrEmpty(requst.Form["meetingcheckin_date"].ToString()))
                info.meetingcheckin_date = Convert.ToDateTime(requst.Form["meetingcheckin_date"]);
            if (!string.IsNullOrEmpty(requst.Form["regenddate"].ToString()))
                info.regenddate = Convert.ToDateTime(requst.Form["regenddate"]);

            info.m_website = requst.Form["m_website"].ToString();

            info.is_live = int.Parse(requst.Form["is_live"].ToString());
            info.is_playBack = int.Parse(requst.Form["is_playBack"].ToString());
            info.is_recommend = int.Parse(requst.Form["is_recommend"].ToString());
            info.is_xsh_show = int.Parse(requst.Form["is_xsh_show"].ToString());

            info.zzjzpasswd = TechMaxClass.GetRandomStr();

            int result = tech_meetingManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                //string content = "添加mid为" + result + "的会议！";
                //operating_record(content);

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