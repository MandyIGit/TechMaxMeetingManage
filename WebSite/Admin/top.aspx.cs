using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using Model;
using BLL;

namespace WebSite.Admin
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebCommon.GetCookieIstate(WebCommon.ADMIN_KEY) == "")
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}