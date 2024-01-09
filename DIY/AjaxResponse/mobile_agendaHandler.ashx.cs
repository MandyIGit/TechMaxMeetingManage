using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace DIY.AjaxResponse
{
    /// <summary>
    /// mobile_agenda 的摘要说明
    /// </summary>
    public class mobile_agendaHandler : PageBaseHandler
    {
        HttpRequest request = null;
        HttpResponse response = null;
        HttpContext Context = null;
        private string mid, mtype_id;

        protected override void GetData(HttpContext context)
        {
            request = context.Request;
            response = context.Response;
            Context = context;
            sbContextWrite = new StringBuilder();
            string contextType = request.Params["type"];
            string xml = Convert.ToString(request.Params["postvalue"]);
            mid = request.Params["mid"];
            mtype_id = request.Params["mtype_id"];
            DataSet ds = null;

            if (!string.IsNullOrEmpty(xml) && xml != "")
            {
                ds = TechMaxClass.DataSetVerify(TechMaxClass.getDataSetfromXML(xml));
            }

            int pageIndex = 0;
            int pageSize = 10;

            if (ds != null)
            {
                if (ds.Tables[0].Columns[0].ColumnName == "pageIndex")
                {
                    pageIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["pageIndex"]);
                    pageSize = Convert.ToInt32(ds.Tables[0].Rows[0]["pageSize"]);
                }
            }

            switch (contextType)
            {
                case "GetHallList":
                    GetHallList();
                    break;
                case "GetMeetingTime":
                    GetMeetingTime();
                    break;
                case "GetSchedule_HallListByTime":
                    GetSchedule_HallListByTime();
                    break;
                case "GetSchedule_HallListCountByTime":
                    GetSchedule_HallListCountByTime();
                    break;
                case "DeleteMsg":
                    DeleteMsg();
                    break;
                case "AddSession":
                    AddSession();
                    break;
                case "UpdateSession":
                    UpdateSession();
                    break;
                case "GetSession":
                    GetSession();
                    break;
                case "GetScheduleList":
                    GetScheduleList();
                    break;
                case "AddSchedule":
                    AddSchedule();
                    break;
                case "UpdateSchedule":
                    UpdateSchedule();
                    break;
                case "GetSchedule":
                    GetSchedule();
                    break;
                case "DeleteSchedule":
                    DeleteSchedule();
                    break;
                case "selectuser":
                    selectuser();
                    break;
                case "GetSessionUser":
                    GetSessionUser();
                    break;
                case "GetScheduleUser":
                    GetScheduleUser();
                    break;
                case "GetHallLists":
                    GetHallLists();
                    break;
                case "DeleteHall":
                    DeleteHall();
                    break;
                case "ModefyHall":
                    ModefyHall();
                    break;
                case "GetHall":
                    GetHall();
                    break;
            }

        }

        /// <summary>
        /// 获取会场详情
        /// </summary>
        public void GetHall()
        {
            string hallid = request.Form["hallid"];
            string mid = request.Form["mid"];
            string mtype_id = request.Form["mtype_id"];

            string zhibo_url = string.Empty;
            string channelId = string.Empty;
            string secretkey = string.Empty;

            StringBuilder sb = new StringBuilder();
            tech_meeting_hall model = tech_meeting_hallManager.Instance.GetHallByID(hallid);
            DataTable dt_session = tech_sessionManager.Instance.GetSessionByHallname(model.Hallname, mid, mtype_id);
            if (dt_session != null && dt_session.Rows.Count > 0)
            {
                zhibo_url = dt_session.Rows[0].GetStringValue("zhibo_url");
                channelId = dt_session.Rows[0].GetStringValue("channelId");
                secretkey = dt_session.Rows[0].GetStringValue("secretkey");
            }
            sb.Append("{");
            sb.AppendFormat("'hallname':'{0}','meetingid':'{1}','en_hallname':'{2}','orders':'{3}','zhibo_url':'{4}','channelId':'{5}','secretkey':'{6}'", model.Hallname, model.Mid, model.En_hallname, model.Orders, zhibo_url, channelId, secretkey);
            sb.Append("}");
            response.Write(sb.ToString());
        }

        /// <summary>
        /// 更新或添加会议大厅
        /// </summary>       
        public void ModefyHall()
        {
            tech_meeting_hall model = new tech_meeting_hall();
            model.Hallid = Convert.ToInt32(request.Form["hallid"]);
            model.Hallname = request.Form["meetinghall"];
            model.En_hallname = request.Form["en_meetinghall"];
            model.Orders = Convert.ToInt32(request.Form["orders"]);

            model.zhibo_url = request.Form["zhibo_url"];
            model.channelId = request.Form["channelId"];
            model.secretkey = request.Form["secretkey"];

            model.Mid = mid;
            model.Inputtime = DateTime.Now;
            int i = tech_meeting_hallManager.Instance.ModiAddHall(model);
            response.Write(i.ToString());
            response.End();
        }

        /// <summary>
        /// 删除会议厅
        /// </summary>
        public void DeleteHall()
        {
            string hallid = request.QueryString["hallid"];
            int result = tech_meeting_hallManager.Instance.DeleteHall(Convert.ToInt32(hallid), mid);
            response.Write(result.ToString());
        }

        /// <summary>
        /// 加载会场列表
        /// </summary>
        public void GetHallLists()
        {
            IList<tech_meeting_hall> list = tech_meeting_hallManager.Instance.GetList(mid);
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");
            sb.Append("<th>会议厅会场名称</th>");
            sb.Append("<th>英文会议厅名称</th>");
            sb.Append("<th>排序</th>");
            sb.Append("<th>修改</th>");
            sb.Append("<th>删除</th>");
            sb.Append("</tr>");
            foreach (tech_meeting_hall item in list)
            {
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", item.Hallname);
                sb.AppendFormat("<td>{0}</td>", item.En_hallname);
                sb.AppendFormat("<td>{0}</td>", item.Orders);
                sb.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"javascript:OpenUrl('modifyhall.aspx?hid=" + item.Hallid + "','修改会议大厅',500,400);\"  class=\"i-xiugai\">修改</a></td>");
                sb.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"javascript:deletehall('{0}')\"  class=\"i-shanchu\">修改</a></td>", item.Hallid);
                sb.Append("</tr>");
            }
            sb.Append("<tr>");
            sb.Append("<td colspan=\"5\" style=\"text-align:right;\"><a href=\"javascript:void(0)\" class=\"btnblue\" onclick=\"javascript:OpenUrl('modifyhall.aspx','添加会议大厅',440,240);\">添加会议厅</a></td>");
            sb.Append("</tr>");
            response.Write(sb.ToString());
        }

        #region GetScheduleUser
        protected void GetScheduleUser()
        {
            string sch_id = request.Form["sch_id"];
            StringBuilder sb = new StringBuilder();
            DataTable dt = tech_scheduleManager.Instance.GetScheduleUser(sch_id, mid, mtype_id);
            string zhuchiren = " ";
            string dianping = " ";
            string fanyi = " ";
            string taolun = " ";
            string jiangzhe = " ";
            string canhui = " ";
            string shuzhe = " ";
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (Convert.ToInt32(dr["role_type"]) == 1)
                    {
                        string text = zhuchiren;
                        zhuchiren = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 2)
                    {
                        string text = dianping;
                        dianping = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 4)
                    {
                        string text = fanyi;
                        fanyi = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 5)
                    {
                        string text = taolun;
                        taolun = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 6)
                    {
                        string text = canhui;
                        canhui = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 3)
                    {
                        string text = jiangzhe;
                        jiangzhe = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 17)
                    {
                        string text = shuzhe;
                        shuzhe = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                }
                sb.AppendFormat("{0}+{1}+{2}+{3}+{4}+{5}",
                    zhuchiren,
                    dianping,
                    fanyi,
                    jiangzhe,
                    taolun,
                    shuzhe
                );
            }
            else
            {
                sb.Append("暂无信息");
            }
            response.Write(sb.ToString());
        }
        #endregion

        #region GetSessionUser
        public void GetSessionUser()
        {
            StringBuilder sb = new StringBuilder();
            string session_id = request.Form["session_id"];
            DataTable dataset = tech_sessionManager.Instance.GetSessionuser(Convert.ToInt32(session_id), mid, mtype_id);
            string zhuchiren = "";
            string dianping = "";
            string fanyi = "";
            string taolun = "";
            string canhui = "";
            string zhuxi = "";
            string zhixingzhuxi = "";
            string huiyizhuxi = "";
            string teyaodianpingjiabin = "";
            string pingwei = "";
            string dianpingtaolun = "";
            string shuzhe = "";
            string shoushuzhuchi = "";
            string dianpingjiabin = "";
            if (dataset != null)
            {
                foreach (DataRow dr in dataset.Rows)
                {
                    if (Convert.ToInt32(dr["role_type"]) == 1)
                    {
                        string text = zhuchiren;
                        zhuchiren = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 2)
                    {
                        string text = dianping;
                        dianping = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 4)
                    {
                        string text = fanyi;
                        fanyi = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 5)
                    {
                        string text = taolun;
                        taolun = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 6)
                    {
                        string text = canhui;
                        canhui = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 11)
                    {
                        string text = zhuxi;
                        zhuxi = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 12)
                    {
                        string text = zhixingzhuxi;
                        zhixingzhuxi = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 13)
                    {
                        string text = huiyizhuxi;
                        huiyizhuxi = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 14)
                    {
                        string text = teyaodianpingjiabin;
                        teyaodianpingjiabin = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 15)
                    {
                        string text = pingwei;
                        pingwei = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 16)
                    {
                        string text = dianpingtaolun;
                        dianpingtaolun = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 17)
                    {
                        string text = shuzhe;
                        shuzhe = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 18)
                    {
                        string text = shoushuzhuchi;
                        shoushuzhuchi = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }
                    if (Convert.ToInt32(dr["role_type"]) == 19)
                    {
                        string text = dianpingjiabin;
                        dianpingjiabin = string.Concat(new string[]
                        {
                            text,
                            "<li ff=\"",
                            Convert.ToString(dr["user_code"]),
                            "\"><span>",
                            Convert.ToString(dr["fullname"]),
                            "</span><a onclick=\"deleteRole(this)\">&nbsp;</a></li>"
                        });
                    }

                }
                sb.AppendFormat("{0}+{1}+{2}+{3}+{4}+{5}+{6}+{7}+{8}+{9}+{10}+{11}+{12}+{13}",
                    zhuchiren,
                    dianping,
                    fanyi,
                    taolun,
                    canhui,
                    zhuxi,
                    zhixingzhuxi,
                    huiyizhuxi,
                    teyaodianpingjiabin,
                    pingwei,
                    dianpingtaolun,
                    shuzhe,
                    shoushuzhuchi,
                    dianpingjiabin
                );
            }
            response.Write(sb.ToString());
        }
        #endregion

        #region selectuser
        private void selectuser()
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(request.Form["rolefullname"])) 
            {
                string family_name = "";
                string given_name = "";
                string uname = Convert.ToString(request.Form["rolefullname"]).Trim().Replace(" ", "");
                if (Common.Pinyin.GetFuxing(uname))
                {
                    family_name = uname.Substring(0, 2);
                    given_name = uname.Substring(2, uname.Length - 2);
                }
                else
                {
                    family_name = uname.Substring(0, 1);
                    given_name = uname.Substring(1, uname.Length - 1);
                }
           
                DataTable dt = new tech_meeting_user_pptManager().SelectUser(family_name, given_name, mtype_id);
                if (dt != null && dt.Rows.Count > 0)
                {
                    sb.Append("{");
                    sb.AppendFormat("'result':'yes','id':'{0}','name':'{1}'", Convert.ToString(dt.Rows[0]["puid"]), Convert.ToString(dt.Rows[0]["fullname"]));
                    sb.Append("}");
                }
                else
                {
                    int puid = new tech_meeting_user_pptManager().AddscheduleUser(family_name, given_name, mtype_id, mid);
                    if (puid > 0)
                    {
                        sb.Append("{");
                        sb.AppendFormat("'result':'yes','id':'{0}','name':'{1}'", puid, family_name + given_name);
                        sb.Append("}");
                    }
                }
            }
            else
            {
                sb.Append("{'result':'no'}");
            }
            response.Write(sb.ToString());
        }
        #endregion


        #region  日程管理
        /// <summary>
        /// 获取会议厅列表
        /// </summary>
        protected void GetHallList()
        {
            IList<tech_meeting_hall> list = new tech_meeting_hallManager().GetList(mid);
            StringBuilder sb = new StringBuilder();
            sb.Append("{'plist':[");
            sb.Append("{'value':'0','name':'-请选择-'}");
            sb.AppendFormat("{0}", list.Count > 0 ? "," : "");
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append("{");
                    sb.AppendFormat("'value':'{0}','name':'{1}'", list[i].Hallid, list[i].Hallname);
                    sb.Append("}");
                }
                else
                {
                    sb.Append("{");
                    sb.AppendFormat("'value':'{0}','name':'{1}'", list[i].Hallid, list[i].Hallname);
                    sb.Append("},");
                }
            }
            sb.Append("]}");
            response.Write(sb.ToString());
        }

        /// <summary>
        /// 获取会议时间
        /// </summary>
        protected void GetMeetingTime()
        {
            StringBuilder sb = new StringBuilder();
            tech_meeting meeting = new tech_meetingManager().GetModelByMId(mid);
            TimeSpan ts = meeting.enddate - meeting.begindate;
            int days = ts.Days;
            List<DateTime> list = new List<DateTime>();
            for (int i = 0; i <= days; i++)
            {
                list.Add(meeting.begindate.AddDays(i));
            }

            sb.Append("{'plist':[");
            for (int i = 0; i < list.Count; i++)
            {
                if (i == list.Count - 1)
                {
                    sb.Append("{");
                    sb.AppendFormat("'value':'{0}','name':'{1}'", list[i].ToString("yyyy-MM-dd"), list[i].ToString("yyyy-MM-dd"));
                    sb.Append("}");
                }
                else
                {
                    sb.Append("{");
                    sb.AppendFormat("'value':'{0}','name':'{1}'", list[i].ToString("yyyy-MM-dd"), list[i].ToString("yyyy-MM-dd"));
                    sb.Append("},");
                }
            }
            sb.Append("]}");
            response.Write(sb.ToString());

        }
        /// <summary>
        /// 根据时间加载日程会议厅列表
        /// </summary>
        protected void GetSchedule_HallListByTime()
        {
            StringBuilder sb = new StringBuilder();
            DateTime time = Convert.ToDateTime(request.Form["session_date"]);
            DataTable hallList = tech_sessionManager.Instance.GetHallList(mid);
            if (hallList != null)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotable\">");
                sb.Append("<tr>");
                sb.AppendFormat("<th colspan=\"8\" class=\"f14\"><a href=\"javascript:viod(0)\" >{0}</a></th>", time.ToString("yyyy-MM-dd"));
                sb.Append("</tr>");
                foreach (DataRow dr in hallList.Rows)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td colspan=\"8\"><span class=\"fl b \">会议厅场：{0}</span></td>", dr["hallname"]);
                    sb.Append("</tr>");
                    sb.Append("<tr>");
                    sb.AppendFormat("<td><input type=\"checkbox\" name=\"{0}_{1}\" id=\"{0}_{1}\" onclick=\"getAllValue('{0}_{1}')\"/></td>", dr["hallname"], time.ToString("yyyyMMdd"));
                    sb.Append("<td class=\"b\">会议时间段</td>");
                    sb.Append("<td class=\"b\">主题名称</td>");
                    sb.Append("<td class=\"b\">会议主持</td>");
                    sb.Append("<td class=\"b\">点评专家</td>");
                    sb.Append("<td class=\"b\">讨论专家</td>");
                    sb.Append("<td class=\"b\">参会</td>");
                    sb.Append("<td class=\"b\">操作</td>");
                    sb.Append(" </tr>");
                    DataTable sessionList = tech_sessionManager.Instance.GetSessionList(time, Convert.ToString(dr["hallname"]), mid, mtype_id);
                    if (sessionList != null)
                    {
                        foreach (DataRow sRow in sessionList.Rows)
                        {
                            sb.Append("<tr>");
                            sb.AppendFormat("<td><input class=\"check_class\" type=\"checkbox\" name=\"s_{0}_{1}\" id=\"{2}\" /></td>", dr["hallname"], time.ToString("yyyyMMdd"), sRow["session_id"]);
                            sb.AppendFormat("<td>{0}-{1}</td>", Convert.ToDateTime(sRow["begin_time"]).ToString("HH:mm"), Convert.ToDateTime(sRow["end_time"]).ToString("HH:mm"));
                            sb.AppendFormat("<td>{0}</td>", sRow["session_name_ch"]);
                            DataTable sessionListuser = tech_sessionManager.Instance.GetSessionListuser(Convert.ToString(sRow["session_id"]), mid, mtype_id);
                            if (sessionListuser != null)
                            {
                                sb.AppendFormat("<td>{0}</td>", Convert.ToString(sessionListuser.Rows[0]["fullname"]));
                                sb.AppendFormat("<td>{0}</td>", Convert.ToString(sessionListuser.Rows[1]["fullname"]));
                                sb.AppendFormat("<td>{0}</td>", Convert.ToString(sessionListuser.Rows[3]["fullname"]));
                                sb.AppendFormat("<td>{0}</td>", Convert.ToString(sessionListuser.Rows[4]["fullname"]));
                            }
                            else
                            {
                                sb.Append("<td>&nbsp;</td>");
                                sb.Append("<td>&nbsp;</td>");
                                sb.Append("<td>&nbsp;</td>");
                                sb.Append("<td>&nbsp;</td>");
                            }
                            sb.Append("<td>");
                            sb.AppendFormat("<a href=\"javascript:void(0)\" onclick=\"OpenUrl('add_sch.aspx?session_id={0}','增加日程',600,450)\">增加日程</a>&nbsp;| ", sRow["session_id"]);
                            sb.Append("&nbsp;<a href=\"javascript:void(0)\" onclick=\"OpenUrl('schedule_list.aspx?session_id=" + sRow["session_id"] + "','修改会议日程',900,600)\">日程管理</a>&nbsp;|");
                            sb.Append("&nbsp;<a href=\"javascript:void(0)\" onclick=\"OpenUrl('edit_session.aspx?session_id=" + sRow["session_id"] + "','单元修改',900,600)\">单元修改</a>");
                            sb.Append("</td>");
                            sb.Append("</tr>");
                        }
                    }
                    else
                    {
                        sb.Append("<tr><td colspan=\"8\">暂无数据</td></tr>");
                    }
                }
                sb.Append(" </table>");
                sb.Append("<div class=\"h10\">  ");
                sb.Append("</div>");
            }
            else
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotable\">");
                sb.Append("<tr>");
                sb.Append("<td colspan=\"8\" >暂无数据</td>");
                sb.Append("</tr>");
                sb.Append("</table>");
            }
            response.Write(sb.ToString());
        }

        /// <summary>
        /// 根据时间加载日程会议厅列表的总页数
        /// </summary>
        protected void GetSchedule_HallListCountByTime()
        {
            string hallid = request.Form["select_halllist"];
            string meetingtime = request.Form["select_mt"];
            if (meetingtime == "0")
            {
                IList<DateTime> list = tech_meeting_scheduleManager.Instance.GetTimeList(mid, hallid);
                response.Write(list.Count);
            }
            else
            {
                response.Write("1");
            }
        }

        /// <summary>
        /// 删除会议单元
        /// </summary>
        protected void DeleteMsg()
        {
            string ids = request.Form["IDs"];
            int result = tech_sessionManager.Instance.DeleteSessions(ids, mtype_id, mid);
            response.Write(result.ToString());
        }

        /// <summary>
        /// 根据会议时间获取日程列表
        /// </summary>
        /// <param name="meetingtime"></param>
        /// <returns></returns>
        public DateTime GetTimeList(string hallid, string meetingtime, int pageindex)
        {

            if (meetingtime == "0")
            {
                IList<DateTime> list = tech_meeting_scheduleManager.Instance.GetTimeList(mid, hallid);
                if (list.Count > 0)
                {
                    return list[pageindex - 1];
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
            else
            {
                return Convert.ToDateTime(meetingtime);
            }


        }

        /// <summary>
        /// 添加单元信息
        /// </summary>
        public void AddSession()
        {
            tech_session session = new tech_session();

            session.Session_name = request.Form["session_name"];
            session.Session_date = Convert.ToDateTime(request.Form["session_date"]);
            session.Hall_id = Convert.ToInt32(request.Form["hall_id"]);
            session.Session_btime = Convert.ToDateTime(session.Session_date.ToString("yyyy-MM-dd") + " " + request.Form["session_btime"]);
            session.Session_etime = Convert.ToDateTime(session.Session_date.ToString("yyyy-MM-dd") + " " + request.Form["session_etime"]);
            session.Holders = request.Form["holders"];
            session.Transfers = request.Form["transfers"];
            session.Reviewers = request.Form["reviewers"];
            session.Discussers = request.Form["discussers"];
            session.Meetingusers = request.Form["meetingusers"];
            session.zhuxi = this.request.Form["zhuxi"];
            session.zhixingzhuxi = this.request.Form["zhixingzhuxi"];
            session.huiyizhuxi = this.request.Form["huiyizhuxi"];
            session.teyaodianpingjiabin = this.request.Form["teyaodianpingjiabin"];
            session.pingwei = this.request.Form["pingwei"];
            session.dianpingtaolun = this.request.Form["dianpingtaolun"];
            session.shuzhe = this.request.Form["shuzhe"];
            session.shoushuzhuchi = this.request.Form["shoushuzhuchi"];
            session.dianpingjiabin = this.request.Form["dianpingjiabin"];
            session.Mid = mid;
            session.Mtype_id = mtype_id;

            int i = tech_sessionManager.Instance.AddSession(session);
            if (i > 0)
            {
                response.Write("{result:1,msg:''}");
            }
            else
            {
                response.Write("{result:0,msg:'添加失败，请重试'}");
            }

        }

        /// <summary>
        /// 修改单元信息
        /// </summary>
        public void UpdateSession()
        {
            tech_session session = new tech_session();
            session.Session_id = Convert.ToInt32(this.request.Form["session_id"]);
            session.Session_name = this.request.Form["session_name"];
            session.Session_date = Convert.ToDateTime(this.request.Form["session_date"]);
            session.Hall_id = Convert.ToInt32(this.request.Form["hall_id"]);
            session.Session_btime = Convert.ToDateTime(session.Session_date.ToString("yyyy-MM-dd") + " " + this.request.Form["session_btime"]);
            session.Session_etime = Convert.ToDateTime(session.Session_date.ToString("yyyy-MM-dd") + " " + this.request.Form["session_etime"]);
            session.Holders = this.request.Form["holders"];
            session.Transfers = this.request.Form["transfers"];
            session.Reviewers = this.request.Form["reviewers"];
            session.Discussers = this.request.Form["discussers"];
            session.Meetingusers = this.request.Form["meetingusers"];
            session.zhuxi = this.request.Form["zhuxi"];
            session.zhixingzhuxi = this.request.Form["zhixingzhuxi"];
            session.huiyizhuxi = this.request.Form["huiyizhuxi"];
            session.teyaodianpingjiabin = this.request.Form["teyaodianpingjiabin"];
            session.pingwei = this.request.Form["pingwei"];
            session.dianpingtaolun = this.request.Form["dianpingtaolun"];
            session.shuzhe = this.request.Form["shuzhe"];
            session.shoushuzhuchi = this.request.Form["shoushuzhuchi"];
            session.dianpingjiabin = this.request.Form["dianpingjiabin"];
            session.Mid = mid;
            session.Mtype_id = mtype_id;
            int i = tech_sessionManager.Instance.UpdateSession(session);
            if (i > 0)
            {
                response.Write("{result:1,msg:''}");
            }
            else
            {
                response.Write("{result:0,msg:'修改失败，请重试'}");
            }

        }

        /// <summary>
        /// 获取信息
        /// </summary>
        public void GetSession()
        {
            StringBuilder sb = new StringBuilder();
            string session_id = this.request.Form["session_id"];
            DataTable dt = tech_sessionManager.Instance.GetSession(Convert.ToInt32(session_id), mid);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                sb.Append("{\"result\":\"1\",");
                sb.AppendFormat("\"session_date\":\"{0}\",\"hall_id\":\"{1}\",\"session_btime\":\"{2}\",\"session_name\":\"{3}\",", new object[]
                {
                    Convert.ToDateTime(dr["session_date"]).ToString("yyyy-MM-dd"),
                    dr["hallid"],
                    Convert.ToDateTime(dr["begin_time"]).ToString("HH:mm"),
                    dr["session_name_ch"]
                });
                sb.AppendFormat("\"session_etime\":\"{0}\",\"hall_name\":\"{1}\"", Convert.ToDateTime(dr["end_time"]).ToString("HH:mm"), dr["session_place_ch"]);
                sb.Append("}");
            }
            else
            {
                sb.Append("{\"result\":\"0\"}");
            }

            response.Write(sb.ToString());
        }


        /// <summary>
        /// 获取日程内容列表
        /// </summary>       
        protected void GetScheduleList()
        {
            string session_id = request.Form["session_id"];
            StringBuilder sb = new StringBuilder();
            sb.Append("<tr>");
            sb.Append("<th>时间</th>");
            sb.Append("<th>讲题</th>");
            sb.Append("<th>主讲人</th>");
            sb.Append("<th>修改</th>");
            sb.Append("<th>删除</th>");
            sb.Append("</tr>");
            DataTable dtResult = tech_scheduleManager.Instance.GetScheduleList(session_id, mid, mtype_id);
            if (dtResult != null)
            {
                foreach (DataRow dr in dtResult.Rows)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", Convert.ToDateTime(dr["begin_time"]).ToString("HH:mm") + "-" + Convert.ToDateTime(dr["end_time"]).ToString("HH:mm"));
                    sb.AppendFormat("<td>{0}</td>", dr["agenda_name_ch"]);
                    sb.AppendFormat("<td>{0}</td>", dr["fullname"]);
                    sb.AppendFormat("<td><a class=\"i-xiugai\" onclick=\"OpenUrl('edit_sch.aspx?sch_id={0}&session_id={1}','修改日程',600,450)\" title=\"修改\">修改</a></td>", dr["agenda_id"], session_id);
                    sb.AppendFormat("<td><a class=\"i-shanchu\" href=\"javascript:DeleteSch('{0}')\" title=\"删除\">删除</a></td>", dr["agenda_id"]);
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr><td colspan=\"5\"> 暂无数据 </td> </tr>");
            }

            response.Write(sb.ToString());
        }


        /// <summary>
        /// 添加日程
        /// </summary>
        protected void AddSchedule()
        {
            tech_schedule model = new tech_schedule();
            model.Session_id = Convert.ToInt32(request.Form["session_id"]);
            model.Speaker = request.Form["speaker"];
            model.Sch_name = request.Form["sch_name"];
            model.Begintime = request.Form["session_date"] + " " + request.Form["btime"] + ":00";
            model.Endtime = request.Form["session_date"] + " " + request.Form["etime"] + ":00";
            model.Holders = request.Form["holders"];
            model.Transfers = request.Form["transfers"];
            model.Reviewers = request.Form["reviewers"];
            model.Discussers = request.Form["discussers"];
            model.Shuzhe = request.Form["shuzhe"];
            model.Mid = mid;
            model.Mtyleid = mtype_id;
            int i = tech_scheduleManager.Instance.AddSchedule(model);
            if (i > 0)
            {
                response.Write("{result:1,msg:''}");
            }
            else
            {
                response.Write("{result:0,msg:'添加失败，请重试'}");
            }

        }

        /// <summary>
        /// 获取日程信息
        /// </summary>
        protected void GetSchedule()
        {
            string session_id = request.Form["session_id"];
            string sch_id = request.Form["sch_id"];
            StringBuilder sb = new StringBuilder();
            DataTable dt = tech_scheduleManager.Instance.GetSchedule(sch_id, session_id, mid, mtype_id);
            if (dt != null)
            {
                DataRow dr = dt.Rows[0];
                sb.Append("{result:1,");
                sb.AppendFormat("sch_id:\"{0}\",sch_name:\"{1}\",session_id:\"{2}\",", dr["agenda_id"], dr["agenda_name_ch"], dr["session_id"]);
                sb.AppendFormat("sch_btime:\"{0}\",sch_etime:\"{1}\"", Convert.ToDateTime(dr["begin_time"]).ToString("HH:mm"), Convert.ToDateTime(dr["end_time"]).ToString("HH:mm"));
                sb.Append("}");
            }
            else
            {
                sb.Append("{result:0}");
            }
            response.Write(sb.ToString());
        }

        /// <summary>
        /// 修改日程
        /// </summary>
        protected void UpdateSchedule()
        {
            tech_schedule model = new tech_schedule();
            model.Sch_id = Convert.ToInt32(this.request.Form["sch_id"]);
            model.Session_id = Convert.ToInt32(this.request.Form["session_id"]);
            model.Speaker = this.request.Form["speaker"];
            model.Sch_name = this.request.Form["sch_name"];
            model.Begintime = this.request.Form["session_date"] + " " + this.request.Form["btime"] + ":00";
            model.Endtime = this.request.Form["session_date"] + " " + this.request.Form["etime"] + ":00";
            model.Holders = this.request.Form["holders"];
            model.Transfers = this.request.Form["transfers"];
            model.Reviewers = this.request.Form["reviewers"];
            model.Discussers = this.request.Form["discussers"];
            model.Shuzhe = this.request.Form["shuzhe"];
            model.Mid = mid;
            model.Mtyleid = mtype_id;
            int i = tech_scheduleManager.Instance.UpdateSchedule(model);
            if (i > 0)
            {
                response.Write("{result:1,msg:''}");
            }
            else
            {
                response.Write("{result:0,msg:'修改失败，请重试'}");
            }
        }


        /// <summary>
        /// 删除日程
        /// </summary>
        protected void DeleteSchedule()
        {
            string sch_id = request.Params["sch_id"];
            int i = tech_scheduleManager.Instance.DeleteSchedule(sch_id);
            if (i > 0)
            {
                response.Write("{result:1,msg:''}");
            }
            else
            {
                response.Write("{result:0,msg:'删除失败，请重试'}");
            }
        }
        #endregion

    }
}
