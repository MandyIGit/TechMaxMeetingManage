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

namespace WebSite.Admin.HtmlTemplatePage
{
    public partial class tech_html_template_list_edit : System.Web.UI.Page
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
            string mid = "", tm_id = "";
            if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
            {
                mid = Request.QueryString["mid"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["tm_id"]))
            {
                tm_id = Request.QueryString["tm_id"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Request.QueryString["page"].ToString();
            }

            Model.tech_html_template_list info = new Model.tech_html_template_list { Mid=mid, Tm_id=tm_id };


            DataTable dt = tech_html_template_listManager.Instance.GetTechHtmlTemplateList(info);

            if (dt != null)
            {
                ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
                ddl_mid.DataTextField = "mname";
                ddl_mid.DataValueField = "mid";
                if (dt.Rows[0]["mid"] != null && dt.Rows[0]["mid"].ToString() != "")
                {
                    ddl_mid.SelectedValue = dt.Rows[0]["mid"].ToString();
                }
                ddl_mid.DataBind();

                txt_tm_id.Text = dt.Rows[0]["tm_id"].ToString();
                txt_tm_name.Text = dt.Rows[0]["Tm_name"].ToString();
                txt_tm_img.Text = dt.Rows[0]["Tm_img"].ToString();
                txt_tm_css.Text = dt.Rows[0]["Tm_css"].ToString();
                txt_first_content.Text = TechMaxClass.Decompress(dt.Rows[0]["First_content"].ToString());
                txt_en_first_content.Text = TechMaxClass.Decompress(dt.Rows[0]["En_first_content"].ToString());
                txt_second_content.Text = TechMaxClass.Decompress(dt.Rows[0]["Second_content"].ToString());
                txt_en_second_content.Text = TechMaxClass.Decompress(dt.Rows[0]["En_second_content"].ToString());
                txt_third_content.Text = TechMaxClass.Decompress(dt.Rows[0]["Third_content"].ToString());
                txt_en_third_content.Text = TechMaxClass.Decompress(dt.Rows[0]["En_third_content"].ToString());
                txt_person_content.Text = TechMaxClass.Decompress(dt.Rows[0]["Person_content"].ToString());
                txt_en_person_content.Text = TechMaxClass.Decompress(dt.Rows[0]["En_person_content"].ToString());
            }
            
        }
    }
}