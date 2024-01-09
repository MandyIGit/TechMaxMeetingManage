using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_send_wx_messageManager
    {
        private Itech_send_wx_message dal = null;
        public tech_send_wx_messageManager()
        {
            dal = BLLComm.GetClassInstance("tech_send_wx_message") as Itech_send_wx_message;
        }

        static readonly private tech_send_wx_messageManager _instance = new tech_send_wx_messageManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_send_wx_messageManager Instance
        {
            get { return _instance; }
        }

        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetTech_Send_WX_Message(Object obj, string type)
        {
            return dal.GetTech_Send_WX_Message(obj, type);
        }
        public DataTable GetTech_Send_WX_Message(tech_send_wx_message model)
        {
            return dal.GetTech_Send_WX_Message(model);
        }
        public tech_send_wx_message GetModelById(string id)
        {
            return dal.GetModelById(id);
        }

    }
}
