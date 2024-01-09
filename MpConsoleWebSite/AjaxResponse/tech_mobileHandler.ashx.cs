using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace MpConsoleWebSite.AjaxResponse
{
    /// <summary>
    /// tech_mobileHandler 的摘要说明
    /// </summary>
    public class tech_mobileHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;

        protected override void GetData(HttpContext context)
        {
            requst = context.Request;
            response = context.Response;

            sbContextWrite = new StringBuilder();
            string contextType = requst.Params["type"];
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
            switch (contextType)
            {
                case "1":
                    InputTechMTemplateList(pageIndex, pageSize);
                    break;
                case "2":
                    InputTechMTemplateList2(pageIndex, pageSize);
                    break;
                case "SaveMeeting":
                    SaveMeeting();
                    break;
                case "SaveMobileImgs":
                    SaveMobileImgs();
                    break;
                case "SaveSkin":
                    SaveSkin(xml);
                    break;
                case "SaveSiteTemplate":
                    SaveSiteTemplate();
                    break;
                case "SaveSkinAndSiteImg":
                    SaveSkinAndSiteImg();
                    break;
                case "SaveMeetingAdd":
                    SaveMeetingAdd();
                    break;
                case "pmSaveEdit":
                    pmSaveEdit();
                    break;
            }
        }

        private void pmSaveEdit()
        {
            int is_mobile = 0;
            tech_project_manager info = new tech_project_manager();

            info.mobile = Convert.ToString(requst.Form["mobile"]);
            DataTable mobile_dt = tech_project_managerManager.Instance.GetTech_project_manager(info, "select_manager");
            if (mobile_dt != null && mobile_dt.Rows.Count != 0)
            {
                foreach (DataRow dr in mobile_dt.Rows)
                {
                    if (Convert.ToString(dr["id"]) != Convert.ToString(requst.Form["id"]))
                    {
                        is_mobile += 1;
                    }
                }
            }
            if (is_mobile > 0)
            {
                response.Write("{result:'fail',msg:'手机号码已存在，请重新填写！'}");
                return;
            }

            info.id = Convert.ToInt32(requst.Form["id"].ToString());
            info.full_name = requst.Form["full_name"].ToString();
            info.mobile = requst.Form["mobile"].ToString();
            info.login_name = requst.Form["login_name"].ToString();
            info.login_pwd = Common.DEncrypt.DESEncrypt.Encrypt(requst.Form["login_pwd"].ToString());

            if (requst.Form["full_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'姓名不能为空！'}");
                return;
            }
            if (requst.Form["mobile"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'手机号不能为空！'}");
                return;
            }
            if (requst.Form["login_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'登录名称不能为空！'}");
                return;
            }
            if (requst.Form["login_pwd"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'登录密码不能为空！'}");
                return;
            }

            int result = tech_project_managerManager.Instance.Operation(info, "edit_project_manager");
            if (result > 0)
            {
                response.Write("{result:'succ'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'编辑失败！'}");
                return;
            }
        }

        private void SaveMeetingAdd()
        {
            tech_meeting meeting = new tech_meeting();
            meeting.mtype_id = requst.Form["mtype_id"];
            meeting.mid = requst.Form["mid"];
            meeting.mname = requst.Form["mname"];
            meeting.address = requst.Form["address"];
            meeting.begindate = Convert.ToDateTime(requst.Form["begindate"]);
            meeting.enddate = Convert.ToDateTime(requst.Form["enddate"]);
            meeting.project_manager_id = Convert.ToInt32(requst.Form["project_manager_id"]);
            meeting.reguser = Convert.ToInt32(requst.Form["reguser"]);
            meeting.reguserdate = Convert.ToDateTime(requst.Form["reguserdate"]);
            meeting.article = Convert.ToInt32(requst.Form["article"]);
            meeting.articledate = Convert.ToDateTime(requst.Form["articledate"]);
            meeting.lodging = Convert.ToInt32(requst.Form["lodging"]);
            meeting.lodgingdate = Convert.ToDateTime(requst.Form["lodgingdate"]);
            meeting.meetingcheckin_date = Convert.ToDateTime(requst.Form["meetingcheckin_date"]);
            meeting.regenddate = Convert.ToDateTime(requst.Form["regenddate"]);
            meeting.m_website = requst.Form["m_website"];
            int i = tech_meetingManager.Instance.Operation(meeting, "add");
            if (i >= 1)
            {
                sbContextWrite.Append("OK");
            }
            else
            {
                sbContextWrite.Append("信息保存失败！");
            }
        }

        private void SaveSkinAndSiteImg()
        {
            int result = 0;

            int template_count = tech_mobile_site_templateManager.Instance.Operation(new tech_mobile_site_template { mid = requst.Form["mid"] }, "select_mobile_site_template_count");
            if (template_count > 0)
            {
                sbContextWrite.Append("对不起，网站已经是开通状态，不可再使用其他模板！");
                return;
            }
            else
            {
                string mtemplate_id = Convert.ToString(requst.Form["mtemplate_id"]);
                tech_mobile_template tmt = tech_mobile_templateManager.Instance.GetModelByMTemplateId(mtemplate_id);
                if (tmt != null)
                {
                    tech_mobile_site_template info = new tech_mobile_site_template();

                    info.first_content = tmt.first_content;
                    info.second_content = tmt.second_content;
                    info.footer_content = tmt.footer_content;
                    info.menu_type = tech_mobile_versionManager.Instance.GetModelByVersonId(tmt.version_id.ToString()).menu_type;
                    info.mid = Convert.ToString(requst.Form["mid"]);


                    DataTable dt = tech_mobile_site_templateManager.Instance.GetTech_mobile_site_template(new tech_mobile_site_template { mid = requst.Form["mid"] }, "select_mobile_site_template");
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        result = tech_mobile_site_templateManager.Instance.Operation(info, "add");
                    }

                    IList<tech_mobile_menu> mobile_menu_list = tech_mobile_menuManager.Instance.GetMenuList(Convert.ToString(requst.Form["mid"]));
                    if (mobile_menu_list.Count == 0)
                    {
                        IList<tech_mobile_template_menu> tech_mobile_template_menu_list = tech_mobile_template_menuManager.Instance.GetMenuList(tmt.mtemplate_id.ToString());
                        foreach (var template_menu in tech_mobile_template_menu_list)
                        {
                            tech_mobile_menu mobile_menu = new tech_mobile_menu();
                            mobile_menu.Menu_id = Convert.ToInt32(DateTime.Now.ToString("HHmmssff"));
                            mobile_menu.Menu_name = template_menu.menu_name;
                            mobile_menu.Menu_icon = template_menu.menu_icon;
                            mobile_menu.Menu_url = template_menu.menu_url;
                            mobile_menu.Mid = Convert.ToString(requst.Form["mid"]);
                            mobile_menu.Sort = template_menu.sort;

                            tech_mobile_menuManager.Instance.ModifyMenu(mobile_menu);
                        }
                    }
                }
            }

            if (result >= 1)
            {
                sbContextWrite.Append("OK");
            }
            else
            {
                sbContextWrite.Append("信息保存失败！");
            }
        }

        private void SaveSiteTemplate()
        {
            tech_mobile_site_template info = new tech_mobile_site_template();
            info.first_content = Common.TechMaxClass.Compress(requst.Form["first_content"].ToString());
            info.second_content = Common.TechMaxClass.Compress(requst.Form["second_content"].ToString());
            info.footer_content = Common.TechMaxClass.Compress(requst.Form["footer_content"].ToString());
            info.mid = Convert.ToString(requst.Form["mid"]);
            info.id = Convert.ToInt32(requst.Form["id"]);
            int i = tech_mobile_site_templateManager.Instance.Operation(info, "edit");
            if (i >= 1)
            {
                sbContextWrite.Append("OK");
            }
            else
            {
                sbContextWrite.Append("信息保存失败！");
            }
        }

        private void SaveSkin(string xml)
        {
            int result = 0;

            int template_count = tech_mobile_site_templateManager.Instance.Operation(new tech_mobile_site_template { mid = requst.Form["mid"] }, "select_mobile_site_template_count");
            if (template_count > 0)
            {
                sbContextWrite.Append("对不起，网站已经是开通状态，不可再使用其他模板！");
                return;
            }
            else
            {
                tech_mobile_template tmt = tech_mobile_templateManager.Instance.GetModelByMTemplateId(xml);
                if (tmt != null)
                {
                    tech_mobile_site_template info = new tech_mobile_site_template();

                    info.first_content = tmt.first_content;
                    info.second_content = tmt.second_content;
                    info.footer_content = tmt.footer_content;
                    info.menu_type = tech_mobile_versionManager.Instance.GetModelByVersonId(tmt.version_id.ToString()).menu_type;
                    info.mid = Convert.ToString(requst.Form["mid"]);

                    DataTable dt = tech_mobile_site_templateManager.Instance.GetTech_mobile_site_template(new tech_mobile_site_template { mid = requst.Form["mid"] }, "select_mobile_site_template");
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        result = tech_mobile_site_templateManager.Instance.Operation(info, "add");
                    }

                    IList<tech_mobile_menu> mobile_menu_list = tech_mobile_menuManager.Instance.GetMenuList(Convert.ToString(requst.Form["mid"]));
                    if (mobile_menu_list.Count == 0)
                    {
                        IList<tech_mobile_template_menu> tech_mobile_template_menu_list = tech_mobile_template_menuManager.Instance.GetMenuList(tmt.mtemplate_id.ToString());
                        foreach (var template_menu in tech_mobile_template_menu_list)
                        {
                            tech_mobile_menu mobile_menu = new tech_mobile_menu();
                            mobile_menu.Menu_id = Convert.ToInt32(DateTime.Now.ToString("HHmmssff"));
                            mobile_menu.Menu_name = template_menu.menu_name;
                            mobile_menu.Menu_icon = template_menu.menu_icon;
                            mobile_menu.Menu_url = template_menu.menu_url;
                            mobile_menu.Mid = Convert.ToString(requst.Form["mid"]);
                            mobile_menu.Sort = template_menu.sort;

                            tech_mobile_menuManager.Instance.ModifyMenu(mobile_menu);
                        }
                    }
                }
            }            

            if (result >= 1)
            {
                sbContextWrite.Append("OK");
            }
            else
            {
                sbContextWrite.Append("信息保存失败！");
            }
        }

        private void SaveMobileImgs()
        {
            int result = 0;
            tech_mobile_site_template info = new tech_mobile_site_template();
            info.id = Convert.ToInt32(requst.Params["id"]);
            info.logo = Convert.ToString(requst.Params["logo"]);
            info.main_img_pc = Convert.ToString(requst.Params["main_img_pc"]);
            info.main_img_mobile = Convert.ToString(requst.Params["main_img_mobile"]);
            info.first_content_bg = Convert.ToString(requst.Params["first_content_bg"]);
            info.scend_top_bg = Convert.ToString(requst.Params["scend_top_bg"]);
            info.web_back_color = Convert.ToString(requst.Params["web_back_color"]);
            info.mid = Convert.ToString(requst.Params["mid"]);

            if (info.id == 0)
            {
                result = tech_mobile_site_templateManager.Instance.Operation(info, "add");
            }
            else
            {
                result = tech_mobile_site_templateManager.Instance.Operation(info, "edit");
            }
            if (result >= 1)
            {
                sbContextWrite.Append("OK");
            }
            else
            {
                sbContextWrite.Append("信息保存失败！");
            }
        }

        private void InputTechMTemplateList2(int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            tech_mobile_template info = new tech_mobile_template();
            if (requst.Form["mtype_id"] != null && Convert.ToInt32(requst.Form["mtype_id"]) > 0)
            {
                info.mtype_id = Convert.ToInt32(requst.Form["mtype_id"]);
            }
            if (requst.Form["version_id"] != null && Convert.ToInt32(requst.Form["version_id"]) > 0)
            {
                info.version_id = Convert.ToInt32(requst.Form["version_id"]);
            }
            if (!string.IsNullOrWhiteSpace(requst.Form["mtemplate_name"]))
            {
                info.mtemplate_name = Convert.ToString(requst.Form["mtemplate_name"]);
            }

            info.PageIndex = pageIndex;
            info.PageSize = pageSize;

            DataTable dt = tech_mobile_templateManager.Instance.GetTech_mobile_template(info, "select_mobile_template_to_page");
            int allCount = tech_mobile_templateManager.Instance.Operation(info, "select_mobile_template_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.AppendFormat("<dl id=\"{0}\">", Convert.ToString(dt.Rows[i]["mtemplate_id"]));
                    sb.AppendFormat("<dt><img src=\"{0}\" /></dt>", Convert.ToString(dt.Rows[i]["mtemplate_thumbnail"]));
                    sb.AppendFormat("<dd class=\"clear\">");
                    sb.AppendFormat("<span>{0}</span>", Convert.ToString(dt.Rows[i]["mtemplate_name"]));
                    sb.AppendFormat("<span style=\"float:right;\"><a href=\"javascript: void(0);\" class=\"btn btnyellow\" onclick=\"ChangeMT('{0}')\">选择</a></span>", Convert.ToString(dt.Rows[i]["mtemplate_id"]));
                    sb.AppendFormat("</dd>");
                    sb.Append("</dl>");
                }
            }
            else
            {

                sb.Append("Null");
            }

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_mobileHandler", 1, "form1", "tb_Content"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        private void InputTechMTemplateList(int pageIndex, int pageSize)
        {
            StringBuilder sb = new StringBuilder();
            tech_mobile_template info = new tech_mobile_template();
            if (requst.Form["mtype_id"] != null && Convert.ToInt32(requst.Form["mtype_id"]) > 0)
            {
                info.mtype_id = Convert.ToInt32(requst.Form["mtype_id"]);
            }
            if (requst.Form["version_id"] != null && Convert.ToInt32(requst.Form["version_id"]) > 0)
            {
                info.version_id = Convert.ToInt32(requst.Form["version_id"]);
            }
            if (!string.IsNullOrWhiteSpace(requst.Form["mtemplate_name"]))
            {
                info.mtemplate_name = Convert.ToString(requst.Form["mtemplate_name"]);
            }

            info.PageIndex = pageIndex;
            info.PageSize = pageSize;

            DataTable dt = tech_mobile_templateManager.Instance.GetTech_mobile_template(info, "select_mobile_template_to_page");
            int allCount = tech_mobile_templateManager.Instance.Operation(info, "select_mobile_template_count");
            int pageCount = (allCount + pageSize - 1) / pageSize;
            
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sb.Append("<dl>");
                    sb.AppendFormat("<dt><img src=\"{0}\" /></dt>", Convert.ToString(dt.Rows[i]["mtemplate_thumbnail"]));
                    sb.AppendFormat("<dd class=\"clear\">");
                    sb.AppendFormat("<span>{0}</span>", Convert.ToString(dt.Rows[i]["mtemplate_name"]));
                    sb.AppendFormat("<span style=\"float:right;\"><a href=\"javascript: void(0);\" class=\"btn btnyellow\" onclick=\"SaveData('{0}')\">使用</a></span>", Convert.ToString(dt.Rows[i]["mtemplate_id"]));
                    sb.AppendFormat("</dd>");
                    sb.Append("</dl>");                    
                }
            }
            else
            {

                sb.Append("Null");
            }

            //分页
            sb.Append("<div class=\"fenye\">");
            sb.Append(Page(pageCount, pageIndex, pageSize, "AjaxSubmitDiv", "tech_mobileHandler", 1, "form1", "tb_Content"));
            sb.Append("</div>");
            response.Write(sb.ToString());
        }

        private void SaveMeeting()
        {
            string mid= requst.Form["mid"];
            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
            if (meeting != null && !string.IsNullOrEmpty(meeting.mid))
            {
                meeting.mid = mid;
                meeting.mname = requst.Form["mname"];
                meeting.address = requst.Form["address"];
                meeting.begindate = Convert.ToDateTime(requst.Form["begindate"]);
                meeting.enddate = Convert.ToDateTime(requst.Form["enddate"]);
                meeting.project_manager_id = Convert.ToInt32(requst.Form["project_manager_id"]);
                meeting.reguser = Convert.ToInt32(requst.Form["reguser"]);
                meeting.reguserdate = Convert.ToDateTime(requst.Form["reguserdate"]);
                meeting.article = Convert.ToInt32(requst.Form["article"]);
                meeting.articledate = Convert.ToDateTime(requst.Form["articledate"]);
                meeting.lodging = Convert.ToInt32(requst.Form["lodging"]);
                meeting.lodgingdate = Convert.ToDateTime(requst.Form["lodgingdate"]);
                meeting.meetingcheckin_date = Convert.ToDateTime(requst.Form["meetingcheckin_date"]);
                meeting.regenddate = Convert.ToDateTime(requst.Form["regenddate"]);
                meeting.m_website = requst.Form["m_website"];
                int i = tech_meetingManager.Instance.Operation(meeting, "updateByMobile");
                if (i >= 1)
                {
                    sbContextWrite.Append("OK");
                }
                else
                {
                    sbContextWrite.Append("信息保存失败！");
                }
            }            
        }
    }
}