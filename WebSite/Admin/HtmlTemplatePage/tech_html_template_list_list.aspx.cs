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
    public partial class tech_html_template_list_list : System.Web.UI.Page
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
            Model.tech_html_template_list info = new Model.tech_html_template_list();

            info.pageIndex = pageIndex;
            info.pageSize = 10;

            rpt_listNews.DataSource = tech_html_template_listManager.Instance.GetTech_html_template_list(info, "select_html_template_list_to_page");
            rpt_listNews.DataBind();
            mypager.RecordCount = tech_html_template_listManager.Instance.GetTech_html_template_list(info, "select_html_template_list").Rows.Count;
            mypager.PageSize = info.pageSize;
        }
        protected void mypager_PageChanged(object sender, EventArgs e)
        {
            Binder(mypager.CurrentPageIndex);
        }
    }
}