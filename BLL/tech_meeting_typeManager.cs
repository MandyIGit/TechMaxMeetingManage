using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_meeting_typeManager
    {
        private Itech_meeting_type dal = null;
        public tech_meeting_typeManager()
        {
            dal = BLLComm.GetClassInstance("tech_meeting_type") as Itech_meeting_type;
        }

        static readonly private tech_meeting_typeManager _instance = new tech_meeting_typeManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_meeting_typeManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public tech_meeting_type GetModelByTypeId(string type_id)
        {
            return dal.GetModelByTypeId(type_id);
        }
        public DataTable GetTech_meeting_type(Object obj, string type)
        {
            return dal.GetTech_meeting_type(obj, type);
        }
        public string GetMtype_id()
        {
            return dal.GetMtype_id();
        }
    }
}
