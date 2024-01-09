using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using Model;
using System.Data;
using DBHelper;
using MySql.Data.MySqlClient;
using Common;

namespace DAL
{
    public class PagesDal
    {
        public DataTable GetSql(Pages pages)
        {
            //用于sqlserver
            //return SqlHelper.Table(string.Concat(new object[] { "Select ", " top ", (pages.Num), pages.Column, " From ", pages.Table, " where 1=1 ", pages.Where, " and ", pages.Prikey, " not in ", " ( ", " select top ", ((pages.Index - 1) * pages.Num), pages.Prikey, " From ", pages.Table, " where 1=1 ", pages.Where, " order by  ", pages.Orderby, " ) ", " order by  ", pages.Orderby }));

            //适用于mysql数据库
            return MySQLHelper.ExecuteDataTable(string.Concat(new object[] { "Select ", pages.Column, " From ", pages.Table, " where  1=1 ", pages.Where, "  order by   ", pages.Orderby, "  limit   ", pages.Num * (pages.Index - 1), ",", pages.Num }));
        }
        public int GetSql_Count(Pages pages)
        {
            return Convert.ToInt32(MySQLHelper.ExecuteScalar("Select count(*) From " + pages.Table + " where 1=1 " + pages.Where));
        }
    }
}
