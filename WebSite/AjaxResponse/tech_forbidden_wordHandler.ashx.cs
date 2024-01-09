using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Model;
using BLL;
using Newtonsoft.Json;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_forbidden_wordHandler 的摘要说明
    /// </summary>
    public class tech_forbidden_wordHandler : PageBaseHandler
    {

        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
            requst = context.Request;
            response = context.Response;
            string type = requst.Params["type"];
            string xml = requst.Params["postvalue"];

            switch (type)
            {
                case "add":
                    add();
                    break;
                case "edit":
                    edit();
                    break;
                case "del":
                    del(xml);
                    break;
            }
        }

        private void del(string id)
        {
            tech_forbidden_word info = new tech_forbidden_word();
            info.id = int.Parse(id);
            int result = tech_forbidden_wordManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'删除失败！'}");
                return;
            }
        }

        private void edit()
        {
            tech_forbidden_word info = new tech_forbidden_word();
            info.id = int.Parse(requst.Form["id"].ToString());
            info.word = requst.Form["word"].ToString();
            int result = tech_forbidden_wordManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'更新失败！'}");
                return;
            }
        }

        private void add()
        {
            tech_forbidden_word info = new tech_forbidden_word();
            info.word = requst.Form["word"].ToString();
            int result = tech_forbidden_wordManager.Instance.Operation(info, "add");
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