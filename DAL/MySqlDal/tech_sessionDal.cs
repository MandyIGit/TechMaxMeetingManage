using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Model;
using IDAL;
using DBHelper;
using Common;

namespace DAL.MySqlDal
{
    public class tech_sessionDal : Itech_session
    {
        /// <summary>
        /// 获取时间列表
        /// </summary>
        /// <returns></returns>
        public IList<DateTime> GetTimeList(string meetingmid, string meetingmtyid)
        {
            StringBuilder sb = new StringBuilder();
            IList<DateTime> list = new List<DateTime>();
            sb.Append("SELECT DATE_FORMAT(session_date,'%Y-%m-%d') as dt from tech_session ");
            sb.AppendFormat("where `status`=2 and mtype_id='{0}' and mid='{1}' GROUP BY DATE_FORMAT(session_date,'%y%m%d')", meetingmtyid, meetingmid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(Convert.ToDateTime(dr["dt"]));
                }
            }
            return list;
        }

        /// <summary>
        /// 获取会议厅列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetHallList(string meetingmid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT * FROM tech_meeting_hall WHERE `status`=2 AND mid='{0}' ORDER BY orders ", meetingmid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 获取单元列表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hallname"></param>
        /// <param name="meetingmid"></param>
        /// <param name="meetingmtyid"></param>
        /// <returns></returns>
        public DataTable GetSessionList(DateTime dt, string hallname, string meetingmid, string meetingmtyid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT * FROM tech_session WHERE isdel=2 AND mid='{0}' AND mtype_id='{1}' ", meetingmid, meetingmtyid);
            sb.AppendFormat(" AND session_place_ch='{0}' AND DATE_FORMAT(session_date,'%Y-%m-%d')='{1}' ", hallname, dt.ToString("yyyy-MM-dd"));
            DataTable dat = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dat;
        }

        /// <summary>
        /// 获取单元列表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="hallid"></param>
        /// <param name="meetingmid"></param>
        /// <param name="meetingmtyid"></param>
        /// <returns></returns>
        public DataTable GetSessionList(DateTime dt, int hallid, string meetingmid, string meetingmtyid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT * FROM tech_session WHERE isdel=2 AND mid='{0}' AND mtype_id='{1}' ", meetingmid, meetingmtyid);
            sb.AppendFormat(" AND hall_id='{0}' AND DATE_FORMAT(session_date,'%Y-%m-%d')='{1}' ", hallid, dt.ToString("yyyy-MM-dd"));
            DataTable dat = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dat;
        }

