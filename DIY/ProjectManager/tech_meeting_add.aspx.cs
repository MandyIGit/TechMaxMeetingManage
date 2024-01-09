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

namespace DIY.ProjectManager
{
    public partial class tech_meeting_add : ProjectUserPage
    {
        public string mid = "", tmt_option = "", project_manager_id = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            mid = tech_meetingManager.Instance.GetMid();

            tech_meeting_type info = new tech_meeting_type();
            DataTable dt_tmt = tech_meeting_typeManager.Instance.GetTech_meeting_type(info, "select_meeting_type");
            if (dt_tmt != null && dt_tmt.Rows.Count > 0)
            {
                for (int i = 0; i < dt_tmt.Rows.Count; i++)
                {
                    tmt_option += "<option value=\"" + dt_tmt.Rows[i]["mtype_id"] + "\">" + dt_tmt.Rows[i]["mtype_name"] + "</option>";
                }
            }

            project_manager_id = Request.Cookies[WebCommon.MANAGER_KEY].Values["manager_id"];
        }
    }
}