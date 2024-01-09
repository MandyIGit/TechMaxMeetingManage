using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_mobile_versionManager
    {
        private Itech_mobile_version dal = null;
        public tech_mobile_versionManager()
        {
            dal = BLLComm.GetClassInstance("tech_mobile_version") as Itech_mobile_version;
        }

        static readonly private tech_mobile_versionManager _instance = new tech_mobile_versionManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_mobile_versionManager Instance
        {
            get { return _instance; }
        }

        public int Operation(object obj, string type)
        {
            return dal.Operation(obj, type);
        }

        public DataTable GetTech_mobile_version(Object obj, string type)
        {
            return dal.GetTech_mobile_version(obj, type);
        }

        public tech_mobile_version GetModelByVersonId(string v_id)
        {
            return dal.GetModelByVersonId(v_id);
        }
    }
}
