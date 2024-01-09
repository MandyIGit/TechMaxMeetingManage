using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_user_all
    {
        /// <summary>
        /// 个人相关信息查询(综合)
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <param name="type">操作类型</param>
        /// <returns>查询结果</returns>
        DataTable GetTech_user_all(tech_user_all info);

        /// <summary>
        /// 方法说明：按条件得到用户及会议注册信息记录数（外宾）
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>用户及会议注册信息记录数</returns>
        int GetTech_user_all_count(tech_user_all info);
    }
}
