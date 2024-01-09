using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tv_subjectsManager
    {
        private Itv_subjects dal = null;

        /// <summary>
        /// 取得实例
        /// </summary>
        public tv_subjectsManager()
        {
            dal = BLLComm.GetClassInstance("tv_subjects") as Itv_subjects;
        }
        static readonly private tv_subjectsManager _instance = new tv_subjectsManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tv_subjectsManager Instance
        {
            get { return _instance; }
        }


        /// <summary>
        /// 获取全部的学科
        /// </summary>
        /// <returns></returns>
        public IList<tv_subjects> GetList()
        {
            return dal.GetList();
        }

        #region 得到所有学科类别信息
        /// <summary>
        /// 得到所有学科类别信息
        /// </summary>
        /// <returns>学科类别信息</returns>
        public DataTable GetTv_subjects()
        {
            return dal.GetTv_subjects();
        }
        #endregion


        public tv_subjects getModel(string v_sid)
        {
            return dal.getModel(v_sid);
        }
    }
}
