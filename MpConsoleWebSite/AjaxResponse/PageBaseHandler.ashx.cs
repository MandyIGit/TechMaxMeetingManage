using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text;

namespace MpConsoleWebSite.AjaxResponse
{
    /// <summary>
    /// PageBaseHandler 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class PageBaseHandler : IHttpHandler
    {
        public StringBuilder sbContextWrite = null;
        HttpRequest requst;
        HttpResponse response;
        public void ProcessRequest(HttpContext context)
        {
            requst = context.Request;
            response = context.Response;
            if (context.Request.HttpMethod == "POST" || context.Request.HttpMethod == "GET")
            {

                if (!string.IsNullOrEmpty(context.Request.Params["type"]))
                {

                    GetData(context);
                    if (sbContextWrite != null)
                    {
                        //context.Request.ContentEncoding = Encoding.UTF8;
                        string ss = sbContextWrite.ToString();
                        context.Response.Write(sbContextWrite.ToString());
                        context.Response.End();
                    }
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
        public string UserId(string key)
        {

            if (requst.Cookies[key] != null) return requst.Cookies[key]["uid"];
            else return null;

        }

        #region 后台输出分页
        /// <summary>
        /// 方法说明：后台输出分页
        /// 创建人员：曲福岳
        /// 创建日期：2013/11/4 14:52
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
        /// <returns>分页</returns>
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
            sb.AppendFormat("<input type=\"hidden\" id=\"txtpageIndex\" name=\"txtpageIndex\" value=\"{0}\">", pageIndex);
            return sb.ToString();
        }
        #endregion

    }
}