using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tv_competenceManager
    {
        private Itv_competence dal = null;

        /// <summary>
        /// 取得实例
        /// </summary>
        public tv_competenceManager()
        {
            dal = BLLComm.GetClassInstance("tv_competence") as Itv_competence;
        }
        static readonly private tv_competenceManager _instance = new tv_competenceManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tv_competenceManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// 按管理员ID得到权限信息
        /// </summary>
        /// <param name="sys_code">管理员ID</param>
        /// <returns>权限信息</returns>
        public DataTable GetTv_competence(int sys_code)
        {
            return dal.GetTv_competence(sys_code);
        }

        /// <summary>
        /// 按管理员ID删除权限信息（真删除）
        /// </summary>
        /// <param name="sys_code">管理员ID</param>
        /// <returns>受影响的行数</returns>
        public int DeleteTv_competence(int sys_code)
        {
            return dal.DeleteTv_competence(sys_code);
        }

        /// <summary>
        /// 添加或修改权限信息
        /// </summary>
        /// <param name="info">权限信息</param>
        /// <param name="type">操作类型</param>
        /// <returns>受影响的行数</returns>
        public int Add_Update(tv_competence info, string type)
        {
            return dal.Add_Update(info, type);
        }
    }
}
