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
    public partial class mtemplate_edit : System.Web.UI.Page
    {
        public string version_select_str, mtemplate_id;
        public tech_mobile_template info;
        public string script_html = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.Params["mtemplate_id"]))
            {
                mtemplate_id = Request.Params["mtemplate_id"].ToString();

                info = tech_mobile_templateManager.Instance.GetModelByMTemplateId(mtemplate_id);

                DataTable dt_version = tech_mobile_versionManager.Instance.GetTech_mobile_version(new tech_mobile_version { }, "select_mobile_version");
                if (dt_version != null && dt_version.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_version.Rows.Count; i++)
                    {
                        version_select_str += string.Format("<option value=\"{0}\">{1}</option>", dt_version.Rows[i]["v_id"].ToString(), dt_version.Rows[i]["v_name"].ToString());
                    }
                }

                script_html += "<script type=\"text/javascript\">";
                script_html += "setTimeout(function(){";
                script_html += "$(\"#version_id\").val('" + Convert.ToString(info.version_id) + "');";
                if (info.menu_type == 1)
                    script_html += "$(\"#menu_type_1\").attr(\"checked\",\"checked\");";
                else if (info.menu_type == 2)
                    script_html += "$(\"#menu_type_2\").attr(\"checked\",\"checked\");";
                script_html += "},1000);";
                script_html += "</script>";
            }
        }
    }
}