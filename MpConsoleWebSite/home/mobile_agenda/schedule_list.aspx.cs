using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MpConsoleWebSite.home.mobile_agenda
{
    public partial class schedule_list : MeetingUserPage
    {
        public string session_id;
        public string mid = string.Empty;
        public string mtype_id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            session_id = Request.QueryString["session_id"];

            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
            if (meeting != null)
                mtype_id = meeting.mtype_id;
        }
    }
}