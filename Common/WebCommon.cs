using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace Common
{
    public class WebCommon
    {

        /// <summary>
        /// 用户标记
        /// </summary>

        ///后台管理员登录标记
        public const string ADMIN_KEY = "ADMIN";
        public const string MOBLIE_KEY = "MOBILE";
        public const string MEETING_KEY = "MEETING";
        public const string MANAGER_KEY = "MANAGER";

        /// <summary>
        /// 设置SESSION
        /// </summary>
        /// <param name="key"></param>
        /// <param name="so"></param>
        public static void SetSession(string key, SeesionObject so)
        {
            HttpContext.Current.Session[key] = so;
            HttpContext.Current.Session.Timeout = 30;
        }

        public static void SetCookie(string key, string value)
        {
            HttpCookie model = new HttpCookie(key);
            model.Values["mobile"] = value;

            model.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.AppendCookie(model);
        }

        public static void SetMeetingCookie(string key, string mid, string mtype_id)
        {
            HttpCookie model = new HttpCookie(key);
            model.Values["mid"] = mid;
            model.Values["mtype_id"] = mtype_id;
            model.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.AppendCookie(model);
        }

        public static void SetMeetingCookie(string key, string mid, string sys_code, string login_id, string login_pwd)
        {
            HttpCookie model = new HttpCookie(key);
            model.Values["mid"] = mid;
            model.Values["sys_code"] = sys_code;
            model.Values["login_id"] = login_id;
            model.Values["login_pwd"] = login_pwd;
            model.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.AppendCookie(model);
        }

        public static void SetManagerCookie(string key, string manager_id, string full_name, string login_name, string login_pwd, string mobile)
        {
            HttpCookie model = new HttpCookie(key);
            model.Values["manager_id"] = manager_id;
            model.Values["full_name"] = full_name;
            model.Values["login_name"] = login_name;
            model.Values["login_pwd"] = login_pwd;
            model.Values["mobile"] = mobile;

            model.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.AppendCookie(model);
        }

        /// <summary>
        /// 设置Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="admin_type"></param>
        /// <param name="loginname"></param>
        /// <param name="loginpwd"></param>
        /// <param name="admin_code"></param>
        /// <param name="mtype_id"></param>
        /// <param name="mid"></param>
        public static void SetCookie(string key, string admin_type, string admin_name, string loginname, string loginpwd, string admin_code)
        {
            HttpCookie model = new HttpCookie(key);
            model.Values["admin_type"] = admin_type;
            model.Values["admin_name"] = admin_name;
            model.Values["loginname"] = loginname;
            model.Values["loginpwd"] = loginpwd;
            model.Values["admin_code"] = admin_code;

            model.Expires = DateTime.Now.AddDays(1);
            HttpContext.Current.Response.AppendCookie(model);
        }

        public static void SetCookieIstate(string cookname, string cookvalue)
        {
            HttpCookie httpCookie = new HttpCookie(cookname);
            httpCookie.Value = cookvalue;
            httpCookie.Expires = DateTime.Now.AddDays(1);
            System.Web.HttpContext.Current.Response.Cookies.Add(httpCookie);
        }

        public static string GetCookie(string cookname, int i)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookname];
            return cookie.Value.Split('&')[i];
        }

        public static string GetCookieIstate(string cookname)
        {
            string values = "";
            if (System.Web.HttpContext.Current.Request.Cookies[cookname] != null)
                values = HttpUtility.UrlDecode(System.Web.HttpContext.Current.Request.Cookies[cookname].Value);
            return values;
        }
        /// <summary>
        /// 删除cookie
        /// </summary>
        public static void RemoveCookie(string key)
        {
            HttpCookie model = new HttpCookie(key);
            model.Expires = DateTime.Now.AddHours(-1);
            HttpContext.Current.Response.AppendCookie(model);
        }

        public static void RemoveCookieIstate(string cookieName)
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Values.Clear();
                cookie.Expires = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).AddDays(0);
                //     Response.Cookies.Add(cookie);
                System.Web.HttpContext.Current.Response.Cookies.Set(cookie);
            }
        }

        public static void RemoveAllCookie()
        {
            //RemoveCookie(WebCommon.ENTERPRICE_KEY);
            //RemoveCookie(WebCommon.USER_KEY);

            HttpCookie aCookie;
            string cookieName;
            int limit = System.Web.HttpContext.Current.Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = System.Web.HttpContext.Current.Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.AppendCookie(aCookie);
            }
        }
    }
}
