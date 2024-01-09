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
    public class email_templateDal : Iemail_template
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            email_template info = (email_template)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO email_template(tp_name,tp_content,tel,fax,email,web_url,mid,mtype_id,inputtime");
                    sb.Append(",m_p_content_ch,m_p_content_en,h_p_content_ch,h_p_content_en)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.Tp_name))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Tp_name);
                    }

                    if (!string.IsNullOrEmpty(info.Tp_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Tp_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Tel))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Tel);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Fax))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Fax);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Email))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Email);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Web_url))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Web_url);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
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

                    sb.AppendFormat(" ,\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (!string.IsNullOrEmpty(info.M_p_content_ch))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.M_p_content_ch);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.M_p_content_en))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.M_p_content_en);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.H_p_content_ch))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.H_p_content_ch);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.H_p_content_en))
                    {
                        sb.AppendFormat(" ,\"{0}\" );select @@IDENTITY; ", info.H_p_content_en);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT );select @@IDENTITY; ");
                    }
                    object okey = MySQLHelper.ExecuteScalar(sb.ToString());
                    if (okey != null)//如果插入成功，则返回主键
                        result = Convert.ToInt32(okey.ToString());
                    else
                        result = 0;
                    #endregion
                    break;

                case "edit":
                    #region edit
                    sb.AppendFormat("UPDATE email_template SET operatingtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(info.Tp_name))
                    {
                        sb.AppendFormat(" ,tp_name=\"{0}\" ", info.Tp_name);
                    }
                    if (!string.IsNullOrEmpty(info.Tp_content))
                    {
                        sb.AppendFormat(" ,tp_content=\"{0}\" ", info.Tp_content);
                    }
                    if (!string.IsNullOrEmpty(info.Tel))
                    {
                        sb.AppendFormat(" ,tel=\"{0}\" ", info.Tel);
                    }
                    if (!string.IsNullOrEmpty(info.Fax))
                    {
                        sb.AppendFormat(" ,fax=\"{0}\" ", info.Fax);
                    }
                    if (!string.IsNullOrEmpty(info.Email))
                    {
                        sb.AppendFormat(" ,email=\"{0}\" ", info.Email);
                    }
                    if (!string.IsNullOrEmpty(info.Web_url))
                    {
                        sb.AppendFormat(" ,web_url=\"{0}\" ", info.Web_url);
                    }
                    if (!string.IsNullOrEmpty(info.Mid))
                    {
                        sb.AppendFormat(" ,mid=\"{0}\" ", info.Mid);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_id))
                    {
                        sb.AppendFormat(" ,mtype_id=\"{0}\" ", info.Mtype_id);
                    }

                    if (!string.IsNullOrEmpty(info.M_p_content_ch))
                    {
                        sb.AppendFormat(" ,m_p_content_ch=\"{0}\" ", info.M_p_content_ch);
                    }
                    else
                    {
                        sb.Append(" ,m_p_content_ch=DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.M_p_content_en))
                    {
                        sb.AppendFormat(" ,m_p_content_en=\"{0}\" ", info.M_p_content_en);
                    }
                    else
                    {
                        sb.Append(" ,m_p_content_en=DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.H_p_content_ch))
                    {
                        sb.AppendFormat(" ,h_p_content_ch=\"{0}\" ", info.H_p_content_ch);
                    }
                    else
                    {
                        sb.Append(" ,h_p_content_ch=DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.H_p_content_en))
                    {
                        sb.AppendFormat(" ,h_p_content_en=\"{0}\" ", info.H_p_content_en);
                    }
                    else
                    {
                        sb.Append(" ,h_p_content_en=DEFAULT ");
                    }
                    sb.AppendFormat(" WHERE id={0} ", info.Id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE email_template SET isdel=1 WHERE id={0}", info.Id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
            }

            return result;
        }

        public DataTable GetEmail_template(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            email_template info = new email_template();
            switch (type)
            {
                case "select_email_template_to_page":
                    #region 无条件查询会议信息（带分页）
                    info = (email_template)obj;
                    sb.Append("SELECT * FROM email_template WHERE isdel=2 ORDER BY id DESC");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_email_template":
                    #region 无条件查询会议信息
                    info = (email_template)obj;
                    sb.Append("SELECT * FROM email_template WHERE isdel=2 ORDER BY id DESC");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public DataTable GetEmailTemplate(email_template model)
        {
            string strSQL = string.Format("SELECT * FROM email_template WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}'", model.Mtype_id, model.Mid);
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public email_template GetModelById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM email_template");
            sb.AppendFormat(" WHERE isdel=2 AND id={0}", id);
            email_template model = new email_template();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<email_template>(dt)[0];
            return model;
        }
    }
}
