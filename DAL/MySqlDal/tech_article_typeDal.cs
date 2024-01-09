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
    public class tech_article_typeDal : Itech_article_type
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_article_type info = (tech_article_type)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_article_type(type_name,app_type");
                    sb.Append(",mid,mtype_id,operatingtime,inputtime)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.Type_name))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Type_name);
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
                    sb.AppendFormat("UPDATE tech_article_type SET operatingtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(info.Type_name))
                    {
                        sb.AppendFormat(" ,type_name=\"{0}\" ", info.Type_name);
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

                    sb.AppendFormat(" WHERE type_id={0} ", info.Type_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_article_type SET isdel=1 WHERE type_id={0}", info.Type_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
            }
            return result;
        }

        public DataTable GetTech_article_type(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_published_form info = new tech_published_form();
            switch (type)
            {
                case "select_article_type_to_page":
                    #region 无条件查询信息（带分页）
                    info = (tech_published_form)obj;
                    sb.AppendFormat("SELECT * FROM tech_article_type WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}' ORDER BY id DESC", info.Mtype_id, info.Mid);
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_article_type":
                    #region 无条件查询信息
                    info = (tech_published_form)obj;
                    sb.AppendFormat("SELECT * FROM tech_article_type WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}' ORDER BY id DESC", info.Mtype_id, info.Mid);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public DataTable GetTechArticleType(tech_article_type model)
        {
            string strSQL = string.Format("SELECT * FROM tech_article_type WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}'", model.Mtype_id, model.Mid);
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public tech_article_type GetModelById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM tech_article_type WHERE isdel=2 AND type_id={0}", id);
            tech_article_type model = new tech_article_type();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_article_type>(dt)[0];
            return model;
        }
    }
}
