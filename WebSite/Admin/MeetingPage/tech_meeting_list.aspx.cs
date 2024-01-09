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
    public partial class tech_meeting_list : System.Web.UI.Page
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
            tech_meeting info = new tech_meeting();

            info.pageIndex = pageIndex;
            info.pageSize = 10;

            rpt_listNews.DataSource = tech_meetingManager.Instance.GetTech_meeting(info, "select_meeting_to_page");
            rpt_listNews.DataBind();
            mypager.RecordCount = tech_meetingManager.Instance.GetTech_meeting(info, "select_meeting").Rows.Count;
            mypager.PageSize = info.pageSize;
        }
        protected void mypager_PageChanged(object sender, EventArgs e)
        {
            Binder(mypager.CurrentPageIndex);
        }

        protected string getMtypeName(string mtype_id)
        {
            string MtypeName = "";
            tech_meeting_type info = tech_meeting_typeManager.Instance.GetModelByTypeId(mtype_id);
            if (info != null)
            {
                MtypeName = info.Mtype_name;
            }
            return MtypeName;
        }

        protected string getTrueFalseStr(string str)
        {
            string strResult = "";
            if (str == "1")
                strResult = "是";
            else if (str == "2")
                strResult = "否";
            return strResult;
        }

        protected string getProjectManager(string pmid)
        {
            string full_name = "";
            tech_project_manager info = tech_project_managerManager.Instance.GetModelById(pmid);
            if (info != null)
            {
                full_name = info.full_name;
            }
            return full_name;
        }
    }

}