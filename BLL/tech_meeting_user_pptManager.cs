using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BLL
{
    public class tech_meeting_user_pptManager
    {
        private Itech_meeting_user_ppt dal = null;
        static readonly private tech_meeting_user_pptManager _instance = new tech_meeting_user_pptManager();

        /// <summary>
        /// 取得实例
        /// </summary>
        public static tech_meeting_user_pptManager Instance
        {
            get { return _instance; }
        }

        public tech_meeting_user_pptManager()
        {
            dal = BLLComm.GetClassInstance("tech_meeting_user_ppt") as Itech_meeting_user_ppt;
        }

        /// <summary>
        /// 根据姓氏名字查询人员
        /// </summary>
        /// <param name="family_name">姓氏</param>
        /// <param name="given_name">名字</param>
        /// <param name="mtype_id">m_typeid</param>
        /// <returns></returns>
        public DataTable SelectUser(string family_name, string given_name, string mtype_id)
        {
            return dal.SelectUser(family_name, given_name, mtype_id);
        }

        /// <summary>
        /// 添加日程人员
        /// </summary>
        /// <param name="family_name">姓氏</param>
        /// <param name="given_name">名字</param>
        /// <param name="mtype_id">m_typeid</param>
        /// <param name="mid">mid</param>
        /// <returns></returns>
        public int AddscheduleUser(string family_name, string given_name, string mtype_id, string mid)
        {
            return dal.AddscheduleUser(family_name, given_name, mtype_id, mid);
        }

        public int Operation(object obj, string type)
        {
            return dal.Operation(obj, type);
        }

        public IList<tech_meeting_user_ppt> GetList(tech_meeting_user_ppt obj, string type)
        {
            return dal.GetList(obj, type);
        }

        public tech_meeting_user_ppt GetMeetingUser_ppt(int id)
        {
            return dal.GetMeetingUser_ppt(id);
        }

        public DataTable GetMeetingUserByLikeName(tech_meeting_user_ppt info)
        {
            return dal.GetMeetingUserByLikeName(info);
        }

        public tech_meeting_user_ppt GetMeetingUserByName(string mtype_id, string full_name)
        {
            return dal.GetMeetingUserByName(mtype_id, full_name);
        }

    }
}
