using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_meeting_hallManager
    {
        Itech_meeting_hall dal = null;
        static readonly private tech_meeting_hallManager _instance = new tech_meeting_hallManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_meeting_hallManager Instance
        {
            get { return _instance; }
        }

        public tech_meeting_hallManager()
        {
            dal = BLLComm.GetClassInstance("tech_meeting_hall") as Itech_meeting_hall;
        }
        /// <summary>
        /// 获取所有会议大厅列表
        /// 靳海云
        /// </summary>
        /// <returns></returns>
        public IList<tech_meeting_hall> GetList(string meetingmid)
        {
            return dal.GetList(meetingmid);
        }
        /// <summary>
        /// 根据大厅id获取单个会议大厅的详细信息
        /// 靳海云
        /// </summary>
        /// <param name="hallid">大厅id</param>
        /// <returns></returns>
        public tech_meeting_hall GetHallByID(string hallid)
        {
            return dal.GetHallByID(hallid);
        }
        /// <summary>
        /// 添加和修改会议大厅
        /// 靳海云
        /// </summary>
        /// <param name="model">大厅的实体信息</param>
        /// <returns></returns>
        public int ModiAddHall(tech_meeting_hall model)
        {
            return dal.ModiAddHall(model);
        }

        /// <summary>
        /// 删除会议厅
        /// 靳海云
        /// </summary>
        /// <param name="hallid">会议厅id</param>
        /// <returns></returns>
        public int DeleteHall(int hallid, string meetingmid)
        {
            return dal.DeleteHall(hallid, meetingmid);
        }

        /// <summary>
        /// 获取包含日程的会议厅
        /// </summary>
        /// <param name="hallid">大厅id</param>
        /// <param name="meetingtime">会议时间</param>
        /// <param name="meetingid">会议id</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        public IList<tech_meeting_hall> GetSchedule_HallList(string hallid, string meetingtime, string meetingid, int pageindex)
        {
            return dal.GetSchedule_HallList(hallid, meetingtime, meetingid, pageindex);
        }

        /// <summary>
        /// 获取日程的总页数
        /// 靳海云
        /// </summary>
        /// <param name="hallid">大厅id</param>
        /// <param name="meetingtime">会议时间</param>
        /// <param name="meetingid">会议id</param>
        /// <returns></returns>
        public int GetSchedule_HallListCount(string hallid, string meetingtime, string meetingid)
        {
            return dal.GetSchedule_HallListCount(hallid, meetingtime, meetingid);
        }

        /// <summary>
        /// 获取会议厅列表
        /// </summary>
        /// <param name="hallid"></param>
        /// <param name="meetingtime"></param>
        /// <param name="meetingid"></param>
        /// <returns></returns>
        public IList<tech_meeting_hall> GetHallList(string hallid, string meetingtime, string meetingid)
        {
            return dal.GetHallList(hallid, meetingtime, meetingid);
        }
    }
}
