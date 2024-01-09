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
    public partial class meeting_reg_type_list : System.Web.UI.Page
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
            tech_meeting_reg_type info = new tech_meeting_reg_type();
            info.Mid = meeting.mid;
            info.Mtype_id = meeting.mtype_id;
            rpt_list.DataSource = tech_meeting_reg_typeManager.Instance.GetTechMeetingRegType(info);
            rpt_list.DataBind();
        }

        protected string getUseType(string s)
        {
            string str = "";

            switch (s)
            {
                case "1":
                str = "中宾个人";
                break;
                case "2":
                str = "外宾个人";
                break;
                case "3":
                str = "中宾团队";
                break;
                case "4":
                str = "外宾团队";
                break;
                case "5":
                str = "晚宴";
                break;
            }
            return str;
        }

        protected string getIsupload(string s)
        {
            string str = "";

            switch (s)
            {
                case "1":
                    str = "是";
                    break;
                case "2":
                    str = "否";
                    break;
            }
            return str;
        }
    }
}