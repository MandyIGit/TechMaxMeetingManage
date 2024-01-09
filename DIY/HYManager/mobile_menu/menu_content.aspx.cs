using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Common;

namespace DIY.HYManager.mobile_menu
{
    public partial class menu_content : MeetingUserPage
    {
        public string mid = string.Empty, mname = string.Empty, m_website = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
            if (!string.IsNullOrEmpty(meeting.m_website))
            {
                m_website = meeting.m_website;
                mname = meeting.mname;
            }
        }
    }
}