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
    public class tech_mobile_typeDal : Itech_mobile_type
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_mobile_type info = (tech_mobile_type)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_mobile_type(mtype_name,mtype_memo,pid,sort,inputtime) ");
                    sb.Append(" VALUES( ");

                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Mtype_name);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_memo))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Mtype_memo);
                    }
                    if (info.Pid>0)
                    {
                        sb.AppendFormat(" ,{0} ", info.Pid);
                    }
                    else
                    {
                        sb.AppendFormat(" ,{0} ", 0);
                    }
                    if (info.Sort > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.Sort);
                    }
                    else
                    {
                        sb.AppendFormat(" ,{0} ", 0);
                    }
                    sb.AppendFormat(" ,\"{0}\" );select @@IDENTITY; ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    object okey = MySQLHelper.ExecuteScalar(sb.ToString());
                    if (okey != null)//如果插入成功，则返回主键
                        result = Convert.ToInt32(okey.ToString());
                    else
                        result = 0;
                    #endregion
                    break;

                case "edit":
                    #region edit
                    sb.Append("UPDATE tech_mobile_type SET isdel=2 ");
                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" ,mtype_name=\"{0}\" ", info.Mtype_name);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_memo))
                    {
                        sb.AppendFormat(" ,mtype_memo=\"{0}\" ", info.Mtype_memo);
                    }
                    if (info.Pid > 0)
                    {
                        sb.AppendFormat(" ,pid={0} ", info.Pid);
                    }
                    else
                    {
                        sb.AppendFormat(" ,pid={0} ", 0);
                    }
                    if (info.Sort > 0)
                    {
                        sb.AppendFormat(" ,sort={0} ", info.Sort);
                    }
                    else
                    {
                        sb.AppendFormat(" ,sort={0} ", 0);
                    }
                    sb.AppendFormat(" WHERE mtype_id={0} ", info.Mtype_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_mobile_type SET isdel=1 WHERE mtype_id={0} ", info.Mtype_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "select_mobile_type_count":
                    #region 查询select_mobile_type_count信息
                    info = (tech_mobile_type)obj;
                    sb.Append("SELECT COUNT(*) FROM tech_mobile_type WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" AND mtype_name LIKE \"%{0}%\" ", info.Mtype_name);
                    }
                    if (info.Pid > 0)
                    {
                        sb.AppendFormat(" AND pid = {0} ", info.Pid);
                    }
                    else
                    {
                        sb.AppendFormat(" AND pid = {0} ", 0);
                    }
                    sb.Append(" ORDER BY mtype_id ASC,sort ASC ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }

        public DataTable GetTech_mobile_type(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_mobile_type info = new tech_mobile_type();
            switch (type)
            {
                case "select_mobile_type_to_page":
                    #region 查询mobile_type信息（带分页）
                    info = (tech_mobile_type)obj;
                    sb.Append("SELECT * FROM tech_mobile_type WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" AND mtype_name LIKE \"%{0}%\" ", info.Mtype_name);
                    }
                    if (info.Pid > 0)
                    {
                        sb.AppendFormat(" AND pid = {0} ", info.Pid);
                    }
                    else
                    {
                        sb.AppendFormat(" AND pid = {0} ", 0);
                    }
                    sb.Append(" ORDER BY mtype_id ASC,sort ASC ");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_mobile_type":
                    #region 查询mobile_type信息
                    info = (tech_mobile_type)obj;
                    sb.Append("SELECT * FROM tech_mobile_type WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" AND mtype_name LIKE \"%{0}%\" ", info.Mtype_name);
                    }
                    if (info.Pid > 0)
                    {
                        sb.AppendFormat(" AND pid = {0} ", info.Pid);
                    }
                    else
                    {
                        sb.AppendFormat(" AND pid = {0} ", 0);
                    }
                    sb.Append(" ORDER BY mtype_id ASC,sort ASC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public tech_mobile_type GetModelByTypeId(string type_id)
        {
            tech_mobile_type mobile_type = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_mobile_type where mtype_id={0} ", type_id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                mobile_type = MySQLHelper.ConvertTableToObject<tech_mobile_type>(dt)[0];
            }
            return mobile_type;
        }
    }
}
