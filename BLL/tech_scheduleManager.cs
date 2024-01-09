using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_scheduleManager
    {
        Itech_schedule dal = null;

        static readonly private tech_scheduleManager _instance = new tech_scheduleManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_scheduleManager Instance
        {
            get { return _instance; }
        }

        public tech_scheduleManager()
        {
            dal = BLLComm.GetClassInstance("tech_schedule") as Itech_schedule;
        }

        /// <summary>
        /// 根据单元ID获取日程信息
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public DataTable GetScheduleList(string session_id, string meetingmid, string meetingmtyid)
        {
            return dal.GetScheduleList(session_id, meetingmid, meetingmtyid);
        }

        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSchedule(tech_schedule model)
        {
            return dal.AddSchedule(model);
        }

        /// <summary>
        /// 根据日程ID获取日程信息
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public DataTable GetSchedule(string sch_id, string session_id, string meetingmid, string meetingmtype)
        {
            return dal.GetSchedule(sch_id, session_id, meetingmid, meetingmtype);
        }

        /// <summary>
        /// 获取日程信息 人员
        /// </summary>
        /// <param name="sch_id"></param>
        /// <returns></returns>
        public DataTable GetScheduleUser(string sch_id, string meetingmid, string meetingmtype)
        {
            return this.dal.GetScheduleUser(sch_id, meetingmid, meetingmtype);
        }

        /// <summary>
        /// 更新日程信息
        /// </summary>
        /// <param name="sch"></param>
        /// <returns></returns>
        public int UpdateSchedule(tech_schedule sch)
        {
            return dal.UpdateSchedule(sch);
        }

        /// <summary>
        /// 删除日程
        /// </summary>
        /// <param name="sch_id"></param>
        /// <returns></returns>
        public int DeleteSchedule(string sch_id)
        {
            return dal.DeleteSchedule(sch_id);
        }
    }
}
