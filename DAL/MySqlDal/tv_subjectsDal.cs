using DBHelper;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.MySqlDal
{
    public class tv_subjectsDal : Itv_subjects
    {
        /// <summary>
        /// 获取全部的学科
        /// 靳海云
        /// </summary>
        /// <returns></returns>
        public IList<tv_subjects> GetList()
        {
            IList<tv_subjects> list = new List<tv_subjects>();
            string sql = "select * from tv_subjects where status=2";
            DataTable dt = MySQLHelper.ExecuteDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                list = MySQLHelper.ConvertTableToObject<tv_subjects>(dt);
            }
            return list;
        }

        #region 得到所有学科类别信息
        /// <summary>
        /// 方法说明：得到所有学科类别信息
        /// 创建人员：曲福岳
        /// 创建日期：2013/11/6 10:02
        /// 修改日期：
        /// </summary>
        /// <returns>学科类别信息</returns>
        public DataTable GetTv_subjects()
        {
            string sql = " SELECT v_sid,v_sname,status,inputtime FROM tv_subjects WHERE status = 2 ";
            return MySQLHelper.ExecuteDataTable(sql);
        }
        #endregion

        public tv_subjects getModel(string v_sid)
        {
            string sql = " SELECT * FROM tv_subjects WHERE status = 2 AND v_sid=" + v_sid;
            DataTable dt = MySQLHelper.ExecuteDataTable(sql);
            return MySQLHelper.ConvertToObject<tv_subjects>(dt.Rows[0]);
        }
    }
}
