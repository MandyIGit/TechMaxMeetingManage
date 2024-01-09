using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;
using Model;

namespace MpConsoleWebSite.home
{
    public partial class index : MeetingUserPage
    {
        public string login_id = string.Empty;
        public string m_website = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies[WebCommon.MEETING_KEY].Values["mid"] != null)
                {
                    //sys_code = Convert.ToString(Request.Cookies[WebCommon.MEETING_KEY].Values["sys_code"]);
                    //login_id = Common.DEncrypt.DESEncrypt.Decrypt(Request.Cookies[WebCommon.MEETING_KEY].Values["login_id"]);
                    login_id = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
                }

                string mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
                tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
                if (!string.IsNullOrEmpty(meeting.m_website))
                {
                    m_website = meeting.m_website;
                }
            }
        }
    }
}