using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_operating_recordManager
    {
        Itech_operating_record dal = null;

        static readonly private tech_operating_recordManager _instance = new tech_operating_recordManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_operating_recordManager Instance
        {
            get { return _instance; }
        }

        public tech_operating_recordManager()
        {
            dal = BLLComm.GetClassInstance("tech_operating_record") as Itech_operating_record;
        }

        public int Operating(tech_operating_record info, string type)
        {
            return dal.Operating(info, type);
        }

        public DataTable GetTech_operation_record(Object obj, string type)
        {
            return dal.GetTech_operation_record(obj, type);
        }

    }
}
