using System;
using System.Collections.Generic;
using System.Text;

using IDAL;
using System.Data;
using Model;

namespace BLL
{
    /// <summary>
    /// 学术论文表业务逻辑类
    /// Jacky
    /// 2014-11-11
    /// </summary>
    public class tech_articleManager
    {
        private Itech_article dal = null;

        /// <summary>
        /// 取得实例
        /// </summary>
        public tech_articleManager()
        {
            dal = BLLComm.GetClassInstance("tech_article") as Itech_article;
        }

        static readonly private tech_articleManager _instance = new tech_articleManager();

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_articleManager Instance
        {
            get { return _instance; }
        }

        #region 按条件得到学术论文信息并分页显示
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
        public DataTable GetTech_article(tech_article info, int pageIndex, int pageSize)
        {
            return dal.GetTech_article(info, pageIndex, pageSize);
        }
        #endregion

        #region 按条件得到学术论文信息
        /// <summary>
        /// 方法说明：按条件得到学术论文信息
        /// 创建人员：Jacky
        /// 创建日期：2014/11/11 15:09
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>学术论文信息</returns>
        public DataTable GetTech_article(tech_article info)
        {
            return dal.GetTech_article(info);
        }
        #endregion

        #region 按名字索引查找论文通知
        /// <summary>
        /// 方法说明：按名字索引查找论文通知
        /// 创建人员：李
        /// 创建日期：2015/12/25
        /// 修改日期：
        /// </summary>
        /// <param name="info">名字</param>
        public DataTable GetTech_article(string info)
        {
            return dal.GetTech_article(info);
        }
        #endregion

        #region 按条件得到学术论文信息数
        /// <summary>
        /// 方法说明：按条件得到学术论文信息数
        /// 创建人员：Jacky
        /// 创建日期：2014/11/11 15:10
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>学术论文信息数</returns>
        public int GetTech_article_count(tech_article info)
        {
            return dal.GetTech_article_count(info);
        }
        #endregion

    }
}
