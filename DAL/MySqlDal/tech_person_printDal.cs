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
    class tech_person_printDal : Itech_person_print
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_person_print info = (tech_person_print)obj;

            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_person_print(person_code,person_name,person_group,is_print,operatingtime,inputtime)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.person_code))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.person_code);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.person_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.person_name);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    if (info.person_group > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.person_group);
                    }
                    else
                    {
                        sb.Append(" ,0 ");
                    }

                    if (info.is_print > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.is_print);
                    }
                    else
                    {
                        sb.Append(" ,2 ");
                    }

                    if (info.operatingtime.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.AppendFormat(" ,\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.operatingtime.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.inputtime.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.AppendFormat(" ,\"{0}\" ); ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ); ", info.inputtime.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "edit":
                    #region edit
                    sb.AppendFormat("UPDATE tech_person_print SET operatingtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(info.person_code))
                    {
                        sb.AppendFormat(" ,person_code=\"{0}\" ", info.person_code);
                    }
                    if (!string.IsNullOrEmpty(info.person_name))
                    {
                        sb.AppendFormat(" ,person_name=\"{0}\" ", info.person_name);
                    }
                    if (info.person_group > 0)
                    {
                        sb.AppendFormat(" ,person_group=\"{0}\" ", info.person_group);
                    }
                    if (info.is_print > 0)
                    {
                        sb.AppendFormat(" ,is_print=\"{0}\" ", info.is_print);
                    }

                    sb.AppendFormat(" WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "del":
                    #region del
                    sb.AppendFormat("DELETE FROM tech_person_print WHERE id={0}", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "setPrint":
                    #region setPrint
                    sb.AppendFormat("UPDATE tech_person_print SET is_print=1 WHERE id={0}", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
            }

            return result;

        }

        public DataTable Get_tech_person_print(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_person_print info = (tech_person_print)obj;
            switch (type)
            {
                case "select_person_print_to_page":
                    #region 无条件查询信息（带分页）
                    sb.Append("SELECT * FROM tech_person_print WHERE 1=1 ");
                    if (!string.IsNullOrEmpty(info.person_code))
                    {
                        sb.AppendFormat(" AND person_code=\"{0}\" ", info.person_code);
                    }
                    if (!string.IsNullOrEmpty(info.person_name))
                    {
                        sb.AppendFormat(" AND person_name=\"{0}\" ", info.person_name);
                    }
                    if (info.person_group > 0)
                    {
                        sb.AppendFormat(" AND person_group={0} ", info.person_group);
                    }
                    if (info.is_print > 0)
                    {
                        sb.AppendFormat(" AND is_print={0} ", info.is_print);
                    }
                    sb.Append(" ORDER BY id ASC");
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_person_print":
                    #region 无条件查询信息
                    sb.Append("SELECT * FROM tech_person_print WHERE 1=1 ");
                    if (!string.IsNullOrEmpty(info.person_code))
                    {
                        sb.AppendFormat(" AND person_code=\"{0}\" ", info.person_code);
                    }
                    if (!string.IsNullOrEmpty(info.person_name))
                    {
                        sb.AppendFormat(" AND person_name=\"{0}\" ", info.person_name);
                    }
                    if (info.person_group > 0)
                    {
                        sb.AppendFormat(" AND person_group={0} ", info.person_group);
                    }
                    if (info.is_print > 0)
                    {
                        sb.AppendFormat(" AND is_print={0} ", info.is_print);
                    }
                    sb.Append(" ORDER BY id ASC");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public DataTable GetTechPersonPrint(tech_person_print model)
        {
            string strSQL = string.Format("SELECT * FROM tech_person_print ORDER BY id ASC");
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public tech_person_print GetModelById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM tech_person_print WHERE id={0}", id);
            tech_person_print model = new tech_person_print();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_person_print>(dt)[0];
            return model;
        }
    }
}
