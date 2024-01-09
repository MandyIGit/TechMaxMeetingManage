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
    /// tech_user_allHandler 的摘要说明
    /// </summary>
    public class tech_user_allHandler : PageBaseHandler
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
                    InputUserAll_listHTML(pageIndex, pageSize);
                    break;
            }
        }

        private void InputUserAll_listHTML(int pageIndex, int pageSize)
        {
            tech_user_all info = new tech_user_all();
            info.PageIndex = pageIndex;
            info.PageSize = pageSize;
            if (!string.IsNullOrEmpty(requst.Form["Full_name"]) && Convert.ToString(requst.Form["Full_name"]) != "")
            {
                info.Full_name = Convert.ToString(requst.Form["Full_name"]).Trim();
            }
            if (!string.IsNullOrEmpty(requst.Form["mail"]) && Convert.ToString(requst.Form["mail"]) != "")
            {
                info.Mail = Convert.ToString(requst.Form["mail"]).Trim();
            }
            if (!string.IsNullOrEmpty(requst.Form["mobile"]) && Convert.ToString(requst.Form["mobile"]) != "")
            {
                info.Mobile = Convert.ToString(requst.Form["mobile"]).Trim();
            }
            
            StringBuilder sb = new StringBuilder();
            int allCount = tech_user_allManager.Instance.GetTech_user_all_count(info);
            int pageCount = (allCount + pageSize - 1) / pageSize;
            DataTable dt = tech_user_allManager.Instance.GetTech_user_all(info);
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th data-priority=\"1\">用户编码</th>");
            sb.Append("<th data-priority=\"1\">姓名</th>");
            sb.Append("<th data-priority=\"1\">性别</th>");
            sb.Append("<th data-priority=\"1\">邮箱</th>");
            sb.Append("<th data-priority=\"1\">手机</th>");
            sb.Append("<th data-priority=\"1\">省市</th>");
            sb.Append("<th data-priority=\"1\">单位</th>");
            sb.Append("<th data-priority=\"1\">科室</th>");
            sb.Append("<th data-priority=\"1\">参会统计数</th>");
            sb.Append("<th data-priority=\"1\">操作</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["user_code"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["full_name"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["gender_title"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["mail"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["mobile"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["province_name"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["unit_name"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["offices"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["order_count"].ToString());
                    sb.AppendFormat("<td>");
                    sb.AppendFormat("<a href=\"javascript:;\" id=\"{0}\" onclick=\"window.open('meeting_order_list.aspx?userid={0}','_blank','width=1111,height=460,top=180,left=220,scrollbars=yes,resizable=1,modal=false,alwaysRaised=yes')\" class=\"btn btn-secondary btn-xs\">查看参会记录</a>", dt.Rows[i]["user_code"].ToString());
                    sb.Append("</td>");
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
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_user_allHandler", 1, "aspnetForm", "tb_Content"));
            sb.Append("</div>");

            response.Write(sb.ToString());
        }

    }
}