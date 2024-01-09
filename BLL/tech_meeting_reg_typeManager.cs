using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_meeting_reg_typeManager
    {
        private Itech_meeting_reg_type dal = null;
        public tech_meeting_reg_typeManager()
        {
            dal = BLLComm.GetClassInstance("tech_meeting_reg_type") as Itech_meeting_reg_type;
        }

        static readonly private tech_meeting_reg_typeManager _instance = new tech_meeting_reg_typeManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_meeting_reg_typeManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetTech_meeting_reg_type(Object obj, string type)
        {
            return dal.GetTech_meeting_reg_type(obj, type);
        }
        public DataTable GetTechMeetingRegType(tech_meeting_reg_type model)
        {
            return dal.GetTechMeetingRegType(model);
        }
        public tech_meeting_reg_type GetModelById(int id)
        {
            return dal.GetModelById(id);
        }
    }
}
