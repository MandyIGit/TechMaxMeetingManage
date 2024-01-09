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

namespace MpConsoleWebSite.home.base_setting
{
    public partial class mobile_skin_edit : MeetingUserPage
    {
        public string mid = string.Empty;
        public int id = 0;
        public string first_content, second_content, footer_content;
        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
            tech_mobile_site_template info = new tech_mobile_site_template();
            info.mid = mid;
            DataTable dt = tech_mobile_site_templateManager.Instance.GetTech_mobile_site_template(info, "select_mobile_site_template");
            if (dt != null && dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[0]["id"]);
                if(string.IsNullOrEmpty(dt.Rows[0]["first_content"].ToString()) || string.IsNullOrEmpty(dt.Rows[0]["second_content"].ToString()))
                {
                    Response.Write("<script>alert('还未创建微站模板，请先使用一个皮肤样式后再来编辑！');window.location.href='/home/base_setting/mobile_skin_select.aspx';</script>");
                    Response.End();
                }
                first_content = Convert.ToString(dt.Rows[0]["first_content"]);
                second_content = Convert.ToString(dt.Rows[0]["second_content"]);
                footer_content = Convert.ToString(dt.Rows[0]["footer_content"]);
            }
            else
            {
                Response.Write("<script>alert('还未创建微站模板，请先使用一个皮肤样式后再来编辑！');window.location.href='/home/base_setting/mobile_skin_select.aspx';</script>");
                Response.End();
            }
        }
    }
}