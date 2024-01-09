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
    public class tech_task_listDal : Itech_task_list
    {
        public DataTable GetTech_task_list_by_name(tech_task_list info, int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM tech_task_list ");
            sb.AppendFormat(" WHERE mid='{0}' AND mtype_id='{1}' ", info.mid, info.mtype_id);

            if (!string.IsNullOrEmpty(info.full_name))
            {
                sb.AppendFormat(" AND full_name = '{0}' ", info.full_name);
            }
            if (info.begin_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                sb.AppendFormat(" AND begin_time >= '{0}' ", info.begin_time);
            }
            if (info.end_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                sb.AppendFormat(" AND end_time <= '{0}' ", info.end_time);
            }
            int index = pageIndex;
            if (index <= 0)
            {
                index = 1;
            }
            sb.Append(" ORDER BY begin_time ASC  ");
            sb.AppendFormat(" LIMIT {0},{1} ", (index - 1) * pageSize, pageSize);

            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public DataTable GetTech_task_list(tech_task_list info, int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM tech_task_list ");
            sb.AppendFormat(" WHERE mid='{0}' AND mtype_id='{1}' ", info.mid, info.mtype_id);

            if (!string.IsNullOrEmpty(info.full_name))
            {
                sb.AppendFormat(" AND full_name = '{0}' ", info.full_name);
            }
            if (info.begin_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                sb.AppendFormat(" AND begin_time >= '{0}' ", info.begin_time);
            }
            if (info.end_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                sb.AppendFormat(" AND end_time <= '{0}' ", info.end_time);
            }
            int index = pageIndex;
            if (index <= 0)
            {
                index = 1;
            }
            sb.Append(" ORDER BY begin_time ASC  ");
            sb.AppendFormat(" LIMIT {0},{1} ", (index - 1) * pageSize, pageSize);

            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public DataTable GetTech_task_list(tech_task_list info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM tech_task_list ");
            sb.AppendFormat(" WHERE mid='{0}' AND mtype_id='{1}' ", info.mid, info.mtype_id);
            if (!string.IsNullOrEmpty(info.full_name))
            {
                sb.AppendFormat(" AND full_name = '{0}' ", info.full_name);
            }
            if (info.begin_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                sb.AppendFormat(" AND begin_time >= '{0}' ", info.begin_time);
            }
            if (info.end_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                sb.AppendFormat(" AND end_time <= '{0}' ", info.end_time);
            }
            sb.Append(" ORDER BY begin_time ASC  ");
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public DataTable GetTech_task_list(tech_task_list info, string type)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = null;
            switch (type)
            {
                case "select_having":
                    #region 查询专家大于1个任务的数据
                    sb.Append(" SELECT full_name,count(full_name) AS count FROM tech_task_list ");
                    sb.AppendFormat(" WHERE mid='{0}' AND mtype_id='{1}' ", info.mid, info.mtype_id);
                    if (!string.IsNullOrEmpty(info.full_name))
                    {
                        sb.AppendFormat(" AND full_name='{0}' ", info.full_name);
                    }
                    sb.Append(" GROUP BY full_name HAVING count>1");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }

            return dt;
        }

        public tech_task_list GetModel(string id)
        {
            tech_task_list model = new tech_task_list();
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM tech_task_list ");
            sb.AppendFormat(" WHERE id={0} ", id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return MySQLHelper.ConvertTableToObject<tech_task_list>(dt).Count > 0 ? MySQLHelper.ConvertTableToObject<tech_task_list>(dt)[0] : model;
        }

        public int GetTech_task_list_count(tech_task_list info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT COUNT(1) ");
            sb.Append(" FROM tech_task_list ");
            sb.AppendFormat(" WHERE mid='{0}' AND mtype_id='{1}' ", info.mid, info.mtype_id);
            if (!string.IsNullOrEmpty(info.full_name))
            {
                sb.AppendFormat(" AND full_name = '{0}' ", info.full_name);
            }
            if (info.begin_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                sb.AppendFormat(" AND begin_time >= '{0}' ", info.begin_time);
            }
            if (info.end_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
            {
                sb.AppendFormat(" AND end_time <= '{0}' ", info.end_time);
            }
            sb.Append(" ORDER BY begin_time ASC  ");
            return Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
        }

        public int Operation(tech_task_list info, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            switch (type)
            {
                case "add":
                    #region add

                    sb.Append("INSERT INTO tech_task_list(meeting_hall,session_name,role_name,full_name,mobile,task_title,begin_time,end_time,mid,mtype_id,inputtime)");
                    sb.Append(" VALUES( ");

                    if (!string.IsNullOrEmpty(info.meeting_hall))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.meeting_hall);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.session_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.session_name);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.role_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.role_name);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.full_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.full_name);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mobile);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.task_title))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.task_title);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.begin_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.begin_time);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.end_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.end_time);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    sb.AppendFormat(" ,\"{0}\",\"{1}\",NOW() ", info.mid, info.mtype_id);

                    sb.Append(" ); ");
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "delAll":
                    #region delAll
                    sb.AppendFormat("DELETE FROM tech_task_list WHERE mid='{0}' AND mtype_id='{1}'", info.mid, info.mtype_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
            }
            return result;
        }
    }
}
