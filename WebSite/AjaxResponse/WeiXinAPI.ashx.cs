using BLL;
using Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// WeiXinAPI 的摘要说明
    /// </summary>
    public class WeiXinAPI : IHttpHandler
    {

        HttpResponse response;
        HttpRequest request;
        public string GetAccess_Token()
        {
            if (string.IsNullOrEmpty(System.Web.HttpContext.Current.Application["Access_Token"].ToString()))
            {
                HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid=" + ConfigurationManager.AppSettings["AppID"] + "&secret=" + ConfigurationManager.AppSettings["AppSecret"]);
                HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
                if (Response.StatusCode == HttpStatusCode.OK)
                {
                    string strs = new StreamReader(Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                    System.Web.HttpContext.Current.Application["Access_Token"] = JObject.Parse(strs)["access_token"].ToString();
                }
                Response.Close();
                Response.Dispose();
            }
            return System.Web.HttpContext.Current.Application["Access_Token"].ToString();
        }
        public JToken GetOpenIDs(string Access_Token)
        {
            JToken OpenIDs = null;
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/user/get?access_token=" + Access_Token);
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                string strs = new StreamReader(Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                OpenIDs = JObject.Parse(strs)["data"]["openid"];
            }
            Response.Close();
            Response.Dispose();

            return OpenIDs;
        }

        public JToken GetOpenIDsByTag(string Access_Token, string Tag)
        {
            JToken OpenIDs = null;
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/user/tag/get?access_token=" + Access_Token);
            string JSONData = "{\"tagid\" : " + Tag + ", \"next_openid\":\"\" }";
            byte[] bytes = Encoding.UTF8.GetBytes(JSONData);
            Request.Method = "POST";
            Request.ContentLength = bytes.Length;
            Request.ContentType = "json";
            Stream reqstream = Request.GetRequestStream();
            reqstream.Write(bytes, 0, bytes.Length);
            Request.Timeout = 90000;
            Request.Headers.Set("Pragma", "no-cache");
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            Stream streamReceive = Response.GetResponseStream();

            if (Response.StatusCode == HttpStatusCode.OK)
            {
                string strs = new StreamReader(Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                OpenIDs = JObject.Parse(strs)["data"]["openid"];
            }
            Response.Close();
            Response.Dispose();

            return OpenIDs;
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            request = context.Request;
            response = context.Response;

            JToken OpenIDs = GetOpenIDsByTag(GetAccess_Token(), request.Params["tagGroup"]);
            //JToken OpenIDs = GetOpenIDs(GetAccess_Token());

            foreach (string OpenID in OpenIDs)
            {
                if (SendMessage(OpenID, GetAccess_Token()).Equals("41006"))
                {
                    System.Web.HttpContext.Current.Application["Access_Token"] = "";
                    SendMessage(OpenID, GetAccess_Token());
                }
            }

            tech_send_wx_message info = new tech_send_wx_message();

            info.keyword1 = request.Params["keyword1"].ToString();
            info.keyword2 = request.Params["keyword2"].ToString();
            info.keyword3 = request.Params["keyword3"].ToString();
            info.keyword4 = request.Params["keyword4"].ToString();
            info.keyword5 = request.Params["keyword5"].ToString();
            info.weburl = request.Params["weburl"].ToString();
            info.tagGroup = request.Params["tagGroup"].ToString();
            info.sendTime = DateTime.Now;

            tech_send_wx_messageManager.Instance.Operation(info, "add");

            context.Response.Write("OK");
        }

        public string SendMessage(string OpenID, string Access_Token)
        {
            string ErrCode = "";
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + Access_Token);

            string JSONData = "{\"touser\": \"" + OpenID + "\"," +
                "\"template_id\": \"" + ConfigurationManager.AppSettings["TemplateID"] + "\", " +
                "\"url\":\"" + request.Params["weburl"] + "\"," +
                "\"topcolor\": \"#FF0000\", " +
                "\"data\": " +
                "{\"first\": {\"value\": \"尊敬的老师，您好！会议即将召开，期待您的参与！\",\"color\":\"#7D7D7D\"}," +
                "\"keyword1\": { \"value\": \"" + request.Params["keyword1"] + "\",\"color\":\"#243378\"}," +
                "\"keyword2\": { \"value\": \"" + request.Params["keyword2"] + "\",\"color\":\"#243378\"}," +
                "\"keyword3\": { \"value\": \"" + request.Params["keyword3"] + "\",\"color\":\"#243378\"}," +
                "\"keyword4\": { \"value\": \"" + request.Params["keyword4"] + "\",\"color\":\"#243378\"}," +
                "\"keyword5\": { \"value\": \"" + request.Params["keyword5"] + "\",\"color\":\"#243378\" }}}";

            byte[] bytes = Encoding.UTF8.GetBytes(JSONData);
            Request.Method = "POST";
            Request.ContentLength = bytes.Length;
            Request.ContentType = "json";
            Stream reqstream = Request.GetRequestStream();
            reqstream.Write(bytes, 0, bytes.Length);
            Request.Timeout = 90000;
            Request.Headers.Set("Pragma", "no-cache");
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            Stream streamReceive = Response.GetResponseStream();
            if (Response.StatusCode == HttpStatusCode.OK)
            {
                string strs = new StreamReader(Response.GetResponseStream(), Encoding.UTF8).ReadToEnd();
                ErrCode = JObject.Parse(strs)["errcode"].ToString();
            }
            Response.Close();
            Response.Dispose();
            return ErrCode;

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}