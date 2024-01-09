using DBHelper;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DAL.MySqlDal
{
    public class tech_meeting_hallDal : Itech_meeting_hall
    {
        private int pagesize = 3;
        /// <summary>
        /// 获取所有大厅信息
        /// 靳海云
        /// </summary>
        /// <returns></returns>
        public IList<tech_meeting_hall> GetList(string meetingmid)
        {
            IList<tech_meeting_hall> list = new List<tech_meeting_hall>();
            string sql = string.Format(@"select hall.*,meeting.mname as meetingname from tech_meeting_hall hall Left join tech_meeting meeting on meeting.mid=hall.mid where hall.status=2 and hall.mid='{0}'", meetingmid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                list = MySQLHelper.ConvertTableToObject<tech_meeting_hall>(dt);
            }
            return list;
        }

        /// <summary>
        /// 根据hallid查询大厅信息
        /// 靳海云
        /// </summary>
        /// <param name="hallid">大厅id</param>
        /// <returns></returns>
        public tech_meeting_hall GetHallByID(string hallid)
        {
            string sql = "select * from tech_meeting_hall where status=2 and hallid=" + hallid;
            tech_meeting_hall model = new tech_meeting_hall();
            DataTable dt = MySQLHelper.ExecuteDataTable(sql);
            return MySQLHelper.ConvertTableToObject<tech_meeting_hall>(dt).Count > 0 ? MySQLHelper.ConvertTableToObject<tech_meeting_hall>(dt)[0] : model;
        }
        /// <summary>
        /// 修改和添加大厅
        /// 靳海云
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int ModiAddHall(tech_meeting_hall model)
        {
            string sql = string.Empty;
            if (model.Hallid == 0)
            {
                sql = string.Format("insert into tech_meeting_hall (hallname,en_hallname,orders,mid,inputtime) values ('{0}','{1}','{2}','{3}','{4}')", model.Hallname, model.En_hallname, model.Orders, model.Mid, model.Inputtime);
            }
            else
            {
                sql = string.Format("SELECT hallname FROM tech_meeting_hall WHERE hallid={0}", model.Hallid);
                string di_name = Convert.ToString(MySQLHelper.ExecuteScalar(sql));
                sql = string.Format("update tech_meeting_hall set hallname='{0}',en_hallname='{1}',orders={2},mid='{3}' where hallid={4};", model.Hallname, model.En_hallname, model.Orders, model.Mid, model.Hallid);

                sql += string.Format("update tech_session set session_place_ch='{0}',session_place_en='{1}',zhibo_url='{2}',channelId='{3}',secretkey='{4}' WHERE isdel=2 AND mid='{5}' AND session_place_ch='{6}';", model.Hallname, model.En_hallname, model.zhibo_url, model.channelId, model.secretkey, model.Mid, di_name);
            }
            int i = MySQLHelper.ExecuteNonQuery(sql);
            return i;
        }

        /// <summary>
        /// 删除会议厅
        /// 靳海云
        /// </summary>
        /// <param name="hallid">会议厅id</param>
        /// <returns></returns>
        public int DeleteHall(int hallid, string meetingmid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" update tech_session set isdel=1 WHERE mid='{0}' AND session_place_ch=(SELECT hallname FROM tech_meeting_hall WHERE hallid={1}); ", meetingmid, hallid);
            sb.Append("update tech_meeting_hall set `status`=1 ");
            sb.AppendFormat(" where hallid={0};", hallid);
            return MySQLHelper.ExecuteNonQuery(sb.ToString());
        }
        /// <summary>
        /// 获取包含日程的会议厅
        /// 靳海云
        /// </summary>
        /// <param name="hallid">大厅id</param>
        /// <param name="meetingtime">会议时间</param>
        /// <param name="meetingid">会议id</param>
        /// <param name="pageindex">当前页码</param>
        /// <returns></returns>
        public IList<tech_meeting_hall> GetSchedule_HallList(string hallid, string meetingtime, string meetingid, int pageindex)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from tech_meeting_hall where status=2 and hallid in (");
            sb.Append("select hallid from tech_meeting_msg ");
            sb.AppendFormat(" where (hallid='{0}' or '{0}'='0')", hallid);
            sb.AppendFormat(" and (meetingtime='{0}' or '{0}'='0')", meetingtime);
            sb.AppendFormat(" and mid='{0}' and `status` = 2  )", meetingid);
            sb.AppendFormat(" limit {0},{1}", (pageindex - 1) * pagesize, pagesize);
            IList<tech_meeting_hall> list = new List<tech_meeting_hall>();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            list = MySQLHelper.ConvertTableToObject<tech_meeting_hall>(dt);
            return list;
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
            StringBuilder sb = new StringBuilder();
            sb.Append("select count(1) from tech_meeting_hall where status=2 and hallid in ( ");
            sb.Append("select hallid from tech_meeting_msg ");
            sb.AppendFormat(" where (hallid='{0}' or '{0}'='0')", hallid);
            sb.AppendFormat(" and (meetingtime='{0}' or '{0}'='0')", meetingtime);
            sb.AppendFormat(" and mid='{0}' and `status` = 2  )", meetingid);
            int i = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
            if (i >= 0) { if (i % pagesize == 0) { return i / pagesize; } else { return i / pagesize + 1; } } else { return 0; }
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
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" select * from tech_meeting_hall where status=2 and hallid in (");
            sb.Append("select hallid from tech_meeting_msg ");
            sb.AppendFormat(" where (hallid='{0}' or '{0}'='0')", hallid);
            sb.AppendFormat(" and (meetingtime='{0}' or '{0}'='0')", meetingtime);
            sb.AppendFormat(" and mid='{0}' and `status` = 2  )", meetingid);

            IList<tech_meeting_hall> list = new List<tech_meeting_hall>();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null && dt.Rows.Count > 0)
            {
                list = MySQLHelper.ConvertTableToObject<tech_meeting_hall>(dt);
            }
            return list;
        }
    }
}
