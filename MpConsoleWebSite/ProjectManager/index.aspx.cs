using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common;
using BLL;
using Model;
using Common.DEncrypt;

namespace MpConsoleWebSite.ProjectManager
{
    public partial class index : ProjectUserPage
    {
        public string PMFullName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.Cookies[WebCommon.MANAGER_KEY].Values["full_name"]))
                {
                    PMFullName = DESEncrypt.Decrypt(Request.Cookies[WebCommon.MANAGER_KEY].Values["full_name"]);
                }
            }
        }
    }
}