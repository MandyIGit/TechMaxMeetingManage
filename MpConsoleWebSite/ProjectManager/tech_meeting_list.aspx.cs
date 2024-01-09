using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MpConsoleWebSite.ProjectManager
{
    public partial class tech_meeting_list : ProjectUserPage
    {
        public string project_manager_id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            project_manager_id = Request.Cookies[WebCommon.MANAGER_KEY].Values["manager_id"];
        }
    }
}