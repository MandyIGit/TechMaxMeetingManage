using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Common;
using Model;
using System.Data;
using System.Text;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_mobile_typeHandler 的摘要说明
    /// </summary>
    public class tech_mobile_typeHandler : PageBaseHandler
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
                    InputTechMobileTypeList(pageIndex, pageSize);
                    break;
            }
        }

        private void InputTechMobileTypeList(int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            tech_mobile_type info = new tech_mobile_type();

            info.PageIndex = pageIndex;
            info.PageSize = pageSize;

            DataTable dt = tech_mobile_typeManager.Instance.GetTech_mobile_type(info, "select_mobile_type_to_page");
            int allCount = tech_mobile_typeManager.Instance.Operation(info, "select_mobile_type_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th>类型ID</th>");
            sb.Append("<th>会议类型名称</th>");
            sb.Append("<th>会议类型描述</th>");
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
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["mtype_id"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["mtype_name"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["mtype_memo"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["inputtime"]));
                    sb.Append("<td>");
                    sb.AppendFormat("<a href=\"mtemplate_type_edit.aspx?mtype_id={0}\" class=\"btn btn-secondary btn-xs\">编辑</a>", dt.Rows[i]["mtype_id"].ToString());
                    sb.AppendFormat("<a href=\"javascript:;\" class=\"btn btn-danger btn-xs\" onclick=\"mydelete({0})\">删除</a>", dt.Rows[i]["mtype_id"].ToString());
                    //sb.AppendFormat("<a href=\"mobile_type_menuEdit.aspx?mtype_id={0}\" class=\"btn btn-secondary btn-xs\">菜单栏目管理</a>", dt.Rows[i]["mtype_id"].ToString());
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr class=\"odd gradeX\">");
                sb.Append("<td colspan=\"5\">Null</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_mobile_typeHandler", 1, "aspnetForm", "tb_Content"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        private void Del()
        {
            tech_mobile_type info = new tech_mobile_type();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.Mtype_id = Convert.ToInt32(requst.QueryString["id"].ToString());
            }

            int exists = tech_mobile_templateManager.Instance.Operation(new tech_mobile_template { mtype_id= info.Mtype_id }, "select_mobile_template_count");
            if (exists > 0)
            {
                response.Write("{result:'fail',msg:'该类型下有模板存在，请删除模板后再来删除该类型！'}");
                return;
            }

            int result = tech_mobile_typeManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                string content = "删除Mtype_id为" + info.Mtype_id + "的会议类型！";
                operating_record(content);

                response.Write("{result:'succ',msg:'删除成功！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'删除失败！'}");
                return;
            }
        }

        private void Edit()
        {
            tech_mobile_type info = new tech_mobile_type();
            info.Mtype_id = Convert.ToInt32(requst.Form["mtype_id"].ToString());
            info.Mtype_name = requst.Form["mtype_name"].ToString();
            info.Mtype_memo = requst.Form["mtype_memo"].ToString();

            if (requst.Form["mtype_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'类型名称不能为空！'}");
                return;
            }

            int result = tech_mobile_typeManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                string content = "编辑Mtype_id为" + info.Mtype_id + "的会议类型！";
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
            tech_mobile_type info = new tech_mobile_type();
            info.Mtype_name = requst.Form["mtype_name"].ToString();
            info.Mtype_memo = requst.Form["mtype_memo"].ToString();

            if (requst.Form["mtype_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'类型名称不能为空！'}");
                return;
            }

            int result = tech_mobile_typeManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                string content = "添加Mtype_id为" + result + "的会议类型！";
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
    }
}