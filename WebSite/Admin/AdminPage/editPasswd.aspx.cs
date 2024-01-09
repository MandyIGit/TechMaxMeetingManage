using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using BLL;
using Common;
using Model;

namespace WebSite.Admin.AdminPage
{
    public partial class editPasswd : System.Web.UI.Page
    {
        protected string admin_code;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder();
            }
        }

        protected void Binder()
        {
            if (WebCommon.GetCookieIstate(WebCommon.ADMIN_KEY) != "")
            {
                admin_code = WebCommon.GetCookie(WebCommon.ADMIN_KEY, 4).Split('=')[1];
                txtAdminName.Text = HttpUtility.UrlDecode(WebCommon.GetCookie(WebCommon.ADMIN_KEY, 1).Split('=')[1]);
                txtLoginName.Text = WebCommon.GetCookie(WebCommon.ADMIN_KEY, 2).Split('=')[1];
            }
            
        }

    }
}