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
    public partial class menu_content_edit : MeetingUserPage
    {
        public string mid = string.Empty, menuid = string.Empty;

        public int mc_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
            if (Request.QueryString["menuid"] != null)
            {
                menuid = Request.QueryString["menuid"].ToString();

                DataTable dt = tech_mobile_menu_contentManager.Instance.GetTech_mobile_menu_content(new tech_mobile_menu_content { menu_id = int.Parse(menuid) }, "select_mobile_menu_content");
                if (dt != null && dt.Rows.Count > 0)
                {
                    mc_id = Convert.ToInt32(dt.Rows[0]["mc_id"]);
                }
            }
        }
    }
}