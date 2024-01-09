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
    public class tech_html_templateDal : Itech_html_template
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_html_template info = (tech_html_template)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_html_template(tm_id,mid,first_content,en_first_content,second_content,en_second_content");
                    sb.Append(",third_content,en_third_content,person_content,en_person_content,inputtime,tm_name,tm_img)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.Tm_id))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Tm_id);
                    }

                    if (!string.IsNullOrEmpty(info.Mid))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Mid);
                    }

                    if (!string.IsNullOrEmpty(info.First_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.First_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_first_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.En_first_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Second_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Second_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_second_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.En_second_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Third_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Third_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_third_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.En_third_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Person_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Person_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_person_content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.En_person_content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    sb.AppendFormat(" ,\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (!string.IsNullOrEmpty(info.Tm_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Tm_name);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Tm_img))
                    {
                        sb.AppendFormat(" ,\"{0}\" ); ", info.Tm_img);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ); ");
                    }
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "edit":
                    #region edit
                    sb.AppendFormat("UPDATE tech_html_template SET mid=\"{0}\",tm_id=\"{1}\" ", info.Mid, info.Tm_id);
                    if (!string.IsNullOrEmpty(info.First_content))
                    {
                        sb.AppendFormat(" ,first_content=\"{0}\" ", info.First_content);
                    }
                    if (!string.IsNullOrEmpty(info.En_first_content))
                    {
                        sb.AppendFormat(" ,en_first_content=\"{0}\" ", info.En_first_content);
                    }
                    if (!string.IsNullOrEmpty(info.Second_content))
                    {
                        sb.AppendFormat(" ,second_content=\"{0}\" ", info.Second_content);
                    }
                    if (!string.IsNullOrEmpty(info.En_second_content))
                    {
                        sb.AppendFormat(" ,en_second_content=\"{0}\" ", info.En_second_content);
                    }
                    if (!string.IsNullOrEmpty(info.Third_content))
                    {
                        sb.AppendFormat(" ,third_content=\"{0}\" ", info.Third_content);
                    }
                    if (!string.IsNullOrEmpty(info.En_third_content))
                    {
                        sb.AppendFormat(" ,en_third_content=\"{0}\" ", info.En_third_content);
                    }
                    if (!string.IsNullOrEmpty(info.Person_content))
                    {
                        sb.AppendFormat(" ,person_content=\"{0}\" ", info.Person_content);
                    }
                    if (!string.IsNullOrEmpty(info.En_person_content))
                    {
                        sb.AppendFormat(" ,en_person_content=\"{0}\" ", info.En_person_content);
                    }
                    if (!string.IsNullOrEmpty(info.Tm_name))
                    {
                        sb.AppendFormat(" ,tm_name=\"{0}\" ", info.Tm_name);
                    }
                    if (!string.IsNullOrEmpty(info.Tm_img))
                    {
                        sb.AppendFormat(" ,tm_img=\"{0}\" ", info.Tm_img);
                    }
                    sb.AppendFormat(" WHERE t_id={0} ", info.T_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_html_template SET isdel=1 WHERE t_id={0}", info.T_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
            }

            return result;
        }

        public DataTable GetTech_html_template(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_html_template info = new tech_html_template();
            switch (type)
            {
                case "select_html_template_to_page":
                #region 无条件查询会议信息（带分页）
                info = (tech_html_template)obj;
                sb.Append("SELECT * FROM tech_html_template WHERE isdel=2 ORDER BY tm_id DESC");
                int index = info.pageIndex;
                if (index <= 0)
                {
                    index = 1;
                }
                sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                #endregion
                break;

                case "select_html_template":
                #region 无条件查询会议信息
                info = (tech_html_template)obj;
                sb.Append("SELECT * FROM tech_html_template WHERE isdel=2 ORDER BY tm_id DESC");
                dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                #endregion
                break;
            }
            return dt;
        }

        public DataTable GetTechHtmlTemplate(tech_html_template model)
        {
            string strSQL = string.Format("SELECT * FROM tech_html_template WHERE isdel=2 AND tm_id='{0}' AND mid='{1}'", model.Tm_id, model.Mid);
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public tech_html_template GetModelByTId(int t_id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM tech_html_template");
            sb.AppendFormat(" WHERE isdel=2 AND t_id={0}", t_id);
            tech_html_template model = new tech_html_template();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_html_template>(dt)[0];
            return model;
        }
        private string GetLastTMid()
        {
            string tm_id = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT tm_id FROM tech_html_template WHERE isdel=2 ORDER BY tm_id DESC LIMIT 0,1;");
            tm_id = MySQLHelper.ExecuteScalar(sb.ToString()).ToString();
            return tm_id;
        }
        public string Get_tm_id()
        {
            int oldid = int.Parse(GetLastTMid().Substring(2, 4));
            int newid = oldid + 1;
            return "TM" + newid;
        }
    }
}
