using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data;

namespace IDAL
{
    public interface Itv_competence
    {
        /// <summary>
        /// 按管理员ID得到权限信息
        /// </summary>
        /// <param name="sys_code">管理员ID</param>
        /// <returns>权限信息</returns>
        DataTable GetTv_competence(int sys_code);

        /// <summary>
        /// 按管理员ID删除权限信息（真删除）
        /// </summary>
        /// <param name="sys_code">管理员ID</param>
        /// <returns>受影响的行数</returns>
        int DeleteTv_competence(int sys_code);

        /// <summary>
        /// 添加或修改权限信息
        /// </summary>
        /// <param name="info">权限信息</param>
        /// <param name="type">操作类型</param>
        /// <returns>受影响的行数</returns>
        int Add_Update(tv_competence info, string type);
    }
}
