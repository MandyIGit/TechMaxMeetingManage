using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Common;
using Model;
using System.Data;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_html_template_listHandler 的摘要说明
    /// </summary>
    public class tech_html_template_listHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;
        protected override void GetData(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            requst = context.Request;
            response = context.Response;
            string type = requst.QueryString["type"];
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
            }
        }

        private void Del()
        {
            tech_html_template_list info = new tech_html_template_list();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.Tm_id = requst.QueryString["id"].ToString();
            }

            int result = tech_html_template_listManager.Instance.Operation(info, "del");

            if (result > 0)
            {
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
            tech_html_template_list info = new tech_html_template_list();

            if (requst.Form["tm_id"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'模板编码不能为空！'}");
                return;
            }
            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["tm_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'模板名称不能为空！'}");
                return;
            }
            if (requst.Form["first_content"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'一级页面内容信息不能为空！'}");
                return;
            }
            if (requst.Form["second_content"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'二级页面内容信息不能为空！'}");
                return;
            }

            info.Mid = requst.Form["mid"].ToString();
            info.Tm_id = requst.Form["tm_id"].ToString();
            info.Tm_name = requst.Form["tm_name"].ToString();
            info.Tm_img = requst.Form["tm_img"].ToString();
            info.Tm_type = requst.Form["tm_type"].ToString();
            info.Tm_css = requst.Form["tm_css"].ToString();
            info.First_content = TechMaxClass.Compress(requst.Form["first_content"].ToString());
            info.En_first_content = TechMaxClass.Compress(requst.Form["en_first_content"].ToString());
            info.Second_content = TechMaxClass.Compress(requst.Form["second_content"].ToString());
            info.En_second_content = TechMaxClass.Compress(requst.Form["en_second_content"].ToString());
            info.Third_content = TechMaxClass.Compress(requst.Form["third_content"].ToString());
            info.En_third_content = TechMaxClass.Compress(requst.Form["en_third_content"].ToString());
            info.Person_content = TechMaxClass.Compress(requst.Form["person_content"].ToString());
            info.En_person_content = TechMaxClass.Compress(requst.Form["en_person_content"].ToString());

            int result = tech_html_template_listManager.Instance.Operation(info, "edit");

            if (result > 0)
            {
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
            tech_html_template_list info = new tech_html_template_list();

            if (requst.Form["tm_id"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'模板编码不能为空！'}");
                return;
            }
            if (requst.Form["mid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'会议编码不能为空！'}");
                return;
            }
            if (requst.Form["tm_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'模板名称不能为空！'}");
                return;
            }
            if (requst.Form["tm_img"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'模板缩略图地址不能为空！'}");
                return;
            }
            if (requst.Form["first_content"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'一级页面内容信息不能为空！'}");
                return;
            }
            if (requst.Form["second_content"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'二级页面内容信息不能为空！'}");
                return;
            }

            info.Mid = requst.Form["mid"].ToString();
            info.Tm_id = requst.Form["tm_id"].ToString();
            info.Tm_name = requst.Form["tm_name"].ToString();
            info.Tm_img = requst.Form["tm_img"].ToString();
            info.Tm_type = requst.Form["tm_type"].ToString();
            info.Tm_css = requst.Form["tm_css"].ToString();
            info.First_content = TechMaxClass.Compress(requst.Form["first_content"].ToString());
            info.En_first_content = TechMaxClass.Compress(requst.Form["en_first_content"].ToString());
            info.Second_content = TechMaxClass.Compress(requst.Form["second_content"].ToString());
            info.En_second_content = TechMaxClass.Compress(requst.Form["en_second_content"].ToString());
            info.Third_content = TechMaxClass.Compress(requst.Form["third_content"].ToString());
            info.En_third_content = TechMaxClass.Compress(requst.Form["en_third_content"].ToString());
            info.Person_content = TechMaxClass.Compress(requst.Form["person_content"].ToString());
            info.En_person_content = TechMaxClass.Compress(requst.Form["en_person_content"].ToString());

            int result = tech_html_template_listManager.Instance.Operation(info, "add");

            if (result > 0)
            {
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