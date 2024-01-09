using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using IDAL;
using System.Data;

namespace BLL
{
    public class tech_meetingManager
    {
        private Itech_meeting dal = null;
        public tech_meetingManager()
        {
            dal = BLLComm.GetClassInstance("tech_meeting") as Itech_meeting;
        }

        static readonly private tech_meetingManager _instance = new tech_meetingManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_meetingManager Instance
        {
            get { return _instance; }
        }
        public int Operation(Object obj, string type)
        {
            return dal.Operation(obj, type);
        }
        public DataTable GetTech_meeting(Object obj, string type)
        {
            return dal.GetTech_meeting(obj,type);
        }
        public DataTable GetTechMeeting(tech_meeting model)
        {
            return dal.GetTechMeeting(model);
        }
        public tech_meeting MeetingLogin(string mid, string pwd)
        {
            return dal.MeetingLogin(mid, pwd);
        }
        public tech_meeting GetModelByMId(string mid)
        {
            return dal.GetModelByMId(mid);
        }
        public string GetMid()
        {
            return dal.GetMid();
        }

    }
}
