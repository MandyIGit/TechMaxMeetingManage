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
    /// tech_send_wx_messageHandler 的摘要说明
    /// </summary>
    public class tech_send_wx_messageHandler : PageBaseHandler
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
                case "addMsg":
                    Add();
                    break;
                case "delMsg":
                    Del();
                    break;
                case "1":
                    InputMsg_listHTML(pageIndex, pageSize);
                    break;
            }
        }

        private void Add()
        {
            tech_send_wx_message info = new tech_send_wx_message();

            info.keyword1 = requst.Form["keyword1"].ToString();
            info.keyword2 = requst.Form["keyword2"].ToString();
            info.keyword3 = requst.Form["keyword3"].ToString();
            info.keyword4 = requst.Form["keyword4"].ToString();
            info.keyword5 = requst.Form["keyword5"].ToString();
            info.weburl = requst.Form["weburl"].ToString();
            info.tagGroup = requst.Form["weburl"].ToString();
            info.sendTime = DateTime.Now;

            int result = tech_send_wx_messageManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'添加失败！'}");
                return;
            }
        }

        private void Del()
        {
            tech_send_wx_message info = new tech_send_wx_message();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.id = int.Parse(requst.QueryString["id"].ToString());
            }

            int result = tech_send_wx_messageManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                response.Write("{result:'succ',msg:'删除成功！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'删除失败！'}");
                return;
            }
        }

        private void InputMsg_listHTML(int pageIndex, int pageSize)
        {
            tech_send_wx_message info = new tech_send_wx_message();
            info.pageIndex = pageIndex;
            info.pageSize = pageSize;
            if (!string.IsNullOrEmpty(requst.Form["keyword1"]))
            {
                info.keyword1 = Convert.ToString(requst.Form["keyword1"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["keyword2"]))
            {
                info.keyword2 = Convert.ToString(requst.Form["keyword2"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["keyword3"]))
            {
                info.keyword3 = Convert.ToString(requst.Form["keyword3"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["keyword4"]))
            {
                info.keyword4 = Convert.ToString(requst.Form["keyword4"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["keyword5"]))
            {
                info.keyword5 = Convert.ToString(requst.Form["keyword5"]);
            }
            StringBuilder sb = new StringBuilder();
            int allCount = tech_send_wx_messageManager.Instance.Operation(info, "select_message_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            DataTable dt = tech_send_wx_messageManager.Instance.GetTech_Send_WX_Message(info, "select_send_wx_message_to_page");
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th data-priority=\"1\">ID</th>");
            sb.Append("<th data-priority=\"1\">会议主题</th>");
            sb.Append("<th data-priority=\"2\">会议日期</th>");
            sb.Append("<th data-priority=\"2\">会议地点</th>");
            sb.Append("<th data-priority=\"2\">发起人</th>");
            sb.Append("<th data-priority=\"2\">备注</th>");
            sb.Append("<th data-priority=\"2\">链接网址</th>");
            sb.Append("<th data-priority=\"2\">用户组</th>");
            sb.Append("<th data-priority=\"2\">发送时间</th>");
            sb.Append("<th data-priority=\"2\">操作</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["id"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["keyword1"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["keyword2"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["keyword3"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["keyword4"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["keyword5"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["weburl"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["tagGroup"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["sendTime"].ToString());
                    sb.Append("<td>");
                    sb.AppendFormat("<a href=\"javascript:;\" class=\"btn btn-danger btn-xs\" onclick=\"mydelete({0})\">删除</a>", dt.Rows[i]["id"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr>");
                sb.Append("<td colspan=\"9\">无</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_send_wx_messageHandler", 1, "aspnetForm", "tb_Content"));
            sb.Append("</div>");

            response.Write(sb.ToString());
        }
    }
}