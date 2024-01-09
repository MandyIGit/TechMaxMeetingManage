using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace WebSite.Admin.MeetingPage
{
    public partial class tech_meeting_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder();
            }
        }

        private void Binder()
        {
            tech_meeting_type info = new tech_meeting_type();
            ddl_mtype_id.DataSource = tech_meeting_typeManager.Instance.GetTech_meeting_type(info, "select_meeting_type");
            ddl_mtype_id.DataTextField = "mtype_name";
            ddl_mtype_id.DataValueField = "mtype_id";
            ddl_mtype_id.DataBind();

            tech_project_manager manager = new tech_project_manager();
            ddl_project_manager_id.DataSource = tech_project_managerManager.Instance.GetTech_project_manager(manager, "select_manager");
            ddl_project_manager_id.DataTextField = "full_name";
            ddl_project_manager_id.DataValueField = "id";
            ddl_project_manager_id.DataBind();

            txt_mid.Text = tech_meetingManager.Instance.GetMid();
        }
    }
}