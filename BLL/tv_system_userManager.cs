using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tv_system_userManager
    {
        private Itv_system_user dal = null;

        /// <summary>
        /// 取得实例
        /// </summary>
        public tv_system_userManager()
        {
            dal = BLLComm.GetClassInstance("tv_system_user") as Itv_system_user;
        }

        static readonly private tv_system_userManager _instance = new tv_system_userManager();

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tv_system_userManager Instance
        {
            get { return _instance; }
        }

        #region 按条件得到管理员信息
        public DataTable GetTv_system_user(tv_system_user info)
        {
            return dal.GetTv_system_user(info);
        }
        #endregion

        #region 按条件得到管理员信息并分页显示
        public DataTable GetTv_system_user(tv_system_user info, int pageIndex, int pageSize)
        {
            return dal.GetTv_system_user(info, pageIndex, pageSize);
        }
        #endregion

        #region 按条件得到所有管理员记录数
        public int GetTv_system_user_count(tv_system_user info)
        {
            return dal.GetTv_system_user_count(info);
        }
        #endregion

        #region 添加或修改管理员信息
        public int Add_Update(tv_system_user info, string type)
        {
            return dal.Add_Update(info, type);
        }
        #endregion

        #region 删除管理员信息
        public int Delete_system_user(string id_array, string mid)
        {
            return dal.Delete_system_user(id_array, mid);
        }
        #endregion
    }
}