        /// <summary>
		/// 查询日程有关人员
		/// </summary>
		/// <param name="sessionid"></param>
		/// <returns></returns>
        public DataTable GetSessionListuser(string sessionid, string meetingmid, string meetingmtyid)
        {
            StringBuilder sb = new StringBuilder();
            //主持0
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=1 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //点评专家1
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=2 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //翻译2
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=4 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //讨论3
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=5 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //参会4
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=6 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //主席5
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=11 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //执行主席6
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=12 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //分会场主席7
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=13 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //特邀点评嘉宾8
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=14 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //共同主席9
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=15 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //点评讨论10
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=16 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //术者11
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=17 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //手术主持及解说专家12
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=18 UNION ALL ", meetingmid, meetingmtyid, sessionid);
            //名家观点13
            sb.Append(" SELECT GROUP_CONCAT(CONCAT(ren.family_name,ren.given_name)) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE ren.`status`=2 AND richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' AND richeng.role_type=19 ", meetingmid, meetingmtyid, sessionid);

            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 获取单元信息
        /// </summary>
        /// <param name="session_id"></param>
        /// <param name="meetingmid"></param>
        /// <returns></returns>
        public DataTable GetSession(int session_id, string meetingmid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT richeng.session_id,richeng.session_date,richeng.begin_time,richeng.end_time,richeng.session_name_ch,richeng.session_place_ch,di.hallid ");
            sb.Append(" FROM tech_session richeng LEFT JOIN tech_meeting_hall di ON di.hallname=richeng.session_place_ch ");
            sb.AppendFormat(" WHERE richeng.isdel=2 AND richeng.session_id='{0}' AND richeng.mid='{1}' AND di.mid='{1}' ", session_id, meetingmid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 获取单元信息
        /// </summary>
        /// <param name="session_id"></param>
        /// <param name="meetingmid"></param>
        /// <returns></returns>
        public DataTable GetSessionJoinHallid(int session_id, string meetingmid)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT richeng.session_id,richeng.session_date,richeng.begin_time,richeng.end_time,richeng.session_name_ch,richeng.session_place_ch,di.hallid ");
            sb.Append(" FROM tech_session richeng LEFT JOIN tech_meeting_hall di ON di.hallid=richeng.hall_id ");
            sb.AppendFormat(" WHERE richeng.isdel=2 AND richeng.session_id='{0}' AND richeng.mid='{1}' AND di.mid='{1}' ", session_id, meetingmid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 获取单元信息 参与人员
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public DataTable GetSessionuser(int session_id, string meetingmid, string meetingmtyid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT uid.user_code,uid.role_type,CONCAT(ren.family_name,ren.given_name) AS fullname ");
            sb.Append(" FROM tech_meeting_role uid LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=uid.user_code ");
            sb.AppendFormat(" WHERE uid.isDel=2 AND uid.mid='{0}' AND uid.mtype_id='{1}' AND uid.session_id='{2}'", meetingmid, meetingmtyid, session_id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 获取单元信息
        /// </summary>
        /// <param name="hallname"></param>
        /// <param name="meetingmid"></param>
        /// <param name="meetingmtyid"></param>
        /// <returns></returns>
        public DataTable GetSessionByHallname(string hallname, string meetingmid, string meetingmtyid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT * FROM tech_session WHERE isdel=2 AND mid='{0}' AND mtype_id='{1}' ", meetingmid, meetingmtyid);
            sb.AppendFormat(" AND session_place_ch='{0}' ", hallname);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 获取单元信息
        /// </summary>
        /// <param name="hallname"></param>
        /// <param name="meetingmid"></param>
        /// <param name="meetingmtyid"></param>
        /// <returns></returns>
        public DataTable GetSessionByHallid(int hallid, string meetingmid, string meetingmtyid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT * FROM tech_session WHERE isdel=2 AND mid='{0}' AND mtype_id='{1}' ", meetingmid, meetingmtyid);
            sb.AppendFormat(" AND hall_id='{0}' ", hallid);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 添加单元
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public int AddSession(tech_session session)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" INSERT INTO tech_session (session_date,begin_time,end_time,session_name_ch,hall_id,session_place_ch,session_place_en,mid,mtype_id,operatingtime,inputtime) ");
            sb.AppendFormat(" VALUES ('{0}','{1}','{2}','{3}' ",
                session.Session_date.ToString("yyyy-MM-dd HH:mm:ss"),
                session.Session_btime.ToString("yyyy-MM-dd HH:mm:ss"),
                session.Session_etime.ToString("yyyy-MM-dd HH:mm:ss"),
                session.Session_name
            );
            sb.AppendFormat(" ,'{0}',(SELECT hallname FROM tech_meeting_hall WHERE hallid='{0}'),(SELECT en_hallname FROM tech_meeting_hall WHERE hallid='{0}') ", session.Hall_id);
            sb.AppendFormat(" ,'{0}','{1}','{2}','{2}');SELECT @@IDENTITY; ", session.Mid, session.Mtype_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            int i = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
            int result;
            if (i > 0)
            {
                sb.Remove(0, sb.Length);
                if (!string.IsNullOrEmpty(session.Holders))
                {
                    if (session.Holders.Contains(","))
                    {
                        string[] userids = session.Holders.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','1','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','1','{2}','{3}','{4}','{4}'); ",
                            session.Holders,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.Transfers))
                {
                    if (session.Transfers.Contains(","))
                    {
                        string[] userids = session.Transfers.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','4','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','4','{2}','{3}','{4}','{4}'); ",
                            session.Transfers,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.Discussers))
                {
                    if (session.Discussers.Contains(","))
                    {
                        string[] userids = session.Discussers.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','5','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','5','{2}','{3}','{4}','{4}'); ",
                            session.Discussers,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.Reviewers))
                {
                    if (session.Reviewers.Contains(","))
                    {
                        string[] userids = session.Reviewers.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','2','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','2','{2}','{3}','{4}','{4}'); ",
                            session.Reviewers,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.Meetingusers))
                {
                    if (session.Meetingusers.Contains(","))
                    {
                        string[] userids = session.Meetingusers.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','6','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','6','{2}','{3}','{4}','{4}'); ",
                            session.Meetingusers,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }

                if (!string.IsNullOrEmpty(session.zhuxi))
                {
                    if (session.zhuxi.Contains(","))
                    {
                        string[] userids = session.zhuxi.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','11','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','11','{2}','{3}','{4}','{4}'); ",
                            session.zhuxi,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.zhixingzhuxi))
                {
                    if (session.zhixingzhuxi.Contains(","))
                    {
                        string[] userids = session.zhixingzhuxi.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','12','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','12','{2}','{3}','{4}','{4}'); ",
                            session.zhixingzhuxi,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.huiyizhuxi))
                {
                    if (session.huiyizhuxi.Contains(","))
                    {
                        string[] userids = session.huiyizhuxi.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','13','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','13','{2}','{3}','{4}','{4}'); ",
                            session.huiyizhuxi,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.teyaodianpingjiabin))
                {
                    if (session.teyaodianpingjiabin.Contains(","))
                    {
                        string[] userids = session.teyaodianpingjiabin.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','14','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','14','{2}','{3}','{4}','{4}'); ",
                            session.teyaodianpingjiabin,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.pingwei))
                {
                    if (session.pingwei.Contains(","))
                    {
                        string[] userids = session.pingwei.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','15','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','15','{2}','{3}','{4}','{4}'); ",
                            session.pingwei,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.dianpingtaolun))
                {
                    if (session.dianpingtaolun.Contains(","))
                    {
                        string[] userids = session.dianpingtaolun.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','16','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','16','{2}','{3}','{4}','{4}'); ",
                            session.dianpingtaolun,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.shuzhe))
                {
                    if (session.shuzhe.Contains(","))
                    {
                        string[] userids = session.shuzhe.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','17','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','17','{2}','{3}','{4}','{4}'); ",
                            session.shuzhe,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.shoushuzhuchi))
                {
                    if (session.shoushuzhuchi.Contains(","))
                    {
                        string[] userids = session.shoushuzhuchi.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','18','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','18','{2}','{3}','{4}','{4}'); ",
                            session.shoushuzhuchi,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(session.dianpingjiabin))
                {
                    if (session.dianpingjiabin.Contains(","))
                    {
                        string[] userids = session.dianpingjiabin.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string userid = array[j];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','{1}','0','19','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                session.Mid,
                                session.Mtype_id,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','19','{2}','{3}','{4}','{4}'); ",
                            session.dianpingjiabin,
                            i,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }

                if (sb.Length <= 0)
                {
                    result = i;
                }
                else
                {
                    int j = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    result = j;
                }
            }
            else
            {
                result = i;
            }
            return result;
        }


        /// <summary>
        /// 删除单元
        /// </summary>
        /// <param name="IdS"></param>
        /// <returns></returns>
        public int DeleteSessions(string IdS, string meetingmtyid, string meetingmid)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" update tech_meeting_role set isDel=1 where session_id in({0}) and mtype_id='{1}' and mid='{2}'; ", IdS, meetingmtyid, meetingmid);
            sb.AppendFormat(" update tech_session_agenda set isDel=1 where session_id in({0}) and mtype_id='{1}' and mid='{2}'; ", IdS, meetingmtyid, meetingmid);
            sb.AppendFormat(" update tech_session set isdel=1 where session_id in({0}) and mtype_id='{1}' and mid='{2}'; ", IdS, meetingmtyid, meetingmid);
            int i = MySQLHelper.ExecuteNonQuery(sb.ToString());
            return i;
        }

        /// <summary>
        /// 修改单元
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public int UpdateSession(tech_session session)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(" UPDATE tech_session SET session_date='{0}',begin_time='{1}',end_time='{2}',session_name_ch='{3}',session_place_ch= ",
                session.Session_date.ToString("yyyy-MM-dd HH:mm:ss"),
                session.Session_btime.ToString("yyyy-MM-dd HH:mm:ss"),
                session.Session_etime.ToString("yyyy-MM-dd HH:mm:ss"),
                session.Session_name
            );
            sb.AppendFormat(" (SELECT hallname FROM tech_meeting_hall WHERE hallid='{0}') ", session.Hall_id);
            sb.AppendFormat(" ,hall_id='{0}' ", session.Hall_id);
            sb.AppendFormat(" ,operatingtime='{0}' ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            sb.AppendFormat(" WHERE session_id='{0}'; ", session.Session_id);
            sb.AppendFormat(" DELETE FROM tech_meeting_role WHERE isDel=2 AND mid='{0}' AND mtype_id='{1}' AND session_id='{2}'; ", session.Mid, session.Mtype_id, session.Session_id);
            if (!string.IsNullOrEmpty(session.Holders))
            {
                if (session.Holders.Contains(","))
                {
                    string[] userids = session.Holders.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','1','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','1','{2}','{3}','{4}','{4}'); ",
                        session.Holders,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.Transfers))
            {
                if (session.Transfers.Contains(","))
                {
                    string[] userids = session.Transfers.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','4','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','4','{2}','{3}','{4}','{4}'); ",
                        session.Transfers,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.Discussers))
            {
                if (session.Discussers.Contains(","))
                {
                    string[] userids = session.Discussers.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','5','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','5','{2}','{3}','{4}','{4}'); ",
                        session.Discussers,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.Reviewers))
            {
                if (session.Reviewers.Contains(","))
                {
                    string[] userids = session.Reviewers.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','2','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','2','{2}','{3}','{4}','{4}'); ",
                        session.Reviewers,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.Meetingusers))
            {
                if (session.Meetingusers.Contains(","))
                {
                    string[] userids = session.Meetingusers.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','6','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','6','{2}','{3}','{4}','{4}'); ",
                        session.Meetingusers,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.zhuxi))
            {
                if (session.zhuxi.Contains(","))
                {
                    string[] userids = session.zhuxi.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','11','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','11','{2}','{3}','{4}','{4}'); ",
                        session.zhuxi,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.zhixingzhuxi))
            {
                if (session.zhixingzhuxi.Contains(","))
                {
                    string[] userids = session.zhixingzhuxi.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','12','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','12','{2}','{3}','{4}','{4}'); ",
                        session.zhixingzhuxi,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.huiyizhuxi))
            {
                if (session.huiyizhuxi.Contains(","))
                {
                    string[] userids = session.huiyizhuxi.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','13','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','13','{2}','{3}','{4}','{4}'); ",
                        session.huiyizhuxi,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.teyaodianpingjiabin))
            {
                if (session.teyaodianpingjiabin.Contains(","))
                {
                    string[] userids = session.teyaodianpingjiabin.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','14','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','14','{2}','{3}','{4}','{4}'); ",
                        session.teyaodianpingjiabin,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.pingwei))
            {
                if (session.pingwei.Contains(","))
                {
                    string[] userids = session.pingwei.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','15','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','15','{2}','{3}','{4}','{4}'); ",
                        session.pingwei,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.dianpingtaolun))
            {
                if (session.dianpingtaolun.Contains(","))
                {
                    string[] userids = session.dianpingtaolun.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','16','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','16','{2}','{3}','{4}','{4}'); ",
                        session.dianpingtaolun,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.shuzhe))
            {
                if (session.shuzhe.Contains(","))
                {
                    string[] userids = session.shuzhe.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','17','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','17','{2}','{3}','{4}','{4}'); ",
                        session.shuzhe,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.shoushuzhuchi))
            {
                if (session.shoushuzhuchi.Contains(","))
                {
                    string[] userids = session.shoushuzhuchi.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','18','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','18','{2}','{3}','{4}','{4}'); ",
                        session.shoushuzhuchi,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(session.dianpingjiabin))
            {
                if (session.dianpingjiabin.Contains(","))
                {
                    string[] userids = session.dianpingjiabin.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','{1}','0','19','{2}','{3}','{4}','{4}'); ",
                            userid,
                            session.Session_id,
                            session.Mid,
                            session.Mtype_id,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','{1}','0','19','{2}','{3}','{4}','{4}'); ",
                        session.dianpingjiabin,
                        session.Session_id,
                        session.Mid,
                        session.Mtype_id,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            return MySQLHelper.ExecuteNonQuery(sb.ToString());
        }

    }
}
