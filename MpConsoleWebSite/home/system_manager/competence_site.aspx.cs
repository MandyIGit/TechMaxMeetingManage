using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MpConsoleWebSite.home.system_manager
{
    public partial class competence_site : MeetingUserPage
    {
        public string mid = string.Empty;
        public string sys_code = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
                sys_code = Convert.ToString(Request.QueryString["sys_code"]);
            }
        }
    }
}