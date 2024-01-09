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
    public class tech_mobile_templateDal : Itech_mobile_template
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_mobile_template info = (tech_mobile_template)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_mobile_template(mtype_id,version_id,mtemplate_name,mtemplate_css,mtemplate_thumbnail,mtemplate_memo,first_content,second_content,footer_content,inputtime) ");
                    sb.Append(" VALUES( ");

                    if (info.mtype_id > 0)
                    {
                        sb.AppendFormat(" {0} ", info.mtype_id);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    if (info.version_id > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.version_id);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.mtemplate_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mtemplate_name);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.mtemplate_css))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mtemplate_css);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.mtemplate_thumbnail))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mtemplate_thumbnail);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.mtemplate_memo))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mtemplate_memo);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.first_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.first_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.second_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.second_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.footer_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.footer_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
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
                    sb.Append("UPDATE tech_mobile_template SET isdel=2 ");
                    if (info.mtype_id > 0)
                    {
                        sb.AppendFormat(" ,mtype_id={0} ", info.mtype_id);
                    }
                    if (info.version_id > 0)
                    {
                        sb.AppendFormat(" ,version_id={0} ", info.version_id);
                    }
                    if (!string.IsNullOrEmpty(info.mtemplate_name))
                    {
                        sb.AppendFormat(" ,mtemplate_name=\"{0}\" ", info.mtemplate_name);
                    }
                    if (!string.IsNullOrEmpty(info.mtemplate_css))
                    {
                        sb.AppendFormat(" ,mtemplate_css=\"{0}\" ", info.mtemplate_css);
                    }
                    if (!string.IsNullOrEmpty(info.mtemplate_thumbnail))
                    {
                        sb.AppendFormat(" ,mtemplate_thumbnail=\"{0}\" ", info.mtemplate_thumbnail);
                    }
                    if (!string.IsNullOrEmpty(info.mtemplate_memo))
                    {
                        sb.AppendFormat(" ,mtemplate_memo=\"{0}\" ", info.mtemplate_memo);
                    }
                    if (!string.IsNullOrEmpty(info.first_content))
                    {
                        sb.AppendFormat(" ,first_content=\"{0}\" ", info.first_content);
                    }
                    if (!string.IsNullOrEmpty(info.second_content))
                    {
                        sb.AppendFormat(" ,second_content=\"{0}\" ", info.second_content);
                    }
                    if (!string.IsNullOrEmpty(info.footer_content))
                    {
                        sb.AppendFormat(" ,footer_content=\"{0}\" ", info.footer_content);
                    }

                    sb.AppendFormat(" WHERE mtemplate_id={0} ", info.mtemplate_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_mobile_template SET isdel=1 WHERE mtemplate_id={0} ", info.mtemplate_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "select_mobile_template_count":
                    #region 查询select_mobile_template_count信息
                    info = (tech_mobile_template)obj;
                    sb.Append("SELECT COUNT(*) FROM tech_mobile_template WHERE isdel=2 ");
                    if (info.mtype_id > 0)
                    {
                        sb.AppendFormat(" AND mtype_id = {0} ", info.mtype_id);
                    }
                    if (info.version_id > 0)
                    {
                        sb.AppendFormat(" AND version_id = {0} ", info.version_id);
                    }
                    if (!string.IsNullOrEmpty(info.mtemplate_name))
                    {
                        sb.AppendFormat(" AND mtemplate_name LIKE \"%{0}%\" ", info.mtemplate_name);
                    }
                    sb.Append(" ORDER BY mtemplate_id DESC ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }


        public DataTable GetTech_mobile_template(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_mobile_template info = new tech_mobile_template();
            switch (type)
            {
                case "select_mobile_template_to_page":
                    #region 查询tech_mobile_template信息（带分页）
                    info = (tech_mobile_template)obj;
                    sb.Append("SELECT * FROM tech_mobile_template WHERE isdel=2 ");
                    if (info.mtype_id > 0)
                    {
                        sb.AppendFormat(" AND mtype_id = {0} ", info.mtype_id);
                    }
                    if (info.version_id > 0)
                    {
                        sb.AppendFormat(" AND version_id = {0} ", info.version_id);
                    }
                    if (!string.IsNullOrEmpty(info.mtemplate_name))
                    {
                        sb.AppendFormat(" AND mtemplate_name LIKE \"%{0}%\" ", info.mtemplate_name);
                    }
                    sb.Append(" ORDER BY mtemplate_id DESC ");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_mobile_template":
                    #region 查询mobile_type信息
                    info = (tech_mobile_template)obj;
                    sb.Append("SELECT * FROM tech_mobile_template WHERE isdel=2 ");
                    if (info.mtype_id > 0)
                    {
                        sb.AppendFormat(" AND mtype_id = {0} ", info.mtype_id);
                    }
                    if (info.version_id > 0)
                    {
                        sb.AppendFormat(" AND version_id = {0} ", info.version_id);
                    }
                    if (!string.IsNullOrEmpty(info.mtemplate_name))
                    {
                        sb.AppendFormat(" AND mtemplate_name LIKE \"%{0}%\" ", info.mtemplate_name);
                    }
                    sb.Append(" ORDER BY mtemplate_id DESC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public tech_mobile_template GetModelByMTemplateId(string mtemplate_id)
        {
            tech_mobile_template mobile_template = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_mobile_template where mtemplate_id={0} ", mtemplate_id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                mobile_template = MySQLHelper.ConvertTableToObject<tech_mobile_template>(dt)[0];
            }
            return mobile_template;
        }
    }
}
