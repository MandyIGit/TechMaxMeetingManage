using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

namespace WebSite.Admin.TechUserAllPage
{
    public partial class meeting_order_list : System.Web.UI.Page
    {
        public string user_code = "", full_name = "", gender_title = "", province_name = "", unit_name = "", offices = "";
        public string order_id = "", ying_shou = "", yi_shou = "", mid = "", mname = "", address = "", begindate = "", enddate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userid"]))
            {
                user_code = Request.QueryString["userid"];

                tech_user_all user = new tech_user_all();
                user.User_code = int.Parse(user_code);
                user.PageSize = 1;
                DataTable dt_user = tech_user_allManager.Instance.GetTech_user_all(user);
                if (dt_user.Rows.Count > 0)
                {
                    full_name = dt_user.Rows[0]["family_name"].ToString() + dt_user.Rows[0]["given_name"].ToString();
                    gender_title = dt_user.Rows[0]["gender_title"].ToString();
                    province_name = dt_user.Rows[0]["province_name"].ToString();
                    unit_name = dt_user.Rows[0]["unit_name"].ToString();
                    offices = dt_user.Rows[0]["offices"].ToString();
                }

                DataTable dt_order = tech_meeting_orderManager.Instance.GetTech_meeting_order(user_code);
                rpt_orders.DataSource = dt_order;
                rpt_orders.DataBind();
            }            
        }
    }
}