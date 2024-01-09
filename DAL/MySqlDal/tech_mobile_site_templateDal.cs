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
    public class tech_mobile_site_templateDal : Itech_mobile_site_template
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_mobile_site_template info = (tech_mobile_site_template)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_mobile_site_template(logo,main_img_pc,main_img_mobile,first_content_bg,first_content,second_content,scend_top_bg,footer_content,web_back_color,menu_type,mid,inputtime) ");
                    sb.Append(" VALUES( ");

                    if (!string.IsNullOrEmpty(info.logo))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.logo);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.main_img_pc))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.main_img_pc);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.main_img_mobile))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.main_img_mobile);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.first_content_bg))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.first_content_bg);
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

                    if (!string.IsNullOrEmpty(info.scend_top_bg))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.scend_top_bg);
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

                    if (!string.IsNullOrEmpty(info.web_back_color))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.web_back_color);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.menu_type > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.menu_type);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.mid))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mid);
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
                    sb.Append("UPDATE tech_mobile_site_template SET isdel=2 ");
                    if (!string.IsNullOrEmpty(info.logo))
                    {
                        sb.AppendFormat(" ,logo=\"{0}\" ", info.logo);
                    }
                    if (!string.IsNullOrEmpty(info.main_img_pc))
                    {
                        sb.AppendFormat(" ,main_img_pc=\"{0}\" ", info.main_img_pc);
                    }
                    if (!string.IsNullOrEmpty(info.main_img_mobile))
                    {
                        sb.AppendFormat(" ,main_img_mobile=\"{0}\" ", info.main_img_mobile);
                    }
                    if (!string.IsNullOrEmpty(info.first_content_bg))
                    {
                        sb.AppendFormat(" ,first_content_bg=\"{0}\" ", info.first_content_bg);
                    }
                    if (!string.IsNullOrEmpty(info.first_content))
                    {
                        sb.AppendFormat(" ,first_content=\"{0}\" ", info.first_content);
                    }
                    if (!string.IsNullOrEmpty(info.second_content))
                    {
                        sb.AppendFormat(" ,second_content=\"{0}\" ", info.second_content);
                    }
                    if (!string.IsNullOrEmpty(info.scend_top_bg))
                    {
                        sb.AppendFormat(" ,scend_top_bg=\"{0}\" ", info.scend_top_bg);
                    }
                    if (!string.IsNullOrEmpty(info.footer_content))
                    {
                        sb.AppendFormat(" ,footer_content=\"{0}\" ", info.footer_content);
                    }
                    if (!string.IsNullOrEmpty(info.web_back_color))
                    {
                        sb.AppendFormat(" ,web_back_color=\"{0}\" ", info.web_back_color);
                    }
                    if (info.menu_type > 0)
                    {
                        sb.AppendFormat(" ,menu_type={0} ", info.menu_type);
                    }
                    if (!string.IsNullOrEmpty(info.mid))
                    {
                        sb.AppendFormat(" ,mid=\"{0}\" ", info.mid);
                    }                    

                    sb.AppendFormat(" WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_mobile_site_template SET isdel=1 WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "select_mobile_site_template_count":
                    #region 查询select_mobile_template_count信息
                    info = (tech_mobile_site_template)obj;
                    sb.Append("SELECT COUNT(*) FROM tech_mobile_site_template WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.mid))
                    {
                        sb.AppendFormat(" AND mid = \"{0}\" ", info.mid);
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }


        public DataTable GetTech_mobile_site_template(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_mobile_site_template info = new tech_mobile_site_template();
            switch (type)
            {
                case "select_mobile_site_template_to_page":
                    #region 查询tech_mobile_site_template信息（带分页）
                    info = (tech_mobile_site_template)obj;
                    sb.Append("SELECT * FROM tech_mobile_site_template WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.mid))
                    {
                        sb.AppendFormat(" AND mid = \"{0}\" ", info.mid);
                    }
                    sb.Append(" ORDER BY id DESC ");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_mobile_site_template":
                    #region 查询mobile_type信息
                    info = (tech_mobile_site_template)obj;
                    sb.Append("SELECT * FROM tech_mobile_site_template WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.mid))
                    {
                        sb.AppendFormat(" AND mid = \"{0}\" ", info.mid);
                    }
                    sb.Append(" ORDER BY id DESC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public tech_mobile_site_template GetModelByTemplateId(string id)
        {
            tech_mobile_site_template mobile_site_template = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_mobile_site_template where id={0} ", id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                mobile_site_template = MySQLHelper.ConvertTableToObject<tech_mobile_site_template>(dt)[0];
            }
            return mobile_site_template;
        }

    }
}
