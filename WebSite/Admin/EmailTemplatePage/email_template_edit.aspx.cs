using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;
using Common.DEncrypt;

namespace WebSite.Admin.EmailTemplatePage
{
    public partial class email_template_edit : System.Web.UI.Page
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
            int id = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                hid_id.Value = Request.QueryString["id"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Request.QueryString["page"].ToString();
            }
            email_template info = email_templateManager.Instance.GetModelById(id);

            ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
            ddl_mid.DataTextField = "mname";
            ddl_mid.DataValueField = "mid";
            ddl_mid.SelectedValue = info.Mid;
            ddl_mid.DataBind();

            txt_tp_name.Text = info.Tp_name;
            txt_tp_content.Text = info.Tp_content;
            txt_tel.Text = info.Tel;
            txt_fax.Text = info.Fax;
            txt_email.Text = info.Email;
            txt_web_url.Text = info.Web_url;
            if (!string.IsNullOrEmpty(info.M_p_content_ch))
                txt_m_p_content_ch.Text = DESEncrypt.Decrypt(info.M_p_content_ch);
            if (!string.IsNullOrEmpty(info.M_p_content_en))
                txt_m_p_content_en.Text = DESEncrypt.Decrypt(info.M_p_content_en);
            if (!string.IsNullOrEmpty(info.H_p_content_ch))
                txt_h_p_content_ch.Text = DESEncrypt.Decrypt(info.H_p_content_ch);
            if (!string.IsNullOrEmpty(info.H_p_content_en))
                txt_h_p_content_en.Text = DESEncrypt.Decrypt(info.H_p_content_en);
        }
    }
}