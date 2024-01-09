using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace IDAL
{
    public interface Itech_meeting_schedule
    {
        /// <summary>
        /// 根据条件查询会议日程信息
        /// </summary>
        /// <param name="hallid">大厅ID</param>
        /// <param name="dt">时间</param>
        /// <param name="userid">用户ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <returns></returns>
        IList<tech_meeting_schedule> GetList(string hallid, string dt, string userid, int pageIndex);

        /// <summary>
        /// 根据条件查询符合的条数（分页）
        /// </summary>
        /// <param name="hallid">大厅ID</param>
        /// <param name="dt">时间</param>
        /// <param name="userid">用户ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <returns></returns>
        int GetAllCount(string hallid, string dt, string userid);

        /// <summary>
        /// 根据ID删除会议单元日程
        /// </summary>
        /// <param name="ids">日程ID</param>
        /// <returns></returns>
        int Delete(string ids);

        /// <summary>
        /// 根据id获取单元日程信息的详细、
        /// 靳海云
        /// </summary>
        /// <param name="id">单元日程信息id</param>
        /// <returns></returns>
        tech_meeting_schedule GetMeeting_schedule(int id);

        /// <summary>
        /// 更新单元日程
        /// 靳海云
        /// </summary>
        /// <param name="model">实体信息</param>
        /// <returns></returns>
        int Update(tech_meeting_schedule model);

        /// <summary>
        /// 添加会议单元日程
        /// 靳海云
        /// </summary>
        /// <param name="model">实体信息</param>
        /// <returns></returns>
        int Add(tech_meeting_schedule model);

        /// <summary>
        /// 根据条件获取日程信息列表
        /// 靳海云
        /// </summary>
        /// <param name="meetinghall">大厅id</param>
        /// <param name="meetingdate">会议时间</param>
        /// <param name="meetingtype">会议主题</param>
        /// <param name="artauth">论文作者</param>
        /// <param name="publishtype">发表形式</param>
        /// <param name="hire">演讲顺序</param>
        /// <param name="arttype">论文类型</param>
        /// <param name="pageIndex">当前页码</param>
        /// <returns></returns>
        IList<tech_meeting_schedule.meeting_schedule_export> GetExportList(string meetinghall, string meetingdate, string meetingtype, string artauth, string publishtype, string hire, string arttype, int pageIndex);

        /// <summary>
        /// 根据条件获取日程信息列表的数量
        /// 靳海云
        /// </summary>
        /// <param name="meetinghall">大厅id</param>
        /// <param name="meetingdate">会议时间</param>
        /// <param name="meetingtype">会议主题</param>
        /// <param name="artauth">论文作者</param>
        /// <param name="publishtype">发表形式</param>
        /// <param name="hire">演讲顺序</param>
        /// <param name="arttype">论文类型</param>       
        /// <returns></returns>
        int GetExportListCount(string meetinghall, string meetingdate, string meetingtype, string artauth, string publishtype, string hire, string arttype);

        /// <summary>
        /// 论文迁移
        /// 靳海云
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="articleid">论文id</param>
        /// <returns></returns>
        int UpdateSpeaker(string userid, string articleid);

        /// <summary>
        /// 导出日程信息列表
        /// 靳海云
        /// </summary>
        /// <param name="meetinghall">大厅id</param>
        /// <param name="meetingdate">会议时间</param>
        /// <param name="meetingtype">会议主题</param>
        /// <param name="artauth">论文作者</param>
        /// <param name="publishtype">发表形式</param>
        /// <param name="hire">演讲顺序</param>
        /// <param name="arttype">论文类型</param>     
        /// <returns></returns>
        DataTable ExportExcel(string meetinghall, string meetingdate, string meetingtype, string artauth, string publishtype, string hire, string arttype);

        /// <summary>
        /// 根据单元信息id获取单元日程
        /// 靳海云
        /// </summary>
        /// <param name="msgid">单元信息id</param>
        /// <returns></returns>
        IList<tech_meeting_schedule> GetScheduList(string msgid);

        /// <summary>
        /// 更新日程单元信息
        /// 靳海云
        /// </summary>
        /// <param name="model">实体信息</param>
        /// <returns></returns>
        int UpdateSchedule(tech_meeting_schedule model);
        /// <summary>
        /// 获取最大的演讲顺序
        /// </summary>
        /// <param name="msg_id">会议单元id</param>
        /// <returns></returns>
        int GetMaxOrder(int msg_id);

        /// <summary>
        /// 获取发送确认函的用户列表
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="username">用户名</param>
        /// <param name="unitename">单位名称</param>
        /// <param name="mid">会议id</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        IList<tech_user> GetUserList(string userid, string username, string unitename, string mid, int pageindex);

        /// <summary>
        /// 获取发送确认函的用户列表的页数
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="username">用户名</param>
        /// <param name="unitename">单位名称</param>
        /// <param name="mid">会议id</param>      
        /// <returns></returns>
        int GetUserListCount(string userid, string username, string unitename, string mid);

        /// <summary>
        /// 获取用户的日程信息（发送邮件）
        /// 靳海云
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="meetingid">会议id</param>
        /// <returns></returns>
        DataTable GetUserDuty(string userid, string meetingid);

        /// <summary>
        /// 根据条件获取当天的所有日程
        /// 靳海云
        /// </summary>
        /// <param name="hallid">会议厅ID</param>
        /// <param name="meetingid">会议ID</param>
        /// <returns></returns>
        DataTable GetList(string hallid, string meetingid);

        /// <summary>
        /// 获取该会议下的包含会议单元的日程时间
        /// 靳海云
        /// </summary>
        /// <param name="meetingid">会议id</param>
        /// <returns></returns>
        IList<DateTime> GetTimeList(string meetingid, string hallid);

        /// <summary>
        /// 获取日程列表
        /// 靳海云
        /// </summary>
        /// <param name="speakuser">发言人id</param>
        /// <param name="speakerusername">发言人姓名</param>
        /// <param name="meetingtime">会议时间</param>
        /// <param name="hallid">会议厅id</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        IList<tech_meeting_schedule> GetScheduleList(string speakuser, string speakerusername, string meetingtime, string hallid, int pageindex);

        /// <summary>
        /// 获取日程列表总页数
        /// 靳海云
        /// </summary>
        /// <param name="speakuser">发言人id</param>
        /// <param name="speakerusername">发言人姓名</param>
        /// <param name="meetingtime">会议时间</param>
        /// <param name="hallid">会议厅id</param>        
        /// <returns></returns>
        int GetScheduleListCount(string speakuser, string speakerusername, string meetingtime, string hallid);

        /// <summary>
        /// 根据日程id获取到日程信息
        /// 靳海云
        /// </summary>
        /// <param name="scheduleid">日程id</param>
        /// <returns></returns>
        tech_meeting_schedule GetModel(int scheduleid);

        /// <summary>
        /// 更新上传PPT状态
        /// 靳海云
        /// </summary>
        /// <param name="scheduleid">日程id</param>
        /// <returns></returns>
        int UpdatePptStatus(int scheduleid, int status);

        /// <summary>
        /// 导出全部日程
        /// 靳海云
        /// </summary>
        /// <param name="mid">会议id</param>
        /// <returns></returns>
        DataTable GetExportList(string mid, string dt);

        /// <summary>
        /// 导出全部专家提醒
        /// </summary>   
        /// <param name="meetingid"></param>
        /// <returns></returns>
        DataTable ExportUserDuty(string meetingid);


        /// <summary>
        /// 方法说明：根据日程ID返回日程信息，会议单元信息，会议厅信息
        /// 创建人员：lzchina
        /// 创建日期：2014-07-24 10:33
        /// 修改日期：
        /// </summary>
        /// <param name="scid">日程ID</param>
        /// <returns></returns>
        DataTable GetScheduleList(int scid);

        /// <summary>
        /// 方法说明：得到日程信息
        /// 创建人员：Jacky
        /// 创建日期：2014/7/24 17:06
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>日程信息</returns>
        DataTable GetTech_meeting_schedule(tech_meeting_schedule info);
    }
}
