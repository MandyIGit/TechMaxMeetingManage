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

namespace WebSite.Admin.MobilePage
{
    public partial class mtemplate_add : System.Web.UI.Page
    {
        public string version_select_str;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt_version = tech_mobile_versionManager.Instance.GetTech_mobile_version(new tech_mobile_version { }, "select_mobile_version");
            if (dt_version != null && dt_version.Rows.Count > 0)
            {
                for (int i = 0; i < dt_version.Rows.Count; i++)
                {
                    version_select_str += string.Format("<option value=\"{0}\">{1}</option>", dt_version.Rows[i]["v_id"].ToString(), dt_version.Rows[i]["v_name"].ToString());
                }
            }
        }
    }
}