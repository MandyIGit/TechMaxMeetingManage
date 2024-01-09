using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common;
using BLL;
using Model;

namespace WebSite.CommonPage
{
    public class PageBaseClass : Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!IsLogin)
            {
                string url = Request.Url.AbsoluteUri;
                Response.Redirect("/Admin/Login.aspx?url=" + url);
                CookieObj.Expires.AddDays(-1);
            }
            else
            {
                tech_admin adminInfo = tech_adminManager.Instance.Login(CookieObj["loginname"], CookieObj["loginpwd"]);
                if (adminInfo == null)
                {
                    Response.Redirect("/Admin/Login.aspx");
                    CookieObj.Expires.AddDays(-1);
                }
            }
        }

        /// <summary>
        /// 判断是否登录
        /// </summary>
        public bool IsLogin
        {
            get { return CookieObj != null; }
        }
        /// <summary>
        /// 获取表示当前登陆状态的Cookie对象
        /// </summary>
        protected virtual HttpCookie CookieObj
        {
            get { return Request.Cookies[WebCommon.ADMIN_KEY]; }
        }

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName
        {
            get
            {
                if (IsLogin) return this.CookieObj["loginname"];
                else return null;
            }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string LoginPwd
        {
            get
            {
                if (IsLogin) return this.CookieObj["loginpwd"];
                else return null;
            }
        }
        /// <summary>
        /// 用户id
        /// </summary>
        public string AdminCode
        {
            get
            {
                if (IsLogin) return this.CookieObj["admin_code"];
                else return null;
            }
        }
    }
}