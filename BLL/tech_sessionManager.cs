using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_sessionManager
    {
        Itech_session dal = null;

        static readonly private tech_sessionManager _instance = new tech_sessionManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_sessionManager Instance
        {
            get { return _instance; }
        }

        public tech_sessionManager()
        {
            dal = BLLComm.GetClassInstance("tech_session") as Itech_session;
        }

        /// <summary>
        /// 获取时间列表
        /// </summary>
        /// <returns></returns>
        public IList<DateTime> GetTimeList(string meetingmid, string meetingmtyid)
        {
            return dal.GetTimeList(meetingmid, meetingmtyid);
        }

        /// <summary>
        /// 获取会议厅列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetHallList(string meetingmid)
        {
            return dal.GetHallList(meetingmid);
        }

        /// <summary>
        /// 获取单元列表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hallid"></param>
        /// <returns></returns>
        public DataTable GetSessionList(DateTime dt, string hallname, string meetingmid, string meetingmtyid)
        {
            return dal.GetSessionList(dt, hallname, meetingmid, meetingmtyid);
        }

        /// <summary>
        /// 获取单元信息
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hallid"></param>
        /// <returns></returns>
        public DataTable GetSession(int session_id, string meetingmid)
        {
            return dal.GetSession(session_id, meetingmid);
        }

        /// <summary>
        /// 获取单元信息 参与人员
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public DataTable GetSessionuser(int session_id, string meetingmid, string meetingmtyid)
        {
            return this.dal.GetSessionuser(session_id, meetingmid, meetingmtyid);
        }

        /// <summary>
        /// 获取单元信息 参与人员
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public DataTable GetSessionListuser(string sessionid, string meetingmid, string meetingmtyid)
        {
            return this.dal.GetSessionListuser(sessionid, meetingmid, meetingmtyid);
        }

        /// <summary>
        /// 获取单元信息
        /// </summary>
        /// <param name="hallname"></param>
        /// <param name="meetingmid"></param>
        /// <param name="meetingmtyid"></param>
        public DataTable GetSessionByHallname(string hallname, string meetingmid, string meetingmtyid)
        {
            return dal.GetSessionByHallname(hallname, meetingmid, meetingmtyid);
        }

        /// <summary>
        /// 添加单元
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public int AddSession(tech_session session)
        {
            return dal.AddSession(session);
        }

        /// <summary>
        /// 删除单元
        /// </summary>
        /// <param name="IdS"></param>
        /// <returns></returns>
        public int DeleteSessions(string IdS, string meetingmid, string meetingmtyid)
        {
            return dal.DeleteSessions(IdS, meetingmid, meetingmtyid);
        }

        /// <summary>
        /// 修改单元
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public int UpdateSession(tech_session session)
        {
            return dal.UpdateSession(session);
        }
    }
}
