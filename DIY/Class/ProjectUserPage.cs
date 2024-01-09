using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common;
using BLL;

namespace DIY
{
    public class ProjectUserPage : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Request.Cookies[WebCommon.MANAGER_KEY] == null)
            {
                Response.Redirect("/login.aspx");
            }
        }
    }
}