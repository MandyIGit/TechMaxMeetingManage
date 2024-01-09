using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.Admin.MobilePage
{
    public partial class mt_open_css : System.Web.UI.Page
    {
        public string mtemplate_id, mtype_id, mtemplate_css, timestamp;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Request.Params["mtemplate_id"]))
            {
                mtemplate_id = Request.Params["mtemplate_id"].ToString();
                tech_mobile_template info = tech_mobile_templateManager.Instance.GetModelByMTemplateId(mtemplate_id);
                if (info != null)
                {
                    mtype_id = info.mtype_id.ToString();
                    mtemplate_css = info.mtemplate_css;
                }
            }

            timestamp = TimeStamp.GetTimeStamp();
        }
    }
}