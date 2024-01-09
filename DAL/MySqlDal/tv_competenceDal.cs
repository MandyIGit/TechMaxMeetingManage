using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using DBHelper;
using Model;
using System.Data;
using MySql.Data.MySqlClient;
using System.Reflection;
using Common;

namespace DAL.MySqlDal
{
    public class tv_competenceDal : Itv_competence
    {
        #region 按管理员ID得到权限信息
        /// <summary>
        /// 按管理员ID得到权限信息
        /// </summary>
        /// <param name="sys_code">管理员ID</param>
        /// <returns>权限信息</returns>
        public DataTable GetTv_competence(int sys_code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT sys_code,menu_id FROM tv_competence WHERE sys_code = {0} ORDER BY menu_id ASC ", sys_code);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }
        #endregion

        #region 按管理员ID删除权限信息（真删除）
        /// <summary>
        /// 按管理员ID删除权限信息（真删除）
        /// </summary>
        /// <param name="sys_code">管理员ID</param>
        /// <returns>受影响的行数</returns>
        public int DeleteTv_competence(int sys_code)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" DELETE FROM tv_competence WHERE sys_code = {0} ", sys_code);
            return MySQLHelper.ExecuteNonQuery(sb.ToString());
        }
        #endregion

        #region 添加或修改权限信息
        /// <summary>
        /// 添加或修改权限信息
        /// </summary>
        /// <param name="info">权限信息</param>
        /// <param name="type">操作类型</param>
        /// <returns>受影响的行数</returns>
        public int Add_Update(tv_competence info, string type)
        {
            StringBuilder sb = new StringBuilder();

            switch (type)
            {
                case "add":
                    sb.Append(" INSERT INTO tv_competence(sys_code,menu_id) ");
                    sb.AppendFormat(" VALUES({0},{1}) ", info.Sys_code, info.Menu_id);
                    break;
                case "update":
                    sb.AppendFormat(" UPDATE tv_competence SET sys_code={0},menu_id={1} ", info.Sys_code, info.Menu_id);
                    sb.AppendFormat(" WHERE c_id={0} ", info.C_id);
                    break;
            }

            return MySQLHelper.ExecuteNonQuery(sb.ToString());
        }
        #endregion
    }
}