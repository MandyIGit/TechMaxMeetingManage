using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Wuqi.Webdiyer;

namespace WebSite.Admin.PrintPage
{
    public partial class PersonList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Binder(1);
        }
        protected void Binder(int pageIndex)
        {
            tech_person_print info = new tech_person_print();
            if (!string.IsNullOrEmpty(Request["person_code"]))
            {
                info.person_code = Request["person_code"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["person_name"]))
            {
                info.person_name = Request["person_name"].ToString();
            }
            if (!string.IsNullOrEmpty(Request["person_group"]))
            {
                info.person_group = int.Parse(Request["person_group"].ToString());
            }
            if (!string.IsNullOrEmpty(Request["is_print"]))
            {
                info.is_print = int.Parse(Request["is_print"].ToString());
            }

            info.pageIndex = pageIndex;
            info.pageSize = 10;

            rpt_list.DataSource = tech_person_printManager.Instance.Get_tech_person_print(info, "select_person_print_to_page");
            rpt_list.DataBind();
            mypager.RecordCount = tech_person_printManager.Instance.Get_tech_person_print(info, "select_person_print").Rows.Count;
            mypager.PageSize = info.pageSize;
        }
        protected void mypager_PageChanged(object sender, EventArgs e)
        {
            Binder(mypager.CurrentPageIndex);
        }

        protected string getGroupStr(string groupInt)
        {
            string groupStr = "";

            if (groupInt != null && int.Parse(groupInt)>0)
            {
                switch (int.Parse(groupInt))
                {
                    case 1:
                        groupStr = "医师领导及工作人员";
                        break;
                    case 2:
                        groupStr = "中宾专家";
                        break;
                    case 3:
                        groupStr = "外宾专家";
                        break;
                    default:
                        groupStr = "";
                        break;
                }
            }
            return groupStr;
        }
        protected string getPrintState(string printInt)
        {
            string printStr = "";

            if (printInt != null && int.Parse(printInt) > 0)
            {
                switch (int.Parse(printInt))
                {
                    case 1:
                        printStr = "<span style=\"color:green;\">已打印</span>";
                        break;
                    case 2:
                        printStr = "<span style=\"color:red;\">未打印</span>";
                        break;
                    default:
                        printStr = "";
                        break;
                }
            }
            return printStr;
        }

    }
}