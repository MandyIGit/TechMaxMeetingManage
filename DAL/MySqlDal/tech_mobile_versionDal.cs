using DBHelper;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.MySqlDal
{
    public class tech_mobile_versionDal : Itech_mobile_version
    {

        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_mobile_version info = (tech_mobile_version)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_mobile_version(v_name,sort,menu_type,inputtime) ");
                    sb.Append(" VALUES( ");

                    if (!string.IsNullOrEmpty(info.v_name))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.v_name);
                    }

                    if (info.sort>0)
                    {
                        sb.AppendFormat(" ,{0} ", info.sort);
                    }
                    else
                    {
                        sb.AppendFormat(" ,{0} ", 0);
                    }

                    if (info.menu_type > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.menu_type);
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
                    sb.Append("UPDATE tech_mobile_version SET isdel=2 ");
                    if (!string.IsNullOrEmpty(info.v_name))
                    {
                        sb.AppendFormat(" ,v_name=\"{0}\" ", info.v_name);
                    }                    
                    if (info.sort > 0)
                    {
                        sb.AppendFormat(" ,sort={0} ", info.sort);
                    }
                    if (info.menu_type > 0)
                    {
                        sb.AppendFormat(" ,menu_type={0} ", info.menu_type);
                    }
                    sb.AppendFormat(" WHERE v_id={0} ", info.v_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_mobile_version SET isdel=1 WHERE v_id={0} ", info.v_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "select_mobile_version_count":
                    #region 查询select_mobile_version_count信息
                    info = (tech_mobile_version)obj;
                    sb.Append("SELECT COUNT(*) FROM tech_mobile_version WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.v_name))
                    {
                        sb.AppendFormat(" AND v_name = \"{0}\" ", info.v_name);
                    }
                    sb.Append(" ORDER BY v_id ASC,sort ASC ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }

        public DataTable GetTech_mobile_version(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_mobile_version info = new tech_mobile_version();
            switch (type)
            {
                case "select_mobile_version_to_page":
                    #region 查询mobile_version信息（带分页）
                    info = (tech_mobile_version)obj;
                    sb.Append("SELECT * FROM tech_mobile_version WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.v_name))
                    {
                        sb.AppendFormat(" AND v_name = \"{0}\" ", info.v_name);
                    }
                    sb.Append(" ORDER BY v_id ASC,sort ASC ");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_mobile_version":
                    #region 查询mobile_version信息
                    info = (tech_mobile_version)obj;
                    sb.Append("SELECT * FROM tech_mobile_version WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.v_name))
                    {
                        sb.AppendFormat(" AND v_name = \"{0}\" ", info.v_name);
                    }
                    
                    sb.Append(" ORDER BY v_id ASC,sort ASC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public tech_mobile_version GetModelByVersonId(string v_id)
        {
            tech_mobile_version mobile_version = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_mobile_version where v_id={0} ", v_id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                mobile_version = MySQLHelper.ConvertTableToObject<tech_mobile_version>(dt)[0];
            }
            return mobile_version;
        }
    }
}
