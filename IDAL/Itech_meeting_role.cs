using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_meeting_role
    {
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="obj">操作信息</param>
        /// <param name="type">操作类型</param>
        /// <returns>操作结果</returns>
        int Operating(Object obj, string type);


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="obj">条件信息</param>
        /// <param name="type">查询类型</param>
        /// <returns>查询结果</returns>
        DataTable GetTech_meeting_role(Object obj, string type);

    }
}
