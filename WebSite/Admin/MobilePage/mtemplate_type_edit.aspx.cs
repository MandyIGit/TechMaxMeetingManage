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
    public partial class mtemplate_type_edit : System.Web.UI.Page
    {
        public string mtype_id = "", mtype_name = "", mtype_memo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.Params["mtype_id"]))
            {
                mtype_id = Request.Params["mtype_id"];
                tech_mobile_type info = tech_mobile_typeManager.Instance.GetModelByTypeId(mtype_id);
                if (info != null)
                {
                    mtype_id = info.Mtype_id.ToString();
                    mtype_name = info.Mtype_name;
                    mtype_memo = info.Mtype_memo;
                }
            }
        }
    }
}