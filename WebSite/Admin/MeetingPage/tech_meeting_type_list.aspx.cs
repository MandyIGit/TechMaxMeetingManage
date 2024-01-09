using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Wuqi.Webdiyer;

namespace WebSite.Admin.MeetingPage
{
    public partial class tech_meeting_type_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder(1);
            }
        }
        protected void Binder(int pageIndex)
        {
            tech_meeting_type info = new tech_meeting_type();

            info.PageIndex = pageIndex;
            info.PageSize = 10;            

            rpt_listNews.DataSource = tech_meeting_typeManager.Instance.GetTech_meeting_type(info, "select_meeting_type_to_page");
            rpt_listNews.DataBind();
            mypager.RecordCount = tech_meeting_typeManager.Instance.GetTech_meeting_type(info, "select_meeting_type").Rows.Count;
            mypager.PageSize = info.PageSize;
        }
        protected void mypager_PageChanged(object sender, EventArgs e)
        {
            Binder(mypager.CurrentPageIndex);
        }

        protected string getSubject(string v_sid)
        {
            string v_sname = "";
            tv_subjects subject = tv_subjectsManager.Instance.getModel(v_sid);
            if (subject != null)
            {
                v_sname = subject.v_Sname;
            }
            return v_sname;
        }

        protected string getSubstring(string str)
        {
            if (str.Length > 20)
            {
                return str.Substring(0, 20) + "...";
            }
            else
            {
                return str;
            }
        }
    }
}