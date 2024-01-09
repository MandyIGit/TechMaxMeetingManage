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

namespace DIY.AjaxResponse
{
    /// <summary>
    /// tech_mobile_menuHandler 的摘要说明
    /// </summary>
    public class tech_mobile_menuHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;
        protected override void GetData(HttpContext context)
        {
            requst = context.Request;
            response = context.Response;
            string currentUrl = requst.UrlReferrer.AbsolutePath.ToLower();
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
                //菜单管理
                case "GetMenu":
                    GetMenu();
                    break;
                case "GetMenuContent":
                    GetMenuContent();
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
                case "DisMenu":
                    DisMenu();
                    break;
                case "ModifyContent":
                    ModifyContent();
                    break;
                case "GetContent":
                    GetContent();
                    break;
                case "menu_up":
                    MenuUp();
                    break;
                case "menu_down":
                    MenuDown();
                    break;
            }

        }

        private void MenuDown()
        {
            int i = 0, j = 0;
            int MenuID = int.Parse(requst.Params["menu_id"]);
            int Sort = int.Parse(requst.Params["Sort"]);
            tech_mobile_menu CurrentModel = tech_mobile_menuManager.Instance.GetModel(MenuID);
            if (CurrentModel != null)
            {
                tech_mobile_menu DownModel = tech_mobile_menuManager.Instance.GetDownModel(CurrentModel.Sort, CurrentModel.Mid);
                if (DownModel != null)
                {
                    i = tech_mobile_menuManager.Instance.ModifyMenu(new tech_mobile_menu { Menu_id = CurrentModel.Menu_id, Sort = DownModel.Sort });
                    j = tech_mobile_menuManager.Instance.ModifyMenu(new tech_mobile_menu { Menu_id = DownModel.Menu_id, Sort = CurrentModel.Sort });
                }
            }
            response.Write(i + j);
        }

        private void MenuUp()
        {
            int i = 0, j = 0;
            int MenuID = int.Parse(requst.Params["menu_id"]);
            int Sort = int.Parse(requst.Params["Sort"]);
            tech_mobile_menu CurrentModel = tech_mobile_menuManager.Instance.GetModel(MenuID);
            if (CurrentModel != null)
            {
                tech_mobile_menu UpModel = tech_mobile_menuManager.Instance.GetUpModel(CurrentModel.Sort, CurrentModel.Mid);
                if (UpModel != null)
                {
                    i = tech_mobile_menuManager.Instance.ModifyMenu(new tech_mobile_menu { Menu_id = CurrentModel.Menu_id, Sort = UpModel.Sort });
                    j = tech_mobile_menuManager.Instance.ModifyMenu(new tech_mobile_menu { Menu_id = UpModel.Menu_id, Sort = CurrentModel.Sort });
                }
            }
            response.Write(i + j);
        }


        #region  添加和修改内容信息
        private void GetContent()
        {
            StringBuilder sb = new StringBuilder();
            string mc_id = Convert.ToString(requst.Form["mc_id"]);
            tech_mobile_menu_content model = tech_mobile_menu_contentManager.Instance.GetModelByMcId(mc_id);
            if (model != null)
            {
                string content = "";
                if (!string.IsNullOrEmpty(model.mc_msg))
                {
                    content = TechMaxClass.Decompress(model.mc_msg);
                }

                sb.AppendFormat("<div id=\"divmc_title\">{0}</div>", model.mc_title);
                sb.AppendFormat("<div id=\"divmc_msg\">{0}</div>", content.Trim().Replace("'", " "));
                //sb.Append("{");
                //sb.AppendFormat("'mc_title':'{0}','mc_url':'{1}','en_mc_title':'{2}',", model.Mc_title, model.Mc_url, model.en_mc_title);

                //sb.AppendFormat("'mc_msg':'{0}','en_mc_msg':'{1}'", content.Trim().Replace("'", " "), en_content.Trim().Replace("'", " "));
                //sb.Append("}");
            }

            response.Write(sb.ToString());
        }
        private void ModifyContent()
        {
            int mc_id = Convert.ToInt32(requst.Form["mc_id"]);
            string mc_title = requst.Form["mc_title"];
            string mc_msg = requst.Form["mc_msg"];
            int menuid = Convert.ToInt32(requst.Form["menuid"]);

            tech_mobile_menu_content model = new tech_mobile_menu_content();
            model.mc_id = mc_id;
            model.mc_title = mc_title;
            model.mc_msg = TechMaxClass.Compress(mc_msg);
            model.menu_id = menuid;
            model.inputtime = DateTime.Now;
            int i = tech_mobile_menu_contentManager.Instance.ModifyModel(model);
            if (i > 0)
            {
                string content = WebCommon.GetCookie(WebCommon.MEETING_KEY, 0).Split('=')[1] + "编辑了menuid为" + menuid + "的内容！";
                operating_record(content);
                response.Write("sur_ok");
            }                
            else
                response.Write("sur_err");
        }
        #endregion

        #region 菜单管理
        private void GetMenu()
        {
            string mid = requst.Form["mid"].ToString();
            StringBuilder sb = new StringBuilder();


            sb.Append(" <colgroup>");
            sb.Append(" <col width=\"30\">");
            sb.Append(" <col>");
            sb.Append(" <col width=\"200\">");
            sb.Append(" <col width=\"200\">");
            sb.Append(" </colgroup>");
            sb.Append(" <thead id=\"gettmplace\">");
            sb.Append(" <tr>");
            sb.Append(" <td width=\"20\" style=\"display:none;\"></td>");
            sb.Append(" <td>顺序</td>");
            sb.Append(" <td>菜单名称</td>");
            sb.Append(" <td style=\"display:none;\">菜单图标编码</td>");
            sb.Append(" <td style=\"display:none;\">图标编码</td>");
            sb.Append(" <td width=\"100\" style=\"display:none;\">链接</td>");
            sb.Append(" <td width=\"200\" style=\"display:none;\">操作</td>");
            sb.Append(" <td>排序操作</td>");
            sb.Append(" </tr>");
            sb.Append(" </thead>");
            IList<tech_mobile_menu> list = tech_mobile_menuManager.Instance.GetMenuList(mid);
            int i = 1;
            foreach (tech_mobile_menu item in list)
            {
                sb.Append(" <tbody>");
                sb.AppendFormat("<tr id=\"tr_{0}\">", item.Menu_id);
                sb.AppendFormat("<td style=\"display:none;\"><span class=\"J_start_icon zero_icon\"></span><input type=\"hidden\" id=\"temp_id_{0}\"  name=\"temp_id\" value=\"{0}\"/></td>", item.Menu_id);
                sb.AppendFormat("<td><input type=\"text\" name=\"sort\" id=\"sort_{0}\" value=\"{1}\" class=\"txt_table mr5 txt30\"></td>", item.Menu_id, item.Sort);
                sb.AppendFormat("<td><input type=\"text\" name=\"menu_name\" id=\"menu_name_{0}\" class=\"mr5 txt80\" value=\"{1}\"></td>", item.Menu_id, item.Menu_name);
                sb.AppendFormat("<td style=\"display:none;\"><input type=\"text\" name=\"menu_icon\" id=\"menu_icon_{0}\" class=\"noborder mr5 txt80\" value=\"{1}\"></td>", item.Menu_id, item.Menu_icon);
                sb.AppendFormat("<td style=\"display:none;\"><xmp>{0}</xmp></td>", item.Menu_icon);
                sb.AppendFormat("<td style=\"display:none;\"><input type=\"text\" name=\"menu_url\" id=\"menu_url_{0}\" value=\"{1}\" class=\"txt_table\"></td>", item.Menu_id, item.Menu_url);
                sb.AppendFormat("<td style=\"display:none;\"><a class=\"mr5\" onclick=\"deletemenu('{0}')\">[删除]</a><a class=\"mr5\" onclick=\"dismenu('{0}')\">[{1}]</a></td>", item.Menu_id, item.Isban == 1 ? "导航显示" : "导航隐藏");
                sb.Append("<td>");
                if (i == 1)
                {
                    sb.AppendFormat("<button type=\"button\" disabled=\"disabled\" class=\"btn btn-primary\">上移</button>");
                }
                else
                {
                    sb.AppendFormat("<button type=\"button\" class=\"btn btn-primary\" onclick=\"menu_up('{0}','{1}')\">上移</button>", item.Menu_id, item.Sort);
                }
                sb.Append("&nbsp;");
                if (i == list.Count)
                {
                    sb.AppendFormat("<button type=\"button\" disabled=\"disabled\" class=\"btn btn-success\">下移</button>");
                }
                else
                {
                    sb.AppendFormat("<button type=\"button\" class=\"btn btn-success\" onclick=\"menu_down('{0}','{1}')\">下移</button>", item.Menu_id, item.Sort);
                }
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append(" </tbody>");
                i++;
            }

            response.Write(sb.ToString());
        }

        private void GetMenuContent()
        {
            string mid = requst.Form["mid"].ToString();
            StringBuilder sb = new StringBuilder();


            sb.Append(" <colgroup>");
            sb.Append(" <col width=\"30\">");
            sb.Append(" <col>");
            sb.Append(" <col width=\"200\">");
            sb.Append(" <col width=\"200\">");
            sb.Append(" </colgroup>");
            sb.Append(" <thead id=\"gettmplace\">");
            sb.Append(" <tr>");
            sb.Append(" <td width=\"20\"></td>");
            sb.Append(" <td>菜单名称</td>");
            //sb.Append(" <td width=\"200\">链接</td>");
            sb.Append(" <td width=\"200\">操作</td>");
            sb.Append(" </tr>");
            sb.Append(" </thead>");
            IList<tech_mobile_menu> list = tech_mobile_menuManager.Instance.GetMenuList(mid);
            foreach (tech_mobile_menu item in list)
            {
                sb.Append("<tbody>");
                sb.AppendFormat("<tr id=\"tr_{0}\">", item.Menu_id);
                sb.AppendFormat("<td><span class=\"J_start_icon zero_icon\"></span><input type=\"hidden\" id=\"temp_id_{0}\"  name=\"temp_id\" value=\"{0}\"/></td>", item.Menu_id);
                //sb.AppendFormat("<td><input type=\"text\" name=\"sort\" id=\"sort_{2}\" value=\"{0}\" class=\"txt mr5 txt20\"><input type=\"text\" name=\"menu_name\" id=\"menu_name_{2}\"  class=\"txt noborder\" value=\"{1}\"></td>", item.Sort, item.Menu_name, item.Menu_id);
                sb.AppendFormat("<td>{0}</td>", item.Menu_name);
                sb.AppendFormat("<td style=\"display:none;\"><input type=\"text\" value=\"menu_id={0}\" class=\"txt\"></td>", item.Menu_id);
                sb.Append("<td>");
                if (string.IsNullOrEmpty(item.Menu_url))
                    sb.Append("<a href=\"menu_content_edit.aspx?menuid=" + item.Menu_id + "\" class=\"mr5\">[管理内容]</a>");
                sb.Append("</td>");
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
            string mid = requst.Form["mid"];
            string strjson = requst.Form["JsonStr"];

            JavaScriptSerializer json = new JavaScriptSerializer();
            List<tech_mobile_menu> list = json.Deserialize<List<tech_mobile_menu>>(strjson);
            foreach (tech_mobile_menu item in list)
            {
                if (item.Menu_name != "请输入菜单名称")
                {
                    item.Mid = mid;
                    if (item.Menu_icon == "请输入菜单图标编码")
                    {
                        item.Menu_icon = "";
                    }
                    if (item.Menu_url == "连接暂无")
                    {
                        item.Menu_url = "";
                    }
                    i += tech_mobile_menuManager.Instance.ModifyMenu(item);
                }
            }

            string content = WebCommon.GetCookie(WebCommon.MEETING_KEY, 0).Split('=')[1] + "自助微站菜单更新！";
            operating_record(content);

            response.Write(i.ToString());
        }


        /// <summary>
        /// 添加顶级菜单
        /// </summary>
        private void AddTopMenu()
        {

            string temepid = DateTime.Now.ToString("HHmmssff");
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<tbody id=\"tbody_{0}\">", temepid);
            sb.Append("<tr>");
            sb.AppendFormat("<td><span class=\"J_start_icon zero_icon\"></span><input type=\"hidden\" id=\"temp_id_{0}\"  name=\"temp_id\" value=\"{0}\"/></td>", temepid);
            sb.AppendFormat("<td><input type=\"text\" name=\"sort\" id=\"sort_{1}\" value=\"{0}\" class=\"txt mr5 txt20\"></td>", 0, temepid);
            sb.AppendFormat("<td><input type=\"text\" name=\"menu_name\" id=\"menu_name_{1}\" class=\"noborder mr5 txt80\" value=\"{0}\"></td>", "请输入菜单名称", temepid);
            sb.AppendFormat("<td><input type=\"text\" name=\"menu_icon\" id=\"menu_icon_{1}\" class=\"noborder mr5 txt80\" value=\"{0}\"></td>", "请输入菜单图标编码", temepid);
            sb.AppendFormat("<td><input type=\"text\" name=\"menu_url\" id=\"menu_url_{0}\" value=\"连接暂无\" class=\"txt_table\"></td>", temepid);
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
            int i = tech_mobile_menuManager.Instance.Delete(menu_id);
            response.Write(i.ToString());
        }
        /// <summary>
        /// 禁用或者启用菜单
        /// </summary>
        private void DisMenu()
        {
            string mid = requst.Form["mid"];
            int menu_id = Convert.ToInt32(requst.QueryString["menu_id"]);
            int i = tech_mobile_menuManager.Instance.SetBanStatu(menu_id);
            response.Write(i.ToString());
        }
        #endregion

    }
}