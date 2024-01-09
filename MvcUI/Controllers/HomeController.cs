using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL;
using Common;
using Model;


namespace MvcUI.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        NewsManager bll = new NewsManager();

        int pageSize = 2;

        public ActionResult Index()
        {
            News info = new News() { };
            List<News> lst = bll.GetNewsList(info,1,pageSize);
            return View(lst);
        }

    }
}
