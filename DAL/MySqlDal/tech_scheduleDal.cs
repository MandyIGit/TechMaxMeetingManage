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
    public class tech_scheduleDal : Itech_schedule
    {
        /// <summary>
        /// 根据单元ID获取日程信息
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public DataTable GetScheduleList(string session_id, string meetingmid, string meetingmtyid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT richeng.agenda_id,richeng.session_id,richeng.begin_time,richeng.end_time,richeng.agenda_name_ch,CONCAT(ren.family_name,ren.given_name) AS fullname ");
            sb.Append(" FROM tech_session_agenda richeng LEFT JOIN tech_meeting_role uid ON uid.agenda_id=richeng.agenda_id ");
            sb.Append(" LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=uid.user_code ");
            sb.AppendFormat(" WHERE richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.session_id='{2}' ORDER BY richeng.begin_time ", meetingmid, meetingmtyid, session_id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }


        /// <summary>
        /// 添加日程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddSchedule(tech_schedule model)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" INSERT INTO tech_session_agenda (session_id,begin_time,end_time,agenda_name_ch,inputtime,operatingtime,mid,mtype_id)  ");
            sb.AppendFormat(" VALUES ('{0}','{1}','{2}','{3}','{4}','{4}','{5}','{6}');select @@IDENTITY; ",
                model.Session_id,
                Convert.ToDateTime(model.Begintime).ToString("yyyy-MM-dd HH:mm:ss"),
                Convert.ToDateTime(model.Endtime).ToString("yyyy-MM-dd HH:mm:ss"),
                model.Sch_name,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                model.Mid,
                model.Mtyleid);
            int i = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
            int result;
            if (i > 0)
            {
                sb.Remove(0, sb.Length);
                if (!string.IsNullOrEmpty(model.Speaker))
                {
                    if (model.Speaker.Contains(","))
                    {
                        string[] userids = model.Speaker.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','0','{1}','3','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                model.Mid,
                                model.Mtyleid,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','3','{2}','{3}','{4}','{4}'); ",
                            model.Speaker,
                            i,
                            model.Mid,
                            model.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }

                if (!string.IsNullOrEmpty(model.Shuzhe))
                {
                    if (model.Shuzhe.Contains(","))
                    {
                        string[] userids = model.Shuzhe.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','0','{1}','17','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                model.Mid,
                                model.Mtyleid,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','17','{2}','{3}','{4}','{4}'); ",
                            model.Shuzhe,
                            i,
                            model.Mid,
                            model.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }

                if (!string.IsNullOrEmpty(model.Holders))
                {
                    if (model.Holders.Contains(","))
                    {
                        string[] userids = model.Holders.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','0','{1}','1','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                model.Mid,
                                model.Mtyleid,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','1','{2}','{3}','{4}','{4}'); ",
                            model.Holders,
                            i,
                            model.Mid,
                            model.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(model.Transfers))
                {
                    if (model.Transfers.Contains(","))
                    {
                        string[] userids = model.Transfers.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','0','{1}','4','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                model.Mid,
                                model.Mtyleid,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','4','{2}','{3}','{4}','{4}'); ",
                            model.Transfers,
                            i,
                            model.Mid,
                            model.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(model.Reviewers))
                {
                    if (model.Reviewers.Contains(","))
                    {
                        string[] userids = model.Reviewers.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','0','{1}','2','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                model.Mid,
                                model.Mtyleid,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','2','{2}','{3}','{4}','{4}'); ",
                            model.Reviewers,
                            i,
                            model.Mid,
                            model.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (!string.IsNullOrEmpty(model.Discussers))
                {
                    if (model.Discussers.Contains(","))
                    {
                        string[] userids = model.Discussers.Split(new char[]
                        {
                            ','
                        });
                        string[] array = userids;
                        for (int k = 0; k < array.Length; k++)
                        {
                            string userid = array[k];
                            sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.AppendFormat(" VALUES ('{0}','0','{1}','5','{2}','{3}','{4}','{4}'); ",
                                userid,
                                i,
                                model.Mid,
                                model.Mtyleid,
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                            );
                        }
                    }
                    else
                    {
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','5','{2}','{3}','{4}','{4}'); ",
                            model.Discussers,
                            i,
                            model.Mid,
                            model.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                if (sb.Length > 0)
                {
                    int j = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    if (j > 0)
                    {
                        result = j;
                    }
                    else
                    {
                        result = i;
                    }
                }
                else
                {
                    result = i;
                }
            }
            else
            {
                result = i;
            }
            return result;
        }

        /// <summary>
        /// 根据日程ID获取日程信息
        /// </summary>
        /// <param name="session_id"></param>
        /// <returns></returns>
        public DataTable GetSchedule(string sch_id, string session_id, string meetingmid, string meetingmtype)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM tech_session_agenda WHERE isDel=2 AND agenda_id='{0}' AND session_id='{1}' AND mid='{2}' AND mtype_id='{3}' ", sch_id, session_id, meetingmid, meetingmtype);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        /// <summary>
        /// 获取日程信息 人员
        /// </summary>
        /// <param name="sch_id"></param>
        /// <returns></returns>
        public DataTable GetScheduleUser(string sch_id, string meetingmid, string meetingmtype)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT richeng.roleid,richeng.user_code,richeng.role_type,CONCAT(ren.family_name,ren.given_name) AS fullname ");
            sb.Append(" FROM tech_meeting_role richeng LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=richeng.user_code ");
            sb.AppendFormat(" WHERE richeng.isDel=2 AND richeng.mid='{0}' AND richeng.mtype_id='{1}' AND richeng.agenda_id='{2}' ", meetingmid, meetingmtype, sch_id);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 更新日程信息
        /// </summary>
        /// <param name="sch"></param>
        /// <returns></returns>
        public int UpdateSchedule(tech_schedule sch)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" UPDATE tech_session_agenda SET begin_time='{0}',end_time='{1}',agenda_name_ch='{2}',operatingtime='{3}' WHERE isDel=2 AND agenda_id='{4}'; ", new object[]
            {
                Convert.ToDateTime(sch.Begintime).ToString("yyyy-MM-dd HH:mm:ss"),
                Convert.ToDateTime(sch.Endtime).ToString("yyyy-MM-dd HH:mm:ss"),
                sch.Sch_name,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                sch.Sch_id
            });
            sb.AppendFormat(" DELETE FROM tech_meeting_role WHERE isDel=2 AND mid='{0}' AND mtype_id='{1}' AND agenda_id='{2}'; ", sch.Mid, sch.Mtyleid, sch.Sch_id);

            if (!string.IsNullOrEmpty(sch.Speaker))
            {
                if (sch.Speaker.Contains(","))
                {
                    string[] userids = sch.Speaker.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','3','{2}','{3}','{4}','{4}'); ",
                            userid,
                            sch.Sch_id,
                            sch.Mid,
                            sch.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','0','{1}','3','{2}','{3}','{4}','{4}'); ",
                        sch.Speaker,
                        sch.Sch_id,
                        sch.Mid,
                        sch.Mtyleid,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }

            if (!string.IsNullOrEmpty(sch.Shuzhe))
            {
                if (sch.Shuzhe.Contains(","))
                {
                    string[] userids = sch.Shuzhe.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','17','{2}','{3}','{4}','{4}'); ",
                            userid,
                            sch.Sch_id,
                            sch.Mid,
                            sch.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','0','{1}','17','{2}','{3}','{4}','{4}'); ",
                        sch.Shuzhe,
                        sch.Sch_id,
                        sch.Mid,
                        sch.Mtyleid,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }

            if (!string.IsNullOrEmpty(sch.Holders))
            {
                if (sch.Holders.Contains(","))
                {
                    string[] userids = sch.Holders.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','1','{2}','{3}','{4}','{4}'); ",
                            userid,
                            sch.Sch_id,
                            sch.Mid,
                            sch.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','0','{1}','1','{2}','{3}','{4}','{4}'); ",
                        sch.Holders,
                        sch.Sch_id,
                        sch.Mid,
                        sch.Mtyleid,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(sch.Transfers))
            {
                if (sch.Transfers.Contains(","))
                {
                    string[] userids = sch.Transfers.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','4','{2}','{3}','{4}','{4}'); ",
                            userid,
                            sch.Sch_id,
                            sch.Mid,
                            sch.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','0','{1}','4','{2}','{3}','{4}','{4}'); ",
                        sch.Transfers,
                        sch.Sch_id,
                        sch.Mid,
                        sch.Mtyleid,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(sch.Reviewers))
            {
                if (sch.Reviewers.Contains(","))
                {
                    string[] userids = sch.Reviewers.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','2','{2}','{3}','{4}','{4}'); ",
                            userid,
                            sch.Sch_id,
                            sch.Mid,
                            sch.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','0','{1}','2','{2}','{3}','{4}','{4}'); ",
                        sch.Reviewers,
                        sch.Sch_id,
                        sch.Mid,
                        sch.Mtyleid,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            if (!string.IsNullOrEmpty(sch.Discussers))
            {
                if (sch.Discussers.Contains(","))
                {
                    string[] userids = sch.Discussers.Split(new char[]
                    {
                        ','
                    });
                    string[] array = userids;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string userid = array[i];
                        sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                        sb.AppendFormat(" VALUES ('{0}','0','{1}','5','{2}','{3}','{4}','{4}'); ",
                            userid,
                            sch.Sch_id,
                            sch.Mid,
                            sch.Mtyleid,
                            DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        );
                    }
                }
                else
                {
                    sb.Append(" INSERT INTO tech_meeting_role (user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.AppendFormat(" VALUES ('{0}','0','{1}','5','{2}','{3}','{4}','{4}'); ",
                        sch.Discussers,
                        sch.Sch_id,
                        sch.Mid,
                        sch.Mtyleid,
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    );
                }
            }
            return MySQLHelper.ExecuteNonQuery(sb.ToString());
        }


        /// <summary>
        /// 删除日程
        /// </summary>
        /// <param name="sch_id"></param>
        /// <returns></returns>
        public int DeleteSchedule(string sch_id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" UPDATE tech_session_agenda SET isDel=1 WHERE isDel=2 AND agenda_id='{0}'; ", sch_id);
            sb.AppendFormat(" UPDATE tech_meeting_role SET isDel=1 WHERE isDel=2 AND agenda_id='{0}'; ", sch_id);
            int i = MySQLHelper.ExecuteNonQuery(sb.ToString());
            return i;
        }
    }
}
