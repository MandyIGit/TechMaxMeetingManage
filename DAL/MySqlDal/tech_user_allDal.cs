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
    public class tech_user_allDal : Itech_user_all
    {

        #region 得到部分查询条件SQL语句
        /// <summary>
        /// 方法说明：得到部分查询条件SQL语句
        /// 创建人员：Jacky
        /// 创建日期：2014/10/29 11:28
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>查询条件SQL语句</returns>
        private string GetSqlCondition(tech_user_all info)
        {
            StringBuilder sb = new StringBuilder();            
            if (!string.IsNullOrEmpty(info.Full_name))
            {
                sb.AppendFormat(" AND CONCAT(tua.family_name,tua.given_name) LIKE \"%{0}%\" ", info.Full_name);
            }           
            if (!string.IsNullOrEmpty(info.Mail))
            {
                sb.AppendFormat(" AND tua.mail=\"{0}\" ", info.Mail);
            }
            if (!string.IsNullOrEmpty(info.Mobile))
            {
                sb.AppendFormat(" AND tua.mobile=\"{0}\" ", info.Mobile);
            }
            if (info.User_code!=0)
            {
                sb.AppendFormat(" AND tua.user_code={0} ", info.User_code);
            }
            return sb.ToString();
        }
        #endregion

        public DataTable GetTech_user_all(tech_user_all info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT tua.user_code,tua.family_name,tua.given_name,CONCAT(tua.family_name,tua.given_name) AS full_name,tua.gender_title,tua.mail,tua.mobile,tp.province_name ");
            sb.Append(" ,CASE when tu.unitname is null THEN tua.unit_name ELSE tu.unitname end as unit_name,tua.offices ");
            sb.Append(" ,(SELECT COUNT(1) FROM tech_meeting_order WHERE user_code=tua.user_code AND isdel=2) AS order_count ");
            sb.Append(" FROM tech_user_all tua ");
            sb.Append(" LEFT JOIN tech_provincecode tp ON tp.province_id=tua.provinceid ");
            sb.Append(" LEFT JOIN tech_unit tu ON tu.unitid=tua.unitid ");
            sb.Append(" WHERE tua.isdel=2 ");
            sb.Append(GetSqlCondition(info));
            sb.Append(" ORDER BY tua.operatingtime DESC ");
            int index = info.PageIndex;
            if (index <= 0)
            {
                index = 1;
            }
            sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public int GetTech_user_all_count(tech_user_all info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT COUNT(1) ");
            sb.Append(" FROM tech_user_all tua ");
            sb.Append(" LEFT JOIN tech_provincecode tp ON tp.province_id=tua.provinceid ");
            sb.Append(" WHERE tua.isdel=2 ");
            sb.Append(GetSqlCondition(info));
            sb.Append(" ORDER BY tua.operatingtime DESC ");
            return Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
        }
    }
}
