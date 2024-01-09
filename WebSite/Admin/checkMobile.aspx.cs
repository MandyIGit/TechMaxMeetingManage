using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSite.CommonPage;

namespace WebSite.Admin
{
    public partial class checkMobile : PageBaseClass
    {
        public string mobile;
        protected void Page_Load(object sender, EventArgs e)
        {
            tech_admin admin = tech_adminManager.Instance.GetModel(int.Parse(this.AdminCode));
            if (admin != null)
            {
                mobile = admin.Phone;
            }
        }
    }
}