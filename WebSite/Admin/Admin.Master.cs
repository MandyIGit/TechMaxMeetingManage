using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using WebSite.CommonPage;

namespace WebSite.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ConfigHelper.GetConfigInt("IsCheckMobile") == 1)
            {
                if (Request.Cookies[WebCommon.MOBLIE_KEY] == null)
                {
                    Response.Redirect("/Admin/checkMobile.aspx");
                }
            }
        }
    }
}