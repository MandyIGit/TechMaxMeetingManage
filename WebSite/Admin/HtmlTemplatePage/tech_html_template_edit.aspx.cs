using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

namespace WebSite.Admin.HtmlTemplatePage
{
    public partial class tech_html_template_edit : System.Web.UI.Page
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
            int t_id = 0;
            if (!string.IsNullOrEmpty(Request.QueryString["t_id"]))
            {
                t_id = int.Parse(Request.QueryString["t_id"].ToString());
                hid_t_id.Value = Request.QueryString["t_id"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Request.QueryString["page"].ToString();
            }
            tech_html_template info = tech_html_templateManager.Instance.GetModelByTId(t_id);

            ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
            ddl_mid.DataTextField = "mname";
            ddl_mid.DataValueField = "mid";
            ddl_mid.SelectedValue = info.Mid;
            ddl_mid.DataBind();

            ddl_tm_id.DataSource = tech_html_template_listManager.Instance.GetTech_html_template_list(new Model.tech_html_template_list(), "select_html_template_list");
            ddl_tm_id.DataTextField = "tm_name";
            ddl_tm_id.DataValueField = "tm_id";
            ddl_tm_id.SelectedValue = info.Tm_id;
            ddl_tm_id.DataBind();

            txt_tm_name.Text = info.Tm_name;
            txt_tm_img.Text = info.Tm_img;
            txt_first_content.Text = TechMaxClass.Decompress(info.First_content);
            txt_en_first_content.Text = TechMaxClass.Decompress(info.En_first_content);
            txt_second_content.Text = TechMaxClass.Decompress(info.Second_content);
            txt_en_second_content.Text = TechMaxClass.Decompress(info.En_second_content);
            txt_third_content.Text = TechMaxClass.Decompress(info.Third_content);
            txt_en_third_content.Text = TechMaxClass.Decompress(info.En_third_content);
            txt_person_content.Text = TechMaxClass.Decompress(info.Person_content);
            txt_en_person_content.Text = TechMaxClass.Decompress(info.En_person_content);
        }
    }
}