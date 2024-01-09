using BLL;
using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace MpConsoleWebSite.AjaxResponse
{
    /// <summary>
    /// tv_menuHandler 的摘要说明
    /// </summary>
    public class tv_menuHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
            sbContextWrite = new StringBuilder();            
            requst = context.Request;
            response = context.Response;
            string contextType = requst.Params["type"];
            string xml = Convert.ToString(requst.Params["postvalue"]);

            switch (contextType)
            {
                case "1":
                    //输出视频后台菜单信息
                    InputSystemMenu(xml);
                    break;
            }
        }

        #region 输出后台菜单信息
        /// <summary>
        /// 输出后台菜单信息
        /// </summary>
        private void InputSystemMenu(string xml)
        {
            StringBuilder sb = new StringBuilder();
            if (requst.Cookies[WebCommon.MEETING_KEY] != null && !string.IsNullOrEmpty(xml))
            {
                DataTable menu_dt = new tv_menuManager().Get_tv_menu(0, Convert.ToInt32(xml));
                if (menu_dt != null && menu_dt.Rows.Count != 0)
                {
                    sb.Append("<ul id=\"main-nav\">");
                    for (int i = 0; i < menu_dt.Rows.Count; i++)
                    {
                        DataTable pid_dt = new tv_menuManager().Get_tv_menu(Convert.ToInt32(menu_dt.Rows[i]["menu_id"]), Convert.ToInt32(xml));
                        if (pid_dt != null && pid_dt.Rows.Count != 0)
                        {
                            sb.AppendFormat("<li><a class=\"nav-top-item current\"><span class=\"nav-name i-huiyuan\">{0}</span></a>", Convert.ToString(menu_dt.Rows[i]["menu_name"]));
                            sb.Append("<ul class=\"ulul\">");
                            for (int j = 0; j < pid_dt.Rows.Count; j++)
                            {
                                sb.AppendFormat("<li><a target=\"mainhtml\" href=\"javascript:void(0);\" onclick=\"htmlskip('{0}')\"><span\"></span>{1}</a> </li>", Convert.ToString(pid_dt.Rows[j]["html_url"]), Convert.ToString(pid_dt.Rows[j]["menu_name"]));
                            }
                            sb.Append("</ul>");
                            sb.Append("</li>");
                        }
                    }
                    sb.Append("</ul>");
                }                
            }
            else if(requst.Cookies[WebCommon.MEETING_KEY] != null && !string.IsNullOrEmpty(requst.Cookies[WebCommon.MEETING_KEY].Values["mtype_id"]))
            {
                DataTable menu_dt = new tv_menuManager().Get_tv_menu(0);
                if (menu_dt != null && menu_dt.Rows.Count != 0)
                {
                    sb.Append("<ul id=\"main-nav\">");
                    for (int i = 0; i < menu_dt.Rows.Count; i++)
                    {
                        DataTable pid_dt = new tv_menuManager().Get_tv_menu(Convert.ToInt32(menu_dt.Rows[i]["menu_id"]));
                        if (pid_dt != null && pid_dt.Rows.Count != 0)
                        {
                            sb.AppendFormat("<li><a class=\"nav-top-item current\"><span class=\"nav-name i-huiyuan\">{0}</span></a>", Convert.ToString(menu_dt.Rows[i]["menu_name"]));
                            sb.Append("<ul class=\"ulul\">");
                            for (int j = 0; j < pid_dt.Rows.Count; j++)
                            {
                                sb.AppendFormat("<li><a target=\"mainhtml\" href=\"javascript:void(0);\" onclick=\"htmlskip('{0}')\"><span\"></span>{1}</a> </li>", Convert.ToString(pid_dt.Rows[j]["html_url"]), Convert.ToString(pid_dt.Rows[j]["menu_name"]));
                            }
                            sb.Append("</ul>");
                            sb.Append("</li>");
                        }
                    }
                    sb.Append("</ul>");
                }
            }

            sbContextWrite.Append(sb.ToString());
        }
        #endregion

    }
}