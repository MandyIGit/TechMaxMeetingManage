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
    public partial class menu_initial : MeetingUserPage
    {
        public string mid = string.Empty;
        public string type_menu_select = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];

            DataTable dt = tech_mobile_typeManager.Instance.GetTech_mobile_type(new tech_mobile_type { }, "select_mobile_type");
            if (dt != null && dt.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendFormat("<option value=\"{0}\">{1}</option>", dt.Rows[i]["mtype_id"], dt.Rows[i]["mtype_name"]);
                }
                type_menu_select = sb.ToString();
            }
        }
    }
}