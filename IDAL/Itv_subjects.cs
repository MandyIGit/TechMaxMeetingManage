using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itv_subjects
    {
        /// <summary>
        /// 获取全部的学科
        /// 靳海云
        /// </summary>
        /// <returns></returns>
        IList<tv_subjects> GetList();

        /// <summary>
        /// 方法说明：得到所有学科类别信息
        /// 创建人员：曲福岳
        /// 创建日期：2013/11/6 10:02
        /// 修改日期：
        /// </summary>
        /// <returns>学科类别信息</returns>
        DataTable GetTv_subjects();

        tv_subjects getModel(string v_sid);
    }
}
