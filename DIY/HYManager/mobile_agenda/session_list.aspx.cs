using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DIY.HYManager.mobile_agenda
{
    public partial class session_list : MeetingUserPage
    {
        public string mid = string.Empty, mtype_id = string.Empty;
        public string mname = string.Empty, m_website = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
            if (meeting != null)
            {
                mtype_id = meeting.mtype_id;
                m_website = meeting.m_website;
                mname = meeting.mname;
            }
                
        }
    }
}