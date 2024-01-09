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
    public partial class speaker_edit : MeetingUserPage
    {
        public string puid, family_name, given_name, family_name_pinyin, given_name_pinyin, mobile, email, img_urlpath, penintro, learnpost, unit = string.Empty;

        public string mid = string.Empty;
        public string mtype_id = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
            if (meeting != null)
                mtype_id = meeting.mtype_id;

            if (Request.QueryString["puid"] != null)
            {
                puid = Request.QueryString["puid"].ToString();
                tech_meeting_user_ppt model = tech_meeting_user_pptManager.Instance.GetMeetingUser_ppt(int.Parse(puid));
                if (model != null)
                {
                    family_name = model.family_name;
                    given_name = model.given_name;
                    family_name_pinyin = model.family_name_pinyin;
                    given_name_pinyin = model.given_name_pinyin;
                    mobile = model.mobile;
                    email = model.email;
                    if (!string.IsNullOrEmpty(model.img_urlpath))
                    {
                        img_urlpath = model.img_urlpath;
                    }
                    else
                    {
                        img_urlpath = "/image/logo_n.png";
                    }
                    penintro = Common.DEncrypt.DESEncrypt.Decrypt(model.penintro);
                    learnpost = model.learnpost;
                    unit = model.unit;
                }
            }
        }
    }
}