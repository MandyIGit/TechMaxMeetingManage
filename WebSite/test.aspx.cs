using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSite
{
    public partial class test : System.Web.UI.Page
    {
        public string _result = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string _zimu = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";//要随机的字母
            Random _rand = new Random(); //随机类
            
            for (int i = 0; i < 6; i++) //循环6次，生成6位数字，10位就循环10次
            {
                _result += _zimu[_rand.Next(62)]; //通过索引下标随机
            }
            
        }
    }
}