using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_mobile_typeManager
    {
        private Itech_mobile_type dal = null;
        public tech_mobile_typeManager()
        {
            dal = BLLComm.GetClassInstance("tech_mobile_type") as Itech_mobile_type;
        }

        static readonly private tech_mobile_typeManager _instance = new tech_mobile_typeManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_mobile_typeManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }

        public tech_mobile_type GetModelByTypeId(string type_id)
        {
            return dal.GetModelByTypeId(type_id);
        }

        public DataTable GetTech_mobile_type(Object obj, string type)
        {
            return dal.GetTech_mobile_type(obj, type);
        }
    }
}
