using IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_meeting_roleManager
    {
        Itech_meeting_role dal = null;
        public tech_meeting_roleManager()
        {
            dal = BLLComm.GetClassInstance("tech_meeting_role") as Itech_meeting_role;
        }

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_meeting_roleManager Instance
        {
            get { return _instance; }
        }

        static readonly private tech_meeting_roleManager _instance = new tech_meeting_roleManager();

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="obj">条件信息</param>
        /// <param name="type">查询类型</param>
        /// <returns>查询结果</returns>
        public DataTable GetTech_meeting_role(Object obj, string type)
        {
            return dal.GetTech_meeting_role(obj, type);
        }
        #endregion

        #region 操作
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="obj">操作信息</param>
        /// <param name="type">操作类型</param>
        /// <returns>操作结果</returns>
        public int Operating(Object obj, string type)
        {
            return dal.Operating(obj, type);
        }
        #endregion
    }
}
