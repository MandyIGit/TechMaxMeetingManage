using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_meeting_hall
    {
        /// <summary>
        /// 获取所有大厅列表
        /// 靳海云
        /// </summary>
        /// <returns></returns>
        IList<tech_meeting_hall> GetList(string meetingmid);

        /// <summary>
        /// 根据大厅id获取详细信息
        /// 靳海云
        /// </summary>
        /// <param name="hallid">大厅id</param>
        /// <returns></returns>
        tech_meeting_hall GetHallByID(string hallid);

        /// <summary>
        /// 添加会议大厅
        /// 靳海云
        /// </summary>
        /// <param name="model">大厅的实体</param>
        /// <returns></returns>
        int ModiAddHall(tech_meeting_hall model);

        /// <summary>
        /// 删除会议厅
        /// 靳海云
        /// </summary>
        /// <param name="hallid">会议厅id</param>
        /// <returns></returns>
        int DeleteHall(int hallid, string meetingmid);

        /// <summary>
        /// 获取包含日程的会议厅
        /// </summary>
        /// <param name="hallid">大厅id</param>
        /// <param name="meetingtime">会议时间</param>
        /// <param name="meetingid">会议id</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        IList<tech_meeting_hall> GetSchedule_HallList(string hallid, string meetingtime, string meetingid, int pageindex);

        /// <summary>
        /// 获取日程的总页数
        /// 靳海云
        /// </summary>
        /// <param name="hallid">大厅id</param>
        /// <param name="meetingtime">会议时间</param>
        /// <param name="meetingid">会议id</param>
        /// <returns></returns>
        int GetSchedule_HallListCount(string hallid, string meetingtime, string meetingid);

        /// <summary>
        /// 获取会议厅列表
        /// </summary>
        /// <param name="hallid"></param>
        /// <param name="meetingtime"></param>
        /// <param name="meetingid"></param>
        /// <returns></returns>
        IList<tech_meeting_hall> GetHallList(string hallid, string meetingtime, string meetingid);
    }
}
