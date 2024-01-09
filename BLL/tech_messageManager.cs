using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_messageManager
    {
        private Itech_message dal = null;
        public tech_messageManager()
        {
            dal = BLLComm.GetClassInstance("tech_message") as Itech_message;
        }

        static readonly private tech_messageManager _instance = new tech_messageManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_messageManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetTech_message(Object obj, string type)
        {
            return dal.GetTech_message(obj, type);
        }
        public DataTable GetTechMessage(tech_message model)
        {
            return dal.GetTechMessage(model);
        }
        public tech_message GetModelById(string id)
        {
            return dal.GetModelById(id);
        }

    }
}
