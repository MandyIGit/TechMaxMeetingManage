using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Common;
using Model;
using System.Data;
using System.Text;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// unsubscribeEmail 的摘要说明
    /// </summary>
    public class unsubscribeEmail : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;
        protected override void GetData(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            requst = context.Request;
            response = context.Response;
            string type = requst.QueryString["type"];
            switch (type)
            {
                case "Send":
                    Send();
                    break;
            }
        }

        private void Send()
        {
            StringBuilder sb_template = new StringBuilder();
            sb_template.Append("<table width=\"600\" border=\"0\" cellpadding=\"5\" cellspacing=\"1\" bgcolor=\"#CCCCCC\">");

            sb_template.Append("<tr>");
            sb_template.Append("<td width=\"100\" bgcolor=\"#FFFFFF\" align=\"right\">退订帐号：</td>");
            sb_template.AppendFormat("<td width=\"500\" bgcolor=\"#FFFFFF\">{0}</td>", requst.Form["account"]);
            sb_template.Append("</tr>");

            sb_template.Append("<tr>");
            sb_template.Append("<td bgcolor=\"#FFFFFF\" align=\"right\">退订原因：</td>");
            sb_template.AppendFormat("<td bgcolor=\"#FFFFFF\">{0}</td>", requst.Form["reason"]);
            sb_template.Append("</tr>");

            sb_template.Append("</table>");

            string mailtitle = "邮件退订";
            bool resultmail = EmailHelper.SendEmail(mailtitle, sb_template.ToString(), "vip@i-conference.org");
            if (resultmail)
            {
                response.Write("{'result':'true','msg':'提交成功！我们会尽快处理！'}");
            }
            else { response.Write("{'result':'false','msg':'发送失败！'}"); }
        }
        
    }
}