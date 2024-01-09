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
    public partial class tech_project_manager_edit : ProjectUserPage
    {
        public string id = "";
        public tech_project_manager info = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.Cookies[WebCommon.MANAGER_KEY].Values["manager_id"];
            tech_project_manager model = tech_project_managerManager.Instance.GetModelById(id);
            if (model != null)
            {
                info = model;
            }
        }
    }
}