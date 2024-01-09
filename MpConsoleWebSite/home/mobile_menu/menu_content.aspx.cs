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

namespace MpConsoleWebSite.home.mobile_menu
{
    public partial class menu_content : MeetingUserPage
    {
        public string mid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
        }
    }
}