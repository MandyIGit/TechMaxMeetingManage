using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Text;

namespace WebSite.Admin.PrintPage
{
    public partial class PersonEdit : System.Web.UI.Page
    {
        protected string person_code = "", person_name = "", person_group = "", id = "", page = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Request.QueryString["page"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Request.QueryString["id"].ToString();
                tech_person_print info = tech_person_printManager.Instance.GetModelById(int.Parse(id));
                if (info != null)
                {
                    id = info.id.ToString();
                    person_code = info.person_code;
                    person_name = info.person_name;
                    StringBuilder sb = new StringBuilder();
                    switch(info.person_group){
                        case 1:
                            sb.AppendFormat("<option value=\"{0}\" selected>{1}</option>", 1, "医师领导及工作人员");
                            sb.AppendFormat("<option value=\"{0}\">{1}</option>", 2, "中宾专家");
                            sb.AppendFormat("<option value=\"{0}\">{1}</option>", 3, "外宾专家");
                            break;
                        case 2:
                            sb.AppendFormat("<option value=\"{0}\">{1}</option>", 1, "医师领导及工作人员");
                            sb.AppendFormat("<option value=\"{0}\" selected>{1}</option>", 2, "中宾专家");
                            sb.AppendFormat("<option value=\"{0}\">{1}</option>", 3, "外宾专家");
                            break;
                        case 3:
                            sb.AppendFormat("<option value=\"{0}\">{1}</option>", 1, "医师领导及工作人员");
                            sb.AppendFormat("<option value=\"{0}\">{1}</option>", 2, "中宾专家");
                            sb.AppendFormat("<option value=\"{0}\" selected>{1}</option>", 3, "外宾专家");
                            break;

                    }
                    person_group = sb.ToString();
                }
            }
            else
            {
                Response.Redirect("PersonList.aspx");
            }
        }
    }
}