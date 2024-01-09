using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Model;
using BLL;
using Newtonsoft.Json;


namespace WebSite.AjaxResponse
{
    /// <summary>
    /// PrintPersonHandler 的摘要说明
    /// </summary>
    public class PrintPersonHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;
        protected override void GetData(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            requst = context.Request;
            response = context.Response;
            string type = requst.QueryString["type"];
            string xml = requst.Params["postvalue"];
            switch (type)
            {
                case "add":
                    Add();
                    break;
                case "edit":
                    Edit();
                    break;
                case "del":
                    Del();
                    break;
                case "uploadExcel":
                    uploadExcel();
                    break;
                case "saveData":
                    saveData(xml);
                    break;
                case "setPrint":
                    setPrint(xml);
                    break;
            }
        }

        

        #region 检查Office版本
        /// <summary>
        /// 检查Office版本
        /// </summary>
        /// <returns></returns>
        public string GetOfficePath()
        {
            string strVersionResult = "没有安装Office";
            string path = "";
            Microsoft.Win32.RegistryKey regKey = null;
            Microsoft.Win32.RegistryKey regSubKey = null;
            try
            {
                regKey = Microsoft.Win32.Registry.LocalMachine;
                for (int i = 8; i < 13; i++)
                {
                    regSubKey = regKey.OpenSubKey(@"SOFTWARE\Microsoft\Office\" + i + @".0\Excel\InstallRoot\");
                    if (regSubKey != null)
                    {
                        path = regSubKey.GetValue("Path").ToString();
                        if (System.IO.File.Exists(path + "Excel.exe"))
                        {
                            switch (i)
                            {
                                case 8: return "2000";
                                case 9: return "XP";
                                case 10: return "2003";
                                case 11: return "2007";
                                case 12: return "2010";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("读取注册表出错!", ex);
            }
            return strVersionResult;
        }
        #endregion

        #region 按Office版本返回相应的DataSet表
        /// <summary>
        /// 按Office版本返回相应的DataSet表
        /// </summary>
        /// <param name="excel_path">Excel文件路径</param>
        /// <returns>连接串</returns>
        public DataSet GetOfficecConnection(string excel_path)
        {
            try
            {
                string version_id = GetOfficePath();
                string strConn = "";
                switch (version_id)
                {
                    case "2003":
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excel_path + ";Extended Properties=\"Excel 8.0;HDR=YES\"";
                        break;
                    case "2007":
                        strConn = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + excel_path + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                        break;
                    case "2010":
                        strConn = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + excel_path + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                        break;
                }
                if (strConn == "")
                {
                    strConn = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=" + excel_path + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                }
                DataSet ds = new DataSet();
                OleDbConnection odc = new OleDbConnection(strConn);
                odc.Open();
                DataTable odc_dt = odc.GetOleDbSchemaTable(OleDbSchemaGuid.Tables_Info, null);
                for (int i = 0; i < odc_dt.Rows.Count; i++)
                {
                    if (Convert.ToString(odc_dt.Rows[i]["CARDINALITY"]) == "0")
                    {
                        OleDbDataAdapter oada = new OleDbDataAdapter("select * from [" + Convert.ToString(odc_dt.Rows[i]["TABLE_NAME"]) + "]", strConn);
                        oada.Fill(ds);
                        odc.Close();
                    }
                }
                return ds;
            }
            catch (Exception ex)
            {
                response.Write(ex.ToString());
                return null;
            }
        }
        #endregion

        private void setPrint(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                tech_person_print info = tech_person_printManager.Instance.GetModelById(int.Parse(xml));
                if (info != null)
                {
                    int result = tech_person_printManager.Instance.Operation(info, "setPrint");
                    if (result > 0)
                    {
                        response.Write("{result:'succ'}");
                        return;
                    }
                    else
                    {
                        response.Write("{result:'fail'}");
                        return;
                    }
                }
            }
        }
        private void saveData(string excel_path)
        {
            string error = "";
            int result = 0;
            DataSet ds = GetOfficecConnection(excel_path);  //检查Office版本并返回相应的DataSet表
            if (ds != null && ds.Tables[0].Rows.Count != 0)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["编码（必填）"])) && Convert.ToString(dt.Rows[i]["编码（必填）"]) != "")
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["姓名（必填）"])) && Convert.ToString(dt.Rows[i]["姓名（必填）"]) == "")
                        {
                            error += "第" + (i + 1) + "行数据“姓名（必填）”无信息，请补充！\r\n";
                        }
                        else
                        {
                            //导入信息

                            string person_code = Convert.ToString(dt.Rows[i]["编码（必填）"]).Trim();
                            string person_name = Convert.ToString(dt.Rows[i]["姓名（必填）"]).Trim();
                            string person_group = Convert.ToString(dt.Rows[i]["类型（必填）"]);

                            tech_person_print info = new tech_person_print();
                            info.person_code = person_code;
                            info.person_name = person_name;
                            switch (person_group)
                            {
                                case "医师领导及工作人员":
                                    info.person_group = 1;
                                    break;

                                case "中宾专家":
                                    info.person_group = 2;
                                    break;

                                case "外宾专家":
                                    info.person_group = 3;
                                    break;

                                default:
                                    info.person_group = 2;
                                    break;

                            }

                            result += tech_person_printManager.Instance.Operation(info, "add");
                        }
                    }
                    else
                    {
                        error += "第" + (i + 1) + "行数据“编码（必填）”无信息，请补充！\r\n";
                    }
                }
                if (result == dt.Rows.Count)
                {
                    response.Write("数据导入成功！");
                    return;
                }
                else if (result > 0 && result < dt.Rows.Count)
                {
                    response.Write("部分数据导入失败！");
                    return;
                }
                else if (result == 0)
                {
                    response.Write("全部数据导入失败！");
                    return;
                }
            }
            else
            {
                response.Write("Excel文件加载错误，请联系管理员！");
            }
        }

        private void uploadExcel()
        {
            HttpPostedFile file = requst.Files["Filedata"];
            //获取文件的保存路径
            string uploadPath = HttpContext.Current.Server.MapPath(requst["folder"]) + "\\";
            //判断上传的文件是否为空
            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //保存文件
                file.SaveAs(uploadPath + file.FileName);
                response.Write(uploadPath + file.FileName);
            }
            else
            {
                response.Write("{result:'fail',msg:'路径错误！'}");
            }
        }

        private void Del()
        {
            tech_person_print info = new tech_person_print();
            if (!string.IsNullOrEmpty(requst.QueryString["id"]))
            {
                info.id = int.Parse(requst.QueryString["id"].ToString());
            }

            int result = tech_person_printManager.Instance.Operation(info, "del");
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
            tech_person_print info = new tech_person_print();

            if (requst.Form["pid"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'ID不能为空！'}");
                return;
            }
            if (requst.Form["person_code"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'人员编码不能为空！'}");
                return;
            }
            if (requst.Form["person_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'人员姓名不能为空！'}");
                return;
            }
            if (requst.Form["person_group"].ToString() == "" || requst.Form["person_group"].ToString() == "0")
            {
                response.Write("{result:'fail',msg:'分组不能为空！'}");
                return;
            }

            info.id = int.Parse(requst.Form["pid"].ToString());
            info.person_code = requst.Form["person_code"].ToString();
            info.person_name = requst.Form["person_name"].ToString();
            info.person_group = int.Parse(requst.Form["person_group"].ToString());

            int result = tech_person_printManager.Instance.Operation(info, "edit");
            if (result > 0)
            {
                response.Write("{result:'succ',msg:'编辑成功！'}");
                return;
            }
            else
            {
                response.Write("{result:'fail',msg:'编辑失败！'}");
                return;
            }
        }

        private void Add()
        {
            tech_person_print info = new tech_person_print();

            if (requst.Form["person_code"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'人员编码不能为空！'}");
                return;
            }
            if (requst.Form["person_name"].ToString() == "")
            {
                response.Write("{result:'fail',msg:'人员姓名不能为空！'}");
                return;
            }
            if (requst.Form["person_group"].ToString() == "" || requst.Form["person_group"].ToString() == "0")
            {
                response.Write("{result:'fail',msg:'分组不能为空！'}");
                return;
            }

            info.person_code = requst.Form["person_code"].ToString();
            info.person_name = requst.Form["person_name"].ToString();
            info.person_group = int.Parse(requst.Form["person_group"].ToString());


            int result = tech_person_printManager.Instance.Operation(info, "add");
            if (result > 0)
            {
                response.Write("{result:'succ',msg:'添加成功！'}");
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