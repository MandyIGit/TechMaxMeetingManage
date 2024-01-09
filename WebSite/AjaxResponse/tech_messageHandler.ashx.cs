using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Common;
using System.Text;

namespace WebSite.AjaxResponse
{
    /// <summary>
    /// tech_messageHandler 的摘要说明
    /// </summary>
    public class tech_messageHandler : PageBaseHandler
    {

        HttpRequest requst;
        HttpResponse response;
        protected override void GetData(HttpContext context)
        {
            requst = context.Request;
            response = context.Response;
            string type = requst.QueryString["type"];
            string xml = Convert.ToString(requst.Params["postvalue"]);

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
            
            switch (type)
            {
                case "addMsg":
                    Add();
                    break;
                case "editMsg":
                    Edit();
                    break;
                case "delMsg":
                    Del();
                    break;
                case "1":
                    InputMsg_listHTML(pageIndex, pageSize);
                    break;
            }
        }

        private void InputMsg_listHTML(int pageIndex, int pageSize)
        {
            tech_message info = new tech_message();
            info.pageIndex = pageIndex;
            info.pageSize = pageSize;
            if (!string.IsNullOrEmpty(requst.Form["Contacts"]) && Convert.ToString(requst.Form["Contacts"]) != "")
            {
                info.Contacts = Convert.ToString(requst.Form["Contacts"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["UnitName"]) && Convert.ToString(requst.Form["UnitName"]) != "")
            {
                info.UnitName = Convert.ToString(requst.Form["UnitName"]);
            }
            if (!string.IsNullOrEmpty(requst.Form["Phone"]) && Convert.ToString(requst.Form["Phone"]) != "")
            {
                info.Phone = Convert.ToString(requst.Form["Phone"]);
            }
            if (Convert.ToInt32(requst.Form["UnitType"]) != 0)
            {
                info.UnitType = Convert.ToInt32(requst.Form["UnitType"]);
            }
            if (Convert.ToInt32(requst.Form["Status"]) != 0)
            {
                info.Status = Convert.ToInt32(requst.Form["Status"]);
            }
            StringBuilder sb = new StringBuilder();
            int allCount = tech_messageManager.Instance.Operation(info, "select_message_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            DataTable dt = tech_messageManager.Instance.GetTech_message(info, "select_message_to_page");
            sb.Append("<div class=\"table-responsive\" data-pattern=\"priority-columns\" data-focus-btn-icon=\"fa-asterisk\" data-sticky-table-header=\"false\" data-add-display-all-btn=\"false\" data-add-focus-btn=\"false\">");
            sb.Append("<table cellspacing=\"0\" class=\"table table-small-font table-bordered table-striped\">");
            sb.Append("<thead><tr>");
            sb.Append("<th data-priority=\"1\">ID</th>");
            sb.Append("<th data-priority=\"1\">联系人</th>");
            sb.Append("<th data-priority=\"2\">单位名称</th>");
            sb.Append("<th data-priority=\"1\">邮箱</th>");
            sb.Append("<th data-priority=\"1\">电话</th>");
            sb.Append("<th data-priority=\"2\">意向</th>");
            sb.Append("<th data-priority=\"5\">留言内容</th>");
            sb.Append("<th data-priority=\"1\">提交时间</th>");
            sb.Append("<th data-priority=\"2\">处理状态</th>");
            sb.Append("<th data-priority=\"5\">单位类型</th>");
            sb.Append("<th data-priority=\"5\">会议需求</th>");
            sb.Append("<th data-priority=\"5\">会议规模</th>");
            sb.Append("<th data-priority=\"5\">会议开始时间</th>");
            sb.Append("<th data-priority=\"5\">是否沟通</th>");
            sb.Append("<th data-priority=\"5\">沟通进度</th>");
            sb.Append("<th data-priority=\"5\">备注</th>");
            sb.Append("<th data-priority=\"3\">操作</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<tr>");
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["id"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["Contacts"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["UnitName"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["Email"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["Phone"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["Intention"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["Content"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["Inputtime"].ToString());
                    sb.AppendFormat("<td>{0}</td>", getStatusName(dt.Rows[i]["Status"].ToString()));
                    sb.AppendFormat("<td>{0}</td>", getUnitTypeName(dt.Rows[i]["UnitType"].ToString()));
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["MeetingNeed"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["MeetingScale"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["MeetingStartTime"].ToString());
                    sb.AppendFormat("<td>{0}</td>", getIsComm(dt.Rows[i]["isComm"].ToString()));
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["CommProgress"].ToString());
                    sb.AppendFormat("<td>{0}</td>", dt.Rows[i]["Remark"].ToString());
                    sb.AppendFormat("<td>");
                    //sb.AppendFormat("<td><a href=\"edit_msg.aspx?id={0}\" class=\"btn btn-secondary btn-xs\">编辑</a></td>", dt.Rows[i]["id"].ToString());
                    sb.AppendFormat("<a href=\"javascript:;\" id=\"{0}\" onclick=\"window.open('edit_msg.aspx?id={0}','_blank','width=800,height=900,top=80,left=200,scrollbars=yes,resizable=1,modal=false,alwaysRaised=yes')\" class=\"btn btn-secondary btn-xs\">编辑</a>", dt.Rows[i]["id"].ToString());
                    sb.AppendFormat("<a href=\"javascript:;\" class=\"btn btn-danger btn-xs\" onclick=\"mydelete({0})\">删除</a></td>", dt.Rows[i]["id"].ToString());
                    sb.Append("</tr>");
                }
            }
            else
            {
                sb.Append("<tr>");
                sb.Append("<td colspan=\"17\">无</td>");
                sb.Append("</tr>");
            }
            sb.Append("</tbody>");
            sb.Append("</table>");
            sb.Append("</div>");

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_messageHandler", 1, "aspnetForm", "tb_Content"));
            sb.Append("</div>");

            response.Write(sb.ToString());
        }

        protected string getStatusName(string status)
        {
            string StatusName = "";
            if (status == "1")
            {
                StatusName = "已处理";
            }
            else if (status == "2")
            {
                StatusName = "未处理";
            }
            else if (status == "3")
            {
                StatusName = "无效信息";
            }
            return StatusName;
        }

        protected string getUnitTypeName(string UnitType)
        {
            string UnitTypeName = "";
            if (UnitType == "1")
            {
                UnitTypeName = "会务公司";
            }
            else if (UnitType == "2")
            {
                UnitTypeName = "医院";
            }
            else if (UnitType == "3")
            {
                UnitTypeName = "企业";
            }
            else if (UnitType == "4")
            {
                UnitTypeName = "其他";
            }
            return UnitTypeName;
        }

        protected string getIsComm(string isComm)
        {
            string isCommStr = "";
            if (isComm == "1")
            {
                isCommStr = "是";
            }
            else if (isComm == "2")
            {
                isCommStr = "否";
            }
            return isCommStr;
        }

        private void Del()
        {
            tech_message info = new tech_message();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.id = int.Parse(requst.QueryString["id"].ToString());
            }

            int result = tech_messageManager.Instance.Operation(info, "del");
            if (result > 0)
            {
                response.Write("{result:'succ',msg:'删除成功！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'删除失败！'}");
                return;
            }
        }

        private void Edit()
        {
            tech_message info = new tech_message();

            if (requst.Form["Contacts"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'联系人不能为空！'}");
                return;
            }
            if (requst.Form["UnitName"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'单位名称不能为空！'}");
                return;
            }
            if (requst.Form["Email"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'邮箱不能为空！'}");
                return;
            }
            if (requst.Form["Phone"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'电话不能为空！'}");
                return;
            }
            if (requst.Form["Content"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'留言内容不能为空！'}");
                return;
            }

            info.Contacts = requst.Form["Contacts"].ToString();
            info.UnitName = requst.Form["UnitName"].ToString();
            info.Email = requst.Form["Email"].ToString();
            info.Phone = requst.Form["Phone"].ToString();

            string yixiang = "";
            if (requst.Form["cbPhonecall"] != null)
            {
                yixiang += "我希望电话沟通；";
            }
            if (requst.Form["cbMeeting"] != null)
            {
                yixiang += "我希望会议面谈；";
            }
            info.Intention = yixiang;

            info.Content = requst.Form["Content"].ToString();
            info.Status = int.Parse(requst.Form["Status"].ToString());

            if (!string.IsNullOrEmpty(requst.Form["UnitType"]))
            {
                info.UnitType = int.Parse(requst.Form["UnitType"].ToString());
            }

            string MeetingNeed = "";
            if (requst.Form["cbMeetingNeed1"] != null)
            {
                MeetingNeed += "网站；";
            }
            if (requst.Form["cbMeetingNeed2"] != null)
            {
                MeetingNeed += "注册；";
            }
            if (requst.Form["cbMeetingNeed3"] != null)
            {
                MeetingNeed += "直播平台；";
            }
            if (requst.Form["cbMeetingNeed4"] != null)
            {
                MeetingNeed += "展商；";
            }
            info.MeetingNeed = MeetingNeed;

            info.MeetingScale = requst.Form["MeetingScale"].ToString();
            info.MeetingStartTime = DateTime.Parse(requst.Form["MeetingStartTime"].ToString());
            info.isComm = int.Parse(requst.Form["isComm"].ToString());
            info.CommProgress = requst.Form["CommProgress"].ToString();
            info.Remark = requst.Form["Remark"].ToString();
            info.id = int.Parse(requst.Form["id"].ToString());
           
            int result = tech_messageManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'修改失败！'}");
                return;
            }

        }

        private void Add()
        {
            tech_message info = new tech_message();

            if (requst.Form["Contacts"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'联系人不能为空！'}");
                return;
            }
            if (requst.Form["UnitName"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'单位名称不能为空！'}");
                return;
            }
            if (requst.Form["Email"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'邮箱不能为空！'}");
                return;
            }
            if (requst.Form["Phone"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'电话不能为空！'}");
                return;
            }
            if (requst.Form["Content"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'留言内容不能为空！'}");
                return;
            }

            info.Contacts = requst.Form["Contacts"].ToString();
            info.UnitName = requst.Form["UnitName"].ToString();
            info.Email = requst.Form["Email"].ToString();
            info.Phone = requst.Form["Phone"].ToString();

            string yixiang = "";
            if (requst.Form["cbPhonecall"] != null)
            {
                yixiang += "我希望电话沟通；";
            }
            if (requst.Form["cbMeeting"] != null)
            {
                yixiang += "我希望会议面谈；";
            }
            info.Intention = yixiang;

            info.Content = requst.Form["Content"].ToString();
            info.Status = int.Parse(requst.Form["Status"].ToString());

            if (!string.IsNullOrEmpty(requst.Form["UnitType"]))
            {
                info.UnitType = int.Parse(requst.Form["UnitType"].ToString());
            }
            
            string MeetingNeed = "";
            if (requst.Form["cbMeetingNeed1"] != null)
            {
                MeetingNeed += "网站；";
            }
            if (requst.Form["cbMeetingNeed2"] != null)
            {
                MeetingNeed += "注册；";
            }
            if (requst.Form["cbMeetingNeed3"] != null)
            {
                MeetingNeed += "直播平台；";
            }
            if (requst.Form["cbMeetingNeed4"] != null)
            {
                MeetingNeed += "展商；";
            }
            info.MeetingNeed = MeetingNeed;

            info.MeetingScale = requst.Form["MeetingScale"].ToString();
            if (!string.IsNullOrEmpty(requst.Form["MeetingStartTime"].ToString()))
            {
                info.MeetingStartTime = DateTime.Parse(requst.Form["MeetingStartTime"].ToString());
            }            
            info.isComm = int.Parse(requst.Form["isComm"].ToString());
            info.CommProgress = requst.Form["CommProgress"].ToString();
            info.Remark = requst.Form["Remark"].ToString();

            int result = tech_messageManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'添加失败！'}");
                return;
            }
        }
    }
}