using BLL;
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
    public partial class mtemplate_list : System.Web.UI.Page
    {
        public string mtype_select_str, version_select_str;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt_mtype = tech_mobile_typeManager.Instance.GetTech_mobile_type(new tech_mobile_type { }, "select_mobile_type");
            if (dt_mtype != null && dt_mtype.Rows.Count > 0)
            {
                for (int i = 0; i < dt_mtype.Rows.Count; i++)
                {
                    mtype_select_str += string.Format("<option value=\"{0}\">{1}</option>", dt_mtype.Rows[i]["mtype_id"].ToString(), dt_mtype.Rows[i]["mtype_name"].ToString());
                }
            }

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