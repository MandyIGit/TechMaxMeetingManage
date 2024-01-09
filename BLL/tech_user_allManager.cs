using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_user_allManager
    {
        private Itech_user_all dal = null;

        public tech_user_allManager()
        {
            dal = BLLComm.GetClassInstance("tech_user_all") as Itech_user_all;
        }

        static readonly private tech_user_allManager _instance = new tech_user_allManager();

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_user_allManager Instance
        {
            get { return _instance; }
        }

        public DataTable GetTech_user_all(tech_user_all info)
        {
            return dal.GetTech_user_all(info);
        }

        public int GetTech_user_all_count(tech_user_all info)
        {
            return dal.GetTech_user_all_count(info);
        }
    }
}
