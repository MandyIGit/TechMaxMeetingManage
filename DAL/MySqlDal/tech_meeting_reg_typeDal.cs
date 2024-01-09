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
    public class tech_meeting_reg_typeDal : Itech_meeting_reg_type
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_meeting_reg_type info = (tech_meeting_reg_type)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_meeting_reg_type(ch_name,en_name,begin_time,end_time,money,use_type,use_location,isupload");
                    sb.Append(",mid,mtype_id,operatingtime,inputtime)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.Ch_name))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Ch_name);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.En_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.En_name);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.Begin_time.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Begin_time.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.End_time.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.End_time.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.Money > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Money);
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", 0);
                    }

                    if (info.Use_type > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Use_type);
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", 1);
                    }

                    if (info.Use_location > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Use_location);
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", 1);
                    }

                    if (info.Isupload > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Isupload);
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", 2);
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
                    #region edit                    
                    sb.AppendFormat("UPDATE tech_meeting_reg_type SET operatingtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(info.Ch_name))
                    {
                        sb.AppendFormat(" ,ch_name=\"{0}\" ", info.Ch_name);
                    }
                    if (!string.IsNullOrEmpty(info.En_name))
                    {
                        sb.AppendFormat(" ,en_name=\"{0}\" ", info.En_name);
                    }

                    if (info.Begin_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
                    {
                        sb.AppendFormat(" ,begin_time=\"{0}\" ", info.Begin_time.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.End_time.ToString("yyyy-MM-dd HH:mm:ss") != "0001-01-01 00:00:00")
                    {
                        sb.AppendFormat(" ,end_time=\"{0}\" ", info.End_time.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.Money > 0)
                    {
                        sb.AppendFormat(" ,money=\"{0}\" ", info.Money);
                    }
                    if (info.Use_type > 0)
                    {
                        sb.AppendFormat(" ,use_type=\"{0}\" ", info.Use_type);
                    }
                    if (info.Use_location > 0)
                    {
                        sb.AppendFormat(" ,use_location=\"{0}\" ", info.Use_location);
                    }
                    if (info.Isupload > 0)
                    {
                        sb.AppendFormat(" ,isupload=\"{0}\" ", info.Isupload);
                    }

                    if (!string.IsNullOrEmpty(info.Mid))
                    {
                        sb.AppendFormat(" ,mid=\"{0}\" ", info.Mid);
                    }

                    if (!string.IsNullOrEmpty(info.Mtype_id))
                    {
                        sb.AppendFormat(" ,mtype_id=\"{0}\" ", info.Mtype_id);
                    }

                    sb.AppendFormat(" WHERE id={0} ", info.Id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    break;
                #endregion

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_meeting_reg_type SET isdel=1 WHERE id={0}", info.Id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
            }
            return result;
        }

        public DataTable GetTech_meeting_reg_type(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_meeting_reg_type info = new tech_meeting_reg_type();
            switch (type)
            {
                case "select_meeting_reg_type_to_page":
                    #region 无条件查询信息（带分页）
                    info = (tech_meeting_reg_type)obj;
                    sb.AppendFormat("SELECT * FROM tech_meeting_reg_type WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}' ORDER BY id DESC", info.Mtype_id, info.Mid);
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_meeting_reg_type":
                    #region 无条件查询信息
                    info = (tech_meeting_reg_type)obj;
                    sb.AppendFormat("SELECT * FROM tech_meeting_reg_type WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}' ORDER BY id DESC", info.Mtype_id, info.Mid);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        public DataTable GetTechMeetingRegType(tech_meeting_reg_type model)
        {
            string strSQL = string.Format("SELECT * FROM tech_meeting_reg_type WHERE isdel=2 AND mtype_id='{0}' AND mid='{1}'", model.Mtype_id, model.Mid);
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public tech_meeting_reg_type GetModelById(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM tech_meeting_reg_type WHERE isdel=2 AND id={0}", id);
            tech_meeting_reg_type model = new tech_meeting_reg_type();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_meeting_reg_type>(dt)[0];
            return model;
        }
    }
}
