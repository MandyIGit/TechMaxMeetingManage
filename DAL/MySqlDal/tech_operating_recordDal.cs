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
    public class tech_operating_recordDal : Itech_operating_record
    {
        private string mid = Common.ConfigHelper.GetConfigString("Mcode");
        private string mtype_id = Common.ConfigHelper.GetConfigString("MType");

        public int Operating(tech_operating_record info, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            switch (type)
            {
                case "add_msg":  //添加操作记录信息
                    #region 添加操作记录信息
                    sb.Append(" INSERT INTO tech_operating_record(record_content,operating_user,admin_code,operating_time,ip_addr,host_name,mid,mtype_id) ");
                    sb.AppendFormat(" VALUES(\"{0}\",\"{1}\",{2},\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\") ", info.Record_content, info.Operating_user, info.Admin_code, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), info.IP_Addr, info.Host_name, mid, mtype_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "add_msg_diy":  //添加操作记录信息
                    #region 添加操作记录信息
                    sb.Append(" INSERT INTO tech_operating_record(record_content,operating_user,admin_code,operating_time,ip_addr,host_name,mid,mtype_id) ");
                    sb.AppendFormat(" VALUES(\"{0}\",\"{1}\",{2},\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\") ", info.Record_content, info.Operating_user, info.Admin_code, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), info.IP_Addr, info.Host_name, info.Mid, info.Mtype_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "get_operation_count":  //得到当前会议所有操作信息条数
                    #region 得到当前会议所有操作信息条数
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_operating_record tor ");
                    sb.AppendFormat(" WHERE tor.mid=\"{0}\" AND tor.mtype_id=\"{1}\" ", mid, mtype_id);
                    if (info.Admin_code > 0)
                    {
                        sb.AppendFormat(" AND tor.admin_code={0} ", info.Admin_code);
                    }
                    if (!string.IsNullOrWhiteSpace(info.Operating_user))
                    {
                        sb.AppendFormat(" AND tor.Operating_user LIKE \"%{0}%\" ", info.Operating_user);
                    }
                    if (!string.IsNullOrWhiteSpace(info.Record_content))
                    {
                        sb.AppendFormat(" AND tor.Record_content LIKE \"%{0}%\" ", info.Record_content);
                    }
                    if (!string.IsNullOrWhiteSpace(info.operating_time_start) && !string.IsNullOrWhiteSpace(info.operating_time_end))
                    {
                        sb.AppendFormat(" AND tor.operating_time BETWEEN '{0}' AND '{1}' ", info.operating_time_start, info.operating_time_end);
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;

                case "get_operation_count_all":  //得到当前会议所有操作信息条数
                    #region 得到当前会议所有操作信息条数
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_operating_record tor ");
                    sb.Append(" WHERE 1=1 ");
                    if (info.Admin_code > 0)
                    {
                        sb.AppendFormat(" AND tor.admin_code={0} ", info.Admin_code);
                    }
                    if (!string.IsNullOrWhiteSpace(info.Operating_user))
                    {
                        sb.AppendFormat(" AND tor.Operating_user LIKE \"%{0}%\" ", info.Operating_user);
                    }
                    if (!string.IsNullOrWhiteSpace(info.Record_content))
                    {
                        sb.AppendFormat(" AND tor.Record_content LIKE \"%{0}%\" ", info.Record_content);
                    }
                    if (!string.IsNullOrWhiteSpace(info.operating_time_start) && !string.IsNullOrWhiteSpace(info.operating_time_end))
                    {
                        sb.AppendFormat(" AND tor.operating_time BETWEEN '{0}' AND '{1}' ", info.operating_time_start, info.operating_time_end);
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }

        public DataTable GetTech_operation_record(Object obj, string type)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = new DataTable();
            tech_operating_record info = new tech_operating_record();
            switch (type)
            {
                case "select_msg_to_page":  //查询管理员操作信息（带分页）
                    #region 查询管理员操作信息（带分页）
                    info = (tech_operating_record)obj;
                    sb.Append(" SELECT tor.id,tor.admin_code,tor.record_content,tor.operating_user,tor.operating_time,tor.ip_addr,tor.host_name ");
                    sb.Append(" FROM tech_operating_record tor ");
                    sb.AppendFormat(" WHERE tor.mid=\"{0}\" AND tor.mtype_id=\"{1}\" ", mid, mtype_id);
                    
                    if (info.Admin_code > 0)
                    {
                        sb.AppendFormat(" AND tor.admin_code={0} ", info.Admin_code);
                    }
                    if (!string.IsNullOrWhiteSpace(info.Operating_user))
                    {
                        sb.AppendFormat(" AND tor.Operating_user LIKE \"%{0}%\" ", info.Operating_user);
                    }
                    if (!string.IsNullOrWhiteSpace(info.Record_content))
                    {
                        sb.AppendFormat(" AND tor.Record_content LIKE \"%{0}%\" ", info.Record_content);
                    }
                    if(!string.IsNullOrWhiteSpace(info.operating_time_start) && !string.IsNullOrWhiteSpace(info.operating_time_end))
                    {
                        sb.AppendFormat(" AND tor.operating_time BETWEEN '{0}' AND '{1}' ", info.operating_time_start, info.operating_time_end);
                    }

                    sb.Append(" ORDER BY tor.operating_time DESC ");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_msg_to_page_all":  //查询管理员操作信息（带分页）
                    #region 查询管理员操作信息（带分页）
                    info = (tech_operating_record)obj;
                    sb.Append(" SELECT tor.id,tor.admin_code,tor.record_content,tor.operating_user,tor.operating_time,tor.ip_addr,tor.host_name,tor.mid,tor.mtype_id ");
                    sb.Append(" FROM tech_operating_record tor ");
                    sb.AppendFormat(" WHERE 1=1 ");

                    if (info.Admin_code > 0)
                    {
                        sb.AppendFormat(" AND tor.admin_code={0} ", info.Admin_code);
                    }
                    if (!string.IsNullOrWhiteSpace(info.Operating_user))
                    {
                        sb.AppendFormat(" AND tor.Operating_user LIKE \"%{0}%\" ", info.Operating_user);
                    }
                    if (!string.IsNullOrWhiteSpace(info.Record_content))
                    {
                        sb.AppendFormat(" AND tor.Record_content LIKE \"%{0}%\" ", info.Record_content);
                    }
                    if (!string.IsNullOrWhiteSpace(info.operating_time_start) && !string.IsNullOrWhiteSpace(info.operating_time_end))
                    {
                        sb.AppendFormat(" AND tor.operating_time BETWEEN '{0}' AND '{1}'  ", info.operating_time_start, info.operating_time_end);
                    }

                    sb.Append(" ORDER BY tor.operating_time DESC ");
                    index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }
    }
}
