using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using Wuqi.Webdiyer;

namespace WebSite.Admin.ForbiddenWord
{
    public partial class WordList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Binder(1,"");
            }
        }
        protected void Binder(int pageIndex,string word)
        {
            tech_forbidden_word info = new tech_forbidden_word();
            if (word != "")
            {
                info.word = word;
            }

            info.PageIndex = pageIndex;
            info.PageSize = 10;

            rpt_listNews.DataSource = tech_forbidden_wordManager.Instance.GetWord(info);
            rpt_listNews.DataBind();
            mypager.RecordCount = tech_forbidden_wordManager.Instance.Operation(info, "GetWordCount");
            mypager.PageSize = info.PageSize;
        }
        protected void mypager_PageChanged(object sender, EventArgs e)
        {
            Binder(mypager.CurrentPageIndex,"");
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_word.Text))
            {
                Binder(1, txt_word.Text);
            }
            else
            {
                Binder(1, "");
            }
        }
    }
}