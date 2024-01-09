using DBHelper;
using IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.MySqlDal
{
    public class tv_menuDal : Itv_menu
    {
        public DataTable Get_tv_menu(int menu_id, int sys_code)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT tm.menu_id,tm.menu_name,tm.pid,tm.html_url,tm.sort_id,tm.isdel,tm.inputtime ");
            sb.Append(" FROM tv_menu tm ");
            sb.Append(" LEFT JOIN tv_competence tc ON tc.menu_id = tm.menu_id ");
            sb.AppendFormat(" WHERE tm.isdel = 2 AND tm.pid = {0} ", menu_id);
            if (menu_id != 0)
            {
                sb.AppendFormat(" AND tc.sys_code = {0} ", sys_code);
            }
            sb.Append(" ORDER BY tm.sort_id ASC,tm.menu_id ASC ");
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public DataTable Get_tv_menu(int menu_id)
        {
            string sql = "SELECT * FROM tv_menu WHERE isdel = 2 AND pid = " + menu_id + " ORDER BY sort_id ASC,menu_id ASC ";
            return MySQLHelper.ExecuteDataTable(sql);
        }

        public DataTable GetTv_menu(int sys_code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT tm.html_url ");
            sb.Append(" FROM tv_menu tm ");
            sb.Append(" LEFT JOIN tv_competence tc ON tc.menu_id = tm.menu_id ");
            sb.Append(" WHERE tm.isdel = 2 ");
            sb.AppendFormat(" AND tc.sys_code = {0} ", sys_code);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }
    }
}
