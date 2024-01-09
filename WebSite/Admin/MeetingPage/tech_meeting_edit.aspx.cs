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
    public partial class tech_meeting_edit : System.Web.UI.Page
    {
        protected string mid = "", page = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder();
            }
        }
        private void Binder()
        {            
            if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
            {
                mid = Request.QueryString["mid"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Request.QueryString["page"].ToString();
            }
            tech_meeting info = tech_meetingManager.Instance.GetModelByMId(mid);

            ddl_mtype_id.DataSource = tech_meeting_typeManager.Instance.GetTech_meeting_type(new tech_meeting_type(), "select_meeting_type");
            ddl_mtype_id.DataTextField = "mtype_name";
            ddl_mtype_id.DataValueField = "mtype_id";
            ddl_mtype_id.SelectedValue = info.mtype_id;
            ddl_mtype_id.DataBind();

            tech_project_manager manager = new tech_project_manager();
            ddl_project_manager_id.DataSource = tech_project_managerManager.Instance.GetTech_project_manager(manager, "select_manager");
            ddl_project_manager_id.DataTextField = "full_name";
            ddl_project_manager_id.DataValueField = "id";
            ddl_project_manager_id.SelectedValue = info.project_manager_id.ToString();
            ddl_project_manager_id.DataBind();

            txt_mid.Text = info.mid;
            txt_mname.Text = info.mname;
            txt_address.Text = info.address;
            txt_begindate.Text = info.begindate.ToString("yyyy-MM-dd HH:mm:ss");
            txt_enddate.Text = info.enddate.ToString("yyyy-MM-dd HH:mm:ss");
            //txt_mcontact.Text = info.mcontact;
            //txt_mcontactmblie.Text = info.mcontactmblie;
            ddl_reguser.SelectedValue = info.reguser.ToString();
            txt_reguserdate.Text = info.reguserdate.ToString("yyyy-MM-dd HH:mm:ss");
            ddl_article.SelectedValue = info.article.ToString();
            txt_articledate.Text = info.articledate.ToString("yyyy-MM-dd HH:mm:ss");
            ddl_lodging.SelectedValue = info.lodging.ToString();
            txt_lodgingdate.Text = info.lodgingdate.ToString("yyyy-MM-dd HH:mm:ss");
            ddl_reviewers.SelectedValue = info.reviewers.ToString();
            txt_reviewersdate.Text = info.reviewersdate.ToString("yyyy-MM-dd HH:mm:ss");
            txt_meetingcheckin_date.Text = info.meetingcheckin_date.ToString("yyyy-MM-dd HH:mm:ss");
            txt_regenddate.Text = info.regenddate.ToString("yyyy-MM-dd HH:mm:ss");
            txt_m_website.Text = info.m_website;
            txt_m_img.Text = info.m_img;

            ddl_is_live.SelectedValue = info.is_live.ToString();
            ddl_is_playBack.SelectedValue = info.is_playBack.ToString();
            ddl_is_recommend.SelectedValue = info.is_recommend.ToString();
            ddl_is_xsh_show.SelectedValue = info.is_xsh_show.ToString();
            ddl_is_weizhankaitong.SelectedValue = info.is_weizhankaitong.ToString();
        }
    }
}