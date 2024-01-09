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
    public partial class tech_meeting_type_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txt_mtype_id.Text = tech_meeting_typeManager.Instance.GetMtype_id();
                Binder();
            }
        }

        private void Binder()
        {
            ddl_v_sid.DataSource = tv_subjectsManager.Instance.GetList();
            ddl_v_sid.DataTextField = "v_sname";
            ddl_v_sid.DataValueField = "v_sid";
            ddl_v_sid.DataBind();
        }

    }
}