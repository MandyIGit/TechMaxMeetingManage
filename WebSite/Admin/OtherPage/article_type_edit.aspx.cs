using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace WebSite.Admin.OtherPage
{
    public partial class article_type_edit : System.Web.UI.Page
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
            int id = 0;

            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                hid_type_id.Value = Request.QueryString["id"].ToString();
            }
            tech_article_type info = tech_article_typeManager.Instance.GetModelById(id);

            ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
            ddl_mid.DataTextField = "mname";
            ddl_mid.DataValueField = "mid";
            ddl_mid.SelectedValue = info.Mid;
            ddl_mid.DataBind();

            ddl_app_type.SelectedValue = info.App_type.ToString();
            txt_type_name.Text = info.Type_name;
        }
    }
}