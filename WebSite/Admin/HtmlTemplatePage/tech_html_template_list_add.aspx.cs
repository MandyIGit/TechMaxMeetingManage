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
    public partial class tech_html_template_list_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txt_tm_id.Text = tech_html_template_listManager.Instance.Get_tm_id();

                ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
                ddl_mid.DataTextField = "mname";
                ddl_mid.DataValueField = "mid";
                ddl_mid.DataBind();
            }
        }
    }
}