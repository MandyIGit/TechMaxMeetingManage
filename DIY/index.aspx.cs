using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DIY
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies[WebCommon.MEETING_KEY] != null)
                Response.Redirect("/HYManager/index.aspx");
            else if (Request.Cookies[WebCommon.MANAGER_KEY] != null)
                Response.Redirect("/ProjectManager/index.aspx");
            else
                Response.Redirect("/login.aspx");
        }
    }
}