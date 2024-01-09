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
    public class tech_meeting_typeDal : Itech_meeting_type
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_meeting_type info = (tech_meeting_type)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_meeting_type(mtype_id,mtype_name,mtype_memo,v_sid,inputtime) ");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.Mtype_id))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Mtype_id);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Mtype_name);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_memo))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Mtype_memo);
                    }
                    if (info.V_sid > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.V_sid);
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
                    sb.Append("UPDATE tech_meeting_type SET isdel=2 ");
                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" ,mtype_name=\"{0}\" ", info.Mtype_name);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_memo))
                    {
                        sb.AppendFormat(" ,mtype_memo=\"{0}\" ", info.Mtype_memo);
                    }
                    if (info.V_sid > 0)
                    {
                        sb.AppendFormat(" ,v_sid={0} ", info.V_sid);
                    }
                    sb.AppendFormat(" WHERE mtype_id=\"{0}\" ", info.Mtype_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_meeting_type SET isdel=1 WHERE mtype_id=\"{0}\" ", info.Mtype_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "isExtTypeName":
                    #region isExtTypeName
                    sb.AppendFormat("SELECT COUNT(1) FROM tech_meeting_type WHERE mtype_name=\"{0}\" ", info.Mtype_name);
                    result = int.Parse(MySQLHelper.ExecuteScalar(sb.ToString()).ToString());
                    #endregion
                    break;
            }
            return result;
        }

        public tech_meeting_type GetModelByTypeId(string type_id)
        {
            tech_meeting_type meeting_type = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_meeting_type where mtype_id=\"{0}\" ", type_id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                meeting_type = MySQLHelper.ConvertTableToObject<tech_meeting_type>(dt)[0];
            }
            return meeting_type;
        }

        public DataTable GetTech_meeting_type(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_meeting_type info = new tech_meeting_type();
            switch (type)
            {
                case "select_meeting_type_to_page":
                    #region 查询meeting_type信息（带分页）
                    info = (tech_meeting_type)obj;
                    sb.Append("SELECT * FROM tech_meeting_type WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" AND mtype_name LIKE \"%{0}%\" ", info.Mtype_name);
                    }
                    sb.Append(" ORDER BY mtype_id DESC ");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_meeting_type":
                    #region 查询meeting_type信息
                    info = (tech_meeting_type)obj;
                    sb.Append("SELECT * FROM tech_meeting_type WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.Mtype_name))
                    {
                        sb.AppendFormat(" AND mtype_name LIKE \"%{0}%\" ", info.Mtype_name);
                    }
                    sb.Append(" ORDER BY mtype_id DESC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

        private string GetLastMtype_id()
        {
            string mtype_id = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT mtype_id FROM tech_meeting_type ORDER BY mtype_id DESC LIMIT 0,1;");
            mtype_id = MySQLHelper.ExecuteScalar(sb.ToString()).ToString();
            return mtype_id;
        }

        public string GetMtype_id()
        {
            int oldid = int.Parse(GetLastMtype_id().Substring(2, 4));
            int newid = oldid + 1;
            return "MT" + newid;
        }

    }
}
