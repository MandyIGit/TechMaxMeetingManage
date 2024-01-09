using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.Admin.MobilePage
{
    public partial class mtemplate_version_edit : System.Web.UI.Page
    {
        public int menu_type = 0;
        public string v_id = "", v_name = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.Params["v_id"]))
            {
                v_id = Request.Params["v_id"];
                tech_mobile_version info = tech_mobile_versionManager.Instance.GetModelByVersonId(v_id);
                if (info != null)
                {
                    v_id = info.v_id.ToString();
                    v_name = info.v_name;
                    menu_type = info.menu_type;
                }
            }
        }
    }
}