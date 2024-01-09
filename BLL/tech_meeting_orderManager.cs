using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_meeting_orderManager
    {
        private Itech_meeting_order dal = null;

        public tech_meeting_orderManager()
        {
            dal = BLLComm.GetClassInstance("tech_meeting_order") as Itech_meeting_order;
        }

        static readonly private tech_meeting_orderManager _instance = new tech_meeting_orderManager();

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_meeting_orderManager Instance
        {
            get { return _instance; }
        }

        public DataTable GetTech_meeting_order(string user_code)
        {
            return dal.GetTech_meeting_order(user_code);
        }
    }
}
