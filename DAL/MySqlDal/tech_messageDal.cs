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
   public class tech_messageDal : Itech_message
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_message info = (tech_message)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_message(Contacts,UnitName,Email,Phone,Intention,Content,Inputtime,Operatingtime,`Status`,UnitType,MeetingNeed,MeetingScale,MeetingStartTime,isComm,CommProgress,Remark)");

                    sb.Append(" VALUES (");
                    if (!string.IsNullOrEmpty(info.Contacts))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Contacts);
                    }

                    if (!string.IsNullOrEmpty(info.UnitName))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.UnitName);
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

                    if (!string.IsNullOrEmpty(info.Phone))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Phone);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Intention))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Intention);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Content))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Content);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    sb.AppendFormat(" ,\"{0}\", \"{0}\" ", DateTime.Now);

                    if (info.Status>0)
                    {
                        sb.AppendFormat(" ,{0} ", info.Status);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.UnitType > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.UnitType);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.MeetingNeed))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.MeetingNeed);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.MeetingScale))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.MeetingScale);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.MeetingStartTime.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.MeetingStartTime.ToString("yyyy-MM-dd"));
                    }

                    if (info.isComm > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.isComm);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.CommProgress))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.CommProgress);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.Remark))
                    {
                        sb.AppendFormat(" ,\"{0}\" );", info.Remark);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT );");
                    }

                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "edit":
                    #region edit
                    sb.AppendFormat("UPDATE tech_message SET Operatingtime='" + DateTime.Now + "' ");
                    if (!string.IsNullOrEmpty(info.Contacts))
                    {
                        sb.AppendFormat(" ,Contacts=\"{0}\" ", info.Contacts);
                    }
                    if (!string.IsNullOrEmpty(info.UnitName))
                    {
                        sb.AppendFormat(" ,UnitName=\"{0}\" ", info.UnitName);
                    }
                    if (!string.IsNullOrEmpty(info.Email))
                    {
                        sb.AppendFormat(" ,Email=\"{0}\" ", info.Email);
                    }
                    if (!string.IsNullOrEmpty(info.Phone))
                    {
                        sb.AppendFormat(" ,Phone=\"{0}\" ", info.Phone);
                    }
                    if (!string.IsNullOrEmpty(info.Intention))
                    {
                        sb.AppendFormat(" ,Intention=\"{0}\" ", info.Intention);
                    }
                    if (!string.IsNullOrEmpty(info.Content))
                    {
                        sb.AppendFormat(" ,Content=\"{0}\" ", info.Content);
                    }
                    if (info.Status > 0)
                    {
                        sb.AppendFormat(" ,`Status`={0} ", info.Status);
                    }
                    if (info.UnitType > 0)
                    {
                        sb.AppendFormat(" ,UnitType={0} ", info.UnitType);
                    }
                    if (!string.IsNullOrEmpty(info.MeetingNeed))
                    {
                        sb.AppendFormat(" ,MeetingNeed=\"{0}\" ", info.MeetingNeed);
                    }
                    if (!string.IsNullOrEmpty(info.MeetingScale))
                    {
                        sb.AppendFormat(" ,MeetingScale=\"{0}\" ", info.MeetingScale);
                    }
                    if (!string.IsNullOrEmpty(info.MeetingStartTime.ToString("yyyy-MM-dd")))
                    {
                        sb.AppendFormat(" ,MeetingStartTime=\"{0}\" ", info.MeetingStartTime.ToString("yyyy-MM-dd"));
                    }
                    if (info.isComm > 0)
                    {
                        sb.AppendFormat(" ,isComm={0} ", info.isComm);
                    }
                    if (!string.IsNullOrEmpty(info.CommProgress))
                    {
                        sb.AppendFormat(" ,CommProgress=\"{0}\" ", info.CommProgress);
                    }
                    if (!string.IsNullOrEmpty(info.Remark))
                    {
                        sb.AppendFormat(" ,Remark=\"{0}\" ", info.Remark);
                    }
                    
                    sb.AppendFormat(" WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("delete FROM tech_message WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "select_message_count":
                    #region 统计信息数量
                    sb.Append(" SELECT COUNT(1) FROM tech_message WHERE 1=1 ");
                    if (!string.IsNullOrEmpty(info.Contacts))
                    {
                        sb.AppendFormat(" AND Contacts LIKE \"%{0}%\" ", info.Contacts);
                    }
                    if (!string.IsNullOrEmpty(info.UnitName))
                    {
                        sb.AppendFormat(" AND UnitName LIKE \"%{0}%\" ", info.UnitName);
                    }
                    if (!string.IsNullOrEmpty(info.Email))
                    {
                        sb.AppendFormat(" AND Email LIKE \"%{0}%\" ", info.Email);
                    }
                    if (!string.IsNullOrEmpty(info.Phone))
                    {
                        sb.AppendFormat(" AND Phone LIKE \"%{0}%\" ", info.Phone);
                    }
                    if (info.UnitType>0)
                    {
                        sb.AppendFormat(" AND UnitType={0}", info.UnitType);
                    }
                    if (info.Status > 0)
                    {
                        sb.AppendFormat(" AND Status={0}", info.Status);
                    }
                    sb.Append(" ORDER BY MeetingStartTime ASC, id DESC ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }

            return result;
        }

        public DataTable GetTech_message(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_message info = new tech_message();
            switch (type)
            {
                case "select_message_to_page":
                    #region 无条件查询会议信息（带分页）
                    info = (tech_message)obj;
                    sb.Append(" SELECT * FROM tech_message WHERE 1=1 ");
                    if (!string.IsNullOrEmpty(info.Contacts))
                    {
                        sb.AppendFormat(" AND Contacts LIKE \"%{0}%\" ", info.Contacts);
                    }
                    if (!string.IsNullOrEmpty(info.UnitName))
                    {
                        sb.AppendFormat(" AND UnitName LIKE \"%{0}%\" ", info.UnitName);
                    }
                    if (!string.IsNullOrEmpty(info.Email))
                    {
                        sb.AppendFormat(" AND Email LIKE \"%{0}%\" ", info.Email);
                    }
                    if (!string.IsNullOrEmpty(info.Phone))
                    {
                        sb.AppendFormat(" AND Phone LIKE \"%{0}%\" ", info.Phone);
                    }
                    if (info.UnitType>0)
                    {
                        sb.AppendFormat(" AND UnitType={0}", info.UnitType);
                    }
                    if (info.Status > 0)
                    {
                        sb.AppendFormat(" AND Status={0}", info.Status);
                    }
                    sb.Append(" ORDER BY MeetingStartTime ASC, id DESC ");
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_message":
                    #region 无条件查询会议信息
                    info = (tech_message)obj;
                    sb.Append(" SELECT * FROM tech_message WHERE 1=1 ");
                    if (!string.IsNullOrEmpty(info.Contacts))
                    {
                        sb.AppendFormat(" AND Contacts LIKE \"%{0}%\" ", info.Contacts);
                    }
                    if (!string.IsNullOrEmpty(info.UnitName))
                    {
                        sb.AppendFormat(" AND UnitName LIKE \"%{0}%\" ", info.UnitName);
                    }
                    if (!string.IsNullOrEmpty(info.Email))
                    {
                        sb.AppendFormat(" AND Email LIKE \"%{0}%\" ", info.Email);
                    }
                    if (!string.IsNullOrEmpty(info.Phone))
                    {
                        sb.AppendFormat(" AND Phone LIKE \"%{0}%\" ", info.Phone);
                    }
                    if (info.UnitType>0)
                    {
                        sb.AppendFormat(" AND UnitType={0}", info.UnitType);
                    }
                    if (info.Status > 0)
                    {
                        sb.AppendFormat(" AND Status={0}", info.Status);
                    }
                    sb.Append(" ORDER BY MeetingStartTime ASC, id DESC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public DataTable GetTechMessage(Model.tech_message model)
        {
            string strSQL = string.Format("select * from tech_message where id={0}", model.id);
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public tech_message GetModelById(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tech_message");
            sb.AppendFormat(" where id={0}", id);
            tech_message model = new tech_message();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_message>(dt)[0];
            return model;
        }
    }
}
