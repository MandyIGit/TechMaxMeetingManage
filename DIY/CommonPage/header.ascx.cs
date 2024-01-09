using BLL;
using Common;
using Common.DEncrypt;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DIY.CommonPage
{
    public partial class header : System.Web.UI.UserControl
    {
        public string PMFullName = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies[WebCommon.MANAGER_KEY] != null)
                {
                    PMFullName = DESEncrypt.Decrypt(Request.Cookies[WebCommon.MANAGER_KEY].Values["full_name"]);
                }
                else if (Request.Cookies[WebCommon.MEETING_KEY] != null)
                {
                    PMFullName = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];
                }
            }
        }
    }
}