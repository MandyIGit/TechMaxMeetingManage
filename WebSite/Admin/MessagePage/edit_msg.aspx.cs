using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Common;
using Model;

namespace WebSite.Admin.MessagePage
{
    public partial class edit_msg : System.Web.UI.Page
    {
        public string id = "";
        public tech_message info = null;
        public string script_html = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Request.QueryString["id"].ToString();
                info = tech_messageManager.Instance.GetModelById(id);

                script_html += "<script type=\"text/javascript\">";
                script_html += "setTimeout(function(){";

                if (!string.IsNullOrEmpty(info.Intention))
                {
                    string Intention = info.Intention.TrimEnd('；');
                    string[] IntentionArr = Intention.Split('；');
                    foreach (var item in IntentionArr)
                    {
                        if (item == "我希望电话沟通")
                        {
                            script_html += "$(\"#cbPhonecall\").prop(\"checked\", true);";
                        }
                        else if (item == "我希望会议面谈")
                        {
                            script_html += "$(\"#cbMeeting\").prop(\"checked\", true);";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(info.MeetingNeed))
                {
                    string MeetingNeed = info.MeetingNeed.TrimEnd('；');
                    string[] MeetingNeedArr = MeetingNeed.Split('；');
                    foreach (var item in MeetingNeedArr)
                    {
                        if (item == "网站")
                        {
                            script_html += "$(\"#cbMeetingNeed1\").prop(\"checked\", true);";
                        }
                        else if (item == "注册")
                        {
                            script_html += "$(\"#cbMeetingNeed2\").prop(\"checked\", true);";
                        }
                        else if (item == "直播平台")
                        {
                            script_html += "$(\"#cbMeetingNeed3\").prop(\"checked\", true);";
                        }
                        else if (item == "展商")
                        {
                            script_html += "$(\"#cbMeetingNeed4\").prop(\"checked\", true);";
                        }
                    }
                }

                script_html += "$(\"#Status\").val('" + info.Status + "');";
                script_html += "$(\"#UnitType\").val('" + info.UnitType + "');";
                script_html += "$(\"#isComm\").val('" + info.isComm + "');";

                script_html += "},1000);";
                script_html += "</script>";

            }
        }
    }
}