using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.AdminLog
{
    public partial class AdminLog : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebCommon.GetCookieIstate(WebCommon.ADMIN_KEY) == "")
            {
                Response.Redirect("/AdminLog/Login.aspx");
            }
        }
    }
}