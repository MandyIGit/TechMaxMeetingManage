using System;
using System.Collections.Generic;
using System.Text;

using Model;
using System.Data;

namespace IDAL
{
    /// <summary>
    /// 学术论文表接口
    /// Jacky
    /// 2014-11-11
    /// </summary>
    public interface Itech_article
    {

        /// <summary>
        /// 方法说明：按条件得到学术论文信息并分页显示
        /// 创建人员：Jacky
        /// 创建日期：2014/11/11 13:30
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <param name="pageIndex">当前页数</param>
        /// <param name="pageSize">每页显示记录数</param>
        /// <returns>学术论文信息</returns>
        DataTable GetTech_article(tech_article info, int pageIndex, int pageSize);

        /// <summary>
        /// 方法说明：按条件得到学术论文信息
        /// 创建人员：Jacky
        /// 创建日期：2014/11/11 15:09
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>学术论文信息</returns>
        DataTable GetTech_article(tech_article info);

        /// <summary>
        /// 方法说明：按名字索引查找论文通知
        /// 创建人员：李
        /// 创建日期：2015/12/25
        /// 修改日期：
        /// </summary>
        /// <param name="info">名字</param>
        DataTable GetTech_article(string info);

        /// <summary>
        /// 方法说明：按条件得到学术论文信息数
        /// 创建人员：Jacky
        /// 创建日期：2014/11/11 15:10
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>学术论文信息数</returns>
        int GetTech_article_count(tech_article info);
    }
}
