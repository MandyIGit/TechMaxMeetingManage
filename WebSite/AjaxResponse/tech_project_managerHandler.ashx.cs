using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_project_managerHandler 的摘要说明
    /// </summary>
    public class tech_project_managerHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            requst = context.Request;
            response = context.Response;
            string type = requst.QueryString["type"];
            string xml = Convert.ToString(requst.Params["postvalue"]);
            DataSet ds = null;

            if (!string.IsNullOrEmpty(xml) && xml != "")
            {
                ds = TechMaxClass.DataSetVerify(TechMaxClass.getDataSetfromXML(xml));
            }

            int pageIndex = 0;
            int pageSize = 10;

            if (ds != null)
            {
                if (ds.Tables[0].Columns[0].ColumnName == "pageIndex")
                {
                    pageIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["pageIndex"]);
                    pageSize = Convert.ToInt32(ds.Tables[0].Rows[0]["pageSize"]);
                }
            }

            switch (type)
            {
                case "add":
                    Add();
                    break;
                case "edit":
                    Edit();
                    break;
                case "del":
                    Del();
                    break;
                case "1":
                    InputTechProjectManagerList(pageIndex, pageSize);
                    break;
            }

        }

        private void InputTechProjectManagerList(int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            tech_project_manager info = new tech_project_manager();

            if (string.IsNullOrWhiteSpace(requst.Form["full_name"]))
            {
                info.full_name = Convert.ToString(requst.Form["full_name"]);
            }
            if (!string.IsNullOrWhiteSpace(requst.Form["login_name"]))
            {
                info.login_name = Convert.ToString(requst.Form["login_name"]);
            }
            if (!string.IsNullOrWhiteSpace(requst.Form["mobile"]))
            {
                info.mobile = Convert.ToString(requst.Form["mobile"]);
            }
            info.PageIndex = pageIndex;
            info.PageSize = pageSize;

            DataTable dt = tech_project_managerManager.Instance.GetTech_project_manager(info, "select_manager_to_page");
            int allCount = tech_project_managerManager.Instance.Operation(info, "select_project_manager_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th>ID</th>");
            sb.Append("<th>姓名</th>");
            sb.Append("<th>登录名称</th>");
            sb.Append("<th>手机</th>");
            sb.Append("<th>添加时间</th>");
            sb.Append("<th>操作</th>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            sb.Append("<tbody id=\"table_body\">");
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr class=\"odd gradeX\">");
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["id"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["full_name"].ToString()));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["login_name"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["mobile"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["inputtime"]));
                    sb.Append("<td>");
                    sb.AppendFormat("<a href=\"project_manager_edit.aspx?id={0}\" class=\"btn btn-secondary btn-xs\">编辑</a>", dt.Rows[i]["id"].ToString());
                    sb.AppendFormat("<a href=\"javascript:;\" class=\"btn btn-danger btn-xs\" onclick=\"mydelete({0})\">删除</a>", dt.Rows[i]["id"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr class=\"odd gradeX\">");
                sb.Append("<td colspan=\"7\">Null</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_project_managerHandler", 1, "aspnetForm", "tb_Content"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        private void Del()
        {
            tech_project_manager info = new tech_project_manager();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.id = Convert.ToInt32(requst.QueryString["id"].ToString());
            }

            int exists = tech_meetingManager.Instance.Operation(new tech_meeting { project_manager_id = info.id }, "isPMExtMName");
            if (exists > 0)
            {
                response.Write("{result:'fail',msg:'该项目经理下还有会议存在，请确保该账户下没有会议后再来删除！'}");
                return;
            }

            int result = tech_project_managerManager.Instance.Operation(info, "delete_project_manager");
            if (result > 0)
            {
                response.Write("{result:'succ',msg:'删除成功！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'编辑失败！'}");
                return;
            }
        }

        private void Edit()
        {
            int is_mobile = 0;
            tech_project_manager info = new tech_project_manager();

            info.mobile = Convert.ToString(requst.Form["mobile"]);
            DataTable mobile_dt = tech_project_managerManager.Instance.GetTech_project_manager(info, "select_manager");
            if (mobile_dt != null && mobile_dt.Rows.Count != 0)
            {
                foreach (DataRow dr in mobile_dt.Rows)
                {
                    if (Convert.ToString(dr["id"]) != Convert.ToString(requst.Form["id"]))
                    {
                        is_mobile += 1;
                    }
                }
            }
            if (is_mobile > 0)
            {
                response.Write("{result:'fail',msg:'手机号码已存在，请重新填写！'}");
                return;
            }

            info.id = Convert.ToInt32(requst.Form["id"].ToString());
            info.full_name = requst.Form["full_name"].ToString();
            info.mobile = requst.Form["mobile"].ToString();
            info.login_name = requst.Form["login_name"].ToString();
            info.login_pwd = Common.DEncrypt.DESEncrypt.Encrypt(requst.Form["login_pwd"].ToString());

            if (requst.Form["full_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'姓名不能为空！'}");
                return;
            }
            if (requst.Form["mobile"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'手机号不能为空！'}");
                return;
            }
            if (requst.Form["login_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'登录名称不能为空！'}");
                return;
            }
            if (requst.Form["login_pwd"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'登录密码不能为空！'}");
                return;
            }

            int result = tech_project_managerManager.Instance.Operation(info, "edit_project_manager");
            if (result > 0)
            {
                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'编辑失败！'}");
                return;
            }
        }

        private void Add()
        {
            tech_project_manager info = new tech_project_manager();
            info.full_name = requst.Form["full_name"].ToString();
            info.login_name = requst.Form["login_name"].ToString();
            info.login_pwd = Common.DEncrypt.DESEncrypt.Encrypt(requst.Form["login_pwd"].ToString());
            info.mobile = requst.Form["mobile"].ToString();

            if (requst.Form["full_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'姓名不能为空！'}");
                return;
            }
            if (requst.Form["mobile"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'手机号不能为空！'}");
                return;
            }
            if (requst.Form["login_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'登录名称不能为空！'}");
                return;
            }
            if (requst.Form["login_pwd"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'登录密码不能为空！'}");
                return;
            }

            int iscunzai = tech_project_managerManager.Instance.Operation(info, "iscunzai");
            if (iscunzai > 0)
            {
                response.Write("{result:'fail',msg:'账户已经存在！'}");
                return;
            }

            int result = tech_project_managerManager.Instance.Operation(info, "add_project_manager");
            if (result > 0)
            {
                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'添加失败！'}");
                return;
            }
        }
    }
}