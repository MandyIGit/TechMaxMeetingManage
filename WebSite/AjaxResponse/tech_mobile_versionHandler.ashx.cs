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
    /// tech_mobile_versionHandler 的摘要说明
    /// </summary>
    public class tech_mobile_versionHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
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
                    InputTechMobileVersionList(pageIndex, pageSize);
                    break;
            }
        }

        private void InputTechMobileVersionList(int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            tech_mobile_version info = new tech_mobile_version();

            info.PageIndex = pageIndex;
            info.PageSize = pageSize;

            DataTable dt = tech_mobile_versionManager.Instance.GetTech_mobile_version(info, "select_mobile_version_to_page");
            int allCount = tech_mobile_versionManager.Instance.Operation(info, "select_mobile_version_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th>版本ID</th>");
            sb.Append("<th>会议版本名称</th>");
            sb.Append("<th>首页菜单类型</th>");
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
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["v_id"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["v_name"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", getMenuStr(dt.Rows[i]["menu_type"].ToString()));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["inputtime"]));
                    sb.Append("<td>");
                    sb.AppendFormat("<a href=\"mtemplate_version_edit.aspx?v_id={0}\" class=\"btn btn-secondary btn-xs\">编辑</a>", dt.Rows[i]["v_id"].ToString());
                    sb.AppendFormat("<a href=\"javascript:;\" class=\"btn btn-danger btn-xs\" onclick=\"mydelete({0})\">删除</a>", dt.Rows[i]["v_id"].ToString());
                    //sb.AppendFormat("<a href=\"mobile_type_menuEdit.aspx?mtype_id={0}\" class=\"btn btn-secondary btn-xs\">菜单栏目管理</a>", dt.Rows[i]["v_id"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr class=\"odd gradeX\">");
                sb.Append("<td colspan=\"4\">Null</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_mobile_versionHandler", 1, "aspnetForm", "tb_Content"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        private void Del()
        {
            tech_mobile_version info = new tech_mobile_version();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.v_id = Convert.ToInt32(requst.QueryString["id"].ToString());
            }

            int exists = tech_mobile_templateManager.Instance.Operation(new tech_mobile_template { version_id = info.v_id }, "select_mobile_template_count");
            if (exists > 0)
            {
                response.Write("{result:'fail',msg:'该版本下有模板存在，请删除模板后再来删除该版本！'}");
                return;
            }

            int result = tech_mobile_versionManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                string content = "删除v_id为" + info.v_id + "的会议版本！";
                operating_record(content);

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
            tech_mobile_version info = new tech_mobile_version();
            info.v_id = Convert.ToInt32(requst.Form["v_id"].ToString());
            info.v_name = requst.Form["v_name"].ToString();
            info.menu_type = Convert.ToInt32(requst.Form["menu_type"].ToString());

            if (requst.Form["v_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'版本名称不能为空！'}");
                return;
            }

            int result = tech_mobile_versionManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                string content = "编辑v_id为" + info.v_id + "的会议版本！";
                operating_record(content);

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
            tech_mobile_version info = new tech_mobile_version();
            info.v_name = requst.Form["v_name"].ToString();
            info.menu_type = Convert.ToInt32(requst.Form["menu_type"].ToString());

            if (requst.Form["v_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'版本名称不能为空！'}");
                return;
            }

            int result = tech_mobile_versionManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                string content = "添加v_id为" + result + "的会议版本！";
                operating_record(content);

                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'添加失败！'}");
                return;
            }
        }

        private string getMenuStr(string m)
        {
            string str = "";
            switch (m)
            {
                case "1":
                    str = "经典型（九宫格）";
                    break;
                case "2":
                    str = "时尚型（上三下六）";
                    break;
                case "3":
                    str = "微软型（不规则型）";
                    break;
                case "4":
                    str = "八宫格（第四个横向占两格）";
                    break;
            }
            return str;
        }

    }
}