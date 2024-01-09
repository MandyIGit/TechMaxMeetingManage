using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Common;

namespace WebSite.Admin.batchAccountCheckPage
{
    public partial class batchAccountCheck : System.Web.UI.Page
    {
        protected string timestamp;
        protected void Page_Load(object sender, EventArgs e)
        {
            timestamp = timestamp = Common.TimeStamp.GetTimeStamp();
        }
    }
}