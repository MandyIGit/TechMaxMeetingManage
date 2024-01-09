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
    public class tech_adminDal : Itech_admin
    {

        public int Operation(Object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_admin info = new tech_admin();
            switch (type)
            {
                case "select_admin_count":  //查询管理员条数
                    #region 查询管理员条数
                    info = (tech_admin)obj;
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_admin ");
                    sb.AppendFormat(" WHERE `status`=2 ");
                    if (info.Admin_type > 0)
                    {
                        sb.AppendFormat(" AND admin_type={0} ", info.Admin_type);
                    }
                    if (info.Admin_code > 0)
                    {
                        sb.AppendFormat(" AND admin_code={0} ", info.Admin_code);
                    }
                    if (!string.IsNullOrEmpty(info.Admin_name))
                    {
                        sb.AppendFormat(" AND admin_name LIKE \"%{0}%\" ", info.Admin_name);
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;

                case "add_admin":
                    #region 添加管理员信息
                    info = (tech_admin)obj;
                    sb.Append(" INSERT INTO tech_admin(admin_name,login_name,login_pwd,phone,mid,mtype_id,input_time,operationtime) ");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.Admin_name))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.Admin_name);
                    }
                    if (!string.IsNullOrEmpty(info.Login_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Login_name);
                    }
                    if (!string.IsNullOrEmpty(info.Login_pwd))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Login_pwd);
                    }
                    if (!string.IsNullOrEmpty(info.Phone))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Phone);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    if (!string.IsNullOrEmpty(info.Mid))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Mid);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_id))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.Mtype_id);
                    }
                    sb.AppendFormat(" ,\"{0}\",\"{0}\" );select @@IDENTITY; ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    object okey = MySQLHelper.ExecuteScalar(sb.ToString());
                    if (okey != null)//如果插入成功，则返回主键
                        result = Convert.ToInt32(okey.ToString());
                    else
                        result = 0;
                    #endregion
                    break;

                case "edit_admin":
                    #region 修改管理员信息
                    info = (tech_admin)obj;
                    sb.AppendFormat(" UPDATE tech_admin SET operationtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(info.Admin_name))
                    {
                        sb.AppendFormat(" ,admin_name=\"{0}\" ", info.Admin_name);
                    }
                    if (!string.IsNullOrEmpty(info.Login_name))
                    {
                        sb.AppendFormat(" ,login_name=\"{0}\" ", info.Login_name);
                    }
                    if (!string.IsNullOrEmpty(info.Login_pwd))
                    {
                        sb.AppendFormat(" ,login_pwd=\"{0}\" ", info.Login_pwd);
                    }
                    if (info.Gender>0)
                    {
                        sb.AppendFormat(" ,gender=\"{0}\" ", info.Gender);
                    }
                    if (!string.IsNullOrEmpty(info.Phone))
                    {
                        sb.AppendFormat(" ,phone=\"{0}\" ", info.Phone);
                    }
                    if (!string.IsNullOrEmpty(info.Address))
                    {
                        sb.AppendFormat(" ,address=\"{0}\" ", info.Address);
                    }
                    if (!string.IsNullOrEmpty(info.Remark))
                    {
                        sb.AppendFormat(" ,remark=\"{0}\" ", info.Remark);
                    }
                    if (!string.IsNullOrEmpty(info.Mid))
                    {
                        sb.AppendFormat(" ,mid=\"{0}\" ", info.Mid);
                    }
                    if (!string.IsNullOrEmpty(info.Mtype_id))
                    {
                        sb.AppendFormat(" ,mtype_id=\"{0}\" ", info.Mtype_id);
                    }
                    if (info.Status == 1)
                    {
                        sb.Append(" ,`status`=1 ");
                    }
                    else if (info.Status == 2)
                    {
                        sb.Append(" ,`status`=2 ");
                    }
                    if (info.Admin_type > 0)
                    {
                        sb.AppendFormat(" ,admin_type=\"{0}\" ", info.Admin_type);
                    }
                    sb.AppendFormat(" WHERE admin_code={0} ", info.Admin_code);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "record_log_time":  //记录登录时间
                    #region 记录登录时间
                    info = (tech_admin)obj;
                    sb.AppendFormat(" UPDATE tech_admin SET lastlogin_time=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(" WHERE `status`=2 ");
                    sb.AppendFormat(" AND login_name=\"{0}\" ", info.Login_name);
                    sb.AppendFormat(" AND login_pwd=\"{0}\" ", info.Login_pwd);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "delete_system":  //删除管理员信息
                    #region 删除管理员信息
                    info = (tech_admin)obj;
                    sb.AppendFormat(" UPDATE tech_admin SET operationtime=\"{0}\",`status`=1 ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.AppendFormat(" WHERE admin_code={0} ", info.Admin_code);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "record_err_time":
                    #region
                    info = (tech_admin)obj;
                    sb.AppendFormat(" UPDATE tech_admin SET ErrorTimes=\"{0}\",LastErrorDateTime=\"{1}\" ", info.ErrorTimes, info.LastErrorDateTime);
                    sb.Append(" WHERE `status`=2 ");
                    sb.AppendFormat(" AND login_name=\"{0}\" ", info.Login_name);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "record_err_times_clear":
                    #region
                    info = (tech_admin)obj;
                    sb.AppendFormat(" UPDATE tech_admin SET ErrorTimes=\"{0}\" ", info.ErrorTimes);
                    sb.Append(" WHERE `status`=2 ");
                    sb.AppendFormat(" AND login_name=\"{0}\" ", info.Login_name);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
            }
            return result;
        }

        public tech_admin Login(string loginname, string pwd)
        {
            tech_admin admin = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_admin where login_name='{0}' and login_pwd='{1}' and status=2 and admin_type=1", loginname, pwd);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                admin = MySQLHelper.ConvertTableToObject<tech_admin>(dt)[0];
            }
            return admin;
        }

        public tech_admin GetModel(int Admin_Code)
        {
            tech_admin admin = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_admin where admin_code={0} and status=2", Admin_Code);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                admin = MySQLHelper.ConvertTableToObject<tech_admin>(dt)[0];
            }
            return admin;
        }

        public DataTable GetTech_admin(Object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_admin info = new tech_admin();
            switch (type)
            {
                case "select_admin_to_page":  //查询管理员信息（带分页）
                    #region 查询管理员信息（带分页）
                    info = (tech_admin)obj;
                    sb.Append(" SELECT ta.admin_code,ta.admin_name,ta.login_name,ta.login_pwd,ta.gender,ta.phone,ta.address,ta.admin_type,ta.lastlogin_time,ta.mid,ta.mtype_id ");
                    sb.Append(" ,ta.`status`,tm.mname,ta.remark ");
                    sb.Append(" FROM tech_admin ta ");
                    sb.Append(" LEFT JOIN tech_meeting tm ON tm.mid=ta.mid ");
                    sb.Append(" WHERE ta.`status`=2 ");

                    if (info.Admin_type > 0)
                    {
                        sb.AppendFormat(" AND admin_type={0} ", info.Admin_type);
                    }
                    if (info.Admin_code > 0)
                    {
                        sb.AppendFormat(" AND admin_code={0} ", info.Admin_code);
                    }
                    if (!string.IsNullOrEmpty(info.Admin_name))
                    {
                        sb.AppendFormat(" AND admin_name LIKE \"%{0}%\" ", info.Admin_name);
                    }
                    sb.Append(" ORDER BY admin_code DESC ");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_admin":  //查询管理员信息
                    #region 查询管理员信息
                    info = (tech_admin)obj;
                    sb.Append(" SELECT ta.admin_code,ta.admin_name,ta.login_name,ta.login_pwd,ta.gender,ta.phone,ta.address,ta.admin_type,ta.lastlogin_time,ta.mid,ta.mtype_id ");
                    sb.Append(" ,ta.`status`,tm.mname,ta.remark,ta.ErrorTimes,ta.LastErrorDateTime ");
                    sb.Append(" FROM tech_admin ta ");
                    sb.Append(" LEFT JOIN tech_meeting tm ON tm.mid=ta.mid ");
                    if (info.Admin_type > 0)
                    {
                        sb.AppendFormat(" AND admin_type={0} ", info.Admin_type);
                    }
                    if (info.Admin_code > 0)
                    {
                        sb.AppendFormat(" AND admin_code={0} ", info.Admin_code);
                    }
                    if (!string.IsNullOrEmpty(info.Admin_name))
                    {
                        sb.AppendFormat(" AND admin_name LIKE \"%{0}%\" ", info.Admin_name);
                    }
                    if (!string.IsNullOrEmpty(info.Login_name))
                    {
                        sb.AppendFormat(" AND login_name=\"{0}\" ", info.Login_name);
                    }
                    if (!string.IsNullOrEmpty(info.Login_pwd))
                    {
                        sb.AppendFormat(" AND login_pwd=\"{0}\" ", info.Login_pwd);
                    }
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_admin_name":  //查询管理员信息
                    #region 查询管理员信息
                    info = (tech_admin)obj;
                    sb.Append(" SELECT ta.admin_code,ta.admin_name,ta.login_name,ta.login_pwd,ta.gender,ta.phone,ta.address,ta.admin_type,ta.lastlogin_time,ta.mid,ta.mtype_id ");
                    sb.Append(" ,ta.`status`,tm.mname,ta.remark,ta.ErrorTimes,ta.LastErrorDateTime ");
                    sb.Append(" FROM tech_admin ta ");
                    sb.Append(" LEFT JOIN tech_meeting tm ON tm.mid=ta.mid ");
                    sb.AppendFormat(" WHERE ta.login_name=\"{0}\" ", info.Login_name);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }
    }
}
