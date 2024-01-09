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
    public class tech_project_managerDal : Itech_project_manager
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_project_manager info = new tech_project_manager();
            switch (type)
            {
                case "select_project_manager_count":  //查询管理员条数
                    #region 查询管理员条数
                    info = (tech_project_manager)obj;
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_project_manager ");
                    sb.AppendFormat(" WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" AND mobile = \"{0}\" ", info.mobile);
                    }
                    if (!string.IsNullOrEmpty(info.full_name))
                    {
                        sb.AppendFormat(" AND full_name LIKE \"%{0}%\" ", info.full_name);
                    }
                    if (!string.IsNullOrEmpty(info.login_name))
                    {
                        sb.AppendFormat(" AND login_name=\"{0}\" ", info.login_name);
                    }
                    
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "add_project_manager":
                    #region 添加管理员信息
                    info = (tech_project_manager)obj;
                    sb.Append(" INSERT INTO tech_project_manager(full_name,login_name,login_pwd,mobile,isdel,inputtime,operationtime) ");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.full_name))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.full_name);
                    }
                    if (!string.IsNullOrEmpty(info.login_name))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.login_name);
                    }
                    if (!string.IsNullOrEmpty(info.login_pwd))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.login_pwd);
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mobile);
                    }                    
                    sb.AppendFormat(" ,2,\"{0}\",\"{0}\" );select @@IDENTITY; ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    object okey = MySQLHelper.ExecuteScalar(sb.ToString());
                    if (okey != null)//如果插入成功，则返回主键
                        result = Convert.ToInt32(okey.ToString());
                    else
                        result = 0;
                    #endregion
                    break;
                case "edit_project_manager":
                    #region 修改管理员信息
                    info = (tech_project_manager)obj;
                    sb.AppendFormat(" UPDATE tech_project_manager SET operationtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(info.full_name))
                    {
                        sb.AppendFormat(" ,full_name=\"{0}\" ", info.full_name);
                    }
                    if (!string.IsNullOrEmpty(info.login_name))
                    {
                        sb.AppendFormat(" ,login_name=\"{0}\" ", info.login_name);
                    }
                    if (!string.IsNullOrEmpty(info.login_pwd))
                    {
                        sb.AppendFormat(" ,login_pwd=\"{0}\" ", info.login_pwd);
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" ,mobile=\"{0}\" ", info.mobile);
                    }                    
                    sb.AppendFormat(" WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "delete_project_manager":  //删除管理员信息
                    #region 删除管理员信息
                    info = (tech_project_manager)obj;
                    sb.AppendFormat(" UPDATE tech_project_manager SET operationtime=\"{0}\",isdel=1 ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.AppendFormat(" WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "iscunzai":
                    #region 管理员信息是否存在
                    info = (tech_project_manager)obj;
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_project_manager ");
                    sb.AppendFormat(" WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" AND mobile = \"{0}\" ", info.mobile);
                    }
                    if (!string.IsNullOrEmpty(info.login_name))
                    {
                        sb.AppendFormat(" AND login_name=\"{0}\" ", info.login_name);
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }

        public tech_project_manager GetModelById(string id)
        {
            tech_project_manager manager = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_project_manager where id={0} and isdel=2", id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                manager = MySQLHelper.ConvertTableToObject<tech_project_manager>(dt)[0];
            }
            return manager;
        }

        public tech_project_manager Login(string login_name, string login_pwd)
        {
            tech_project_manager manager = null;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select * from tech_project_manager where login_name='{0}' and login_pwd='{1}' and isdel=2", login_name, login_pwd);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                manager = MySQLHelper.ConvertTableToObject<tech_project_manager>(dt)[0];
            }
            return manager;
        }

        public DataTable GetTech_project_manager(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_project_manager info = new tech_project_manager();
            switch (type)
            {
                case "select_manager_to_page":  //查询管理员信息（带分页）
                    #region 查询管理员信息（带分页）
                    info = (tech_project_manager)obj;
                    sb.Append(" SELECT * FROM tech_project_manager ");
                    sb.Append(" WHERE isdel=2 ");
                    if (info.id > 0)
                    {
                        sb.AppendFormat(" AND id={0} ", info.id);
                    }                    
                    if (!string.IsNullOrEmpty(info.full_name))
                    {
                        sb.AppendFormat(" AND full_name LIKE \"%{0}%\" ", info.full_name);
                    }
                    if (!string.IsNullOrEmpty(info.login_name))
                    {
                        sb.AppendFormat(" AND login_name = \"{0}\" ", info.login_name);
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" AND mobile = \"{0}\" ", info.mobile);
                    }
                    sb.Append(" ORDER BY id ");
                    int index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_manager":  //查询管理员信息
                    #region 查询管理员信息
                    info = (tech_project_manager)obj;
                    sb.Append(" SELECT * FROM tech_project_manager ");
                    sb.Append(" WHERE isdel=2 ");
                    if (info.id > 0)
                    {
                        sb.AppendFormat(" AND id={0} ", info.id);
                    }
                    if (!string.IsNullOrEmpty(info.full_name))
                    {
                        sb.AppendFormat(" AND full_name LIKE \"%{0}%\" ", info.full_name);
                    }
                    if (!string.IsNullOrEmpty(info.login_name))
                    {
                        sb.AppendFormat(" AND login_name = \"{0}\" ", info.login_name);
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" AND mobile = \"{0}\" ", info.mobile);
                    }
                    sb.Append(" ORDER BY id ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }

    }
}
