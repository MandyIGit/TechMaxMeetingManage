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

namespace MpConsoleWebSite.AjaxResponse
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
            string postvalue = requst.QueryString["postvalue"];
            switch (type)
            {
                case "GetMenu":
                    GetMenu(postvalue);
                    break;
            }
        }

        /// <summary>
        /// 获取菜单
        /// </summary>
        private void GetMenu(string mtype_id)
        {
            StringBuilder sb = new StringBuilder();
            IList<tech_mobile_type_menu> list = tech_mobile_type_menuManager.Instance.GetMenuList(mtype_id);
            if (list.Count > 0)
            {
                sb.Append("<ul>");
                foreach (tech_mobile_type_menu item in list)
                {
                    sb.Append("<li>");
                    sb.AppendFormat("<input name=\"menu_id\" type=\"checkbox\" id=\"menu_id_{0}\" checked=\"checked\" />", item.menu_id);
                    sb.AppendFormat("<label for=\"menu_id_{0}\">{1}</label>", item.menu_id, item.menu_name);
                    sb.Append("</li>");
                }
                sb.Append("</ul>");
            }
            else
            {
                sb.Append("Null");
            }
            response.Write(sb.ToString());
        }
    }
}