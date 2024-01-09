using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using IDAL;

namespace WebSite.Admin.OtherPage
{
    public partial class published_form_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ddl_mid.DataSource = tech_meetingManager.Instance.GetTech_meeting(new tech_meeting(), "select_meeting");
                ddl_mid.DataTextField = "mname";
                ddl_mid.DataValueField = "mid";
                ddl_mid.DataBind();
            }
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(ddl_mid.SelectedItem.Value);
            tech_published_form info = new tech_published_form();
            info.Mid = meeting.mid;
            info.Mtype_id = meeting.mtype_id;
            rpt_list.DataSource = tech_published_formManager.Instance.GetTechPublishedForm(info);
            rpt_list.DataBind();
        }

        protected string getAppType(string s)
        {
            string str = "";

            switch (s)
            {
                case "1":
                    str = "中宾";
                    break;
                case "2":
                    str = "外宾";
                    break;                
            }
            return str;
        }
    }
}