using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using IDAL;

namespace WebSite.Admin.OtherPage
{
    public partial class meeting_reg_type_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
                ddl_mid.DataTextField = "mname";
                ddl_mid.DataValueField = "mid";
                ddl_mid.DataBind();
            }
        }
    }
}