using BLL;
using Common;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace DIY.AjaxResponse
{
    /// <summary>
    /// tech_schedule_searchHandler 的摘要说明
    /// </summary>
    public class tech_schedule_searchHandler : PageBaseHandler
    {

        HttpRequest requst;
        HttpResponse response;

        ArrayList arr_currentID = new ArrayList();

        private string mid, mtype_id;

        protected override void GetData(HttpContext context)
        {
            sbContextWrite = new StringBuilder();
            requst = context.Request;
            response = context.Response;
            string type = requst.QueryString["type"];
            string xml = Convert.ToString(requst.Params["postvalue"]);

            mid = requst.Params["mid"];
            mtype_id = requst.Params["mtype_id"];

            DataSet ds = null;

            if (!string.IsNullOrEmpty(xml) && xml != "")
            {
                ds = TechMaxClass.DataSetVerify(TechMaxClass.getDataSetfromXML(xml));
            }

            int pageIndex = 0;
            int pageSize = 50;

            if (ds != null)
            {
                if (ds.Tables[0].Columns[0].ColumnName == "pageIndex")
                {
                    pageIndex = Convert.ToInt32(ds.Tables[0].Rows[0]["pageIndex"]);
                    pageSize = Convert.ToInt32(ds.Tables[0].Rows[0]["pageSize"]);
                }
            }

            switch (type)
            {
                case "ImportSchedule":
                    ImportSchedule();
                    break;
                case "1":
                    GetSchedule(pageIndex, pageSize);
                    break;
                case "2":
                    getGroupUsers(pageIndex, pageSize);
                    break;
                case "3":
                    labour_list(pageIndex, pageSize);
                    break;
                case "select_having":
                    select_having();
                    break;
                case "saveSignature":
                    saveSignature(xml);
                    break;
            }
        }

        private void saveSignature(string puid)
        {
            tech_meeting_user_ppt info = new tech_meeting_user_ppt();
            info.puid = int.Parse(puid);
            info.signature = requst.Params["signature_url"];
            info.mid = mid;
            info.mtype_id = mtype_id;
            int i = tech_meeting_user_pptManager.Instance.Operation(info, "edit");
            if (i == 1)
            {
                response.Write("success");
            }
            else
            {
                response.Write("faild");
            }
        }

        private void labour_list(int pageIndex, int pageSize)
        {
            tech_meeting_user_ppt info = new tech_meeting_user_ppt();

            string username = requst.Form["username"];

            info.username = username;
            info.mid = mid;
            info.mtype_id = mtype_id;
            info.pageIndex = pageIndex;
            info.pageSize = pageSize;

            StringBuilder sb = new StringBuilder();
            int allCount = tech_meeting_user_pptManager.Instance.Operation(info, "select_user_to_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            IList<tech_meeting_user_ppt> list = tech_meeting_user_pptManager.Instance.GetList(info, "select_user_to_page");
            if (list != null && list.Count > 0)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotable\">");
                sb.Append("<tr>");
                sb.Append("<th>用户编码</th>");
                sb.Append("<th>专家姓名</th>");
                sb.Append("<th>收款账号名称</th>");
                sb.Append("<th>身份证号</th>");
                sb.Append("<th>收款账号开户行</th>");
                sb.Append("<th>收款账号</th>");
                sb.Append("<th>金额</th>");
                sb.Append("<th>手机号码</th>");
                sb.Append("<th>专家签字</th>");
                sb.Append("</tr>");

                foreach (tech_meeting_user_ppt model in list)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", model.puid);
                    sb.AppendFormat("<td>{0}</td>", model.username);
                    sb.AppendFormat("<td>{0}</td>", model.bankAccountName);
                    sb.AppendFormat("<td>{0}</td>", model.idnumber);
                    sb.AppendFormat("<td>{0}</td>", model.bankDeposit);
                    sb.AppendFormat("<td>{0}</td>", model.bankCard);
                    sb.AppendFormat("<td>{0}</td>", model.receive);
                    sb.AppendFormat("<td>{0}</td>", model.mobile);
                    sb.AppendFormat("<td><img src=\"{0}\" style=\"height:20px;\" /></td>", model.signature);
                    sb.Append("</tr>");
                }

                sb.Append("</table>");
            }
            else
            {
                sb.Append("暂无");
            }
            sb.Append("<div class=\"h10\"></div>");
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_schedule_searchHandler", 3, "Myform", "tbContent"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        private void getGroupUsers(int pageIndex, int pageSize)
        {
            tech_meeting_role info = new tech_meeting_role();

            string full_name = requst.Form["full_name"];

            info.Full_name = full_name;
            //info.user_class = int.Parse(requst.Form["user_class"]);
            info.Mid = mid;
            info.Mtype_id = mtype_id;
            info.PageIndex = pageIndex;
            info.PageSize = pageSize;

            StringBuilder sb = new StringBuilder();
            int allCount = 0;
            DataTable dt_count = tech_meeting_roleManager.Instance.GetTech_meeting_role(info, "getGroupUsersCount");
            if (dt_count != null && dt_count.Rows.Count > 0)
            {
                allCount = dt_count.Rows.Count;
            }
            int pageCount = (allCount + pageSize - 1) / pageSize;
            DataTable dt = tech_meeting_roleManager.Instance.GetTech_meeting_role(info, "getGroupUsers");
            if (dt != null && dt.Rows.Count > 0)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotable\">");
                sb.Append("<tr>");
                sb.Append("<th style=\"width:60px;\">用户编码</th>");
                sb.Append("<th style=\"width:80px;\">姓名</th>");
                sb.Append("<th style=\"width:100px;\">学会职称</th>");
                sb.Append("<th>简介</th>");
                sb.Append("<th>照片</th>");
                sb.Append("<th>所属会议</th>");
                sb.Append("<th>操作</th>");
                sb.Append("</tr>");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("puid").ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("full_name").ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("learnpost").ToString());
                    sb.AppendFormat("<td>{0}</td>", Common.TestReplace.ReplaceHtmlTag(Common.DEncrypt.DESEncrypt.Decrypt(dt.Rows[i]["penintro"].ToString())).Length > 45 ? Common.TestReplace.ReplaceHtmlTag(Common.DEncrypt.DESEncrypt.Decrypt(dt.Rows[i]["penintro"].ToString())).Substring(0, 45) + "..." : Common.TestReplace.ReplaceHtmlTag(Common.DEncrypt.DESEncrypt.Decrypt(dt.Rows[i]["penintro"].ToString())));
                    sb.AppendFormat("<td><img src='{0}' style=\"height:50px;\" /></td>", dt.Rows[i].GetValue("img_urlpath").ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("mtype_name").ToString());
                    sb.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"javascript:OpenUrl('/home/mobile_agenda/speaker_edit.aspx?puid={0}','编辑简介',800,610);\">编辑</a></td>", dt.Rows[i].GetValue("puid").ToString());
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
            }
            else
            {
                sb.Append("暂无简介");
            }
            sb.Append("<div class=\"h10\"></div>");
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_schedule_searchHandler", 2, "Myform", "tbContent"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        private void select_having()
        {
            StringBuilder sb = new StringBuilder();
            tech_task_list info = new tech_task_list();
            //info.full_name = "刘冰";
            info.mid = mid;
            info.mtype_id = mtype_id;
            DataTable dt = tech_task_listManager.Instance.GetTech_task_list(info, "select_having");
            if (dt != null && dt.Rows.Count > 0)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotable\">");
                sb.Append("<tr>");
                sb.Append("<th>ID</th>");
                sb.Append("<th>会场</th>");
                sb.Append("<th>Session</th>");
                sb.Append("<th>开始时间</th>");
                sb.Append("<th>结束时间</th>");
                sb.Append("<th>角色</th>");
                sb.Append("<th>姓名</th>");
                sb.Append("<th>任务题目</th>");
                sb.Append("</tr>");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string full_name = dt.Rows[i].GetValue("full_name").ToString();

                    tech_task_list task_list = new tech_task_list();
                    task_list.full_name = full_name;
                    task_list.mid = mid;
                    task_list.mtype_id = mtype_id;
                    DataTable dt_task_list = tech_task_listManager.Instance.GetTech_task_list(task_list);
                    if (dt_task_list != null && dt_task_list.Rows.Count > 0)
                    {
                        ArrayList arr_id = new ArrayList();

                        string currentID = dt_task_list.Rows[0].GetValue("id").ToString();

                        for (int j = 0; j < dt_task_list.Rows.Count; j++)
                        {
                            arr_id.Add(dt_task_list.Rows[j].GetValue("id").ToString());
                        }

                        arr_id.RemoveAt(0);
                        sb.Append(Compar(currentID, arr_id));
                        arr_id.Clear();
                    }
                }
                sb.Append("</table>");
            }
            response.Write(sb.ToString());
        }

        private string Compar(string currentID, ArrayList other_id)
        {

            StringBuilder sb = new StringBuilder();

            tech_task_list curentInfo = tech_task_listManager.Instance.GetModel(currentID);

            for (int i = 0; i < other_id.Count; i++)
            {
                tech_task_list info = tech_task_listManager.Instance.GetModel(other_id[i].ToString());
                if ((Convert.ToDateTime(info.begin_time) >= Convert.ToDateTime(curentInfo.begin_time) && Convert.ToDateTime(info.begin_time) < Convert.ToDateTime(curentInfo.end_time))
                    || (Convert.ToDateTime(info.end_time) > Convert.ToDateTime(curentInfo.begin_time) && Convert.ToDateTime(info.end_time) <= Convert.ToDateTime(curentInfo.end_time)))
                {
                    if (!arr_currentID.Contains(curentInfo.id.ToString()))
                    {
                        sb.Append("<tr>");
                        sb.AppendFormat("<td style=\"color:red;\">{0}</td>", curentInfo.id.ToString());
                        sb.AppendFormat("<td style=\"color:red;\">{0}</td>", curentInfo.meeting_hall.ToString());
                        sb.AppendFormat("<td style=\"color:red;\">{0}</td>", curentInfo.session_name.ToString());
                        sb.AppendFormat("<td style=\"color:red;\">{0}</td>", Convert.ToDateTime(curentInfo.begin_time).ToString("yyyy-MM-dd HH:mm"));
                        sb.AppendFormat("<td style=\"color:red;\">{0}</td>", Convert.ToDateTime(curentInfo.end_time.ToString()).ToString("yyyy-MM-dd HH:mm"));
                        sb.AppendFormat("<td style=\"color:red;\">{0}</td>", curentInfo.role_name.ToString());
                        sb.AppendFormat("<td style=\"color:red;\">{0}</td>", curentInfo.full_name.ToString());
                        sb.AppendFormat("<td style=\"color:red;\">{0}</td>", curentInfo.task_title != null ? curentInfo.task_title.ToString() : "");
                        sb.Append("</tr>");
                    }

                    sb.Append("<tr>");
                    sb.AppendFormat("<td style=\"color:red;\">{0}</td>", info.id.ToString());
                    sb.AppendFormat("<td style=\"color:red;\">{0}</td>", info.meeting_hall.ToString());
                    sb.AppendFormat("<td style=\"color:red;\">{0}</td>", info.session_name.ToString());
                    sb.AppendFormat("<td style=\"color:red;\">{0}</td>", Convert.ToDateTime(info.begin_time).ToString("yyyy-MM-dd HH:mm"));
                    sb.AppendFormat("<td style=\"color:red;\">{0}</td>", Convert.ToDateTime(info.end_time.ToString()).ToString("yyyy-MM-dd HH:mm"));
                    sb.AppendFormat("<td style=\"color:red;\">{0}</td>", info.role_name.ToString());
                    sb.AppendFormat("<td style=\"color:red;\">{0}</td>", info.full_name.ToString());
                    sb.AppendFormat("<td style=\"color:red;\">{0}</td>", info.task_title != null ? info.task_title.ToString() : "");
                    sb.Append("</tr>");

                    arr_currentID.Add(info.id.ToString());
                }

                other_id.RemoveAt(i);
                sb.Append(Compar(info.id.ToString(), other_id));

            }
            return sb.ToString();
        }

        private void ImportSchedule()
        {
            tech_task_list info = new tech_task_list();
            info.mid = mid;
            info.mtype_id = mtype_id;
            tech_task_listManager.Instance.Operation(info, "delAll");

            DataTable dt_schedule = tech_meeting_roleManager.Instance.GetTech_meeting_role(new tech_meeting_role() { Mid = mid, Mtype_id = mtype_id }, "GetTaskForTaskLsit");
            if (dt_schedule != null && dt_schedule.Rows.Count > 0)
            {
                for (int i = 0; i < dt_schedule.Rows.Count; i++)
                {
                    tech_task_list task_list = new tech_task_list();
                    if (dt_schedule.Rows[i].GetValue("role_type").ToString() == "3" || dt_schedule.Rows[i].GetValue("role_type").ToString() == "17")
                    {
                        task_list.meeting_hall = dt_schedule.Rows[i].GetValue("session_place_ch").ToString();
                        task_list.session_name = dt_schedule.Rows[i].GetValue("session_name_ch").ToString();
                        task_list.begin_time = Convert.ToDateTime(dt_schedule.Rows[i].GetValue("begin_time").ToString());
                        task_list.end_time = Convert.ToDateTime(dt_schedule.Rows[i].GetValue("end_time").ToString());
                        task_list.role_name = dt_schedule.Rows[i].GetValue("shenfen").ToString();
                        task_list.full_name = dt_schedule.Rows[i].GetValue("fullname").ToString();
                        task_list.mobile = dt_schedule.Rows[i].GetValue("mobile").ToString();
                        task_list.task_title = dt_schedule.Rows[i].GetValue("agenda_name_ch").ToString();
                        task_list.mid = mid;
                        task_list.mtype_id = mtype_id;
                    }
                    else
                    {
                        task_list.meeting_hall = dt_schedule.Rows[i].GetValue("session_place_chs").ToString();
                        task_list.session_name = dt_schedule.Rows[i].GetValue("session_name_ch").ToString();
                        task_list.begin_time = Convert.ToDateTime(dt_schedule.Rows[i].GetValue("begin_times").ToString());
                        task_list.end_time = Convert.ToDateTime(dt_schedule.Rows[i].GetValue("end_times").ToString());
                        task_list.role_name = dt_schedule.Rows[i].GetValue("shenfen").ToString();
                        task_list.full_name = dt_schedule.Rows[i].GetValue("fullname").ToString();
                        task_list.mobile = dt_schedule.Rows[i].GetValue("mobile").ToString();
                        task_list.task_title = "";
                        task_list.mid = mid;
                        task_list.mtype_id = mtype_id;
                    }
                    tech_task_listManager.Instance.Operation(task_list, "add");
                }
            }
            response.Write("OK");
        }

        private void GetSchedule(int pageIndex, int pageSize)
        {
            tech_task_list info = new tech_task_list();
            info.mid = mid;
            info.mtype_id = mtype_id;

            string meetingtime = requst.Form["select_mt"];
            string btime = "", etime = "";
            if (meetingtime != "0")
            {
                btime = requst.Form["select_mt"] + " " + requst.Form["btime"];
                etime = requst.Form["select_mt"] + " " + requst.Form["etime"];
                info.begin_time = Convert.ToDateTime(btime);
                info.end_time = Convert.ToDateTime(etime);
            }
            string full_name = requst.Form["full_name"];

            info.full_name = full_name;
            info.PageIndex = pageIndex;
            info.PageSize = pageSize;

            StringBuilder sb = new StringBuilder();
            int allCount = tech_task_listManager.Instance.GetTech_task_list_count(info);
            int pageCount = (allCount + pageSize - 1) / pageSize;
            DataTable dt = tech_task_listManager.Instance.GetTech_task_list(info, pageIndex, pageSize);
            if (dt != null && dt.Rows.Count > 0)
            {
                sb.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"infotable\">");
                sb.Append("<tr>");
                sb.Append("<th>ID</th>");
                sb.Append("<th>会场</th>");
                sb.Append("<th>Session</th>");
                sb.Append("<th>开始时间</th>");
                sb.Append("<th>结束时间</th>");
                sb.Append("<th>角色</th>");
                sb.Append("<th>姓名</th>");
                sb.Append("<th>手机</th>");
                sb.Append("<th>任务题目</th>");
                sb.Append("</tr>");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("id").ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("meeting_hall").ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("session_name").ToString());
                    sb.AppendFormat("<td>{0}</td>", Convert.ToDateTime(dt.Rows[i].GetValue("begin_time").ToString()).ToString("yyyy-MM-dd HH:mm"));
                    sb.AppendFormat("<td>{0}</td>", Convert.ToDateTime(dt.Rows[i].GetValue("end_time").ToString()).ToString("yyyy-MM-dd HH:mm"));
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("role_name").ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("full_name").ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("mobile").ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i].GetValue("task_title").ToString());
                    sb.Append("</tr>");
                }
                sb.Append("</table>");
            }
            else
            {
                sb.Append("暂无日程");
            }
            sb.Append("<div class=\"h10\"></div>");
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_schedule_searchHandler", 1, "Myform", "tbContent"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }
    }
}