using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.Admin.MobilePage
{
    public partial class project_manager_edit : System.Web.UI.Page
    {
        public string id = "";
        public tech_project_manager info = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.Params["id"]))
            {
                id = Request.Params["id"].ToString();
                tech_project_manager model = tech_project_managerManager.Instance.GetModelById(id);
                if (model != null)
                {
                    info = model;
                }
            }
        }
    }
}