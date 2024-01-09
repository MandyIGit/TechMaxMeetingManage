using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_schedule
    {
        /// <summary>
        /// 根据单元ID获取日程信息
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        DataTable GetScheduleList(string session_id, string meetingmid, string meetingmtyid);

        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        int AddSchedule(tech_schedule model);

        /// <summary>
        /// 根据日程ID获取日程信息
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        DataTable GetSchedule(string sch_id, string session_id, string meetingmid, string meetingmtype);

        /// <summary>
        /// 获取日程信息 人员
        /// </summary>
        /// <param name="sch_id"></param>
        /// <returns></returns>        
        DataTable GetScheduleUser(string sch_id, string meetingmid, string meetingmtype);

        /// <summary>
        /// 更新日程信息
        /// </summary>
        /// <param name="sch"></param>
        /// <returns></returns>
        int UpdateSchedule(tech_schedule sch);

        /// <summary>
        /// 删除日程
        /// </summary>
        /// <param name="sch_id"></param>
        /// <returns></returns>
        int DeleteSchedule(string sch_id);
    }
}
