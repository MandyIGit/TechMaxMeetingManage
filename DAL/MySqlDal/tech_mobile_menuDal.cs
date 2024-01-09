using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Model;
using IDAL;
using DBHelper;
using Common;

namespace DAL.MySqlDal
{
    public class tech_mobile_menuDal : Itech_mobile_menu
    {
        public int ModifyMenu(tech_mobile_menu menu)
        {
            StringBuilder sb = new StringBuilder();
            if (menu.Menu_id != 0 && menu.Menu_id < 10000)
            {
                sb.Append("update tech_mobile_menu set isdel=2");
                if (!string.IsNullOrEmpty(menu.Menu_name))
                {
                    sb.AppendFormat(" ,menu_name=\"{0}\" ", menu.Menu_name);
                }
                if (!string.IsNullOrEmpty(menu.Menu_icon) && menu.Menu_icon.Contains("&#"))
                {
                    sb.AppendFormat(" ,menu_icon=\"{0}\" ", menu.Menu_icon);
                }
                if (!string.IsNullOrEmpty(menu.Menu_url))
                {
                    sb.AppendFormat(" ,menu_url=\"{0}\" ", menu.Menu_url);
                }
                if (!string.IsNullOrEmpty(menu.Mid))
                {
                    sb.AppendFormat(" ,mid=\"{0}\" ", menu.Mid);
                }
                if (menu.Sort >= 0)
                {
                    sb.AppendFormat(" ,sort={0} ", menu.Sort);
                }
                sb.AppendFormat(" where menu_id={0}", menu.Menu_id);
            }
            else
            {
                if (!string.IsNullOrEmpty(menu.Menu_name))
                {
                    sb.Append("insert into tech_mobile_menu set ");
                    sb.AppendFormat("mid='{0}',menu_name='{1}',menu_icon='{2}',menu_url='{3}',sort={4},inputtime='{5}'", menu.Mid, menu.Menu_name, menu.Menu_icon, menu.Menu_url, menu.Sort, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                return Convert.ToInt32(MySQLHelper.ExecuteNonQuery(sb.ToString()));
            }
            else { return 0; }
        }

        public int Delete(int menuid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update tech_mobile_menu set isdel=1 where menu_id={0} ", menuid);
            return Convert.ToInt32(MySQLHelper.ExecuteNonQuery(sb.ToString()));
        }


        public int SetBanStatu(int menuid)
        {
            int statu = 0;
            tech_mobile_menu model = GetModel(menuid);
            if (model.Isban == 1) { statu = 2; }
            if (model.Isban == 2) { statu = 1; }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update tech_mobile_menu set isban={0}", statu);
            sb.AppendFormat(" where menu_id={0} ", model.Menu_id);
            return Convert.ToInt32(MySQLHelper.ExecuteNonQuery(sb.ToString()));
        }

        public IList<tech_mobile_menu> GetMenuList(string mid)
        {
            IList<tech_mobile_menu> list = new List<tech_mobile_menu>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tech_mobile_menu");
            sb.AppendFormat(" where mid='{0}'", mid);
            sb.Append(" and isdel=2");
            sb.Append(" order by sort");
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null)
            {
                list = MySQLHelper.ConvertTableToObject<tech_mobile_menu>(dt);
            }
            return list;
        }

        public tech_mobile_menu GetModel(int menuid)
        {
            tech_mobile_menu model = new tech_mobile_menu();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tech_mobile_menu ");
            sb.AppendFormat(" where menu_id={0} and isdel=2", menuid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                model = MySQLHelper.ConvertTableToObject<tech_mobile_menu>(dt)[0];
            }
            return model;
        }

        public tech_mobile_menu GetUpModel(int sort, string mid)
        {
            tech_mobile_menu model = new tech_mobile_menu();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM tech_mobile_menu ");
            sb.AppendFormat(" WHERE sort<{0} AND isdel=2 AND mid='{1}' ORDER BY sort DESC LIMIT 0,1", sort, mid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                model = MySQLHelper.ConvertTableToObject<tech_mobile_menu>(dt)[0];
            }
            return model;
        }

        public tech_mobile_menu GetDownModel(int sort, string mid)
        {
            tech_mobile_menu model = new tech_mobile_menu();
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM tech_mobile_menu ");
            sb.AppendFormat(" WHERE sort>{0} AND isdel=2 AND mid='{1}' ORDER BY sort LIMIT 0,1", sort, mid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                model = MySQLHelper.ConvertTableToObject<tech_mobile_menu>(dt)[0];
            }
            return model;
        }

    }
}
