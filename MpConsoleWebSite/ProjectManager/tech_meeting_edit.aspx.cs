using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MpConsoleWebSite.ProjectManager
{
    public partial class tech_meeting_edit : ProjectUserPage
    {
        public tech_meeting tm = null;
        public string mid = string.Empty;
        public string script_html = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["mid"]))
            {
                mid = Request.Params["mid"];

                tm = tech_meetingManager.Instance.GetModelByMId(mid);

                script_html += "<script type=\"text/javascript\">";
                script_html += "setTimeout(function(){";
                script_html += "$(\"#reguser\").val('" + Convert.ToString(tm.reguser) + "');";
                script_html += "$(\"#article\").val('" + Convert.ToString(tm.article) + "');";
                script_html += "$(\"#lodging\").val('" + Convert.ToString(tm.lodging) + "');";
                script_html += "},1000);";
                script_html += "</script>";
            }
        }
    }
}