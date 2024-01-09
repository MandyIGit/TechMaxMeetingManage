using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Common;
using Model;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_mobile_type_menuHandler 的摘要说明
    /// </summary>
    public class tech_mobile_type_menuHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;
        protected override void GetData(HttpContext context)
        {
            requst = context.Request;
            response = context.Response;
            string currentUrl = requst.UrlReferrer.AbsolutePath.ToLower();
            string type = requst.QueryString["type"];
            switch (type)
            {
                case "GetMenu":
                    GetMenu();
                    break;
                case "ModiMenu":
                    ModiMenu();
                    break;
                case "AddTopMenu":
                    AddTopMenu();
                    break;
                case "DeleteMenu":
                    DeleteMenu();
                    break;
            }
        }

        #region 菜单管理
        /// <summary>
        /// 获取菜单
        /// </summary>
        private void GetMenu()
        {
            string mtype_id = requst.Form["mtype_id"].ToString();
            StringBuilder sb = new StringBuilder();

            sb.Append("<colgroup>");
            sb.Append("<col width=\"30\">");
            sb.Append("<col>");
            sb.Append("<col width=\"200\">");
            sb.Append("<col width=\"200\">");
            sb.Append("</colgroup>");
            sb.Append("<thead id=\"gettmplace\">");
            sb.Append("<tr>");
            sb.Append("<td width=\"20\"></td>");
            sb.Append("<td>顺序</td>");
            sb.Append("<td width=\"100\">链接</td>");
            sb.Append("<td width=\"200\">操作</td>");
            sb.Append("</tr>");
            sb.Append("</thead>");
            IList<tech_mobile_type_menu> list = tech_mobile_type_menuManager.Instance.GetMenuList(mtype_id);
            foreach (tech_mobile_type_menu item in list)
            {
                sb.Append("<tbody>");
                sb.AppendFormat("<tr id=\"tr_{0}\">", item.menu_id);
                sb.AppendFormat("<td><span class=\"J_start_icon zero_icon\"></span><input type=\"hidden\" id=\"temp_id_{0}\"  name=\"temp_id\" value=\"{0}\"/></td>", item.menu_id);
                sb.AppendFormat("<td><input type=\"text\" name=\"sort\" id=\"sort_{2}\" value=\"{0}\" class=\"txt_table mr5 txt20\"><input type=\"text\" name=\"menu_name\" id=\"menu_name_{2}\"  class=\"noborder mr5 txt100\" value=\"{1}\"><input type=\"text\" name=\"menu_icon\" id=\"menu_icon_{2}\"  class=\"noborder mr5 txt100\" value=\"{3}\"></td>", item.sort, item.menu_name, item.menu_id, item.menu_icon);
                sb.AppendFormat("<td><input type=\"text\" name=\"menu_url\" id=\"menu_url_{0}\" value=\"{1}\" class=\"txt_table\"></td>", item.menu_id, item.menu_url);
                sb.AppendFormat("<td><a class=\"mr5\" onclick=\"deletemenu('{0}')\">[删除]</a></td>", item.menu_id);
                sb.Append("</tr>");
                sb.Append("</tbody>");
            }

            response.Write(sb.ToString());
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        private void ModiMenu()
        {
            int i = 0;
            string mtype_id = requst.Form["mtype_id"];
            string strjson = requst.Form["JsonStr"];

            JavaScriptSerializer json = new JavaScriptSerializer();
            List<tech_mobile_type_menu> list = json.Deserialize<List<tech_mobile_type_menu>>(strjson);
            foreach (tech_mobile_type_menu item in list)
            {
                if (item.menu_name != "请输入菜单名称")
                {
                    item.mtype_id = Convert.ToInt32(mtype_id);
                    if (item.menu_icon == "请输入菜单图标")
                    {
                        item.menu_icon = "";
                    }
                    if (item.menu_url == "连接暂无")
                    {
                        item.menu_url = "";
                    }
                    i += tech_mobile_type_menuManager.Instance.ModifyMenu(item);
                }
            }
            response.Write(i.ToString());
        }

        /// <summary>
        /// 添加顶级菜单
        /// </summary>
        private void AddTopMenu()
        {
            string temepid = DateTime.Now.ToString("HHmmssff");
            string mtype_id = requst.Form["mtype_id"];
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<tbody id=\"tbody_{0}\">", temepid);
            sb.Append("<tr>");
            sb.AppendFormat("<td><span class=\"J_start_icon zero_icon\"></span><input type=\"hidden\" id=\"temp_id_{0}\"  name=\"temp_id\" value=\"{0}\"/></td>", temepid);
            sb.AppendFormat("<td><input type=\"text\" name=\"sort\" id=\"sort_{2}\" value=\"{0}\" class=\"txt mr5 txt20\"><input type=\"text\" name=\"menu_name\" id=\"menu_name_{2}\"  class=\"noborder mr5 txt100\" value=\"{1}\"><input type=\"text\" name=\"menu_icon\" id=\"menu_icon_{2}\" class=\"noborder mr5 txt100\" value=\"{4}\"></td>", 0, "请输入菜单名称", temepid, 0, "请输入菜单图标");
            sb.AppendFormat("<td><input type=\"text\" name=\"menu_url\" id=\"menu_url_{0}\"  value=\"连接暂无\" class=\"txt_table\"></td>", temepid);
            sb.AppendFormat("<td><a class=\"mr5\" onclick=\"removetop('{0}')\">[删除]</a></td>", temepid);
            sb.Append("</tr>");

            sb.Append("</tbody>");
            response.Write(sb.ToString());
        }

        /// <summary>
        /// 删除菜单
        /// </summary>
        private void DeleteMenu()
        {
            int menu_id = Convert.ToInt32(requst.QueryString["menu_id"]);
            int i = tech_mobile_type_menuManager.Instance.Delete(menu_id);
            response.Write(i.ToString());
        }

        #endregion

    }
}