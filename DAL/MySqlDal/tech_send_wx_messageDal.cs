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
    public class tech_send_wx_messageDal : Itech_send_wx_message
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_send_wx_message info = (tech_send_wx_message)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_send_wx_message(keyword1,keyword2,keyword3,keyword4,keyword5,weburl,tagGroup,sendTime)");

                    sb.Append(" VALUES (");
                    if (!string.IsNullOrEmpty(info.keyword1))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.keyword1);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.keyword2))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.keyword2);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.keyword3))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.keyword3);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.keyword4))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.keyword4);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.keyword5))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.keyword5);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.weburl))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.weburl);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.tagGroup))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.tagGroup);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    sb.Append(" ,NOW() );");

                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("delete FROM tech_send_wx_message WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "select_message_count":
                    #region 统计信息数量
                    sb.Append(" SELECT COUNT(1) FROM tech_send_wx_message WHERE 1=1 ");
                    if (!string.IsNullOrEmpty(info.keyword1))
                    {
                        sb.AppendFormat(" AND keyword1 LIKE \"%{0}%\" ", info.keyword1);
                    }
                    if (!string.IsNullOrEmpty(info.keyword2))
                    {
                        sb.AppendFormat(" AND keyword2 LIKE \"%{0}%\" ", info.keyword2);
                    }
                    if (!string.IsNullOrEmpty(info.keyword3))
                    {
                        sb.AppendFormat(" AND keyword3 LIKE \"%{0}%\" ", info.keyword3);
                    }
                    if (!string.IsNullOrEmpty(info.keyword4))
                    {
                        sb.AppendFormat(" AND keyword4 LIKE \"%{0}%\" ", info.keyword4);
                    }
                    if (!string.IsNullOrEmpty(info.keyword5))
                    {
                        sb.AppendFormat(" AND keyword5 LIKE \"%{0}%\" ", info.keyword5);
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }

        public DataTable GetTech_Send_WX_Message(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_send_wx_message info = (tech_send_wx_message)obj;
            switch (type)
            {
                case "select_send_wx_message_to_page":
                    #region 无条件查询会议信息（带分页）
                    info = (tech_send_wx_message)obj;
                    sb.Append(" SELECT * FROM tech_send_wx_message WHERE 1=1 ");
                    if (!string.IsNullOrEmpty(info.keyword1))
                    {
                        sb.AppendFormat(" AND keyword1 LIKE \"%{0}%\" ", info.keyword1);
                    }
                    if (!string.IsNullOrEmpty(info.keyword2))
                    {
                        sb.AppendFormat(" AND keyword2 LIKE \"%{0}%\" ", info.keyword2);
                    }
                    if (!string.IsNullOrEmpty(info.keyword3))
                    {
                        sb.AppendFormat(" AND keyword3 LIKE \"%{0}%\" ", info.keyword3);
                    }
                    if (!string.IsNullOrEmpty(info.keyword4))
                    {
                        sb.AppendFormat(" AND keyword4 LIKE \"%{0}%\" ", info.keyword4);
                    }
                    if (!string.IsNullOrEmpty(info.keyword5))
                    {
                        sb.AppendFormat(" AND keyword5 LIKE \"%{0}%\" ", info.keyword5);
                    }
                    sb.Append(" ORDER BY sendTime DESC, id DESC ");
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

            }
            return dt;
        }

        public DataTable GetTech_Send_WX_Message(tech_send_wx_message model)
        {
            string strSQL = string.Format("select * from tech_send_wx_message where id={0}", model.id);
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public tech_send_wx_message GetModelById(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tech_message");
            sb.AppendFormat(" where id={0}", id);
            tech_send_wx_message model = new tech_send_wx_message();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_send_wx_message>(dt)[0];
            return model;
        }
    }
}
