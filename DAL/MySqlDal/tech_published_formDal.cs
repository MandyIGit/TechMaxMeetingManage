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
    public class tech_published_formDal : Itech_published_form
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_published_form info = (tech_published_form)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_published_form(p_name,app_type");
                    sb.Append(",mid,mtype_id,operatingtime,inputtime)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.P_name))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.P_name);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    if (info.App_type > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.App_type);
                    }
                    else
                    {
                        sb.Append(" ,1 ");
                    }                    

                    if (!string.IsNullOrEmpty(info.Mid))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Mid);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Mtype_id))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Mtype_id);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.Operatingtime.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.AppendFormat(" ,\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Operatingtime.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.Inputtime.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.AppendFormat(" ,\"{0}\" );select @@IDENTITY; ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" );select @@IDENTITY; ", info.Inputtime.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    object okey = MySQLHelper.ExecuteScalar(sb.ToString());
                    if (okey != null)//如果插入成功，则返回主键
                        result = Convert.ToInt32(okey.ToString());
                    else
                        result = 0;
                    #endregion
                    break;

                case "edit":
                    sb.AppendFormat("UPDATE tech_published_form SET operatingtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(info.P_name))
                    {
                        sb.AppendFormat(" ,p_name=\"{0}\" ", info.P_name);
                    }
                    if (info.App_type > 0)
                    {
                        sb.AppendFormat(" ,app_type=\"{0}\" ", info.App_type);
                    }                    
                    if (!string.IsNullOrEmpty(info.Mid))
                    {
                        sb.AppendFormat(" ,mid=\"{0}\" ", info.Mid);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_id))
                    {
                        sb.AppendFormat(" ,mtype_id=\"{0}\" ", info.Mtype_id);
                    }

                    sb.AppendFormat(" WHERE p_id={0} ", info.P_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_published_form SET isdel=1 WHERE p_id={0}", info.P_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
            }
            return result;
        }

        public DataTable GetTech_published_form(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_published_form info = (tech_published_form)obj;
            switch (type)
            {
                case "select_published_form_to_page":
                    #region 无条件查询信息（带分页）
                    sb.AppendFormat("SELECT * FROM tech_published_form WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}' ORDER BY id DESC", info.Mtype_id, info.Mid);
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_published_form":
                    #region 无条件查询信息
                    sb.AppendFormat("SELECT * FROM tech_published_form WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}' ORDER BY id DESC", info.Mtype_id, info.Mid);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public DataTable GetTechPublishedForm(tech_published_form model)
        {
            string strSQL = string.Format("SELECT * FROM tech_published_form WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}'", model.Mtype_id, model.Mid);
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public tech_published_form GetModelById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM tech_published_form WHERE isdel=2 AND p_id={0}", id);
            tech_published_form model = new tech_published_form();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_published_form>(dt)[0];
            return model;
        }

    }
}
