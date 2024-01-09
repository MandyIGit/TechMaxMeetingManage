using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;

namespace WebSite.Admin
{
    public partial class loginOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebCommon.RemoveCookie(WebCommon.ADMIN_KEY);
            Response.Redirect("Login.aspx");
        }
    }
}