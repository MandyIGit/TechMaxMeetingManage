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
    public class tech_meeting_user_pptDal : Itech_meeting_user_ppt
    {
        /// <summary>
        /// 根据姓氏名字查询人员
        /// </summary>
        /// <param name="family_name">姓氏</param>
        /// <param name="given_name">名字</param>
        /// <param name="mtype_id">mtype_id</param>
        /// <returns></returns>
        public DataTable SelectUser(string family_name, string given_name, string mtype_id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(" SELECT puid,CONCAT(family_name,given_name) AS fullname FROM tech_meeting_user_ppt WHERE `status`=2 AND family_name='{0}' AND given_name='{1}' AND mtype_id='{2}' ", family_name, given_name, mtype_id);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        /// <summary>
        /// 添加日程人员
        /// </summary>
        /// <param name="family_name">姓氏</param>
        /// <param name="given_name">名字</param>
        /// <param name="mtype_id">mtype_id</param>
        /// <param name="mid">mid</param>
        /// <returns></returns>
        public int AddscheduleUser(string family_name, string given_name, string mtype_id, string mid)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" INSERT INTO tech_meeting_user_ppt (family_name,given_name,username,user_type,mtype_id,mid,inputtime) ");
            sb.AppendFormat(" VALUES ('{0}','{1}','{2}',1,'{3}','{4}','{5}');select @@IDENTITY; ", family_name, given_name, family_name + given_name, mtype_id, mid, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            return Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
        }


        public int Operation(object obj, string type)
        {

            int result = 0;
            StringBuilder sb = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            tech_meeting_user_ppt info = null;
            switch (type)
            {
                case "add":
                    #region add
                    info = (tech_meeting_user_ppt)obj;
                    if (!string.IsNullOrEmpty(info.family_name))
                    {
                        strSql1.Append("family_name,");
                        strSql2.Append("'" + info.family_name + "',");
                    }
                    else
                    {
                        strSql1.Append("family_name,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.given_name))
                    {
                        strSql1.Append("given_name,");
                        strSql2.Append("'" + info.given_name + "',");
                    }
                    else
                    {
                        strSql1.Append("given_name,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.username))
                    {
                        strSql1.Append("username,");
                        strSql2.Append("'" + info.username + "',");
                    }
                    else
                    {
                        strSql1.Append("username,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.family_name_pinyin))
                    {
                        strSql1.Append("family_name_pinyin,");
                        strSql2.Append("'" + info.family_name_pinyin + "',");
                    }
                    else
                    {
                        strSql1.Append("family_name_pinyin,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.given_name_pinyin))
                    {
                        strSql1.Append("given_name_pinyin,");
                        strSql2.Append("'" + info.given_name_pinyin + "',");
                    }
                    else
                    {
                        strSql1.Append("given_name_pinyin,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.title))
                    {
                        strSql1.Append("title,");
                        strSql2.Append("'" + info.title + "',");
                    }
                    else
                    {
                        strSql1.Append("title,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.en_title))
                    {
                        strSql1.Append("en_title,");
                        strSql2.Append("'" + info.en_title + "',");
                    }
                    else
                    {
                        strSql1.Append("en_title,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        strSql1.Append("mobile,");
                        strSql2.Append("'" + info.mobile + "',");
                    }
                    else
                    {
                        strSql1.Append("mobile,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.email))
                    {
                        strSql1.Append("email,");
                        strSql2.Append("'" + info.email + "',");
                    }
                    else
                    {
                        strSql1.Append("email,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.loginpwd))
                    {
                        strSql1.Append("loginpwd,");
                        strSql2.Append("'" + info.loginpwd + "',");
                    }
                    else
                    {
                        strSql1.Append("loginpwd,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.education))
                    {
                        strSql1.Append("education,");
                        strSql2.Append("'" + info.education + "',");
                    }
                    else
                    {
                        strSql1.Append("education,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.en_education))
                    {
                        strSql1.Append("en_education,");
                        strSql2.Append("'" + info.en_education + "',");
                    }
                    else
                    {
                        strSql1.Append("en_education,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.unit))
                    {
                        strSql1.Append("unit,");
                        strSql2.Append("'" + info.unit + "',");
                    }
                    else
                    {
                        strSql1.Append("unit,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (!string.IsNullOrEmpty(info.en_unit))
                    {
                        strSql1.Append("en_unit,");
                        strSql2.Append("'" + info.en_unit + "',");
                    }
                    else
                    {
                        strSql1.Append("en_unit,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.offices))
                    {
                        strSql1.Append("offices,");
                        strSql2.Append("'" + info.offices + "',");
                    }
                    else
                    {
                        strSql1.Append("offices,");
                        strSql2.Append(" DEFAULT, ");
                    }

                    if (info.status > 0)
                    {
                        strSql1.Append("status,");
                        strSql2.Append("" + info.status + ",");
                    }
                    else
                    {
                        strSql1.Append("status,");
                        strSql2.Append("2,");
                    }

                    if (info.user_type > 0)
                    {
                        strSql1.Append("user_type,");
                        strSql2.Append("" + info.user_type + ",");
                    }
                    else
                    {
                        strSql1.Append("user_type,");
                        strSql2.Append("1,");
                    }

                    strSql1.Append("mid,");
                    strSql2.Append("'" + info.mid + "',");

                    strSql1.Append("mtype_id,");
                    strSql2.Append("'" + info.mtype_id + "',");

                    strSql1.Append("inputtime,");
                    strSql2.Append("'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "',");


                    if (!string.IsNullOrEmpty(info.img_urlpath))
                    {
                        strSql1.Append("img_urlpath,");
                        strSql2.Append("'" + info.img_urlpath + "',");
                    }
                    else
                    {
                        strSql1.Append("img_urlpath,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.intro_urlpath))
                    {
                        strSql1.Append("intro_urlpath,");
                        strSql2.Append("'" + info.intro_urlpath + "',");
                    }
                    else
                    {
                        strSql1.Append("intro_urlpath,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.en_intro_urlpath))
                    {
                        strSql1.Append("en_intro_urlpath,");
                        strSql2.Append("'" + info.en_intro_urlpath + "',");
                    }
                    else
                    {
                        strSql1.Append("en_intro_urlpath,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.learnpost))
                    {
                        strSql1.Append("learnpost,");
                        strSql2.Append("'" + info.learnpost + "',");
                    }
                    else
                    {
                        strSql1.Append("learnpost,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.penintro))
                    {
                        strSql1.Append("penintro,");
                        strSql2.Append("'" + info.penintro + "',");
                    }
                    else
                    {
                        strSql1.Append("penintro,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.bankAccountName))
                    {
                        strSql1.Append("bankAccountName,");
                        strSql2.Append("'" + info.bankAccountName + "',");
                    }
                    else
                    {
                        strSql1.Append("bankAccountName,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.bankDeposit))
                    {
                        strSql1.Append("bankDeposit,");
                        strSql2.Append("'" + info.bankDeposit + "',");
                    }
                    else
                    {
                        strSql1.Append("bankDeposit,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.bankCard))
                    {
                        strSql1.Append("bankCard,");
                        strSql2.Append("'" + info.bankCard + "',");
                    }
                    else
                    {
                        strSql1.Append("bankCard,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.idnumber))
                    {
                        strSql1.Append("idnumber,");
                        strSql2.Append("'" + info.idnumber + "',");
                    }
                    else
                    {
                        strSql1.Append("idnumber,");
                        strSql2.Append("DEFAULT,");
                    }

                    if (!string.IsNullOrEmpty(info.receive))
                    {
                        strSql1.Append("receive,");
                        strSql2.Append("'" + info.receive + "',");
                    }
                    else
                    {
                        strSql1.Append("receive,");
                        strSql2.Append("DEFAULT,");
                    }

                    sb.Append("INSERT INTO tech_meeting_user_ppt(");
                    sb.Append(strSql1.ToString().Remove(strSql1.Length - 1));
                    sb.Append(") VALUES (");
                    sb.Append(strSql2.ToString().Remove(strSql2.Length - 1));
                    sb.Append(");SELECT @@IDENTITY;");

                    object o = MySQLHelper.ExecuteScalar(sb.ToString());
                    if (obj != null)
                        result = Convert.ToInt32(o);

                    #endregion
                    break;

                case "edit":
                    #region edit
                    info = (tech_meeting_user_ppt)obj;
                    sb.Append("UPDATE tech_meeting_user_ppt SET ");
                    if (!string.IsNullOrEmpty(info.family_name))
                    {
                        sb.Append("family_name='" + info.family_name + "',");
                    }
                    if (!string.IsNullOrEmpty(info.given_name))
                    {
                        sb.Append("given_name='" + info.given_name + "',");
                    }
                    if (!string.IsNullOrEmpty(info.username))
                    {
                        sb.Append("username='" + info.username + "',");
                    }
                    if (!string.IsNullOrEmpty(info.family_name_pinyin))
                    {
                        sb.Append("family_name_pinyin='" + info.family_name_pinyin + "',");
                    }
                    if (!string.IsNullOrEmpty(info.given_name_pinyin))
                    {
                        sb.Append("given_name_pinyin='" + info.given_name_pinyin + "',");
                    }
                    if (!string.IsNullOrEmpty(info.title))
                    {
                        sb.Append("title='" + info.title + "',");
                    }
                    if (!string.IsNullOrEmpty(info.en_title))
                    {
                        sb.Append("en_title='" + info.en_title + "',");
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.Append("mobile='" + info.mobile + "',");
                    }
                    if (!string.IsNullOrEmpty(info.email))
                    {
                        sb.Append("email='" + info.email + "',");
                    }
                    if (!string.IsNullOrEmpty(info.education))
                    {
                        sb.Append("education='" + info.education + "',");
                    }
                    if (!string.IsNullOrEmpty(info.en_education))
                    {
                        sb.Append("en_education='" + info.en_education + "',");
                    }
                    if (!string.IsNullOrEmpty(info.unit))
                    {
                        sb.Append("unit='" + info.unit + "',");
                    }
                    if (!string.IsNullOrEmpty(info.en_unit))
                    {
                        sb.Append("en_unit='" + info.en_unit + "',");
                    }
                    if (!string.IsNullOrEmpty(info.offices))
                    {
                        sb.Append("offices='" + info.offices + "',");
                    }
                    if (info.user_type > 0)
                    {
                        sb.Append("user_type=" + info.user_type + ",");
                    }
                    if (!string.IsNullOrEmpty(info.img_urlpath))
                    {
                        sb.Append("img_urlpath='" + info.img_urlpath + "',");
                    }
                    if (!string.IsNullOrEmpty(info.intro_urlpath))
                    {
                        sb.Append("intro_urlpath='" + info.intro_urlpath + "',");
                    }
                    if (!string.IsNullOrEmpty(info.en_intro_urlpath))
                    {
                        sb.Append("en_intro_urlpath='" + info.en_intro_urlpath + "',");
                    }
                    if (!string.IsNullOrEmpty(info.learnpost))
                    {
                        sb.Append("learnpost='" + info.learnpost + "',");
                    }
                    if (!string.IsNullOrEmpty(info.penintro))
                    {
                        sb.Append("penintro='" + info.penintro + "',");
                    }

                    if (!string.IsNullOrEmpty(info.bankAccountName))
                    {
                        sb.Append("bankAccountName='" + info.bankAccountName + "',");
                    }
                    if (!string.IsNullOrEmpty(info.bankDeposit))
                    {
                        sb.Append("bankDeposit='" + info.bankDeposit + "',");
                    }
                    if (!string.IsNullOrEmpty(info.bankCard))
                    {
                        sb.Append("bankCard='" + info.bankCard + "',");
                    }
                    if (!string.IsNullOrEmpty(info.idnumber))
                    {
                        sb.Append("idnumber='" + info.idnumber + "',");
                    }
                    if (!string.IsNullOrEmpty(info.receive))
                    {
                        sb.Append("receive='" + info.receive + "',");
                    }
                    if (!string.IsNullOrEmpty(info.signature))
                    {
                        sb.Append("signature='" + info.signature + "',");
                    }

                    int n = sb.ToString().LastIndexOf(",");
                    sb.Remove(n, 1);
                    sb.Append(" where puid=" + info.puid + "");

                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());

                    #endregion
                    break;

                case "del":
                    #region del
                    info = (tech_meeting_user_ppt)obj;
                    sb.AppendFormat("UPDATE tech_meeting_user_ppt SET status=1 WHERE puid={0}", info.puid);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "add_user":    //用于添加用户
                    #region 用于添加用户
                    int int_user_code = 0;
                    object obj_user_code = null;
                    info = (tech_meeting_user_ppt)obj;
                    if (!string.IsNullOrEmpty(info.family_name) && !string.IsNullOrEmpty(info.given_name))
                    {
                        string strSQL = string.Format("select puid from tech_meeting_user_ppt where `status`=2 and concat(family_name,given_name)='{0}' and mtype_id='{1}'", info.family_name + info.given_name, info.mtype_id);
                        obj_user_code = MySQLHelper.ExecuteScalar(strSQL);
                        if (obj_user_code != null)
                            int_user_code = Convert.ToInt32(obj_user_code);
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        string strSQL = string.Format("select puid from tech_meeting_user_ppt where isdel=2 and mobile=\"{0}\"", info.mobile);
                        obj_user_code = MySQLHelper.ExecuteScalar(strSQL);
                        if (obj_user_code != null)
                            int_user_code = Convert.ToInt32(obj_user_code);
                    }
                    if (int_user_code == 0)//如果user_code等0,那么代表用户表不存在，则添加新用户。如果不等0，则代表用户存在，返回用户编码
                    {
                        #region 添加用户
                        sb = new StringBuilder();
                        strSql1 = new StringBuilder();
                        strSql2 = new StringBuilder();
                        if (!string.IsNullOrEmpty(info.family_name))
                        {
                            strSql1.Append("family_name,");
                            strSql2.Append("'" + info.family_name + "',");
                        }
                        if (!string.IsNullOrEmpty(info.given_name))
                        {
                            strSql1.Append("given_name,");
                            strSql2.Append("'" + info.given_name + "',");
                        }
                        if (!string.IsNullOrEmpty(info.family_name_pinyin))
                        {
                            strSql1.Append("family_name_pinyin,");
                            strSql2.Append("'" + info.family_name_pinyin + "',");
                        }
                        if (!string.IsNullOrEmpty(info.given_name_pinyin))
                        {
                            strSql1.Append("given_name_pinyin,");
                            strSql2.Append("'" + info.given_name_pinyin + "',");
                        }
                        if (!string.IsNullOrEmpty(info.username))
                        {
                            strSql1.Append("username,");
                            strSql2.Append("'" + info.username + "',");
                        }
                        if (!string.IsNullOrEmpty(info.mobile))
                        {
                            strSql1.Append("mobile,");
                            strSql2.Append("'" + info.mobile + "',");
                        }
                        if (!string.IsNullOrEmpty(info.email))
                        {
                            strSql1.Append("email,");
                            strSql2.Append("'" + info.email + "',");
                        }
                        if (info.inputtime != null)
                        {
                            strSql1.Append("inputtime,");
                            strSql2.Append("'" + info.inputtime + "',");
                        }

                        if (info.user_type > 0)
                        {
                            strSql1.Append("user_type,");
                            strSql2.Append("" + info.user_type + ",");
                        }

                        if (!string.IsNullOrEmpty(info.mid))
                        {
                            strSql1.Append("mid,");
                            strSql2.Append("'" + info.mid + "',");
                        }

                        if (!string.IsNullOrEmpty(info.mtype_id))
                        {
                            strSql1.Append("mtype_id,");
                            strSql2.Append("'" + info.mtype_id + "',");
                        }

                        if (!string.IsNullOrEmpty(info.bankAccountName))
                        {
                            strSql1.Append("bankAccountName,");
                            strSql2.Append("'" + info.bankAccountName + "',");
                        }

                        if (!string.IsNullOrEmpty(info.bankDeposit))
                        {
                            strSql1.Append("bankDeposit,");
                            strSql2.Append("'" + info.bankDeposit + "',");
                        }

                        if (!string.IsNullOrEmpty(info.bankCard))
                        {
                            strSql1.Append("bankCard,");
                            strSql2.Append("'" + info.bankCard + "',");
                        }

                        if (!string.IsNullOrEmpty(info.idnumber))
                        {
                            strSql1.Append("idnumber,");
                            strSql2.Append("'" + info.idnumber + "',");
                        }

                        if (!string.IsNullOrEmpty(info.receive))
                        {
                            strSql1.Append("receive,");
                            strSql2.Append("'" + info.receive + "',");
                        }

                        sb.Append("insert into tech_meeting_user_ppt(");
                        sb.Append(strSql1.ToString().Remove(strSql1.Length - 1));
                        sb.Append(")");
                        sb.Append(" values (");
                        sb.Append(strSql2.ToString().Remove(strSql2.Length - 1));
                        sb.Append(");select @@IDENTITY;");
                        object ob = MySQLHelper.ExecuteScalar(sb.ToString());
                        if (obj != null)
                            result = Convert.ToInt32(ob);
                        #endregion
                    }
                    else
                    {
                        result = int_user_code;//返回用户编码
                    }
                    #endregion
                    break;

                case "select_user_to_count":
                    info = (tech_meeting_user_ppt)obj;
                    sb.Append("SELECT COUNT(1) FROM tech_meeting_user_ppt WHERE ");
                    sb.AppendFormat(" mtype_id='{0}' and status=2 ", info.mtype_id);
                    if (!string.IsNullOrEmpty(info.username))
                    {
                        sb.AppendFormat(" AND CONCAT(user_ppt.family_name,user_ppt.given_name) LIKE '%{0}%' ", info.username);
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" AND user_ppt.mobile='{0}' ", info.mobile);
                    }
                    if (!string.IsNullOrEmpty(info.email))
                    {
                        sb.AppendFormat(" AND user_ppt.email='{0}' ", info.email);
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    break;

            }
            return result;
        }


        public IList<tech_meeting_user_ppt> GetList(tech_meeting_user_ppt obj, string type)
        {
            StringBuilder sb = new StringBuilder();
            tech_meeting_user_ppt info = obj;
            IList<tech_meeting_user_ppt> list = new List<tech_meeting_user_ppt>();
            DataTable dt = null;
            switch (type)
            {
                case "select_user_to_page":
                    #region 无条件查询用户信息（带分页）
                    sb.Append("select * from tech_meeting_user_ppt as user_ppt where ");
                    sb.AppendFormat(" user_ppt.mtype_id='{0}' and user_ppt.status=2 ", info.mtype_id);
                    if (!string.IsNullOrEmpty(info.username))
                    {
                        sb.AppendFormat(" AND CONCAT(user_ppt.family_name,user_ppt.given_name) LIKE '%{0}%' ", info.username);
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" AND user_ppt.mobile='{0}' ", info.mobile);
                    }
                    if (!string.IsNullOrEmpty(info.email))
                    {
                        sb.AppendFormat(" AND user_ppt.email='{0}' ", info.email);
                    }
                    sb.Append(" GROUP BY user_ppt.puid");
                    int index = info.pageIndex;
                    if (index <= 0)
                    {
                        index = 1;
                    }
                    sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.pageSize, info.pageSize);
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        list = MySQLHelper.ConvertTableToObject<tech_meeting_user_ppt>(dt);
                    }
                    #endregion
                    break;

                case "select_user":
                    #region 无条件查询用户信息
                    sb.Append("select * from tech_meeting_user_ppt as user_ppt where ");
                    sb.AppendFormat(" user_ppt.mtype_id='{0}' and user_ppt.status=2 ", info.mtype_id);
                    if (!string.IsNullOrEmpty(info.username))
                    {
                        sb.AppendFormat(" AND CONCAT(user_ppt.family_name,user_ppt.given_name) LIKE '%{0}%' ", info.username);
                    }
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" AND user_ppt.mobile='{0}' ", info.mobile);
                    }
                    if (!string.IsNullOrEmpty(info.email))
                    {
                        sb.AppendFormat(" AND user_ppt.email='{0}' ", info.email);
                    }
                    sb.Append(" GROUP BY user_ppt.puid ");
                    sb.Append(" ORDER BY user_ppt.family_name_pinyin ASC; ");
                    dt = MySQLHelper.ExecuteDataTable(sb.ToString());
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        list = MySQLHelper.ConvertTableToObject<tech_meeting_user_ppt>(dt);
                    }
                    #endregion
                    break;
            }

            return list;
        }


        public tech_meeting_user_ppt GetMeetingUser_ppt(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT user_ppt.puid, user_ppt.family_name, user_ppt.given_name, user_ppt.username, user_ppt.family_name_pinyin, user_ppt.given_name_pinyin, user_ppt.title ");
            sb.Append(" , user_ppt.mobile, user_ppt.email, user_ppt.en_title, user_ppt.education, user_ppt.en_education, user_ppt.unit, user_ppt.en_unit, user_ppt.offices, user_ppt.status ");
            sb.Append(" , user_ppt.user_type, user_ppt.img_urlpath, user_ppt.intro_urlpath, user_ppt.en_intro_urlpath, user_ppt.learnpost, user_ppt.penintro, user_ppt.province, user_ppt.user_code ");
            sb.Append(" , user_ppt.bankAccountName, user_ppt.bankDeposit, user_ppt.bankCard, user_ppt.idnumber, user_ppt.receive, user_ppt.signature ");
            sb.Append(" FROM tech_meeting_user_ppt as user_ppt ");
            sb.AppendFormat(" WHERE user_ppt.status=2 and user_ppt.puid='{0}'", id);
            tech_meeting_user_ppt model = new tech_meeting_user_ppt();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return MySQLHelper.ConvertTableToObject<tech_meeting_user_ppt>(dt).Count > 0 ? MySQLHelper.ConvertTableToObject<tech_meeting_user_ppt>(dt)[0] : model;
        }

        public DataTable GetMeetingUserByLikeName(tech_meeting_user_ppt info)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM tech_meeting_user_ppt as user_ppt ");
            sb.AppendFormat(" WHERE status=2 AND mtype_id='{0}' ", info.mtype_id);
            if (!string.IsNullOrEmpty(info.username))
            {
                sb.AppendFormat(" AND CONCAT(user_ppt.family_name,user_ppt.given_name) LIKE '%{0}%' ", info.username);
            }
            if (!string.IsNullOrEmpty(info.mobile))
            {
                sb.AppendFormat(" AND user_ppt.mobile='{0}' ", info.mobile);
            }
            if (!string.IsNullOrEmpty(info.email))
            {
                sb.AppendFormat(" AND user_ppt.email='{0}' ", info.email);
            }
            sb.Append(" GROUP BY user_ppt.puid; ");
            dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return dt;
        }

        public tech_meeting_user_ppt GetMeetingUserByName(string mtype_id, string full_name)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM tech_meeting_user_ppt ");
            sb.AppendFormat(" WHERE status=2 AND mtype_id='{0}' AND CONCAT(family_name,given_name)='{1}' ", mtype_id, full_name);
            tech_meeting_user_ppt model = new tech_meeting_user_ppt();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return MySQLHelper.ConvertTableToObject<tech_meeting_user_ppt>(dt).Count > 0 ? MySQLHelper.ConvertTableToObject<tech_meeting_user_ppt>(dt)[0] : model;
        }


    }
}
