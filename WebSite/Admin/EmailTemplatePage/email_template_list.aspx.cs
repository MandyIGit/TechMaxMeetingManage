using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Wuqi.Webdiyer;

namespace WebSite.Admin.EmailTemplatePage
{
    public partial class email_template_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder(1);
            }
        }
        protected void Binder(int pageIndex)
        {
            email_template info = new email_template();

            info.PageIndex = pageIndex;
            info.PageSize = 10;

            rpt_listNews.DataSource = email_templateManager.Instance.GetEmail_template(info, "select_email_template_to_page");
            rpt_listNews.DataBind();
            mypager.RecordCount = email_templateManager.Instance.GetEmail_template(info, "select_email_template").Rows.Count;
            mypager.PageSize = info.PageSize;
        }
        protected void mypager_PageChanged(object sender, EventArgs e)
        {
            Binder(mypager.CurrentPageIndex);
        }
    }
}