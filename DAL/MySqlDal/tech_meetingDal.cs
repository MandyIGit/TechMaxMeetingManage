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
    public class tech_meetingDal : Itech_meeting
    {
        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_meeting info = (tech_meeting)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_meeting(mid,mtype_id,mname,address,begindate,enddate,brief,mcontactmblie,mcontact");
                    sb.Append(",project_manager_id,explains,regsize,inputtime,reguser,reguserdate,article,articledate,lodging,lodgingdate");
                    sb.Append(",reviewers,reviewersdate,meetingcheckin_date,regenddate,m_img,m_website,m_level,is_live,is_playBack,is_recommend,is_xsh_show,zzjzpasswd)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.mid))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.mid);
                    }
                    else
                    {
                        sb.AppendFormat(" \"{0}\" ", GetMid());
                    }

                    if (!string.IsNullOrEmpty(info.mtype_id))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mtype_id);
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", "MT1000");
                    }

                    if (!string.IsNullOrEmpty(info.mname))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mname);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.address))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.address);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    sb.AppendFormat(" ,\"{0}\", \"{1}\" ", info.begindate.ToString("yyyy-MM-dd HH:mm:ss"), info.enddate.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (!string.IsNullOrEmpty(info.brief))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.brief);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.mcontactmblie))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mcontactmblie);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.mcontact))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.mcontact);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.project_manager_id > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.project_manager_id);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.explains))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.explains);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.regsize > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.regsize);
                    }
                    else
                    {
                        sb.Append(" ,0 ");
                    }

                    sb.AppendFormat(" ,\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (info.reguser > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.reguser);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.reguserdate.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.reguserdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.article > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.article);
                    }
                    else
                    {
                        sb.Append(" ,1 ");
                    }

                    if (info.articledate.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.articledate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.lodging > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.lodging);
                    }
                    else
                    {
                        sb.Append(" ,1 ");
                    }

                    if (info.lodgingdate.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.lodgingdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.reviewers > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.reviewers);
                    }
                    else
                    {
                        sb.Append(" ,1 ");
                    }

                    if (info.reviewersdate.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.reviewersdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.meetingcheckin_date.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.meetingcheckin_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (info.regenddate.ToString("yyyy-MM-dd HH:mm:ss") == "0001-01-01 00:00:00")
                    {
                        sb.Append(" ,DEFAULT ");
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.regenddate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }

                    if (!string.IsNullOrEmpty(info.m_img))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.m_img);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.m_website))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.m_website);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.m_level))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.m_level);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.is_live > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.is_live);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.is_playBack > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.is_playBack);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.is_recommend > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.is_recommend);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (info.is_xsh_show > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.is_xsh_show);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    if (!string.IsNullOrEmpty(info.zzjzpasswd))
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.zzjzpasswd);
                    }
                    else
                    {
                        sb.AppendFormat(" ,\"{0}\" ", TechMaxClass.GetRandomStr());
                    }

                    sb.Append(" ); ");

                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());

                    #endregion
                    break;

                case "edit":
                    #region edit
                    sb.AppendFormat("UPDATE tech_meeting SET mtype_id=\"{0}\" ", info.mtype_id);
                    if (!string.IsNullOrEmpty(info.mname))
                    {
                        sb.AppendFormat(" ,mname=\"{0}\" ", info.mname);
                    }
                    if (!string.IsNullOrEmpty(info.address))
                    {
                        sb.AppendFormat(" ,address=\"{0}\" ", info.address);
                    }
                    if (!string.IsNullOrEmpty(info.begindate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,begindate=\"{0}\" ", info.begindate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.enddate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,enddate=\"{0}\" ", info.enddate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.brief))
                    {
                        sb.AppendFormat(" ,brief=\"{0}\" ", info.brief);
                    }
                    if (!string.IsNullOrEmpty(info.mcontactmblie))
                    {
                        sb.AppendFormat(" ,mcontactmblie=\"{0}\" ", info.mcontactmblie);
                    }
                    if (!string.IsNullOrEmpty(info.mcontact))
                    {
                        sb.AppendFormat(" ,mcontact=\"{0}\" ", info.mcontact);
                    }
                    if (!string.IsNullOrEmpty(info.explains))
                    {
                        sb.AppendFormat(" ,explains=\"{0}\" ", info.explains);
                    }
                    if (info.regsize > 0)
                    {
                        sb.AppendFormat(" ,regsize=\"{0}\" ", info.regsize);
                    }
                    if (info.reguser > 0)
                    {
                        sb.AppendFormat(" ,reguser=\"{0}\" ", info.reguser);
                    }
                    if (!string.IsNullOrEmpty(info.reguserdate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,reguserdate=\"{0}\" ", info.reguserdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (info.article > 0)
                    {
                        sb.AppendFormat(" ,article=\"{0}\" ", info.article);
                    }
                    if (!string.IsNullOrEmpty(info.articledate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,articledate=\"{0}\" ", info.articledate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (info.lodging > 0)
                    {
                        sb.AppendFormat(" ,lodging=\"{0}\" ", info.lodging);
                    }
                    if (!string.IsNullOrEmpty(info.lodgingdate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,lodgingdate=\"{0}\" ", info.lodgingdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (info.reviewers > 0)
                    {
                        sb.AppendFormat(" ,reviewers=\"{0}\" ", info.reviewers);
                    }
                    if (!string.IsNullOrEmpty(info.reviewersdate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,reviewersdate=\"{0}\" ", info.reviewersdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.meetingcheckin_date.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,meetingcheckin_date=\"{0}\" ", info.meetingcheckin_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.regenddate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,regenddate=\"{0}\" ", info.regenddate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.m_img))
                    {
                        sb.AppendFormat(" ,m_img=\"{0}\" ", info.m_img);
                    }
                    if (!string.IsNullOrEmpty(info.m_website))
                    {
                        sb.AppendFormat(" ,m_website=\"{0}\" ", info.m_website);
                    }
                    if (!string.IsNullOrEmpty(info.m_level))
                    {
                        sb.AppendFormat(" ,m_level=\"{0}\" ", info.m_level);
                    }

                    if (info.is_live > 0)
                    {
                        sb.AppendFormat(" ,is_live={0} ", info.is_live);
                    }
                    if (info.is_playBack > 0)
                    {
                        sb.AppendFormat(" ,is_playBack={0} ", info.is_playBack);
                    }
                    if (info.is_recommend > 0)
                    {
                        sb.AppendFormat(" ,is_recommend={0} ", info.is_recommend);
                    }
                    if (info.is_xsh_show > 0)
                    {
                        sb.AppendFormat(" ,is_xsh_show={0} ", info.is_xsh_show);
                    }
                    if (info.is_weizhankaitong > 0)
                    {
                        sb.AppendFormat(" ,is_weizhankaitong={0} ", info.is_weizhankaitong);
                    }
                    if (info.project_manager_id > 0)
                    {
                        sb.AppendFormat(" ,project_manager_id={0} ", info.project_manager_id);
                    }

                    sb.AppendFormat(" WHERE mid=\"{0}\" ", info.mid);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("DELETE FROM tech_meeting WHERE mid=\"{0}\" ", info.mid);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "isExtMName":
                    #region isExtTypeName
                    sb.AppendFormat("SELECT COUNT(1) FROM tech_meeting WHERE mname=\"{0}\" ", info.mname);
                    result = int.Parse(MySQLHelper.ExecuteScalar(sb.ToString()).ToString());
                    #endregion
                    break;

                case "isPMExtMName":
                    #region isPMExtMName
                    sb.AppendFormat("SELECT COUNT(1) FROM tech_meeting WHERE project_manager_id={0} ", info.project_manager_id);
                    result = int.Parse(MySQLHelper.ExecuteScalar(sb.ToString()).ToString());
                    #endregion
                    break;

                case "updateByMobile":
                    #region edit
                    sb.AppendFormat("UPDATE tech_meeting SET regsize={0} ", 0);
                    if (!string.IsNullOrEmpty(info.mname))
                    {
                        sb.AppendFormat(" ,mname=\"{0}\" ", info.mname);
                    }
                    if (!string.IsNullOrEmpty(info.address))
                    {
                        sb.AppendFormat(" ,address=\"{0}\" ", info.address);
                    }
                    if (!string.IsNullOrEmpty(info.begindate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,begindate=\"{0}\" ", info.begindate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.enddate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,enddate=\"{0}\" ", info.enddate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }                    
                    if (!string.IsNullOrEmpty(info.mcontactmblie))
                    {
                        sb.AppendFormat(" ,mcontactmblie=\"{0}\" ", info.mcontactmblie);
                    }
                    if (!string.IsNullOrEmpty(info.mcontact))
                    {
                        sb.AppendFormat(" ,mcontact=\"{0}\" ", info.mcontact);
                    }
                    if (info.project_manager_id > 0)
                    {
                        sb.AppendFormat(" ,project_manager_id={0} ", info.project_manager_id);
                    }
                    if (info.reguser > 0)
                    {
                        sb.AppendFormat(" ,reguser=\"{0}\" ", info.reguser);
                    }
                    if (!string.IsNullOrEmpty(info.reguserdate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,reguserdate=\"{0}\" ", info.reguserdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (info.article > 0)
                    {
                        sb.AppendFormat(" ,article=\"{0}\" ", info.article);
                    }
                    if (!string.IsNullOrEmpty(info.articledate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,articledate=\"{0}\" ", info.articledate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (info.lodging > 0)
                    {
                        sb.AppendFormat(" ,lodging=\"{0}\" ", info.lodging);
                    }
                    if (!string.IsNullOrEmpty(info.lodgingdate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,lodgingdate=\"{0}\" ", info.lodgingdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (info.reviewers > 0)
                    {
                        sb.AppendFormat(" ,reviewers=\"{0}\" ", info.reviewers);
                    }
                    if (!string.IsNullOrEmpty(info.reviewersdate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,reviewersdate=\"{0}\" ", info.reviewersdate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.meetingcheckin_date.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,meetingcheckin_date=\"{0}\" ", info.meetingcheckin_date.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.regenddate.ToString("yyyy-MM-dd HH:mm:ss")))
                    {
                        sb.AppendFormat(" ,regenddate=\"{0}\" ", info.regenddate.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    if (!string.IsNullOrEmpty(info.m_website))
                    {
                        sb.AppendFormat(" ,m_website=\"{0}\" ", info.m_website);
                    }
                    if (info.is_weizhankaitong > 0)
                    {
                        sb.AppendFormat(" ,is_weizhankaitong={0} ", info.is_weizhankaitong);
                    }

                    sb.AppendFormat(" WHERE mid=\"{0}\" ", info.mid);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "select_meeting_to_page_count":
                    sb.AppendFormat("SELECT COUNT(1) FROM tech_meeting");
                    sb.Append(" WHERE 1=1 ");
                    if (info.project_manager_id > 0)
                    {
                        sb.AppendFormat(" AND project_manager_id={0} ", info.project_manager_id);
                    }
                    if (!string.IsNullOrEmpty(info.mname))
                    {
                        sb.AppendFormat(" AND mname LIKE \"{0}\" ", info.mname);
                    }
                    if (info.huiyi_status == 1) //即将召开
                    {
                        sb.AppendFormat(" AND begindate > \"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else if (info.huiyi_status == 2) //正在召开
                    {
                        sb.AppendFormat(" AND begindate <= \"{0}\" AND enddate >= \"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else if (info.huiyi_status == 3) //已结束
                    {
                        sb.AppendFormat(" AND enddate < \"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    if (info.is_weizhankaitong > 0)
                    {
                        sb.AppendFormat(" AND is_weizhankaitong={0} ", info.is_weizhankaitong);
                    }
                    result = int.Parse(MySQLHelper.ExecuteScalar(sb.ToString()).ToString());
                    break;
            }

            return result;
        }
        public DataTable GetTech_meeting(object obj, string type)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            tech_meeting info = new tech_meeting();
            switch (type)
            {
                case "select_meeting_to_page":
                    #region 无条件查询会议信息（带分页）
                    info = (tech_meeting)obj;
                    sb.Append(" SELECT mid,mtype_id,mname,address,begindate,enddate,brief,mcontactmblie,mcontact,project_manager_id,explains ");
                    sb.Append(" ,regsize,reguser,reguserdate,article,articledate,lodging,lodgingdate,reviewers,reviewersdate,is_weizhankaitong ");
                    sb.Append(" ,meetingcheckin_date,regenddate,m_img,m_website,m_level,is_live,is_playBack,is_recommend,is_xsh_show,zzjzpasswd ");
                    sb.Append(" FROM tech_meeting ");
                    sb.Append(" WHERE 1=1 ");
                    
                    if (info.project_manager_id > 0)
                    {
                        sb.AppendFormat(" AND project_manager_id={0} ", info.project_manager_id);
                    }
                    if (!string.IsNullOrEmpty(info.mname))
                    {
                        sb.AppendFormat(" AND mname LIKE \"%{0}%\" ", info.mname);
                    }
                    if (info.huiyi_status == 1) //即将召开
                    {
                        sb.AppendFormat(" AND begindate > \"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else if (info.huiyi_status == 2) //正在召开
                    {
                        sb.AppendFormat(" AND begindate <= \"{0}\" AND enddate >= \"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else if (info.huiyi_status == 3) //已结束
                    {
                        sb.AppendFormat(" AND enddate < \"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    if (info.is_weizhankaitong > 0)
                    {
                        sb.AppendFormat(" AND is_weizhankaitong={0} ", info.is_weizhankaitong);
                    }
                    sb.Append(" ORDER BY begindate DESC ");
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;

                case "select_meeting":
                    #region 无条件查询会议信息
                    info = (tech_meeting)obj;
                    sb.Append(" SELECT mid,mtype_id,mname,address,begindate,enddate,brief,mcontactmblie,mcontact,project_manager_id,explains ");
                    sb.Append(" ,regsize,reguser,reguserdate,article,articledate,lodging,lodgingdate,reviewers,reviewersdate,is_weizhankaitong ");
                    sb.Append(" ,meetingcheckin_date,regenddate,m_img,m_website,m_level,is_live,is_playBack,is_recommend,is_xsh_show,zzjzpasswd ");
                    sb.Append(" FROM tech_meeting ");
                    sb.Append(" WHERE 1=1 ");
                    
                    if (info.project_manager_id > 0)
                    {
                        sb.AppendFormat(" AND project_manager_id={0} ", info.project_manager_id);
                    }
                    if (!string.IsNullOrEmpty(info.mname))
                    {
                        sb.AppendFormat(" AND mname LIKE \"%{0}%\" ", info.mname);
                    }

                    sb.Append(" ORDER BY begindate DESC ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    #endregion
                    break;
            }
            return dt;
        }
        public DataTable GetTechMeeting(tech_meeting model)
        {
            string strSQL = string.Format("select * from tech_meeting where mid='{0}' and mtype_id='{1}'", model.mid, model.mtype_id);
            return MySQLHelper.ExecuteDataTable(strSQL);
        }

        public tech_meeting MeetingLogin(string mid, string pwd)
        {
            tech_meeting meeting = null;
            string strSQL = string.Format("select * from tech_meeting where mid='{0}' and zzjzpasswd='{1}'", mid, pwd);
            DataTable dt = MySQLHelper.ExecuteDataTable(strSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                meeting = MySQLHelper.ConvertTableToObject<tech_meeting>(dt)[0];
            }
            return meeting;
        }

        public tech_meeting GetModelByMId(string mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from tech_meeting");
            sb.AppendFormat(" where mid='{0}'", mid);
            tech_meeting model = new tech_meeting();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_meeting>(dt)[0];
            return model;
        }
        private string GetLastMid()
        {
            string mid = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT mid FROM tech_meeting ORDER BY mid DESC LIMIT 0,1;");
            mid = MySQLHelper.ExecuteScalar(sb.ToString()).ToString();
            return mid;
        }
        public string GetMid()
        {
            int oldid = int.Parse(GetLastMid().Substring(2, 4));
            int newid = oldid + 1;
            return "HY" + newid;
        }
    }
}
