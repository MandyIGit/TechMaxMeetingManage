using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DIY.HYManager.base_setting
{
    public partial class mobile_imgs : MeetingUserPage
    {
        public string mid = string.Empty;
        public int id = 0;
        public string mname, m_website, logo, main_img_pc, main_img_mobile, first_content_bg, scend_top_bg, web_back_color, timestamp;
        protected void Page_Load(object sender, EventArgs e)
        {
            timestamp = TimeStamp.GetTimeStamp();
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
            if (!string.IsNullOrEmpty(meeting.m_website))
            {
                m_website = meeting.m_website;
                mname = meeting.mname;
            }

            tech_mobile_site_template info = new tech_mobile_site_template();
            info.mid = mid;
            DataTable dt = tech_mobile_site_templateManager.Instance.GetTech_mobile_site_template(info, "select_mobile_site_template");
            if (dt != null && dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0]["id"]);
                logo = Convert.ToString(dt.Rows[0]["logo"]);
                main_img_pc = Convert.ToString(dt.Rows[0]["main_img_pc"]);
                main_img_mobile = Convert.ToString(dt.Rows[0]["main_img_mobile"]);
                first_content_bg = Convert.ToString(dt.Rows[0]["first_content_bg"]);
                scend_top_bg = Convert.ToString(dt.Rows[0]["scend_top_bg"]);
                web_back_color = Convert.ToString(dt.Rows[0]["web_back_color"]);
            }
        }
    }
}