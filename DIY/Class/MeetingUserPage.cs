using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common;
using BLL;
using Model;

namespace DIY
{
    public class MeetingUserPage : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            int yes = 0;
            if (Request.Cookies[WebCommon.MEETING_KEY] == null)
            {
                Response.Redirect("/login.aspx");
            }
            else if (!string.IsNullOrWhiteSpace(Request.Cookies[WebCommon.MEETING_KEY].Values["sys_code"]))
            {
                string html_url = Request.Url.LocalPath.ToLower();
                html_url = html_url.Substring(0, html_url.LastIndexOf('.'));
                if (!html_url.Equals("/HYManager/index"))
                {
                    DataTable dt = new tv_menuManager().GetTv_menu(Convert.ToInt32(Request.Cookies[WebCommon.MEETING_KEY].Values["sys_code"]));
                    if (dt != null && dt.Rows.Count != 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (Convert.ToString(dt.Rows[i]["html_url"]).ToLower().Equals(html_url))
                            {
                                yes = 1;
                            }
                        }
                    }
                    if (yes == 0)
                    {
                        Response.Redirect("/HYManager/Error.aspx");
                    }
                }
            }
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