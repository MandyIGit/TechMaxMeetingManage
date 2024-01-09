using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.AdminLog
{
    public partial class show : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebCommon.GetCookieIstate(WebCommon.ADMIN_KEY) == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string admin_name = HttpUtility.UrlDecode(WebCommon.GetCookie(WebCommon.ADMIN_KEY, 1).Split('=')[1]);
                string admin_code = WebCommon.GetCookie(WebCommon.ADMIN_KEY, 4).Split('=')[1];
                tech_admin model = tech_adminManager.Instance.GetModel(int.Parse(admin_code));
                if (model != null)
                {
                    lblLoginName.Text = admin_name;
                    ltlDateAndTime.Text = model.Operationtime.ToString("yyyy-MM-dd HH:mm:ss");
                    TimeSpan timeSpan = DateTime.Now - model.Operationtime;
                    if (timeSpan.TotalDays > 90.00)
                    {
                        Response.Write("<script>alert('您的密码已经连续超过90天未更换过，请立即前往更换密码！');location.href='/Admin/AdminPage/editPasswd.aspx';</script>");
                    }
                }
            }
        }
    }
}