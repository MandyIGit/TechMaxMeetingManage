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
    public class tech_meeting_roleDal : Itech_meeting_role
    {
        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="obj">条件信息</param>
        /// <param name="type">查询类型</param>
        /// <returns>查询结果</returns>
        public DataTable GetTech_meeting_role(Object obj, string type)
        {
            DataTable dt = null;
            int index = 0;
            StringBuilder sb = new StringBuilder();
            tech_meeting_role info = new tech_meeting_role();
            int num = 0;
            string str = "";
            switch (type)
            {
                case "select_metting_role_li_CAZ": //查询除了A-z的特殊人名
                    #region 查询除了A-z的特殊人名
                    info = (tech_meeting_role)obj;
                    sb.Append("select one.user_code,two.puid,CONCAT(two.family_name,two.given_name) as full_name from tech_meeting_role one LEFT JOIN tech_meeting_user_ppt two ON one.user_code=two.puid ");
                    sb.Append(" where Left(two.family_name_pinyin,1) NOT BETWEEN 'a' AND 'z' ");
                    sb.AppendFormat(" AND one.isDel=2 AND one.mid='{0}' AND one.mtype_id='{1}' ", info.Mid, info.Mtype_id);
                    sb.Append(" GROUP BY one.user_code order by two.family_name_pinyin asc");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_metting_role_li_AZ":   //查询A-Z的人名
                    #region 查询A-Z的人名
                    info = (tech_meeting_role)obj;
                    sb.Append(" select one.user_code,two.puid,CONCAT(two.family_name,two.given_name) as full_name from tech_meeting_role one LEFT JOIN tech_meeting_user_ppt two ON one.user_code=two.puid ");
                    sb.AppendFormat(" where Left(two.family_name_pinyin,1)='{0}' AND one.isDel=2 AND one.mid='{1}' AND one.mtype_id='{2}'  ", info.AZ, info.Mid, info.Mtype_id);
                    sb.Append(" GROUP BY one.user_code order by two.family_name_pinyin asc ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_meeting_role_li":  //查询角色信息 带分组排列
                    #region 查询角色信息
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT tmr.roleid,tmr.user_code,ren.puid,ren.family_name,ren.given_name,ren.family_name_pinyin,ren.unit ");
                    sb.Append(" ,tmr.session_id,tmr.agenda_id,tmr.role_type,tmr.mid,tmr.mtype_id,tmr.isDel,tmr.isAccept ");
                    sb.Append(" ,tmr.operatingtime,tmr.isSend,tmr.inputtime,ren.user_type,tmr.video_url ");
                    sb.Append(" ,CONCAT(ren.family_name,ren.given_name) AS full_name_ch ");
                    sb.Append(" ,CONCAT(ren.given_name,\" \",ren.family_name) AS full_name_en ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.AppendFormat(" WHERE tmr.isDel=2 AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" ", info.Mid, info.Mtype_id);
                    if (info.Role_type > 0)
                    {
                        sb.AppendFormat(" AND tmr.role_type={0} ", info.Role_type);
                    }
                    if (info.Session_id > 0)
                    {
                        sb.AppendFormat(" AND tmr.session_id={0} ", info.Session_id);
                    }
                    if (info.Agenda_id > 0)
                    {
                        sb.AppendFormat(" AND tmr.agenda_id={0} ", info.Agenda_id);
                    }
                    sb.Append(" ORDER BY ren.family_name_pinyin ASC");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_meeting_role":  //查询角色信息 不带分组排列
                    #region 查询角色信息
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT tmr.roleid,tmr.user_code,ren.puid,ren.family_name,ren.given_name,ren.unit,ren.user_type ");
                    sb.Append(" ,tmr.session_id,tmr.agenda_id,tmr.role_type,tmr.mid,tmr.mtype_id,tmr.isDel,tmr.isAccept ");
                    sb.Append(" ,tmr.operatingtime,tmr.isSend,tmr.inputtime,tmr.video_url ");
                    sb.Append(" ,CONCAT(ren.family_name,ren.given_name) AS full_name_ch ");
                    sb.Append(" ,CONCAT(ren.given_name,\" \",ren.family_name) AS full_name_en ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.AppendFormat(" WHERE tmr.isDel=2 AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" ", info.Mid, info.Mtype_id);
                    if (info.Role_type > 0)
                    {
                        sb.AppendFormat(" AND tmr.role_type={0} ", info.Role_type);
                    }
                    if (info.Session_id > 0)
                    {
                        sb.AppendFormat(" AND tmr.session_id={0} ", info.Session_id);
                    }
                    if (info.Agenda_id > 0)
                    {
                        sb.AppendFormat(" AND tmr.agenda_id={0} ", info.Agenda_id);
                    }
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_user_agenda":  //查询指定人员的讲者身份详细日程
                    #region 查询指定人员的讲者身份详细日程
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT tmr.roleid,tmr.user_code,ren.puid,tmr.session_id,tmr.agenda_id,tmr.role_type,ren.family_name,ren.given_name,ren.unit ");
                    sb.Append(" ,CONCAT(ren.family_name,ren.given_name) AS full_name_ch,CONCAT(ren.given_name,\" \",ren.family_name) AS full_name_en ");
                    sb.Append(" ,ts.session_date,ts.begin_time AS session_begin,ts.end_time AS session_end,ts.session_name_ch,ts.session_name_en,tmr.video_url ");
                    sb.Append(" ,ts.session_place_ch,ts.session_place_en,tsa.agenda_name_ch,tsa.agenda_name_en,tsa.begin_time AS agenda_begin,tsa.end_time AS agenda_end ");
                    sb.Append(" ,tsa.upload_ppt,tsa.ppt_url ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.Append(" LEFT JOIN tech_session_agenda tsa ON tsa.agenda_id=tmr.agenda_id ");
                    sb.Append(" LEFT JOIN tech_session ts ON ts.session_id=tsa.session_id ");
                    sb.AppendFormat(" WHERE tmr.isDel=2 AND tsa.isDel=2 AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" ", info.Mid, info.Mtype_id);
                    sb.Append(" AND tmr.role_type=3 ");
                    if (info.User_code > 0)
                    {
                        sb.AppendFormat(" AND tmr.user_code={0} ", info.User_code);
                    }
                    if (info.Session_id > 0)
                    {
                        sb.AppendFormat(" AND tsa.session_id={0} ", info.Session_id);
                    }
                    if (info.Session_date.ToString() != "0001/1/1 0:00:00" && info.Session_date != null)
                    {
                        sb.AppendFormat(" AND ts.session_date=\"{0}\" ", info.Session_date.ToString("yyyy-MM-dd"));
                    }
                    if (info.Agenda_id > 0)
                    {
                        sb.AppendFormat(" AND tmr.agenda_id={0} ", info.Agenda_id);
                    }
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' ", info.Full_name);
                    }
                    if (info.Roleid > 0)
                    {
                        sb.AppendFormat(" AND tmr.roleid={0} ", info.Roleid);
                    }
                    sb.Append(" ORDER BY tsa.begin_time ASC ;");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_user_agenda_to_page":  //查询指定人员的讲者身份详细日程
                    #region 查询指定人员的讲者身份详细日程
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT tmr.roleid,tmr.user_code,ren.puid,tmr.session_id,tmr.agenda_id,tmr.role_type,ren.family_name,ren.given_name,ren.unit ");
                    sb.Append(" ,CONCAT(ren.family_name,ren.given_name) AS full_name_ch,CONCAT(ren.given_name,\" \",ren.family_name) AS full_name_en ");
                    sb.Append(" ,ts.session_date,ts.begin_time AS session_begin,ts.end_time AS session_end,ts.session_name_ch,ts.session_name_en ");
                    sb.Append(" ,ts.session_place_ch,ts.session_place_en,tsa.agenda_name_ch,tsa.agenda_name_en,tsa.begin_time AS agenda_begin,tsa.end_time AS agenda_end ");
                    sb.Append(" ,tsa.look_count,tsa.dianzan_count,tsa.shoucang_count,tsa.msg_count,tsa.upload_ppt,tsa.ppt_url,tsa.polyv_video_id,tmr.video_url ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.Append(" LEFT JOIN tech_session_agenda tsa ON tsa.agenda_id=tmr.agenda_id ");
                    sb.Append(" LEFT JOIN tech_session ts ON ts.session_id=tsa.session_id ");
                    sb.AppendFormat(" WHERE tmr.isDel=2 AND (ts.isdel=2 OR tsa.isDel=2) AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" AND tsa.polyv_video_id is not null AND tsa.polyv_video_id != '' ", info.Mid, info.Mtype_id);
                    sb.Append(" AND tmr.role_type=3 ");
                    if (info.User_code > 0)
                    {
                        sb.AppendFormat(" AND tmr.user_code={0} ", info.User_code);
                    }
                    if (info.Session_id > 0)
                    {
                        sb.AppendFormat(" AND tsa.session_id={0} ", info.Session_id);
                    }
                    if (info.Session_date.ToString() != "0001/1/1 0:00:00" && info.Session_date != null)
                    {
                        sb.AppendFormat(" AND ts.session_date=\"{0}\" ", info.Session_date.ToString("yyyy-MM-dd"));
                    }
                    if (!string.IsNullOrEmpty(info.Session_place_ch))
                    {
                        sb.AppendFormat(" AND ts.session_place_ch = '{0}' ", info.Session_place_ch);
                    }
                    if (info.Agenda_id > 0)
                    {
                        sb.AppendFormat(" AND tmr.agenda_id={0} ", info.Agenda_id);
                    }
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' ", info.Full_name);
                    }
                    if (!string.IsNullOrEmpty(info.Unitname))
                    {
                        sb.AppendFormat(" AND ren.unit LIKE '%{0}%' ", info.Unitname);
                    }
                    if (!string.IsNullOrEmpty(info.Agenda_name_ch))
                    {
                        sb.AppendFormat(" AND tsa.agenda_name_ch LIKE '%{0}%' ", info.Agenda_name_ch);
                    }
                    if (!string.IsNullOrEmpty(info.Key_word))
                    {
                        sb.AppendFormat(" AND (tsa.agenda_name_ch LIKE '%{0}%' OR CONCAT(tua.family_name,tua.given_name) LIKE '%{0}%' OR ren.unit LIKE '%{0}%' OR tsa.key_word LIKE '%{0}%' OR  ts.session_place_ch LIKE '%{0}%' ) ", info.Key_word);
                    }
                    if (info.Roleid > 0)
                    {
                        sb.AppendFormat(" AND tmr.roleid={0} ", info.Roleid);
                    }
                    //sb.Append(" ORDER BY tsa.begin_time ASC ");

                    if (!info.shoucangsort.IsNullOrEmpty() || !info.dianzansort.IsNullOrEmpty() || !info.looksort.IsNullOrEmpty() || !info.msgsort.IsNullOrEmpty())
                    {
                        sb.AppendLine("ORDER BY ");
                        if (info.shoucangsort.Contains("asc"))
                        {
                            sb.AppendFormat("tsa.shoucang_count asc").AppendLine();
                        }
                        else if (info.shoucangsort.Contains("desc"))
                        {
                            sb.AppendFormat("tsa.shoucang_count desc").AppendLine();
                        }

                        if (info.dianzansort.Contains("asc"))
                        {
                            sb.AppendFormat("tsa.dianzan_count asc").AppendLine();
                        }
                        else if (info.dianzansort.Contains("desc"))
                        {
                            sb.AppendFormat("tsa.dianzan_count desc").AppendLine();
                        }

                        if (info.looksort.Contains("asc"))
                        {
                            sb.AppendFormat("tsa.look_count asc").AppendLine();
                        }
                        else if (info.looksort.Contains("desc"))
                        {
                            sb.AppendFormat("tsa.look_count desc").AppendLine();
                        }

                        if (info.msgsort.Contains("asc"))
                        {
                            sb.AppendFormat("tsa.msg_count asc").AppendLine();
                        }
                        else if (info.msgsort.Contains("desc"))
                        {
                            sb.AppendFormat("tsa.msg_count desc").AppendLine();
                        }

                    }
                    else
                    {
                        sb.AppendLine("ORDER BY tsa.tijiao_time DESC,agenda_id DESC");
                    }

                    index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_user_task":  //按用户ID查询其任务信息
                    #region 按用户ID查询其任务信息
                    str = (string)obj;
                    sb.Append(" SELECT tmr.roleid,tmr.user_code,ren.puid,tmr.session_id,tmr.agenda_id,tmr.role_type,ren.family_name,ren.given_name,ren.unit ");
                    sb.Append(" ,CONCAT(ren.family_name,ren.given_name) AS full_name_ch,CONCAT(ren.given_name,\" \",ren.family_name) AS full_name_en,ren.img_urlpath ");
                    sb.Append(" ,ts.session_date,ts.begin_time AS session_begin,ts.end_time AS session_end,ts.session_name_ch,ts.session_name_en ");
                    sb.Append(" ,ts.session_place_ch,ts.session_place_en,tsa.agenda_name_ch,tsa.agenda_name_en,tsa.begin_time AS agenda_begin,tsa.end_time AS agenda_end ");
                    sb.Append(" ,ts_1.session_date AS zd_session_date,ts_1.begin_time AS zd_begin_time,ts_1.end_time AS zd_end_time,ts_1.session_name_ch AS zd_session_name_ch ");
                    sb.Append(" ,ts_1.session_name_en AS zd_session_name_en,ts_1.session_place_ch AS zd_session_place_ch,ts_1.session_place_en AS zd_session_place_en ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.Append(" LEFT JOIN tech_session_agenda tsa ON tsa.agenda_id=tmr.agenda_id ");
                    sb.Append(" LEFT JOIN tech_session ts ON ts.session_id=tsa.session_id ");
                    sb.Append(" LEFT JOIN tech_session ts_1 ON ts_1.session_id=tmr.session_id ");
                    sb.AppendFormat(" WHERE tmr.isDel=2 AND (ts.isdel=2 OR tsa.isDel=2) AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" ", info.Mid, info.Mtype_id);
                    sb.AppendFormat(" AND tmr.user_code={0} ", str);
                    sb.Append(" ORDER BY tsa.begin_time ASC ;");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_user_task_li":
                    #region
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT role.roleid,role.user_code,ren.puid,role.session_id,role.agenda_id,role.role_type,role.isAccept,");
                    sb.Append(" agenda.agenda_id,agenda.begin_time,agenda.end_time,agenda.agenda_name_ch,agenda.session_id as right_session_id,sesstwo.session_place_ch as agenda_session_place_ch, ");
                    sb.Append(" sess.session_id as sess_session_id,sess.session_date,sess.begin_time as sess_begin_time,sess.end_time as sess_end_time,sess.session_name_ch,sess.session_place_ch, ");
                    sb.Append(" CONCAT(ren.family_name,ren.given_name) as full_name,role.video_url,role.noAcceptInfo,role.remark ");
                    sb.Append(" FROM tech_meeting_role role ");
                    sb.Append(" LEFT JOIN tech_session sess ON sess.session_id=role.session_id ");
                    sb.Append(" LEFT JOIN tech_session_agenda agenda ON agenda.agenda_id=role.agenda_id ");
                    sb.Append(" LEFT JOIN tech_session sesstwo on sesstwo.session_id=agenda.session_id ");
                    sb.Append(" LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=role.user_code ");
                    sb.AppendFormat(" WHERE role.isDel=2  AND (sess.isdel=2 OR agenda.isDel=2) AND role.user_code={0} AND role.mid='{1}' AND role.mtype_id='{2}' ", info.User_code, info.Mid, info.Mtype_id);
                    if (info.Begin_Time != new DateTime() && info.Begin_Time != null)
                    {
                        sb.AppendFormat(" AND agenda.begin_time like '{0}%' ", info.Begin_Time.ToString("yyyy-MM-dd"));
                    }
                    if (info.Session_date != new DateTime() && info.Session_date != null)
                    {
                        sb.AppendFormat(" AND sess.begin_time like '{0}%' ", info.Session_date.ToString("yyyy-MM-dd"));
                    }
                    sb.Append(" ORDER BY agenda.begin_time ASC ,sess.begin_time ASC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_role_user_to_page":  //查询角色信息（带分页）
                    #region 查询角色信息（带分页）
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT tmr.roleid,tmr.user_code,ren.puid,ren.family_name,ren.given_name,ren.unit,ren.province,ren.email ");
                    sb.Append(" ,tmr.session_id,tmr.agenda_id,tmr.role_type,tmr.mid,tmr.mtype_id,tmr.isDel,tmr.isAccept ");
                    sb.Append(" ,tmr.operatingtime,tmr.isSend,tmr.inputtime,ren.user_type,tmr.isPrint,tmr.isGxzSend ");
                    sb.Append(" ,CONCAT(ren.family_name,ren.given_name) AS full_name_ch,tmr.video_url ");
                    sb.Append(" ,CONCAT(ren.given_name,\" \",ren.family_name) AS full_name_en ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.AppendFormat(" WHERE tmr.isDel=2 AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" ", info.Mid, info.Mtype_id);
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE \"%{0}%\" ", info.Full_name);
                    }
                    if (info.User_type == 1)
                    {
                        sb.Append(" AND ren.user_type=1 ");
                    }
                    else if (info.User_type == 2)
                    {
                        sb.Append(" AND ren.user_type=2 ");
                    }
                    sb.Append(" GROUP BY tmr.user_code ");
                    index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "select_session_and_agenda_by_user_code":  //按用户ID查询角色任务信息
                    #region 按用户ID查询角色任务信息
                    info = (tech_meeting_role)obj;
                    sb.Append("SELECT tmr.roleid,tmr.user_code,ren.puid,ren.family_name,ren.given_name,CONCAT(ren.family_name,ren.given_name) AS full_name ");
                    sb.Append(",tmr.role_type,ren.user_type,tmr.session_id,tmr.agenda_id,tmr.isAccept,ts.session_name_ch,ts.session_place_ch ");
                    sb.Append(",ts.begin_time AS session_begin,ts.end_time AS session_end,tsa.agenda_name_ch,tsa.begin_time AS agenda_begin ");
                    sb.Append(",tsa.end_time AS agenda_end,ts_agenda.session_place_ch AS agenda_place_ch,tmr.video_url,ren.email ");
                    sb.Append("FROM tech_meeting_role tmr ");
                    sb.Append("INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.Append("LEFT JOIN tech_session ts ON ts.session_id=tmr.session_id ");
                    sb.Append("LEFT JOIN tech_session_agenda tsa ON tsa.agenda_id=tmr.agenda_id ");
                    sb.Append("LEFT JOIN tech_session ts_agenda ON ts_agenda.session_id=tsa.session_id ");
                    sb.AppendFormat("WHERE tmr.isDel=2 AND (ts.isdel=2 OR tsa.isDel=2) AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" ", info.Mid, info.Mtype_id);
                    if (info.User_code > 0)
                    {
                        sb.AppendFormat(" AND tmr.user_code={0} ", info.User_code);
                    }
                    if (info.Roleid > 0)
                    {
                        sb.AppendFormat(" AND tmr.roleid={0} ", info.Roleid);
                    }
                    sb.Append("ORDER BY ts.begin_time AND tsa.begin_time ASC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "GetTask":  //获取任务书内容
                    #region 获取任务书内容
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT CONCAT(ren.family_name,ren.given_name) AS 'fullname',meet.mname,agenda.begin_time,agenda.end_time,agenda.agenda_name_ch,sessa.session_place_ch, ");
                    sb.Append(" CONCAT(ren.family_name_pinyin,\" \",ren.given_name_pinyin) AS 'fullname_pinyin',role.role_type,role.isPrint,role.isSend,role.video_url, ");
                    sb.Append(" sess.begin_time AS 'begin_times',sess.end_time AS 'end_times',sess.session_name_ch,sess.session_place_ch AS 'session_place_chs', ");
                    sb.Append(" CASE WHEN role.role_type=1 THEN '主持' WHEN role.role_type=2 THEN '点评专家' WHEN role.role_type=3 THEN '讲者' WHEN role.role_type=4 THEN '翻译' WHEN role.role_type=5 THEN '讨论专家' WHEN role.role_type=6 THEN '参会' ");
                    sb.Append(" WHEN role.role_type=11 THEN '主席' WHEN role.role_type=12 THEN '执行主席' WHEN role.role_type=13 THEN '分会场主席' WHEN role.role_type=14 THEN '特邀点评嘉宾' WHEN role.role_type=15 THEN '共同主席' ");
                    sb.Append(" WHEN role.role_type=16 THEN '点评讨论' WHEN role.role_type=17 THEN '术者' WHEN role.role_type=18 THEN '手术主持及解说专家' WHEN role.role_type=19 THEN '名家观点' END AS 'shenfen' ");
                    sb.Append(" ,CASE WHEN role.role_type=1 THEN 'Chairmen' WHEN role.role_type=2 THEN '点评专家' WHEN role.role_type=3 THEN 'Speaker' WHEN role.role_type=4 THEN '翻译' WHEN role.role_type=5 THEN '讨论专家' WHEN role.role_type=6 THEN '参会' ");
                    sb.Append(" WHEN role.role_type=11 THEN '主席' WHEN role.role_type=12 THEN '执行主席' WHEN role.role_type=13 THEN '分会场主席' WHEN role.role_type=14 THEN '特邀点评嘉宾' WHEN role.role_type=15 THEN '共同主席' ");
                    sb.Append(" WHEN role.role_type=16 THEN '点评讨论' WHEN role.role_type=17 THEN '术者' WHEN role.role_type=18 THEN '手术主持及解说专家' WHEN role.role_type=19 THEN '名家观点' END AS 'shenfenEn' ");
                    sb.Append(" ,(SELECT COUNT(1) FROM tech_meeting_role roletask WHERE roletask.user_code=role.user_code GROUP BY roletask.user_code) AS 'tasks' ");
                    sb.Append(" FROM tech_meeting_role role LEFT JOIN tech_session_agenda agenda ON agenda.agenda_id=role.agenda_id ");
                    sb.Append(" LEFT JOIN tech_session sess ON sess.session_id=role.session_id ");
                    sb.Append(" LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=role.user_code ");
                    sb.Append(" LEFT JOIN tech_session sessa ON sessa.session_id=agenda.session_id ");
                    sb.Append(" LEFT JOIN tech_meeting meet ON meet.mid=role.mid ");
                    sb.AppendFormat(" WHERE role.isDel=2 AND (agenda.isDel=2 OR sess.isdel=2) AND role.mid='{0}' AND role.mtype_id='{1}' AND ren.user_type=1 ", info.Mid, info.Mtype_id);
                    if (info.User_code > 0) { sb.AppendFormat(" AND role.user_code='{0}' ", info.User_code); }
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' ", info.Full_name);
                    }
                    if (info.Role_type != 3 && info.Role_type > 0)
                    {
                        sb.AppendFormat(" AND role.role_type in (1,2,4,5,6,11,12,13,14,15,16,17,18,19) ");
                    }
                    else if (info.Role_type == 3)
                    {
                        sb.AppendFormat(" AND role.role_type = 3 ");
                    }
                    //else { sb.Append(" GROUP BY role.user_code "); }
                    sb.Append(" ORDER BY sess.begin_time,agenda.begin_time ");
                    sb.AppendFormat(" LIMIT {0},10 ", info.PageIndex);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "getGroupUsers":
                    #region 获取讲者简介
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT ren.puid,CONCAT(ren.family_name,ren.given_name) as full_name,ren.learnpost,ren.penintro,ren.img_urlpath,meeting_type.mtype_name ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.Append(" LEFT JOIN tech_meeting_type meeting_type ON meeting_type.mtype_id=ren.mtype_id ");
                    sb.AppendFormat(" WHERE tmr.mid='{0}' AND tmr.mtype_id='{1}' AND tmr.isDel=2 ", info.Mid, info.Mtype_id);
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' ", info.Full_name);
                    }
                    sb.Append(" GROUP BY tmr.user_code ");
                    
                    index = info.PageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "getGroupUsersCount":
                    #region 获取讲者简介
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT ren.puid,CONCAT(ren.family_name,ren.given_name) as full_name,ren.learnpost,ren.penintro,ren.img_urlpath,meeting_type.mtype_name ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.Append(" LEFT JOIN tech_meeting_type meeting_type ON meeting_type.mtype_id=ren.mtype_id ");
                    sb.AppendFormat(" WHERE tmr.mid='{0}' AND tmr.mtype_id='{1}' AND tmr.isDel=2 AND ren.mtype_id='{1}' ", info.Mid, info.Mtype_id);
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' ", info.Full_name);
                    }
                    sb.Append(" GROUP BY tmr.user_code ");

                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
                case "GetTaskForTaskLsit":
                    #region 获取任务书内容为临时表数据做准备
                    info = (tech_meeting_role)obj;
                    sb.Append("SELECT CONCAT(ren.family_name,ren.given_name) AS 'fullname',ren.mobile,agenda.begin_time,agenda.end_time,agenda.agenda_name_ch,");
                    sb.Append("role.role_type,sessa.session_place_ch,sess.begin_time AS 'begin_times',sess.end_time AS 'end_times',sess.session_place_ch AS 'session_place_chs',");
                    sb.Append("CASE WHEN sess.session_name_ch is NULL THEN sessa.session_name_ch WHEN sessa.session_name_ch is NULL THEN sess.session_name_ch  END as session_name_ch,");
                    sb.Append(" CASE WHEN role.role_type=1 THEN '主持' WHEN role.role_type=2 THEN '点评专家' WHEN role.role_type=3 THEN '讲者' WHEN role.role_type=4 THEN '翻译' WHEN role.role_type=5 THEN '讨论专家' WHEN role.role_type=6 THEN '参会' ");
                    sb.Append(" WHEN role.role_type=11 THEN '主席' WHEN role.role_type=12 THEN '执行主席' WHEN role.role_type=13 THEN '分会场主席' WHEN role.role_type=14 THEN '特邀点评嘉宾' WHEN role.role_type=15 THEN '共同主席' ");
                    sb.Append(" WHEN role.role_type=16 THEN '点评讨论' WHEN role.role_type=17 THEN '术者' WHEN role.role_type=18 THEN '手术主持及解说专家' WHEN role.role_type=19 THEN '名家观点' END AS 'shenfen' ");
                    sb.Append("FROM tech_meeting_role role ");
                    sb.Append("LEFT JOIN tech_session_agenda agenda ON agenda.agenda_id=role.agenda_id ");
                    sb.Append("LEFT JOIN tech_session sess ON sess.session_id=role.session_id ");
                    sb.Append("LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=role.user_code ");
                    sb.Append("LEFT JOIN tech_session sessa ON sessa.session_id=agenda.session_id ");
                    sb.AppendFormat(" WHERE role.isDel=2 AND (agenda.isDel=2 OR sess.isdel=2) AND role.mid='{0}' AND role.mtype_id='{1}' ", info.Mid, info.Mtype_id);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }
        #endregion


        #region 操作
        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="obj">操作信息</param>
        /// <param name="type">操作类型</param>
        /// <returns>操作结果</returns>
        public int Operating(Object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_meeting_role info = new tech_meeting_role();
            switch (type)
            {
                case "add_role":  //添加主持、嘉宾任务信息（事务回滚）
                    #region 添加主持、嘉宾任务信息（事务回滚）
                    info = (tech_meeting_role)obj;
                    sb.Append(" SET autocommit=0; ");
                    sb.Append(" DROP PROCEDURE IF EXISTS InsertRole; ");
                    sb.Append(" CREATE PROCEDURE InsertRole() ");
                    sb.Append(" BEGIN ");
                    sb.Append(" DECLARE errno TINYINT DEFAULT '0'; ");
                    sb.Append(" DECLARE CONTINUE HANDLER FOR SQLEXCEPTION SET errno = 1; ");
                    sb.Append(" START TRANSACTION; ");
                    if (!string.IsNullOrEmpty(info.Preside_array))
                    {
                        string[] pre_str = info.Preside_array.Split(',');
                        foreach (string p in pre_str)
                        {
                            sb.Append(" INSERT INTO tech_meeting_role(user_code,session_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.Append(" VALUES( ");
                            sb.AppendFormat(" {0} ", Convert.ToInt32(p));
                            sb.AppendFormat(" ,{0} ", info.Session_id);
                            sb.Append(" ,1 ");
                            sb.AppendFormat(" ,\"{0}\",\"{1}\" ", info.Mid, info.Mtype_id);
                            sb.AppendFormat(" ,\"{0}\",\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            sb.Append(" ); ");
                        }
                    }
                    if (!string.IsNullOrEmpty(info.Guests_array))
                    {
                        string[] gue_str = info.Guests_array.Split(',');
                        foreach (string g in gue_str)
                        {
                            sb.Append(" INSERT INTO tech_meeting_role(user_code,session_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.Append(" VALUES( ");
                            sb.AppendFormat(" {0} ", Convert.ToInt32(g));
                            sb.AppendFormat(" ,{0} ", info.Session_id);
                            sb.Append(" ,2 ");
                            sb.AppendFormat(" ,\"{0}\",\"{1}\" ", info.Mid, info.Mtype_id);
                            sb.AppendFormat(" ,\"{0}\",\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            sb.Append(" ); ");
                        }
                    }
                    sb.Append(" IF errno=1 THEN ");
                    sb.Append(" ROLLBACK; ");
                    sb.Append(" ELSE ");
                    sb.Append(" COMMIT; ");
                    sb.Append(" END IF; ");
                    sb.Append(" SELECT errno; ");
                    sb.Append(" END; ");
                    sb.Append(" CALL InsertRole(); ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "add_role_import":  //添加主持、嘉宾任务信息（事务回滚）
                    #region 添加主持、嘉宾任务信息（事务回滚）
                    info = (tech_meeting_role)obj;

                    sb.Append(" INSERT INTO tech_meeting_role(user_code,session_id,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                    sb.Append(" VALUES( ");
                    sb.AppendFormat(" {0} ", info.User_code);
                    sb.AppendFormat(" ,{0} ", info.Session_id);
                    sb.AppendFormat(" ,{0} ", info.Agenda_id);
                    sb.AppendFormat(" ,{0} ", info.Role_type);
                    sb.AppendFormat(" ,\"{0}\",\"{1}\" ", info.Mid, info.Mtype_id);
                    sb.AppendFormat(" ,\"{0}\",\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(" ); ");

                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());

                    #endregion
                    break;
                case "edit_role":  //修改主持、嘉宾任务信息（事务回滚）
                    #region 修改主持、嘉宾任务信息（事务回滚）
                    info = (tech_meeting_role)obj;
                    sb.Append(" SET autocommit=0; ");
                    sb.Append(" DROP PROCEDURE IF EXISTS UpdateRole; ");
                    sb.Append(" CREATE PROCEDURE UpdateRole() ");
                    sb.Append(" BEGIN ");
                    sb.Append(" DECLARE errno TINYINT DEFAULT '0'; ");
                    sb.Append(" DECLARE CONTINUE HANDLER FOR SQLEXCEPTION SET errno = 1; ");
                    sb.Append(" START TRANSACTION; ");
                    sb.AppendFormat(" DELETE FROM tech_meeting_role WHERE session_id={0} AND role_type=1; ", info.Session_id);
                    sb.AppendFormat(" DELETE FROM tech_meeting_role WHERE session_id={0} AND role_type=2; ", info.Session_id);
                    if (!string.IsNullOrEmpty(info.Preside_array))
                    {
                        string[] pre_str = info.Preside_array.Split(',');
                        foreach (string p in pre_str)
                        {
                            sb.Append(" INSERT INTO tech_meeting_role(user_code,session_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.Append(" VALUES( ");
                            sb.AppendFormat(" {0} ", Convert.ToInt32(p));
                            sb.AppendFormat(" ,{0} ", info.Session_id);
                            sb.Append(" ,1 ");
                            sb.AppendFormat(" ,\"{0}\",\"{1}\" ", info.Mid, info.Mtype_id);
                            sb.AppendFormat(" ,\"{0}\",\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            sb.Append(" ); ");
                        }
                    }
                    if (!string.IsNullOrEmpty(info.Guests_array))
                    {
                        string[] gue_str = info.Guests_array.Split(',');
                        foreach (string g in gue_str)
                        {
                            sb.Append(" INSERT INTO tech_meeting_role(user_code,session_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.Append(" VALUES( ");
                            sb.AppendFormat(" {0} ", Convert.ToInt32(g));
                            sb.AppendFormat(" ,{0} ", info.Session_id);
                            sb.Append(" ,2 ");
                            sb.AppendFormat(" ,\"{0}\",\"{1}\" ", info.Mid, info.Mtype_id);
                            sb.AppendFormat(" ,\"{0}\",\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            sb.Append(" ); ");
                        }
                    }
                    sb.Append(" IF errno=1 THEN ");
                    sb.Append(" ROLLBACK; ");
                    sb.Append(" ELSE ");
                    sb.Append(" COMMIT; ");
                    sb.Append(" END IF; ");
                    sb.Append(" SELECT errno; ");
                    sb.Append(" END; ");
                    sb.Append(" CALL UpdateRole(); ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "add_speaker":  //添加讲者任务信息（事务回滚）
                    #region 添加主持、嘉宾任务信息（事务回滚）
                    info = (tech_meeting_role)obj;
                    sb.Append(" SET autocommit=0; ");
                    sb.Append(" DROP PROCEDURE IF EXISTS InsertSpeaker; ");
                    sb.Append(" CREATE PROCEDURE InsertSpeaker() ");
                    sb.Append(" BEGIN ");
                    sb.Append(" DECLARE errno TINYINT DEFAULT '0'; ");
                    sb.Append(" DECLARE CONTINUE HANDLER FOR SQLEXCEPTION SET errno = 1; ");
                    sb.Append(" START TRANSACTION; ");
                    if (!string.IsNullOrEmpty(info.Speaker_array))
                    {
                        string[] pre_str = info.Speaker_array.Split(',');
                        foreach (string p in pre_str)
                        {
                            sb.Append(" INSERT INTO tech_meeting_role(user_code,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.Append(" VALUES( ");
                            sb.AppendFormat(" {0} ", Convert.ToInt32(p));
                            sb.AppendFormat(" ,{0} ", info.Agenda_id);
                            sb.Append(" ,3 ");
                            sb.AppendFormat(" ,\"{0}\",\"{1}\" ", info.Mid, info.Mtype_id);
                            sb.AppendFormat(" ,\"{0}\",\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            sb.Append(" ); ");
                        }
                    }
                    sb.Append(" IF errno=1 THEN ");
                    sb.Append(" ROLLBACK; ");
                    sb.Append(" ELSE ");
                    sb.Append(" COMMIT; ");
                    sb.Append(" END IF; ");
                    sb.Append(" SELECT errno; ");
                    sb.Append(" END; ");
                    sb.Append(" CALL InsertSpeaker(); ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "edit_speaker":  //修改讲者任务信息（事务回滚）
                    #region 修改讲者任务信息（事务回滚）
                    info = (tech_meeting_role)obj;
                    sb.Append(" SET autocommit=0; ");
                    sb.Append(" DROP PROCEDURE IF EXISTS EditSpeaker; ");
                    sb.Append(" CREATE PROCEDURE EditSpeaker() ");
                    sb.Append(" BEGIN ");
                    sb.Append(" DECLARE errno TINYINT DEFAULT '0'; ");
                    sb.Append(" DECLARE CONTINUE HANDLER FOR SQLEXCEPTION SET errno = 1; ");
                    sb.Append(" START TRANSACTION; ");
                    if (!string.IsNullOrEmpty(info.Speaker_array))
                    {
                        sb.AppendFormat(" DELETE FROM tech_meeting_role WHERE role_type=3 AND agenda_id={0}; ", info.Agenda_id);
                        string[] pre_str = info.Speaker_array.Split(',');
                        foreach (string p in pre_str)
                        {
                            sb.Append(" INSERT INTO tech_meeting_role(user_code,agenda_id,role_type,mid,mtype_id,inputtime,operatingtime) ");
                            sb.Append(" VALUES( ");
                            sb.AppendFormat(" {0} ", Convert.ToInt32(p));
                            sb.AppendFormat(" ,{0} ", info.Agenda_id);
                            sb.Append(" ,3 ");
                            sb.AppendFormat(" ,\"{0}\",\"{1}\" ", info.Mid, info.Mtype_id);
                            sb.AppendFormat(" ,\"{0}\",\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            sb.Append(" ); ");
                        }
                    }
                    sb.Append(" IF errno=1 THEN ");
                    sb.Append(" ROLLBACK; ");
                    sb.Append(" ELSE ");
                    sb.Append(" COMMIT; ");
                    sb.Append(" END IF; ");
                    sb.Append(" SELECT errno; ");
                    sb.Append(" END; ");
                    sb.Append(" CALL EditSpeaker(); ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "get_role_user_count_by_page":  //查询角色信息总条数（带分页）
                    #region 查询角色信息总条数（带分页）
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.AppendFormat(" WHERE tmr.isDel=2 AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" ", info.Mid, info.Mtype_id);
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE \"%{0}%\" ", info.Full_name);
                    }
                    if (info.User_type == 1)
                    {
                        sb.Append(" AND ren.user_type=1 ");
                    }
                    else if (info.User_type == 2)
                    {
                        sb.Append(" AND ren.user_type=2 ");
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "update_isPrint":  //修改打印状态
                    #region 修改打印状态
                    sb.AppendFormat(" UPDATE tech_meeting_role SET operatingtime=\"{0}\",isPrint=1 ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.AppendFormat(" WHERE mid=\"{0}\" AND mtype_id=\"{1}\" AND user_code={2} ", info.Mid, info.Mtype_id, (int)obj);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "update_isRwsSend":  //修改感谢状状态
                    #region 修改打印状态
                    sb.AppendFormat(" UPDATE tech_meeting_role SET operatingtime=\"{0}\",isSend=1 ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.AppendFormat(" WHERE mid=\"{0}\" AND mtype_id=\"{1}\" AND user_code={2} ", info.Mid, info.Mtype_id, Convert.ToInt32(obj));
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "update_isGxzSend":  //修改感谢状状态
                    #region 修改打印状态
                    sb.AppendFormat(" UPDATE tech_meeting_role SET operatingtime=\"{0}\",isGxzSend=1 ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.AppendFormat(" WHERE mid=\"{0}\" AND mtype_id=\"{1}\" AND user_code={2} ", info.Mid, info.Mtype_id, Convert.ToInt32(obj));
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "isaccept":  //修改接受状态
                    #region 修改接受状态
                    info = (tech_meeting_role)obj;
                    sb.AppendFormat(" UPDATE tech_meeting_role SET operatingtime=NOW() ");
                    if (info.IsAccept == 1)
                    {
                        sb.Append(" ,isAccept=1 ");
                    }
                    else if (info.IsAccept == 2)
                    {
                        sb.Append(" ,isaccept=2 ");
                    }
                    if (info.NoAcceptInfo == 1)
                    {
                        sb.Append(" ,noAcceptInfo=1 ");
                    }
                    else if (info.NoAcceptInfo == 2)
                    {
                        sb.Append(" ,noAcceptInfo=2 ");
                    }
                    else if (info.NoAcceptInfo == 0)
                    {
                        sb.Append(" ,noAcceptInfo=0 ");
                    }
                    if (!string.IsNullOrEmpty(info.Remark))
                    {
                        sb.AppendFormat(" ,remark='{0}' ", info.Remark);
                    }
                    sb.AppendFormat(" WHERE mid=\"{0}\" AND mtype_id=\"{1}\" AND user_code={2} AND roleid={3} ", info.Mid, info.Mtype_id, info.User_code, info.Roleid);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "update_video_url":  //更新视频路径
                    #region 更新视频路径
                    info = (tech_meeting_role)obj;
                    sb.AppendFormat(" UPDATE tech_meeting_role SET operatingtime=\"{0}\",video_url=\"{1}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), info.video_url);
                    sb.AppendFormat(" WHERE mid=\"{0}\" AND mtype_id=\"{1}\" AND user_code={2} AND roleid={3} ", info.Mid, info.Mtype_id, info.User_code, info.Roleid);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;
                case "GetTask":  //获取任务书内容 条数
                    #region 获取任务书内容 条数
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_meeting_role role LEFT JOIN tech_session_agenda agenda ON agenda.agenda_id=role.agenda_id ");
                    sb.Append(" LEFT JOIN tech_session sess ON sess.session_id=role.session_id ");
                    sb.Append(" LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=role.user_code ");
                    sb.Append(" LEFT JOIN tech_session sessa ON sessa.session_id=agenda.session_id ");
                    sb.Append(" LEFT JOIN tech_meeting meet ON meet.mid=role.mid ");
                    sb.AppendFormat(" WHERE role.isDel=2 AND (agenda.isDel=2 OR sess.isdel=2) AND role.mid='{0}' AND role.mtype_id='{1}' and ren.user_type=1 ", info.Mid, info.Mtype_id);
                    if (info.User_code > 0) { sb.AppendFormat(" AND role.user_code='{0}' ", info.User_code); }
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' ", info.Full_name);
                    }
                    if (info.Role_type != 3 && info.Role_type > 0)
                    {
                        sb.AppendFormat(" AND role.role_type in (1,2,4,5,6,11,12,13,14,15,16,17,18,19) ");
                    }
                    else if (info.Role_type == 3)
                    {
                        sb.AppendFormat(" AND role.role_type = 3 ");
                    }
                    //else { sb.Append(" GROUP BY role.user_code "); }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "GetAgendaTask":  //获取任务书内容 条数
                    #region 获取讲课任务 条数
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_meeting_role role LEFT JOIN tech_session_agenda agenda ON agenda.agenda_id=role.agenda_id ");
                    sb.Append(" LEFT JOIN tech_session sess ON sess.session_id=role.session_id ");
                    sb.Append(" LEFT JOIN tech_meeting_user_ppt ren ON ren.puid=role.user_code ");
                    sb.Append(" LEFT JOIN tech_session sessa ON sessa.session_id=agenda.session_id ");
                    sb.Append(" LEFT JOIN tech_meeting meet ON meet.mid=role.mid ");
                    sb.AppendFormat(" WHERE role.isDel=2 AND role.role_type=3 AND (agenda.isDel=2 OR sess.isdel=2) AND role.mid='{0}' AND role.mtype_id='{1}' and ren.user_type=1 ", info.Mid, info.Mtype_id);
                    if (info.User_code > 0) { sb.AppendFormat(" AND role.user_code='{0}' ", info.User_code); }
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' ", info.Full_name);
                    }
                    //else { sb.Append(" GROUP BY role.user_code "); }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "select_user_agenda_to_page_count":  //查询指定人员的讲者身份详细日程 条数
                    #region 查询指定人员的讲者身份详细日程 条数
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.Append(" LEFT JOIN tech_session_agenda tsa ON tsa.agenda_id=tmr.agenda_id ");
                    sb.Append(" LEFT JOIN tech_session ts ON ts.session_id=tsa.session_id ");
                    sb.AppendFormat(" WHERE tmr.isDel=2 AND (ts.isdel=2 OR tsa.isDel=2) AND tmr.mid=\"{0}\" AND tmr.mtype_id=\"{1}\" AND tsa.polyv_video_id is not null AND tsa.polyv_video_id != '' ", info.Mid, info.Mtype_id);
                    sb.Append(" AND tmr.role_type=3 ");
                    if (info.User_code > 0)
                    {
                        sb.AppendFormat(" AND tmr.user_code={0} ", info.User_code);
                    }
                    if (info.Session_id > 0)
                    {
                        sb.AppendFormat(" AND tsa.session_id={0} ", info.Session_id);
                    }
                    if (info.Session_date.ToString() != "0001/1/1 0:00:00" && info.Session_date != null)
                    {
                        sb.AppendFormat(" AND ts.session_date=\"{0}\" ", info.Session_date.ToString("yyyy-MM-dd"));
                    }
                    if (!string.IsNullOrEmpty(info.Session_place_ch))
                    {
                        sb.AppendFormat(" AND ts.session_place_ch = '{0}' ", info.Session_place_ch);
                    }
                    if (info.Agenda_id > 0)
                    {
                        sb.AppendFormat(" AND tmr.agenda_id={0} ", info.Agenda_id);
                    }
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' ", info.Full_name);
                    }
                    if (!string.IsNullOrEmpty(info.Unitname))
                    {
                        sb.AppendFormat(" AND ren.unit LIKE '%{0}%' ", info.Unitname);
                    }
                    if (!string.IsNullOrEmpty(info.Agenda_name_ch))
                    {
                        sb.AppendFormat(" AND tsa.agenda_name_ch LIKE '%{0}%' ", info.Agenda_name_ch);
                    }
                    if (!string.IsNullOrEmpty(info.Key_word))
                    {
                        sb.AppendFormat(" AND (tsa.agenda_name_ch LIKE '%{0}%' OR CONCAT(ren.family_name,ren.given_name) LIKE '%{0}%' OR ren.unit LIKE '%{0}%') ", info.Key_word);
                    }
                    if (info.Roleid > 0)
                    {
                        sb.AppendFormat(" AND tmr.roleid={0} ", info.Roleid);
                    }

                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
                case "getGroupUsersCount":
                    #region 查询用户任务数
                    info = (tech_meeting_role)obj;
                    sb.Append(" SELECT COUNT(1) ");
                    sb.Append(" FROM tech_meeting_role tmr ");
                    sb.Append(" INNER JOIN tech_meeting_user_ppt ren ON ren.puid=tmr.user_code ");
                    sb.AppendFormat(" WHERE tmr.mid='{0}' AND tmr.mtype_id='{1}' AND tmr.isDel=2 ", info.Mid, info.Mtype_id);
                    if (!string.IsNullOrEmpty(info.Full_name))
                    {
                        sb.AppendFormat(" AND CONCAT(ren.family_name,ren.given_name)='{0}' ", info.Full_name);
                    }
                    sb.Append(" GROUP BY tmr.user_code ");
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }
        #endregion

    }
}
