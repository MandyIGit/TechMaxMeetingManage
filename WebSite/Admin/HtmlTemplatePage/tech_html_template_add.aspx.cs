using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using IDAL;

namespace WebSite.Admin.HtmlTemplatePage
{
    public partial class tech_html_template_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
                ddl_mid.DataTextField = "mname";
                ddl_mid.DataValueField = "mid";
                ddl_mid.DataBind();

                ddl_tm_id.DataSource = tech_html_template_listManager.Instance.GetTech_html_template_list(new Model.tech_html_template_list(), "select_html_template_list");
                ddl_tm_id.DataTextField = "tm_name";
                ddl_tm_id.DataValueField = "tm_id";
                ddl_tm_id.DataBind();
            }
        }
    }
}