using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_session
    {
        /// <summary>
        /// 获取时间列表
        /// </summary>
        /// <returns></returns>
        IList<DateTime> GetTimeList(string meetingmid, string meetingmtyid);

        /// <summary>
        /// 添加单元
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        int AddSession(tech_session session);

        /// <summary>
        /// 删除单元
        /// </summary>
        /// <param name="IdS"></param>
        /// <returns></returns>
        int DeleteSessions(string IdS, string meetingmid, string meetingmtyid);

        /// <summary>
        /// 修改单元
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        int UpdateSession(tech_session session);

        /// <summary>
        /// 获取会议厅列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        DataTable GetHallList(string meetingmid);

        /// <summary>
        /// 获取单元信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hallid"></param>
        /// <returns></returns>
        DataTable GetSession(int session_id, string meetingmid);

        /// <summary>
        /// 获取单元列表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hallid"></param>
        /// <returns></returns>
        DataTable GetSessionList(DateTime dt, string hallname, string meetingmid, string meetingmtyid);

        /// <summary>
        /// 查询日程有关人员
        /// </summary>
        /// <param name="sessionid"></param>
        /// <returns></returns>
        DataTable GetSessionListuser(string sessionid, string meetingmid, string meetingmtyid);

        /// <summary>
        /// 获取单元信息 参与人员
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        DataTable GetSessionuser(int session_id, string meetingmid, string meetingmtyid);

        /// <summary>
        /// 获取单元信息
        /// </summary>
        /// <param name="hallname"></param>
        /// <param name="meetingmid"></param>
        /// <param name="meetingmtyid"></param>
        /// <returns></returns>
        DataTable GetSessionByHallname(string hallname, string meetingmid, string meetingmtyid);
    }
}
