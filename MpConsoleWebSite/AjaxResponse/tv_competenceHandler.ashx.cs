using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace MpConsoleWebSite.AjaxResponse
{
    /// <summary>
    /// tv_competenceHandler 的摘要说明
    /// </summary>
    public class tv_competenceHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
            requst = context.Request;
            response = context.Response;

            sbContextWrite = new StringBuilder();
            string contextType = requst.Params["type"];
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
            switch (contextType)
            {
                case "1":
                    //输出权限管理HTML
                    InputTv_competence(context, pageIndex, pageSize);
                    break;
                case "2":
                    //删除管理用户
                    DeleteSystem_user(context, xml);
                    break;
                case "3":
                    //加载修改管理用户信息HTML
                    InputUpdate_system_userHTML(xml);
                    break;
                case "4":
                    //保存修改信息
                    SaveUpdateData(context);
                    break;
                case "5":
                    //新增管理员信息保存
                    SaveAddData(context);
                    break;
                case "6":
                    //加载权限信息HTML
                    InputCompetence_siteHTML();
                    break;
                case "7":
                    //按管理员ID得到其权限
                    GetCompetence(xml);
                    break;
                case "8":
                    //保存管理权限
                    SaveCompetence(context, xml);
                    break;
            }
        }

        #region 输出权限管理HTML
        /// <summary>
        /// 方法说明：输出权限管理HTML
        /// </summary>
        /// <param name="context">HttpContext对象</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        private void InputTv_competence(HttpContext context, int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            tv_system_user info = new tv_system_user();
            info.Mid = Convert.ToString(context.Request.Form["mid"]);
            //姓名
            if (!string.IsNullOrEmpty(requst.Form["sys_name"]) && Convert.ToString(requst.Form["sys_name"]) != "")
            {
                info.Sys_name = Convert.ToString(context.Request.Form["sys_name"]);
            }
            DataTable dt = new tv_system_userManager().GetTv_system_user(info, pageIndex, pageSize);

            int allCount = new tv_system_userManager().GetTv_system_user_count(info);
            int pageCount = (allCount + pageSize - 1) / pageSize;

            sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotable\">");
            sb.Append("<tr>");
            sb.Append("<th scope=\"col\"><input type=\"checkbox\" name=\"checkbox\" id=\"checkbox\" onclick=\"getAll()\" />");
            sb.Append("<label for=\"checkbox\"></label></th>");
            sb.Append("<th scope=\"col\">姓名</th>");
            sb.Append("<th scope=\"col\">登录ID</th>");
            sb.Append("<th scope=\"col\">管理员级别</th>");
            sb.Append("<th scope=\"col\">添加时间</th>");
            sb.Append("<th scope=\"col\">操作</th>");
            sb.Append("</tr>");
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    if (Convert.ToString(dt.Rows[i]["system_level"]) == "1")
                    {
                        sb.Append("<td>-</td>");
                    }
                    else
                    {
                        sb.AppendFormat("<td><input type=\"checkbox\" name=\"sys_check\" id=\"{0}\" /></td>", Convert.ToString(dt.Rows[i]["sys_code"]));
                    }
                    sb.AppendFormat("<td>{0}</td>", Convert.ToString(dt.Rows[i]["sys_name"]));
                    sb.AppendFormat("<td>{0}</td>", Convert.ToString(dt.Rows[i]["login_id"]));
                    switch (Convert.ToString(dt.Rows[i]["system_level"]))
                    {
                        case "1":
                            sb.Append("<td>超级管理员</td>");
                            break;
                        case "2":
                            sb.Append("<td>普通管理员</td>");
                            break;
                    }
                    sb.AppendFormat("<td>{0}</td>", Convert.ToDateTime(dt.Rows[i]["add_date"]).ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append("<td>");
                    sb.AppendFormat("<a class=\"p10\" href=\"javascript:void(0)\" onclick=\"javascript:OpenUrl('system_manager/competence_site.aspx?sys_code={0}','权限设置',800,600);\">权限设置</a>", Convert.ToString(dt.Rows[i]["sys_code"]));
                    sb.Append("|");
                    sb.AppendFormat("<a class=\"p10\" href=\"javascript:void(0)\" onclick=\"javascript:OpenUrl('system_manager/add_update_system.aspx?sys_code={0}','修改资料',350,250);\">修改资料</a>", Convert.ToString(dt.Rows[i]["sys_code"]));
                    sb.Append("</td>");
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr>");
                sb.Append("<td colspan=\"6\">没有任何数据</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            sb.Append("<div class=\"h10\"></div>");
            if (dt != null && dt.Rows.Count != 0)
            {
                sb.Append("<div class=\"listmenu\">");
                sb.Append("<a href=\"javascript:void(0)\" class=\"btnwhite\" onclick=\"DeleteData()\">删除管理员</a>");
                sb.Append("<a href=\"javascript:void(0)\" class=\"btnwhite\" onclick=\"javascript:OpenUrl('system_manager/add_update_system.aspx','新增管理员',350,250);\">新增管理员</a>");
                sb.Append("<div class=\"clear\"></div>");
                sb.Append("</div>");
            }
            sb.Append("<div class=\"h10\"></div>");
            sb.Append("<div class=\"sabrosus\">");

            //分页
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tv_competenceHandler", 1, "form1", "system_data"));

            sb.Append("</div>");
            sb.Append("<div class=\"h10\"></div>");

            sbContextWrite.Append(sb.ToString());
        }
        #endregion

        #region 删除管理用户
        /// <summary>
        /// 方法说明：删除管理用户
        /// </summary>
        private void DeleteSystem_user(HttpContext context, string xml)
        {
            string mid = context.Request.Form["mid"];
            if (new tv_system_userManager().Delete_system_user(xml,mid) >= 1)
            {
                sbContextWrite.Append("OK");
            }
            else
            {
                sbContextWrite.Append("删除管理用户信息失败！");
            }
        }
        #endregion

        #region 加载修改管理用户信息HTML
        /// <summary>
        /// 方法说明：加载修改管理用户信息HTML
        /// </summary>
        /// <param name="xml">管理用户ID</param>
        private void InputUpdate_system_userHTML(string xml)
        {
            StringBuilder sb = new StringBuilder();
            tv_system_user info = new tv_system_user();
            info.Mid = requst.Form["mid"];
            info.Sys_code = Convert.ToInt32(xml);
            DataTable dt = new tv_system_userManager().GetTv_system_user(info);
            if (dt != null && dt.Rows.Count != 0)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotablel\">");
                sb.Append("<tr>");
                sb.Append("<th scope=\"row\">管理员姓名</th>");
                sb.AppendFormat("<td><input class=\"txt\" id=\"sys_name\" name=\"sys_name\" type=\"text\" value=\"{0}\" /></td>", Convert.ToString(dt.Rows[0]["sys_name"]));
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<th scope=\"row\">管理员级别</th>");
                //sb.AppendFormat("<td><input class=\"txt\" id=\"level_name\" name=\"level_name\" type=\"text\" value=\"{0}\" /></td>", Convert.ToString(dt.Rows[0]["level_name"]));
                sb.Append("<td><select id=\"system_level\" name=\"system_level\">");
                sb.Append("<option value=\"9999\">请选择</option>");
                sb.Append("<option value=\"1\">超级管理员</option>");
                sb.Append("<option value=\"2\">普通管理员</option>");
                sb.Append("</select></td>");
                sb.Append("<script type=\"text/javascript\">");
                switch (Convert.ToString(dt.Rows[0]["system_level"]))
                {
                    case "1":
                        sb.Append("$('#system_level').val('1');");
                        break;
                    case "2":
                        sb.Append("$('#system_level').val('2');");
                        break;
                }
                sb.Append("</script>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<th scope=\"row\">登录ID</th>");
                sb.AppendFormat("<td><input class=\"txt\" id=\"login_id\" name=\"login_id\" type=\"text\" value=\"{0}\" /></td>", Convert.ToString(dt.Rows[0]["login_id"]));
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<th scope=\"row\">登录密码</th>");
                sb.AppendFormat("<td><input class=\"txt\" id=\"login_pwd\" name=\"login_pwd\" type=\"password\" value=\"{0}\" /></td>", Common.DEncrypt.DESEncrypt.Decrypt(Convert.ToString(dt.Rows[0]["login_pwd"])));
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<th scope=\"row\">手机号码</th>");
                sb.AppendFormat("<td><input class=\"txt\" id=\"sys_mobile\"  name=\"sys_mobile\"  maxlength=\"11\" type=\"text\" value=\"{0}\" /></td>", Convert.ToString(dt.Rows[0]["sys_mobile"]));
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<th scope=\"row\"></th>");
                sb.Append("<td>");
                sb.AppendFormat("<input type=\"hidden\" id=\"sys_code\" name=\"sys_code\" value=\"{0}\" />", Convert.ToString(dt.Rows[0]["sys_code"]));
                sb.Append("<a class=\"btnblue\" href=\"javascript:void(0)\" onclick=\"SaveData()\">确定</a>");
                sb.Append("</td>");
                sb.Append("</tr>");
                sb.Append("</table>");
                sb.Append("<div class=\"h10\"></div>");
            }
            sbContextWrite.Append(sb.ToString());
        }
        #endregion

        #region 后台输出分页
        /// <summary>
        /// 方法说明：后台输出分页
        /// </summary>
        /// <param name="pageCount">所有记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="method">JS方法名称</param>
        /// <param name="handler">Handler名称</param>
        /// <param name="type">类型ID</param>
        /// <param name="form">页面formID</param>
        /// <param name="input_id">输出的标签ID</param>
        /// <returns>分页</returns>
        private string Page(int pageCount, int pageIndex, int pageSize, string method, string handler, int type, string form, string input_id)
        {
            StringBuilder sb = new StringBuilder();
            //分页
            if (pageCount > 1)
            {
                if (pageIndex <= 0)
                {
                    pageIndex = 1;
                }
                else if (pageIndex >= pageCount)
                {
                    pageIndex = pageCount;
                }
                string upXml = string.Format(@"<pageData><pageIndex>{0}</pageIndex><pageSize>{1}</pageSize></pageData>", pageIndex - 1 <= 1 ? 1 : pageIndex - 1, pageSize);
                string downXml = string.Format(@"<pageData><pageIndex>{0}</pageIndex><pageSize>{1}</pageSize></pageData>", pageIndex + 1 >= pageCount ? pageCount : pageIndex + 1, pageSize);
                if (pageCount > 1)
                {
                    if (pageIndex <= 1)
                    {
                        sb.AppendFormat("<a class=\"disabled\" href=\"javascript:{0}('{1}.ashx','{2}','<pageData><pageIndex>{3}</pageIndex><pageSize>{4}</pageSize></pageData>','{5}','{6}')\">首页</a>", method, handler, type, 1, pageSize, form, input_id);
                        sb.AppendFormat("<a class=\"disabled\" href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">上一页</a>", method, handler, type, upXml, form, input_id);
                    }
                    else
                    {
                        sb.AppendFormat("<a href=\"javascript:{0}('{1}.ashx','{2}','<pageData><pageIndex>{3}</pageIndex><pageSize>{4}</pageSize></pageData>','{5}','{6}')\">首页</a>", method, handler, type, 1, pageSize, form, input_id);
                        sb.AppendFormat("<a href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">上一页</a>", method, handler, type, upXml, form, input_id);
                    }
                    int page_num = 0;

                    if (pageIndex > 5)
                    {
                        for (int i = pageIndex - 5; i < pageCount; i++)
                        {
                            page_num += 1;
                            string pageXml = string.Format(@"<pageData><pageIndex>{0}</pageIndex><pageSize>{1}</pageSize><pageCount>{2}</pageCount></pageData>", i + 1, pageSize, pageCount);
                            if (page_num == 9)
                            {
                                sb.Append("...");
                                page_num = 0;
                                break;
                            }
                            else
                            {
                                if (pageIndex == i + 1)
                                {
                                    sb.AppendFormat("<a class=\"current\" href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">{6}</a>", method, handler, type, pageXml, form, input_id, i + 1);
                                }
                                else
                                {
                                    sb.AppendFormat("<a href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">{6}</a>", method, handler, type, pageXml, form, input_id, i + 1);
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < pageCount; i++)
                        {
                            page_num += 1;
                            if (page_num == 9)
                            {
                                sb.Append("...");
                                page_num = 0;
                                break;
                            }
                            string pageXml = string.Format(@"<pageData><pageIndex>{0}</pageIndex><pageSize>{1}</pageSize><pageCount>{2}</pageCount></pageData>", i + 1, pageSize, pageCount);
                            if (pageIndex == i + 1)
                            {
                                sb.AppendFormat("<a class=\"current\" href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">{6}</a>", method, handler, type, pageXml, form, input_id, i + 1);
                            }
                            else
                            {
                                sb.AppendFormat("<a href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">{6}</a>", method, handler, type, pageXml, form, input_id, i + 1);
                            }
                        }
                    }

                    if (pageIndex >= pageCount)
                    {
                        sb.AppendFormat("<a class=\"disabled\" href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">下一页</a>", method, handler, type, downXml, form, input_id);
                        sb.AppendFormat("<a class=\"disabled\" href=\"javascript:{0}('{1}.ashx','{2}','<pageData><pageIndex>{3}</pageIndex><pageSize>{4}</pageSize></pageData>','{5}','{6}')\">末页</a>", method, handler, type, pageCount, pageSize, form, input_id);
                    }
                    else
                    {
                        sb.AppendFormat("<a href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">下一页</a>", method, handler, type, downXml, form, input_id);
                        sb.AppendFormat("<a href=\"javascript:{0}('{1}.ashx','{2}','<pageData><pageIndex>{3}</pageIndex><pageSize>{4}</pageSize></pageData>','{5}','{6}')\">末页</a>", method, handler, type, pageCount, pageSize, form, input_id);
                    }

                }
            }
            return sb.ToString();
        }
        #endregion

        #region 得到管理用户信息
        /// <summary>
        /// 方法说明：得到管理用户信息
        /// </summary>
        /// <param name="context">HttpContext对象</param>
        /// <returns>用户信息</returns>
        private tv_system_user GetInfo(HttpContext context)
        {
            tv_system_user info = new tv_system_user();
            //用户ID
            if (!string.IsNullOrEmpty(context.Request.Form["mid"]) && Convert.ToString(context.Request.Form["mid"]) != "")
            {
                info.Mid = Convert.ToString(context.Request.Form["mid"]);
            }
            //用户ID
            if (!string.IsNullOrEmpty(context.Request.Form["sys_code"]) && Convert.ToString(context.Request.Form["sys_code"]) != "")
            {
                info.Sys_code = Convert.ToInt32(context.Request.Form["sys_code"]);
            }
            //用户姓名
            if (!string.IsNullOrEmpty(context.Request.Form["sys_name"]) && Convert.ToString(context.Request.Form["sys_name"]) != "")
            {
                info.Sys_name = Convert.ToString(context.Request.Form["sys_name"]);
            }
            //级别名称
            if (Convert.ToString(context.Request.Form["system_level"]) != "9999")
            {
                info.System_level = Convert.ToInt32(context.Request.Form["system_level"]);
            }
            //登陆ID
            if (!string.IsNullOrEmpty(context.Request.Form["login_id"]) && Convert.ToString(context.Request.Form["login_id"]) != "")
            {
                info.Login_id = Convert.ToString(context.Request.Form["login_id"]);
            }
            //登陆密码
            if (!string.IsNullOrEmpty(context.Request.Form["login_pwd"]) && Convert.ToString(context.Request.Form["login_pwd"]) != "")
            {
                info.Login_pwd = Convert.ToString(context.Request.Form["login_pwd"]);
            }
            //手机号码
            if (!string.IsNullOrEmpty(context.Request.Form["sys_mobile"]) && Convert.ToString(context.Request.Form["sys_mobile"]) != "")
            {
                info.Sys_mobile = Convert.ToString(context.Request.Form["sys_mobile"]);
            }
            return info;
        }
        #endregion

        #region 保存修改信息
        /// <summary>
        /// 方法说明：保存修改信息
        /// </summary>
        /// <param name="context">HttpContext对象</param>
        private void SaveUpdateData(HttpContext context)
        {
            tv_system_user info = GetInfo(context);
            if (new tv_system_userManager().Add_Update(info, "update") == 1)
            {
                sbContextWrite.Append("OK");
            }
            else
            {
                sbContextWrite.Append("修改信息保存失败！");
            }
        }
        #endregion

        #region 新增管理员信息保存
        /// <summary>
        /// 方法说明：新增管理员信息保存
        /// </summary>
        /// <param name="context">The context.</param>
        private void SaveAddData(HttpContext context)
        {
            tv_system_user info = GetInfo(context);
            if (new tv_system_userManager().Add_Update(info, "add") == 1)
            {
                sbContextWrite.Append("OK");
            }
            else
            {
                sbContextWrite.Append("新增信息保存失败！");
            }
        }
        #endregion

        #region 加载权限信息HTML
        /// <summary>
        /// 方法说明：加载权限信息HTML
        /// </summary>
        private void InputCompetence_siteHTML()
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new tv_menuManager().Get_tv_menu(0);
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendFormat("<li><a class=\"nav-top-item\"><span class=\"nav-name\">{0}</span></a>", Convert.ToString(dt.Rows[i]["menu_name"]));
                    sb.Append("<ul class=\"ulul\">");
                    DataTable dt_1 = new tv_menuManager().Get_tv_menu(Convert.ToInt32(dt.Rows[i]["menu_id"]));
                    if (dt_1 != null && dt_1.Rows.Count != 0)
                    {
                        for (int j = 0; j < dt_1.Rows.Count; j++)
                        {
                            sb.Append("<li>");
                            sb.Append("<span class=\"allcheck\">");
                            sb.Append("<label>");
                            sb.AppendFormat("<input type=\"checkbox\" name=\"checkfunction\" value=\"{0}\" id=\"{1}\" onclick=\"CheckAll('{0}')\" />", Convert.ToString(dt_1.Rows[j]["menu_id"]), Convert.ToString(dt_1.Rows[j]["html_url"]));
                            sb.Append("</label>");
                            sb.Append("</span>");
                            sb.AppendFormat("<a class=\"nav-top-item\"><span class=\"nav-name\">{0}</span></a>", Convert.ToString(dt_1.Rows[j]["menu_name"]));
                            DataTable dt_2 = new tv_menuManager().Get_tv_menu(Convert.ToInt32(dt_1.Rows[j]["menu_id"]));
                            if (dt_2 != null && dt_2.Rows.Count != 0)
                            {
                                sb.AppendFormat("<ul style=\"display: block;\" id=\"li_{0}\">", Convert.ToInt32(dt_1.Rows[j]["menu_id"]));
                                for (int k = 0; k < dt_2.Rows.Count; k++)
                                {
                                    sb.Append("<li>");
                                    sb.AppendFormat("<label><input type=\"checkbox\" name=\"checkfunction\" value=\"{0}\" id=\"{1}\" />{2}</label>", Convert.ToString(dt_2.Rows[k]["menu_id"]), Convert.ToString(dt_2.Rows[k]["html_url"]), Convert.ToString(dt_2.Rows[k]["menu_name"]));
                                    sb.Append("</li>");
                                }
                                sb.Append("</ul>");
                            }

                            sb.Append("</li>");
                        }
                    }
                    sb.Append("</ul>");
                    sb.Append("</li>");
                }
            }
            sbContextWrite.Append(sb.ToString());
        }
        #endregion

        #region 按管理员ID得到其权限
        /// <summary>
        /// 方法说明：按管理员ID得到其权限
        /// </summary>
        /// <param name="xml">管理员ID</param>
        private void GetCompetence(string xml)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = tv_competenceManager.Instance.GetTv_competence(Convert.ToInt32(xml));
            if (dt != null && dt.Rows.Count != 0)
            {
                sb.Append("{'ids':[");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == dt.Rows.Count - 1)
                    {
                        sb.Append("{");
                        sb.AppendFormat("'id':'{0}'", Convert.ToString(dt.Rows[i]["menu_id"]));
                        sb.Append("}");
                    }
                    else
                    {
                        sb.Append("{");
                        sb.AppendFormat("'id':'{0}'", Convert.ToString(dt.Rows[i]["menu_id"]));
                        sb.Append("},");
                    }
                }
                sb.Append("]}");
            }
            sbContextWrite.Append(sb.ToString());
        }
        #endregion

        #region 保存管理权限
        /// <summary>
        /// 方法说明：保存管理权限
        /// </summary>
        /// <param name="context">HttpContext对象</param>
        /// <param name="xml">管理员ID</param>
        private void SaveCompetence(HttpContext context, string xml)
        {
            int error = 0;
            string[] id_array = Convert.ToString(context.Request.Form["checkfunction"]).Split(',');
            int del = tv_competenceManager.Instance.DeleteTv_competence(Convert.ToInt32(xml));
            tv_competence info = null;
            for (int i = 0; i < id_array.Length; i++)
            {
                info = new tv_competence();
                info.Sys_code = Convert.ToInt32(xml);
                info.Menu_id = Convert.ToInt32(id_array[i]);
                int result = tv_competenceManager.Instance.Add_Update(info, "add");
                if (result != 1)
                {
                    error += 1;
                }
            }
            if (error != 0)
            {
                sbContextWrite.Append("保存管理权限信息失败！");
                del = tv_competenceManager.Instance.DeleteTv_competence(Convert.ToInt32(xml));
            }
            else
            {
                sbContextWrite.Append("OK");
            }
        }
        #endregion
    }
}
