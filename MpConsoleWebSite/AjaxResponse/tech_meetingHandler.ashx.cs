using BLL;
using Common;
using Common.DEncrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace MpConsoleWebSite.AjaxResponse
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
            string xml = Convert.ToString(requst.Params["postvalue"]);
            DataSet ds = null;
            if (!string.IsNullOrEmpty(xml) && xml != "")
            {
                ds = TechMaxClass.DataSetVerify(TechMaxClass.getDataSetfromXML(xml));
            }
            int pageIndex = 0;
            int pageSize = 10;
            if (ds != null)
            {
                if (ds.Tables[0].Columns[0].ColumnName == "pageIndex")
                {
                    pageIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["pageIndex"]);
                    pageSize = Convert.ToInt32(ds.Tables[0].Rows[0]["pageSize"]);
                }
            }

            switch (type)
            {
                case "1":
                    meeting_list(pageIndex, pageSize);
                    break;
                case "ManageMeeting":
                    ManageMeeting(xml);
                    break;
            }
        }

        private void ManageMeeting(string xml)
        {
            string dexml = DESEncrypt.Decrypt(xml);
            string[] mid_pass = dexml.Split('|');
            string mid = mid_pass[0];
            string pwd = mid_pass[1];

            StringBuilder sb = new StringBuilder();
            tech_meeting model = tech_meetingManager.Instance.MeetingLogin(mid, pwd);
            if (model != null)
            {
                Common.WebCommon.RemoveCookie(WebCommon.MEETING_KEY);
                Common.WebCommon.SetMeetingCookie(WebCommon.MEETING_KEY, model.mid, model.mtype_id);
                response.Write("succ");
            }
            else
            {
                response.Write("fail");      //帐号或者密码错误，请重新输入
            }
        }

        private void meeting_list(int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();

            tech_meeting info = new tech_meeting();
            info.project_manager_id = Convert.ToInt32(requst.Form["project_manager_id"]);
            if (!string.IsNullOrEmpty(requst.Form["mname"]))
            {
                info.mname = requst.Form["mname"];
            }
            if (Convert.ToInt32(requst.Form["huiyi_status"]) > 0)
            {
                info.huiyi_status = Convert.ToInt32(requst.Form["huiyi_status"]);
            }
            info.pageIndex = pageIndex;
            info.pageSize = pageSize;

            DataTable dt = tech_meetingManager.Instance.GetTech_meeting(info, "select_meeting_to_page");
            int allCount = tech_meetingManager.Instance.Operation(info, "select_meeting_to_page_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;

            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotable\">");
            sb.Append("<thead><tr>");
            sb.Append("<th>会议编码</th>");
            sb.Append("<th>建站密码</th>");
            sb.Append("<th>会议类型</th>");
            sb.Append("<th>会议名称</th>");
            sb.Append("<th>开会地点</th>");
            sb.Append("<th>会议开始时间</th>");
            sb.Append("<th>会议结束时间</th>");
            //sb.Append("<th>会议负责人</th>");
            //sb.Append("<th>前期注册截止时间</th>");
            //sb.Append("<th>大会报到日期</th>");
            sb.Append("<th>注册缴费截止日期</th>");
            sb.Append("<th>操作</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody id=\"table_body\">");
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr class=\"odd gradeX\">");
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["mid"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["zzjzpasswd"]));
                    sb.AppendFormat("<td title=\"{0}\">{1}</td>", getMeetingTypeName(dt.Rows[i]["mtype_id"].ToString()), Common.StringHelper.FirstString(getMeetingTypeName(dt.Rows[i]["mtype_id"].ToString()), 60, "..."));
                    sb.AppendFormat("<td title=\"{0}\">{1}</td>", dt.Rows[i]["mname"].ToString(), Common.StringHelper.FirstString(dt.Rows[i]["mname"].ToString(), 60, "..."));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["address"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["begindate"]).ToString("yyyy-MM-dd"));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["enddate"]).ToString("yyyy-MM-dd"));
                    //sb.AppendFormat("<td title=\"{0}\">{0}</td>", getProjectManager(dt.Rows[i]["project_manager_id"].ToString()));
                    //sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["reguserdate"]).ToString("yyyy-MM-dd"));
                    //sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["meetingcheckin_date"]).ToString("yyyy-MM-dd"));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["regenddate"]).ToString("yyyy-MM-dd"));
                    sb.Append("<td>");
                    sb.AppendFormat("<a href=\"tech_meeting_edit.aspx?mid={0}\" class=\"btn btn-primary btn-xs\">编辑</a>", dt.Rows[i]["mid"].ToString());
                    sb.Append("&nbsp;");
                    sb.AppendFormat("<a href=\"javascript:;\" class=\"btn btn-success btn-xs\" onclick=\"ManageMeeting('{0}')\">管理会议</a>", DESEncrypt.Encrypt(dt.Rows[i]["mid"].ToString() + "|" + dt.Rows[i]["zzjzpasswd"].ToString()));
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr class=\"odd gradeX\">");
                sb.Append("<td colspan=\"11\">Null</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_meetingHandler", 1, "form1", "meeting_data"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        protected string getMeetingTypeName(string mtid)
        {
            string mtpye_name = "";
            tech_meeting_type info = tech_meeting_typeManager.Instance.GetModelByTypeId(mtid);
            if (info != null)
            {
                mtpye_name = info.Mtype_name;
            }
            return mtpye_name;
        }

        protected string getProjectManager(string pmid)
        {
            string full_name = "";
            tech_project_manager info = tech_project_managerManager.Instance.GetModelById(pmid);
            if (info != null)
            {
                full_name = info.full_name;
            }
            return full_name;
        }
    }
}