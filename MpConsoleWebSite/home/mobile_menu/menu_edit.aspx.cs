using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MpConsoleWebSite.home.mobile_menu
{
    public partial class menu_edit : MeetingUserPage
    {
        public string mid = string.Empty, m_website = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
            if (!string.IsNullOrEmpty(meeting.m_website))
            {
                m_website = meeting.m_website;
            }
        }
    }
}