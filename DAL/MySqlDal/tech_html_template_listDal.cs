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
    public class tech_html_template_listDal : Itech_html_template_list
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            tech_html_template_list info = (tech_html_template_list)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_html_template_list(tm_id,tm_name,tm_img,first_content,en_first_content,second_content,en_second_content");
                    sb.Append(",third_content,en_third_content,person_content,en_person_content,tm_type,tm_css,inputtime)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.Tm_id))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Tm_id);
                    }

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
                        sb.AppendFormat(" ,\"{0}\" ", info.Tm_img);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
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

                    if (!string.IsNullOrEmpty(info.Tm_type))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Tm_type);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Tm_css))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Tm_css);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    sb.AppendFormat(" ,\"{0}\" ); ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion

                    #region add2
                    sb2.Append("INSERT INTO tech_html_template(tm_id,mid,first_content,en_first_content,second_content,en_second_content");
                    sb2.Append(",third_content,en_third_content,person_content,en_person_content,inputtime,tm_name,tm_img)");
                    sb2.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.Tm_id))
                    {
                        sb2.AppendFormat(" \"{0}\" ", info.Tm_id);
                    }

                    if (!string.IsNullOrEmpty(info.Mid))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.Mid);
                    }

                    if (!string.IsNullOrEmpty(info.First_content))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.First_content);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_first_content))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.En_first_content);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Second_content))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.Second_content);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_second_content))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.En_second_content);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Third_content))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.Third_content);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_third_content))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.En_third_content);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Person_content))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.Person_content);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_person_content))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.En_person_content);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    sb2.AppendFormat(" ,\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (!string.IsNullOrEmpty(info.Tm_name))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ", info.Tm_name);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Tm_img))
                    {
                        sb2.AppendFormat(" ,\"{0}\" ); ", info.Tm_img);
                    }
                    else
                    {
                        sb2.Append(" ,DEFAULT ); ");
                    }
                    result = MySQLHelper.ExecuteNonQuery(sb2.ToString());
                    #endregion

                    break;

                case "edit":
                    #region edit
                    sb.AppendFormat("UPDATE tech_html_template_list SET isdel=2");
                    if (!string.IsNullOrEmpty(info.Tm_name))
                    {
                        sb.AppendFormat(" ,tm_name=\"{0}\" ", info.Tm_name);
                    }
                    if (!string.IsNullOrEmpty(info.Tm_img))
                    {
                        sb.AppendFormat(" ,tm_img=\"{0}\" ", info.Tm_img);
                    }
                    if (!string.IsNullOrEmpty(info.Tm_type))
                    {
                        sb.AppendFormat(" ,tm_type=\"{0}\" ", info.Tm_type);
                    }
                    if (!string.IsNullOrEmpty(info.Tm_css))
                    {
                        sb.AppendFormat(" ,tm_css=\"{0}\" ", info.Tm_css);
                    }
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
                    
                    sb.AppendFormat(" WHERE tm_id=\"{0}\" ; ", info.Tm_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    #region edit2
                    sb2.AppendFormat("UPDATE tech_html_template SET mid=\"{0}\" ", info.Mid);
                    if (!string.IsNullOrEmpty(info.First_content))
                    {
                        sb2.AppendFormat(" ,first_content=\"{0}\" ", info.First_content);
                    }
                    if (!string.IsNullOrEmpty(info.En_first_content))
                    {
                        sb2.AppendFormat(" ,en_first_content=\"{0}\" ", info.En_first_content);
                    }
                    if (!string.IsNullOrEmpty(info.Second_content))
                    {
                        sb2.AppendFormat(" ,second_content=\"{0}\" ", info.Second_content);
                    }
                    if (!string.IsNullOrEmpty(info.En_second_content))
                    {
                        sb2.AppendFormat(" ,en_second_content=\"{0}\" ", info.En_second_content);
                    }
                    if (!string.IsNullOrEmpty(info.Third_content))
                    {
                        sb2.AppendFormat(" ,third_content=\"{0}\" ", info.Third_content);
                    }
                    if (!string.IsNullOrEmpty(info.En_third_content))
                    {
                        sb2.AppendFormat(" ,en_third_content=\"{0}\" ", info.En_third_content);
                    }
                    if (!string.IsNullOrEmpty(info.Person_content))
                    {
                        sb2.AppendFormat(" ,person_content=\"{0}\" ", info.Person_content);
                    }
                    if (!string.IsNullOrEmpty(info.En_person_content))
                    {
                        sb2.AppendFormat(" ,en_person_content=\"{0}\" ", info.En_person_content);
                    }
                    if (!string.IsNullOrEmpty(info.Tm_name))
                    {
                        sb2.AppendFormat(" ,tm_name=\"{0}\" ", info.Tm_name);
                    }
                    if (!string.IsNullOrEmpty(info.Tm_img))
                    {
                        sb2.AppendFormat(" ,tm_img=\"{0}\" ", info.Tm_img);
                    }
                    sb2.AppendFormat(" WHERE tm_id=\"{0}\" ", info.Tm_id);
                    result = MySQLHelper.ExecuteNonQuery(sb2.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_html_template_list SET isdel=1 WHERE tm_id=\"{0}\" ", info.Tm_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    #region del2
                    sb2.AppendFormat("UPDATE tech_html_template SET isdel=1 WHERE tm_id=\"{0}\" ", info.Tm_id);
                    result = MySQLHelper.ExecuteNonQuery(sb2.ToString());
                    #endregion
                    break;
            }

            return result;
        }

        public DataTable GetTech_html_template_list(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_html_template_list info = new tech_html_template_list();
            switch (type)
            {
                case "select_html_template_list_to_page":
                    #region 无条件查询模板信息（带分页）
                    info = (tech_html_template_list)obj;
                    sb.Append("SELECT thtl.*,tht.mid FROM tech_html_template_list as thtl left join (select * from tech_html_template where isdel=2) as tht on thtl.tm_id=tht.tm_id where thtl.isdel=2 ORDER BY thtl.tm_id DESC");
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_html_template_list":
                    #region 无条件查询模板信息
                    info = (tech_html_template_list)obj;
                    sb.Append("SELECT thtl.*,tht.mid FROM tech_html_template_list as thtl left join (select * from tech_html_template where isdel=2) as tht on thtl.tm_id=tht.tm_id where thtl.isdel=2 ORDER BY thtl.tm_id DESC");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public DataTable GetTechHtmlTemplateList(tech_html_template_list model)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT thtl.tm_type,thtl.tm_css,tht.* FROM tech_html_template_list as thtl left join");
            sb.AppendFormat(" (select * from tech_html_template where isdel=2 and mid='{0}' and tm_id='{1}')", model.Mid, model.Tm_id);
            sb.AppendFormat(" as tht on thtl.tm_id=tht.tm_id where thtl.isdel=2 and thtl.tm_id='{0}'", model.Tm_id);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public tech_html_template_list GetModelByMId(string mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT thtl.*,tht.mid FROM tech_html_template_list as thtl left join");
            sb.AppendFormat(" (select * from tech_html_template where isdel=2 and mid='{0}')", mid);
            sb.AppendFormat(" as tht on thtl.tm_id=tht.tm_id where thtl.isdel=2");
            tech_html_template_list model = new tech_html_template_list();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_html_template_list>(dt)[0];
            return model;
        }
        private string GetLastTMid()
        {
            string tm_id = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT tm_id FROM tech_html_template_list WHERE isdel=2 ORDER BY tm_id DESC LIMIT 0,1;");
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
