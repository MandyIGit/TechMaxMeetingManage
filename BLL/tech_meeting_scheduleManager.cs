using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_meeting_scheduleManager
    {
        Itech_meeting_schedule dal = null;

        static readonly private tech_meeting_scheduleManager _instance = new tech_meeting_scheduleManager();
        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_meeting_scheduleManager Instance
        {
            get { return _instance; }
        }

        public tech_meeting_scheduleManager()
        {
            dal = BLLComm.GetClassInstance("tech_meeting_schedule") as Itech_meeting_schedule;
        }

        /// <summary>
        /// 根据条件查询会议日程信息
        /// </summary>
        /// <param name="hallid">大厅ID</param>
        /// <param name="dt">时间</param>
        /// <param name="userid">用户ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <returns></returns>
        public IList<tech_meeting_schedule> GetList(string hallid, string dt, string userid, int pageIndex)
        {
            return dal.GetList(hallid, dt, userid, pageIndex);
        }

        /// <summary>
        /// 根据条件查询符合的条数（分页）
        /// </summary>
        /// <param name="hallid">大厅ID</param>
        /// <param name="dt">时间</param>
        /// <param name="userid">用户ID</param>
        /// <param name="pageIndex">当前页</param>
        /// <returns></returns>
        public int GetAllCount(string hallid, string dt, string userid)
        {
            return dal.GetAllCount(hallid, dt, userid);
        }

        /// <summary>
        /// 根据ID删除会议单元日程
        /// </summary>
        /// <param name="ids">日程ID</param>
        /// <returns></returns>
        public int Delete(string ids)
        {
            return dal.Delete(ids);
        }
        /// <summary>
        /// 根据id获取单元日程信息的详细、
        /// 靳海云
        /// </summary>
        /// <param name="id">单元日程信息id</param>
        /// <returns></returns>
        public tech_meeting_schedule GetMeeting_schedule(int id)
        {
            return dal.GetMeeting_schedule(id);
        }
        /// <summary>
        /// 更新单元日程
        /// 靳海云
        /// </summary>
        /// <param name="model">实体信息</param>
        /// <returns></returns>
        public int Update(tech_meeting_schedule model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 添加会议单元日程
        /// 靳海云
        /// </summary>
        /// <param name="model">实体信息</param>
        /// <returns></returns>
        public int Add(tech_meeting_schedule model)
        {
            return dal.Add(model);
        }
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
        public IList<tech_meeting_schedule.meeting_schedule_export> GetExportList(string meetinghall, string meetingdate, string meetingtype, string artauth, string publishtype, string hire, string arttype, int pageIndex)
        {
            return dal.GetExportList(meetinghall, meetingdate, meetingtype, artauth, publishtype, hire, arttype, pageIndex);
        }
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
        public int GetExportListCount(string meetinghall, string meetingdate, string meetingtype, string artauth, string publishtype, string hire, string arttype)
        {
            return dal.GetExportListCount(meetinghall, meetingdate, meetingtype, artauth, publishtype, hire, arttype);
        }
        /// <summary>
        /// 论文迁移
        /// 靳海云
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="articleid">论文id</param>
        /// <returns></returns>
        public int UpdateSpeaker(string userid, string articleid)
        {
            return dal.UpdateSpeaker(userid, articleid);
        }
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
        public DataTable ExportExcel(string meetinghall, string meetingdate, string meetingtype, string artauth, string publishtype, string hire, string arttype)
        {
            return dal.ExportExcel(meetinghall, meetingdate, meetingtype, artauth, publishtype, hire, arttype);
        }
        /// <summary>
        /// 根据单元信息id获取单元日程
        /// 靳海云
        /// </summary>
        /// <param name="msgid">单元信息id</param>
        /// <returns></returns>
        public IList<tech_meeting_schedule> GetScheduList(string msgid)
        {
            return dal.GetScheduList(msgid);
        }
        /// <summary>
        /// 更新日程单元信息
        /// 靳海云
        /// </summary>
        /// <param name="model">实体信息</param>
        /// <returns></returns>
        public int UpdateSchedule(tech_meeting_schedule model)
        {
            return dal.UpdateSchedule(model);
        }

        /// <summary>
        /// 获取最大的演讲顺序
        /// </summary>
        /// <param name="msg_id">会议单元id</param>
        /// <returns></returns>
        public int GetMaxOrder(int msg_id)
        {
            return dal.GetMaxOrder(msg_id);
        }

        /// <summary>
        /// 获取发送确认函的用户列表
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="username">用户名</param>
        /// <param name="unitename">单位名称</param>
        /// <param name="mid">会议id</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        public IList<tech_user> GetUserList(string userid, string username, string unitename, string mid, int pageindex)
        {
            return dal.GetUserList(userid, username, unitename, mid, pageindex);
        }

        /// <summary>
        /// 获取发送确认函的用户列表的页数
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="username">用户名</param>
        /// <param name="unitename">单位名称</param>
        /// <param name="mid">会议id</param>      
        /// <returns></returns>
        public int GetUserListCount(string userid, string username, string unitename, string mid)
        {
            return dal.GetUserListCount(userid, username, unitename, mid);
        }

        /// <summary>
        /// 获取用户的日程信息（发送邮件）
        /// 靳海云
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <param name="meetingid">会议id</param>
        /// <returns></returns>
        public DataTable GetUserDuty(string userid, string meetingid)
        {
            return dal.GetUserDuty(userid, meetingid);
        }

        /// <summary>
        /// 根据条件获取当天的所有日程
        /// 靳海云
        /// </summary>
        /// <param name="hallid">会议厅ID</param>
        /// <param name="meetingid">会议ID</param>
        /// <returns></returns>
        public DataTable GetList(string hallid, string meetingid)
        {
            return dal.GetList(hallid, meetingid);
        }

        /// <summary>
        /// 获取该会议下的包含会议单元的日程时间
        /// 靳海云
        /// </summary>
        /// <param name="meetingid">会议id</param>
        /// <returns></returns>
        public IList<DateTime> GetTimeList(string meetingid, string hallid)
        {
            return dal.GetTimeList(meetingid, hallid);
        }

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
        public IList<tech_meeting_schedule> GetScheduleList(string speakuser, string speakerusername, string meetingtime, string hallid, int pageindex)
        {
            return dal.GetScheduleList(speakuser, speakerusername, meetingtime, hallid, pageindex);
        }

        /// <summary>
        /// 获取日程列表总页数
        /// 靳海云
        /// </summary>
        /// <param name="speakuser">发言人id</param>
        /// <param name="speakerusername">发言人姓名</param>
        /// <param name="meetingtime">会议时间</param>
        /// <param name="hallid">会议厅id</param>        
        /// <returns></returns>
        public int GetScheduleListCount(string speakuser, string speakerusername, string meetingtime, string hallid)
        {
            return dal.GetScheduleListCount(speakuser, speakerusername, meetingtime, hallid);
        }

        /// <summary>
        /// 根据日程id获取到日程信息
        /// 靳海云
        /// </summary>
        /// <param name="scheduleid">日程id</param>
        /// <returns></returns>
        public tech_meeting_schedule GetModel(int scheduleid)
        {
            return dal.GetModel(scheduleid);
        }

        /// <summary>
        /// 更新上传PPT状态
        /// 靳海云
        /// </summary>
        /// <param name="scheduleid">日程id</param>
        /// <returns></returns>
        public int UpdatePptStatus(int scheduleid, int status)
        {
            return dal.UpdatePptStatus(scheduleid, status);
        }


        public bool AddUpdateListXml(int schid, string filetext)
        {
            //tech_meeting_schedule_ppt model = new tech_meeting_schedule_pptManager().GetModelSchedule(Convert.ToInt32(schid));
            ////string dt = GetAMPM(model.begintime.ToString());
            //string dt = model.alias_meetingname;
            //// string filename = string.Format("/upload/ppt/{0}/", model.hallid);
            //string filename = string.Format("/upload/ppt/{0}/", model.hallname);

            //return Common.UpdateListHelper.AddUpdateList(filename, filetext);
            return true;
        }
        /// <summary>
        /// 在ＰＰＴ根目录创建ＸＭＬ文件，用于ＰＰＴ试片室
        /// </summary>
        /// <param name="schid"></param>
        /// <param name="filetext"></param>
        /// <returns></returns>
        public bool AddUpdatePPTListXml(int schid, string filetext)
        {
            //tech_meeting_schedule_ppt model = new tech_meeting_schedule_pptManager().GetModelSchedule(Convert.ToInt32(schid));
            ////string dt = GetAMPM(model.begintime.ToString());
            //string dt = model.alias_meetingname;
            //// string filename = string.Format("/upload/ppt/{0}/", model.hallid);
            //string filename = "/upload/ppt/";

            //return Common.UpdateListHelper.AddUpdateList(filename, model.hallname + "\\" + filetext);
            return true;
        }

        public bool RemoveUpdateListXml(int schid, string filetext)
        {
            //tech_meeting_schedule_ppt model = new tech_meeting_schedule_pptManager().GetModelSchedule(Convert.ToInt32(schid));
            ////string dt = GetAMPM(model.begintime.ToString());
            //string dt = model.alias_meetingname;
            //// string filename = string.Format("/upload/ppt/{0}/", model.hallid);
            //string filename = string.Format("/upload/ppt/{0}/", model.hallname);
            //return Common.UpdateListHelper.RemoveNode(filename, filetext);
            return true;
        }

        /// <summary>
        /// 在ＰＰＴ根目录创建ＸＭＬ文件，用于ＰＰＴ试片室
        /// </summary>
        /// <param name="schid"></param>
        /// <param name="filetext"></param>
        /// <returns></returns>
        public bool RemoveUpdatePPTListXml(int schid, string filetext)
        {
            //tech_meeting_schedule_ppt model = new tech_meeting_schedule_pptManager().GetModelSchedule(Convert.ToInt32(schid));
            ////string dt = GetAMPM(model.begintime.ToString());
            //string dt = model.alias_meetingname;
            //// string filename = string.Format("/upload/ppt/{0}/", model.hallid);
            //string filename = string.Format("/upload/ppt/", model.hallname);
            //return Common.UpdateListHelper.RemoveNode(filename, model.hallname + "\\" + filetext);
            return true;
        }
        #region 操作
        protected string GetAMPM(string btime)
        {
            int t = Convert.ToDateTime(btime).Hour;
            if (t > 12 || t == 12)
            {
                return "PM";
            }
            else
            {
                return "AM";
            }
        }

        protected string RemoveStr(string name)
        {
            return name.Replace('/', '_').Replace('\\', '_').Replace(':', '_').Replace('*', '_').Replace('"', '_').Replace('<', '_').Replace('>', '_').Replace('?', '_').Replace('|', '_');
        }
        #endregion

        /// <summary>
        /// 导出全部日程
        /// 靳海云
        /// </summary>
        /// <param name="mid">会议id</param>
        /// <returns></returns>
        public DataTable GetExportList(string mid, string dt)
        {
            return dal.GetExportList(mid, dt);
        }

        /// <summary>
        /// 导出全部专家提醒
        /// </summary>   
        /// <param name="meetingid"></param>
        /// <returns></returns>
        public DataTable ExportUserDuty(string meetingid)
        {
            return dal.ExportUserDuty(meetingid);
        }

        /// <summary>
        /// 方法说明：根据日程ID返回日程信息，会议单元信息，会议厅信息
        /// 创建人员：lzchina
        /// 创建日期：2014-07-24 10:33
        /// 修改日期：
        /// </summary>
        /// <param name="scid">日程ID</param>
        /// <returns></returns>
        public DataTable GetScheduleList(int scid)
        {
            return dal.GetScheduleList(scid);
        }

        #region 得到日程信息
        /// <summary>
        /// 方法说明：得到日程信息
        /// 创建人员：Jacky
        /// 创建日期：2014/7/24 17:06
        /// 修改日期：
        /// </summary>
        /// <param name="info">条件信息</param>
        /// <returns>日程信息</returns>
        public DataTable GetTech_meeting_schedule(tech_meeting_schedule info)
        {
            return dal.GetTech_meeting_schedule(info);
        }
        #endregion
    }
}
