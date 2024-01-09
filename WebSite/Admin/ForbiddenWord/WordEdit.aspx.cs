using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite.Admin.ForbiddenWord
{
    public partial class WordEdit : System.Web.UI.Page
    {
        protected string id = "", page = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder();
            }
        }

        private void Binder()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Request.QueryString["id"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Request.QueryString["page"].ToString();
            }
            tech_forbidden_word info = tech_forbidden_wordManager.Instance.GetWordByID(id);
            txt_word.Text = info.word;            
        }
    }
}