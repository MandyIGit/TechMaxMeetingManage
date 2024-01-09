using DBHelper;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.MySqlDal
{
    public class tv_system_userDal : Itv_system_user
    {
        public DataTable GetTv_system_user(tv_system_user info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT sys_code,sys_name,login_id,login_pwd,sys_mobile,isdel,inputtime,add_date,system_level,mid ");
            sb.Append(" FROM tv_system_user ");
            sb.AppendFormat(" WHERE isdel = 2 AND mid = '{0}' ", info.Mid);
            //登陆ID
            if (!string.IsNullOrEmpty(info.Login_id))
            {
                sb.AppendFormat(" AND login_id = '{0}' ", info.Login_id);
            }
            //登陆密码
            if (!string.IsNullOrEmpty(info.Login_pwd))
            {
                sb.AppendFormat(" AND login_pwd = '{0}' ", Common.DEncrypt.DESEncrypt.Encrypt(info.Login_pwd));
            }
            //用户姓名
            if (!string.IsNullOrEmpty(info.Sys_name))
            {
                sb.AppendFormat(" AND sys_name LIKE '{0}%' ", info.Sys_name);
            }
            //编号
            if (info.Sys_code != 0)
            {
                sb.AppendFormat(" AND sys_code = {0} ", info.Sys_code);
            }
            sb.Append(" ORDER BY sys_code DESC ");
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public DataTable GetTv_system_user(tv_system_user info, int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT sys_code,sys_name,login_id,login_pwd,sys_mobile,isdel,inputtime,add_date,system_level,mid ");
            sb.Append(" FROM tv_system_user ");
            sb.AppendFormat(" WHERE isdel = 2 AND mid = '{0}' ", info.Mid);
            //登陆ID
            if (!string.IsNullOrEmpty(info.Login_id))
            {
                sb.AppendFormat(" AND login_id = '{0}' ", info.Login_id);
            }
            //登陆密码
            if (!string.IsNullOrEmpty(info.Login_pwd))
            {
                sb.AppendFormat(" AND login_pwd = '{0}' ", Common.DEncrypt.DESEncrypt.Encrypt(info.Login_pwd));
            }
            //用户姓名
            if (!string.IsNullOrEmpty(info.Sys_name))
            {
                sb.AppendFormat(" AND sys_name LIKE '{0}%' ", info.Sys_name);
            }
            //编号
            if (info.Sys_code != 0)
            {
                sb.AppendFormat(" AND sys_code = {0} ", info.Sys_code);
            }
            sb.Append(" ORDER BY sys_code DESC ");
            //分页
            int index = pageIndex;
            if (index <= 0)
            {
                index = 1;
            }
            sb.AppendFormat(" LIMIT {0},{1} ", (index - 1) * pageSize, pageSize);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public int GetTv_system_user_count(tv_system_user info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT COUNT(1) ");
            sb.Append(" FROM tv_system_user ");
            sb.AppendFormat(" WHERE isdel = 2 AND mid = '{0}' ", info.Mid);
            //登陆ID
            if (!string.IsNullOrEmpty(info.Login_id))
            {
                sb.AppendFormat(" AND login_id = '{0}' ", info.Login_id);
            }
            //登陆密码
            if (!string.IsNullOrEmpty(info.Login_pwd))
            {
                sb.AppendFormat(" AND login_pwd = '{0}' ", Common.DEncrypt.DESEncrypt.Encrypt(info.Login_pwd));
            }
            //用户姓名
            if (!string.IsNullOrEmpty(info.Sys_name))
            {
                sb.AppendFormat(" AND sys_name LIKE '{0}%' ", info.Sys_name);
            }
            //编号
            if (info.Sys_code != 0)
            {
                sb.AppendFormat(" AND sys_code = {0} ", info.Sys_code);
            }
            sb.Append(" ORDER BY sys_code DESC ");
            return Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
        }

        public int Add_Update(tv_system_user info, string type)
        {
            StringBuilder sb = new StringBuilder();
            switch (type)
            {
                case "add":
                    sb.Append(" INSERT INTO tv_system_user(sys_name,login_id,login_pwd,sys_mobile,inputtime,add_date,system_level,mid) ");
                    sb.Append(" VALUES( ");
                    sb.AppendFormat(" '{0}' ", info.Sys_name);
                    sb.AppendFormat(" ,'{0}' ", info.Login_id);
                    sb.AppendFormat(" ,'{0}' ", Common.DEncrypt.DESEncrypt.Encrypt(info.Login_pwd));
                    sb.AppendFormat(" ,'{0}' ", info.Sys_mobile);
                    sb.Append(" ,NOW() ");
                    sb.Append(" ,NOW() ");
                    sb.AppendFormat(" ,{0} ", info.System_level);
                    sb.AppendFormat(" ,'{0}' ", info.Mid);
                    sb.Append(" ) ");
                    break;
                case "update":
                    sb.Append(" UPDATE tv_system_user SET inputtime = NOW() ");
                    //管理员姓名
                    if (!string.IsNullOrEmpty(info.Sys_name))
                    {
                        sb.AppendFormat(" ,sys_name = '{0}' ", info.Sys_name);
                    }
                    //管理员级别
                    if (info.System_level != 9999)
                    {
                        sb.AppendFormat(" ,system_level = {0} ", info.System_level);
                    }
                    //管理登陆ID
                    if (!string.IsNullOrEmpty(info.Login_id))
                    {
                        sb.AppendFormat(" ,login_id = '{0}' ", info.Login_id);
                    }
                    //管理登陆密码
                    if (!string.IsNullOrEmpty(info.Login_pwd))
                    {
                        sb.AppendFormat(" ,login_pwd = '{0}' ", Common.DEncrypt.DESEncrypt.Encrypt(info.Login_pwd));
                    }
                    //管理员手机号
                    if (!string.IsNullOrEmpty(info.Sys_mobile))
                    {
                        sb.AppendFormat(" ,sys_mobile = '{0}' ", info.Sys_mobile);
                    }
                    sb.AppendFormat(" WHERE isdel = 2 AND sys_code = {0} AND mid = '{1}' ", info.Sys_code, info.Mid);
                    break;
            }
            return MySQLHelper.ExecuteNonQuery(sb.ToString());
        }

        public int Delete_system_user(string id_array, string mid)
        {
            string sql = " UPDATE tv_system_user SET inputtime=NOW(),isdel=1 WHERE sys_code in (" + id_array + ") AND mid='" + mid + "' ";
            return MySQLHelper.ExecuteNonQuery(sql);
        }
    }
}
