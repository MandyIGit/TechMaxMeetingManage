using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;
using System.Data;

namespace WebSite.Admin.AdminPage
{
    public partial class admin_edit : System.Web.UI.Page
    {
        protected string page = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder();
            }
        }
        private void Binder()
        {
            int admin_code = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                admin_code = int.Parse(Request.QueryString["id"].ToString());
                hid_admin_code.Value = Request.QueryString["id"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Request.QueryString["page"].ToString();
            }

            tech_admin info = tech_adminManager.Instance.GetModel(admin_code);
            ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
            ddl_mid.DataTextField = "mname";
            ddl_mid.DataValueField = "mid";
            ddl_mid.SelectedValue = info.Mid;
            ddl_mid.DataBind();
            txt_admin_name.Text = info.Admin_name;
            txt_login_name.Text = info.Login_name;
            txt_phone.Text = info.Phone;
            txt_address.Text = info.Address;
            txt_remark.Text = info.Remark;

            ddl_gender.SelectedValue = info.Gender.ToString();
            ddl_admin_type.SelectedValue = info.Admin_type.ToString();
            
        }

        protected void ChkIsShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkIsShowPwd.Checked)
            {
                txt_login_pwd.Visible = true;
            }
            else
            {
                txt_login_pwd.Visible = false;
            }
        }
    }
}