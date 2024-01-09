using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Wuqi.Webdiyer;

namespace WebSite.Admin.HtmlTemplatePage
{
    public partial class tech_html_template_list : System.Web.UI.Page
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
            tech_html_template info = new tech_html_template();

            info.pageIndex = pageIndex;
            info.pageSize = 10;

            rpt_listNews.DataSource = tech_html_templateManager.Instance.GetTech_html_template(info, "select_html_template_to_page");
            rpt_listNews.DataBind();
            mypager.RecordCount = tech_html_templateManager.Instance.GetTech_html_template(info, "select_html_template").Rows.Count;
            mypager.PageSize = info.pageSize;
        }
        protected void mypager_PageChanged(object sender, EventArgs e)
        {
            Binder(mypager.CurrentPageIndex);
        }
    }
}