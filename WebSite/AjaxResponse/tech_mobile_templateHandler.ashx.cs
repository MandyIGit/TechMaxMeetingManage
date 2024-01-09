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
    /// tech_mobile_templateHandler 的摘要说明
    /// </summary>
    public class tech_mobile_templateHandler : PageBaseHandler
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
                    InputTechMTemplateList(pageIndex, pageSize);
                    break;
            }
        }

        private void InputTechMTemplateList(int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            tech_mobile_template info = new tech_mobile_template();

            if (requst.Form["version_id"] != null && Convert.ToInt32(requst.Form["version_id"]) > 0)
            {
                info.version_id = Convert.ToInt32(requst.Form["version_id"]);
            }
            if (!string.IsNullOrWhiteSpace(requst.Form["mtemplate_name"]))
            {
                info.mtemplate_name = Convert.ToString(requst.Form["mtemplate_name"]);
            }

            info.PageIndex = pageIndex;
            info.PageSize = pageSize;

            DataTable dt = tech_mobile_templateManager.Instance.GetTech_mobile_template(info, "select_mobile_template_to_page");
            int allCount = tech_mobile_templateManager.Instance.Operation(info, "select_mobile_template_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th>模板ID</th>");
            sb.Append("<th>版本类型</th>");
            sb.Append("<th>模板名称</th>");
            //sb.Append("<th>菜单类型</th>");
            //sb.Append("<th>模板样式</th>");
            sb.Append("<th>模板缩略图</th>");
            sb.Append("<th>模板描述</th>");
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
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["mtemplate_id"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", tech_mobile_versionManager.Instance.GetModelByVersonId(dt.Rows[i]["version_id"].ToString()).v_name);
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["mtemplate_name"]));
                    //sb.AppendFormat("<td title=\"{0}\">{0}</td>", getMenuStr(dt.Rows[i]["menu_type"].ToString()));
                    //sb.AppendFormat("<td title=\"{0}\"><a href=\"javascript:;\" onclick=\"open_css('{1}')\"><img src=\"../images/icon_css.gif\" height=\"16\" /></a></td>", Convert.ToString(dt.Rows[i]["mtemplate_css"]), Convert.ToString(dt.Rows[i]["mtemplate_id"]));
                    sb.AppendFormat("<td title=\"{0}\"><a href=\"javascript:;\" onclick=\"open_thumbnail('{1}')\"><img src=\"../images/icon_img.gif\" height=\"16\" /></a></td>", Convert.ToString(dt.Rows[i]["mtemplate_thumbnail"]), Convert.ToString(dt.Rows[i]["mtemplate_id"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToString(dt.Rows[i]["mtemplate_memo"]));
                    sb.AppendFormat("<td title=\"{0}\">{0}</td>", Convert.ToDateTime(dt.Rows[i]["inputtime"]));
                    sb.Append("<td>");
                    sb.AppendFormat("<a href=\"template_menuEdit.aspx?mtemplate_id={0}\" class=\"btn btn-warning btn-xs\">菜单栏目管理</a>", dt.Rows[i]["mtemplate_id"].ToString());
                    sb.AppendFormat("<a href=\"mtemplate_edit.aspx?mtemplate_id={0}\" class=\"btn btn-secondary btn-xs\">编辑</a>", dt.Rows[i]["mtemplate_id"].ToString());
                    sb.AppendFormat("<a href=\"javascript:;\" class=\"btn btn-danger btn-xs\" onclick=\"mydelete({0})\">删除</a>", dt.Rows[i]["mtemplate_id"].ToString());
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
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_mobile_templateHandler", 1, "aspnetForm", "tb_Content"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        private void Del()
        {
            tech_mobile_template info = new tech_mobile_template();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.mtemplate_id = Convert.ToInt32(requst.QueryString["id"].ToString());
            }

            int result = tech_mobile_templateManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                string content = "删除mtemplate_id为" + info.mtemplate_id + "的模板！";
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
            tech_mobile_template info = new tech_mobile_template();
            if (requst.Form["mtemplate_id"]!=null && Convert.ToInt32(requst.Form["mtemplate_id"].ToString()) > 0)
                info.mtemplate_id = Convert.ToInt32(requst.Form["mtemplate_id"].ToString());
            if (requst.Form["version_id"] != null && Convert.ToInt32(requst.Form["version_id"].ToString()) > 0)
                info.version_id = Convert.ToInt32(requst.Form["version_id"].ToString());
            if (requst.Form["mtemplate_name"] != null)
                info.mtemplate_name = requst.Form["mtemplate_name"].ToString();
            if (requst.Form["mtemplate_css"] != null)
                info.mtemplate_css = requst.Form["mtemplate_css"].ToString();
            if (requst.Form["mtemplate_thumbnail"] != null)
                info.mtemplate_thumbnail = requst.Form["mtemplate_thumbnail"].ToString();
            if (requst.Form["mtemplate_memo"] != null)
                info.mtemplate_memo = requst.Form["mtemplate_memo"].ToString();
            if(!string.IsNullOrEmpty(requst.Form["first_content"]))
                info.first_content = TechMaxClass.Compress(requst.Form["first_content"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["second_content"]))
                info.second_content = TechMaxClass.Compress(requst.Form["second_content"].ToString());
            if (!string.IsNullOrEmpty(requst.Form["footer_content"]))
                info.footer_content = TechMaxClass.Compress(requst.Form["footer_content"].ToString());
            //if (requst.Form["menu_type"] != null && Convert.ToInt32(requst.Form["menu_type"].ToString()) > 0)
            //    info.menu_type = Convert.ToInt32(requst.Form["menu_type"].ToString());

            //if (requst.Form["mtemplate_name"].ToString() == "")
            //{
            //    response.Write("{result:'fail',msg:'模板名称不能为空！'}");
            //    return;
            //}
            //if (requst.Form["mtemplate_css"].ToString() == "")
            //{
            //    response.Write("{result:'fail',msg:'模板css样式不能为空！'}");
            //    return;
            //}
            //if (requst.Form["mtemplate_thumbnail"].ToString() == "")
            //{
            //    response.Write("{result:'fail',msg:'模板缩略图不能为空！'}");
            //    return;
            //}

            int result = tech_mobile_templateManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                string content = "编辑mtemplate_id为" + info.mtemplate_id + "的模板！";
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
            tech_mobile_template info = new tech_mobile_template();
            info.version_id = Convert.ToInt32(requst.Form["version_id"].ToString());
            info.mtemplate_name = requst.Form["mtemplate_name"].ToString();
            info.mtemplate_css = requst.Form["mtemplate_css"].ToString();
            info.mtemplate_thumbnail = requst.Form["mtemplate_thumbnail"].ToString();
            info.mtemplate_memo = requst.Form["mtemplate_memo"].ToString();
            info.first_content = TechMaxClass.Compress(requst.Form["first_content"].ToString());
            info.second_content = TechMaxClass.Compress(requst.Form["second_content"].ToString());
            info.footer_content = TechMaxClass.Compress(requst.Form["footer_content"].ToString());
            //info.menu_type = Convert.ToInt32(requst.Form["menu_type"].ToString());

            if (requst.Form["mtemplate_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'模板名称不能为空！'}");
                return;
            }
            if (requst.Form["first_content"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'一级页面内容模板不能为空！'}");
                return;
            }
            if (requst.Form["second_content"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'二级页面内容模板不能为空！'}");
                return;
            }

            int result = tech_mobile_templateManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                string content = "添加mtemplate_id为" + result + "的模板！";
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