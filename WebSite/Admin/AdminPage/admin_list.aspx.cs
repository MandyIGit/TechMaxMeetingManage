using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using System.Data;

namespace WebSite.Admin.AdminPage
{
    public partial class admin_list : System.Web.UI.Page
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
            tech_admin info = new tech_admin();
            info.PageIndex = pageIndex;
            info.PageSize = 10;

            DataTable adminList = tech_adminManager.Instance.GetTech_admin(info, "select_admin_to_page");

            rpt_list.DataSource = adminList;
            rpt_list.DataBind();

            mypager.RecordCount = tech_adminManager.Instance.Operation(info, "select_admin_count");
            mypager.PageSize = info.PageSize;
        }

        protected void mypager_PageChanged(object sender, EventArgs e)
        {
            Binder(mypager.CurrentPageIndex);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binder(1);
        }

        protected string getGender(string gender)
        {
            return gender == "1" ? "男" : "女";
        }

        protected string getStatus(string status)
        {
            return status == "2" ? "正常" : "删除";
        }
        protected string getAdminType(string admin_type)
        {
            return admin_type == "1" ? "超级管理员" : "普通管理员";
        }
    }
}