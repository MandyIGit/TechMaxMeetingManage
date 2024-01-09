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
    public partial class meeting_reg_type_edit : System.Web.UI.Page
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
                hid_id.Value = Request.QueryString["id"].ToString();
            }
            tech_meeting_reg_type info = tech_meeting_reg_typeManager.Instance.GetModelById(id);

            ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
            ddl_mid.DataTextField = "mname";
            ddl_mid.DataValueField = "mid";
            ddl_mid.SelectedValue = info.Mid;
            ddl_mid.DataBind();

            txt_ch_name.Text = info.Ch_name;
            txt_en_name.Text = info.En_name;
            txt_begin_time.Text = info.Begin_time.ToString("yyyy-MM-dd HH:mm:ss");
            txt_end_time.Text = info.End_time.ToString("yyyy-MM-dd HH:mm:ss");
            txt_money.Text = info.Money.ToString();
            ddl_use_type.SelectedValue = info.Use_type.ToString();
            ddl_use_location.SelectedValue = info.Use_location.ToString();
            ddl_isupload.SelectedValue = info.Isupload.ToString();
        }
    }
}