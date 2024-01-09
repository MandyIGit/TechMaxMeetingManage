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
    public partial class tech_meeting_type_edit : System.Web.UI.Page
    {
        protected string mtype_id = "", page = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder();
            }
        }

        private void Binder()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["mtype_id"]))
            {
                mtype_id = Request.QueryString["mtype_id"].ToString();
                tech_meeting_type info = tech_meeting_typeManager.Instance.GetModelByTypeId(mtype_id);
                txt_mtype_id.Text = info.Mtype_id;
                txt_mtype_name.Text = info.Mtype_name;
                txt_mtype_memo.Text = info.Mtype_memo;

                ddl_v_sid.DataSource = tv_subjectsManager.Instance.GetList();
                ddl_v_sid.DataTextField = "v_sname";
                ddl_v_sid.DataValueField = "v_sid";
                ddl_v_sid.DataBind();
                ddl_v_sid.SelectedValue = info.V_sid.ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Request.QueryString["page"].ToString();
            }
        }
    }
}