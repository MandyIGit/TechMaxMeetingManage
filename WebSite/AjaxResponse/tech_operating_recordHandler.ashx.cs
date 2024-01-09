using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Common;
using System.Text;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_operating_recordHandler 的摘要说明
    /// </summary>
    public class tech_operating_recordHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
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
                    getLog_list(pageIndex, pageSize);
                    break;
                case "2":
                    getLog_all_list(pageIndex, pageSize);
                    break;
            }
        }

        private void getLog_all_list(int pageIndex, int pageSize)
        {
            tech_operating_record info = new tech_operating_record();
            info.PageIndex = pageIndex;
            info.PageSize = pageSize;
            if (!string.IsNullOrEmpty(requst.Form["operating_user"]) && Convert.ToString(requst.Form["operating_user"]) != "")
            {
                info.Operating_user = Convert.ToString(requst.Form["operating_user"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["record_content"]) && Convert.ToString(requst.Form["record_content"]) != "")
            {
                info.Record_content = Convert.ToString(requst.Form["record_content"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["operating_time_start"]) && Convert.ToString(requst.Form["operating_time_start"]) != "")
            {
                info.operating_time_start = Convert.ToString(requst.Form["operating_time_start"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["operating_time_end"]) && Convert.ToString(requst.Form["operating_time_end"]) != "")
            {
                info.operating_time_end = Convert.ToString(requst.Form["operating_time_end"]);
            }

            StringBuilder sb = new StringBuilder();
            int allCount = tech_operating_recordManager.Instance.Operating(info, "get_operation_count_all");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            DataTable dt = tech_operating_recordManager.Instance.GetTech_operation_record(info, "select_msg_to_page_all");
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th data-priority=\"1\">ID</th>");
            sb.Append("<th data-priority=\"1\">用户编码</th>");
            sb.Append("<th data-priority=\"1\">操作内容</th>");
            sb.Append("<th data-priority=\"1\">操作人</th>");
            sb.Append("<th data-priority=\"1\">操作时间</th>");
            sb.Append("<th data-priority=\"1\">IP地址</th>");
            sb.Append("<th data-priority=\"1\">会议ID</th>");
            sb.Append("<th data-priority=\"1\">会议类型ID</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["id"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["admin_code"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["record_content"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["operating_user"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["operating_time"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["ip_addr"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["mid"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["mtype_id"].ToString());
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr>");
                sb.Append("<td colspan=\"8\">无</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_operating_recordHandler", 2, "aspnetForm", "tb_Content"));
            sb.Append("</div>");

            response.Write(sb.ToString());
        }

        private void getLog_list(int pageIndex, int pageSize)
        {
            tech_operating_record info = new tech_operating_record();
            info.PageIndex = pageIndex;
            info.PageSize = pageSize;
            if (!string.IsNullOrEmpty(requst.Form["operating_user"]) && Convert.ToString(requst.Form["operating_user"]) != "")
            {
                info.Operating_user = Convert.ToString(requst.Form["operating_user"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["record_content"]) && Convert.ToString(requst.Form["record_content"]) != "")
            {
                info.Record_content = Convert.ToString(requst.Form["record_content"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["operating_time_start"]) && Convert.ToString(requst.Form["operating_time_start"]) != "")
            {
                info.operating_time_start = Convert.ToString(requst.Form["operating_time_start"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["operating_time_end"]) && Convert.ToString(requst.Form["operating_time_end"]) != "")
            {
                info.operating_time_end = Convert.ToString(requst.Form["operating_time_end"]);
            }

            StringBuilder sb = new StringBuilder();
            int allCount = tech_operating_recordManager.Instance.Operating(info, "get_operation_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            DataTable dt = tech_operating_recordManager.Instance.GetTech_operation_record(info, "select_msg_to_page");
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th data-priority=\"1\">ID</th>");
            sb.Append("<th data-priority=\"1\">用户编码</th>");
            sb.Append("<th data-priority=\"1\">操作内容</th>");
            sb.Append("<th data-priority=\"1\">操作人</th>");
            sb.Append("<th data-priority=\"1\">操作时间</th>");
            sb.Append("<th data-priority=\"1\">IP地址</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["id"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["admin_code"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["record_content"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["operating_user"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["operating_time"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["ip_addr"].ToString());
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr>");
                sb.Append("<td colspan=\"6\">无</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_operating_recordHandler", 1, "aspnetForm", "tb_Content"));
            sb.Append("</div>");

            response.Write(sb.ToString());
        }
    }
}