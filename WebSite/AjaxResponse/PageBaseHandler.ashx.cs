using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using Common;
using Model;
using BLL;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// PageBaseHandler 的摘要说明
    /// </summary>
    public class PageBaseHandler : IHttpHandler
    {
        HttpRequest requst;
        HttpResponse response;
        private string mid = Common.ConfigHelper.GetConfigString("Mcode");
        private string mtype_id = Common.ConfigHelper.GetConfigString("MType");

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            requst = context.Request;
            response = context.Response;

            if (context.Request.HttpMethod == "POST" || context.Request.HttpMethod == "GET")
            {

                if (!string.IsNullOrEmpty(context.Request.Params["type"]))
                {
                    //if (WebCommon.GetCookieIstate(WebCommon.ADMIN_KEY) == "")
                    //{
                    //    response.Redirect("/Admin/Login.aspx");
                    //}
                    GetData(context);
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        protected virtual void GetData(HttpContext context)
        {

        }

        #region 后台输出分页
        /// <summary>
        /// 方法说明：后台输出分页
        /// 创建人员：Jacky
        /// 创建日期：2015/12/14
        /// 修改日期：
        /// </summary>
        /// <param name="pageCount">所有记录数</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <param name="method">JS方法名称</param>
        /// <param name="handler">Handler名称</param>
        /// <param name="type">类型ID</param>
        /// <param name="form">页面formID</param>
        /// <param name="input_id">输出的标签ID</param>
        /// <returns>分页标签</returns>
        public string Page(int pageCount, int pageIndex, int pageSize, string method, string handler, int type, string form, string input_id)
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
                                    sb.AppendFormat("<a id=\"page_{6}\" href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">{6}</a>", method, handler, type, pageXml, form, input_id, i + 1);
                                }
                                else
                                {
                                    sb.AppendFormat("<a id=\"page_{6}\" href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">{6}</a>", method, handler, type, pageXml, form, input_id, i + 1);
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
                                sb.AppendFormat("<a id=\"page_{6}\" href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">{6}</a>", method, handler, type, pageXml, form, input_id, i + 1);
                            }
                            else
                            {
                                sb.AppendFormat("<a id=\"page_{6}\" href=\"javascript:{0}('{1}.ashx','{2}','{3}','{4}','{5}')\">{6}</a>", method, handler, type, pageXml, form, input_id, i + 1);
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
            sb.AppendFormat("<input type=\"hidden\" id=\"txtpageIndex\" name=\"txtpageIndex\" value=\"{0}\">", pageIndex);
            sb.Append("<script type=\"text/javascript\">");
            sb.Append("$('.fenye a').each(function(){$(this).removeClass('ahover');});");
            sb.AppendFormat("$('#page_{0}').addClass('ahover');", pageIndex);
            //sb.Append("window.location.hash = \"#index_body\";");
            sb.Append("window.parent.location.hash = \"#index_body\";");
            sb.Append("</script>");
            return sb.ToString();
        }
        #endregion

        protected void operating_record(string content)
        {            
            string admin_code = WebCommon.GetCookie(WebCommon.ADMIN_KEY, 4).Split('=')[1];
            string admin_name = WebCommon.GetCookie(WebCommon.ADMIN_KEY, 2).Split('=')[1];
            tech_operating_record operating_record = new tech_operating_record();
            operating_record.Admin_code = int.Parse(admin_code);
            operating_record.Operating_user = admin_name;
            operating_record.Record_content = content;
            operating_record.IP_Addr = requst.ServerVariables.Get("Remote_Addr").ToString();
            operating_record.Host_name = requst.ServerVariables.Get("Remote_Host").ToString();
            operating_record.Mid = mid;
            operating_record.Mtype_id = mtype_id;
            tech_operating_recordManager.Instance.Operating(operating_record, "add_msg");
        }
    }
}