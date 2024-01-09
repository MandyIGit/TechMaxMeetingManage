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
    public class tech_mobile_type_menuDal : Itech_mobile_type_menu
    {
        public IList<tech_mobile_type_menu> GetMenuList(string mtype_id)
        {
            IList<tech_mobile_type_menu> list = new List<tech_mobile_type_menu>();

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tech_mobile_type_menu");
            sb.AppendFormat(" where mtype_id='{0}'", mtype_id);
            sb.Append(" order by sort");
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null)
            {
                list = MySQLHelper.ConvertTableToObject<tech_mobile_type_menu>(dt);
            }
            return list;
        }

        public int ModifyMenu(tech_mobile_type_menu menu)
        {
            StringBuilder sb = new StringBuilder();
            if (menu.menu_id != 0 && menu.menu_id < 10000)
            {
                sb.AppendFormat("update tech_mobile_type_menu set mtype_id={0}", menu.mtype_id);
                if (!string.IsNullOrEmpty(menu.menu_name))
                {
                    sb.AppendFormat(" ,menu_name=\"{0}\" ", menu.menu_name);
                }
                if (!string.IsNullOrEmpty(menu.menu_icon) && menu.menu_icon.Contains("&#"))
                {
                    sb.AppendFormat(" ,menu_icon=\"{0}\" ", menu.menu_icon);
                }
                if (!string.IsNullOrEmpty(menu.menu_url))
                {
                    sb.AppendFormat(" ,menu_url=\"{0}\" ", menu.menu_url);
                }
                if (menu.sort > 0)
                {
                    sb.AppendFormat(" ,sort={0} ", menu.sort);
                }
                sb.AppendFormat(" where menu_id={0}", menu.menu_id);
            }
            else
            {
                if (!string.IsNullOrEmpty(menu.menu_name))
                {
                    sb.Append("insert into tech_mobile_type_menu set ");
                    sb.AppendFormat("mtype_id={0},menu_name='{1}',menu_icon='{2}',menu_url='{3}',sort={4}", menu.mtype_id, menu.menu_name, menu.menu_icon, menu.menu_url, menu.sort);
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
            sb.AppendFormat("DELETE FROM tech_mobile_type_menu where menu_id={0} ", menuid);
            return Convert.ToInt32(MySQLHelper.ExecuteNonQuery(sb.ToString()));
        }

        public tech_mobile_type_menu GetModel(int menuid)
        {
            tech_mobile_type_menu model = new tech_mobile_type_menu();
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tech_mobile_type_menu ");
            sb.AppendFormat(" where menu_id={0}", menuid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                model = MySQLHelper.ConvertTableToObject<tech_mobile_type_menu>(dt)[0];
            }
            return model;
        }
    }
}
