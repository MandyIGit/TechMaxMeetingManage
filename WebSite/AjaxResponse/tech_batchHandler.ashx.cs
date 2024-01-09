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
    /// tech_batchHandler 的摘要说明
    /// </summary>
    public class tech_batchHandler : PageBaseHandler
    {
        HttpRequest requst;
        HttpResponse response;
        protected override void GetData(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            requst = context.Request;
            response = context.Response;
            string type = requst.Params["type"];
            string xml = requst.Params["postvalue"];


            switch (type)
            {
                case "uploadExcel":
                    uploadExcel();
                    break;
                case "saveData":
                    saveData(xml);
                    break;
                case "loadTable":
                    loadTable();
                    break;
                case "delAll":
                    delAll();
                    break;
                case "excBatchAccount":
                    excBatchAccount();
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

        private void delAll()
        {
            tech_temp_batch_accountManager.Instance.Operation(new tech_temp_batch_account(), "delAll");
            response.Write("删除成功！");
        }

        private void excBatchAccount()
        {
            int in_error = 0;
            tech_cart cart = new tech_cart();
            List<tech_temp_batch_account> list = tech_temp_batch_accountManager.Instance.GetTechTempBatchAccount();
            foreach (tech_temp_batch_account info in list)
            {
                cart.Order_id = info.order_id;
                cart.Total_fee = info.total_fee;
                tech_cart resultCart = tech_cartManager.Instance.GetTech_cart(cart, "select_msg");
                if (resultCart != null && resultCart.Order_id!=null)
                {
                    tech_temp_batch_accountManager.Instance.Operation(resultCart, "edit");
                }
                else
                {
                    in_error += 1;
                }
            }

            response.Write("" + in_error + "");

        }

        private void loadTable()
        {
            List<tech_temp_batch_account> list = tech_temp_batch_accountManager.Instance.GetTechTempBatchAccount();
            //response.Write(JsonConvert.SerializeObject(list)); 
            StringBuilder sb = new StringBuilder();            
            sb.AppendFormat("<table style=\"width:100%;\" class=\"table table-small-font table-bordered\">");
            sb.AppendFormat("<tr>");
            sb.AppendFormat("<th style=\"height:30px;\">商户订单号</th><th>交易金额(元)</th><th>支付方式</th><th>系统订单</th>");
            sb.AppendFormat("</tr>");
            foreach (tech_temp_batch_account info in list)
            {
                if(info.children_ids=="")
                    sb.AppendFormat("<tr style=\"background:#FF0\">");
                else
                    sb.AppendFormat("<tr>");
                sb.AppendFormat("<td style=\"height:26px;\">{0}</td>", info.order_id);
                sb.AppendFormat("<td>{0}</td>", info.total_fee);
                sb.AppendFormat("<td>{0}</td>", getPayType(info.pay_type));
                sb.AppendFormat("<td>{0}</td>", info.children_ids);
                sb.AppendFormat("</tr>");
            }
            sb.AppendFormat("<tr><td colspan=4 style=\"text-align:center;height:28px;\">共有<b style=\"color:red\">{0}</b>条数据</td></tr>", list.Count);
            sb.AppendFormat("</table>");
            response.Write(sb.ToString());
        }

        private string getPayType(int pay_type)
        {
            string strRet = null;
            switch (pay_type)
            {
                case 1:
                    strRet = "现金支付";
                    break;
                case 2:
                    strRet = "邮局汇款";
                    break;
                case 3:
                    strRet = "支付宝";
                    break;
                case 4:
                    strRet = "环迅支付";
                    break;
                case 5:
                    strRet = "银行汇款";
                    break;
                case 6:
                    strRet = "微信支付";
                    break;
                case 7:
                    strRet = "首信易支付";
                    break;
                default:
                    strRet = "";
                    break;
            }
            return strRet;
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
                    if (!string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["商户订单号（必填）"])) && Convert.ToString(dt.Rows[i]["商户订单号（必填）"]) != "")
                    {
                        if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[i]["交易金额（必填）"])) && Convert.ToString(dt.Rows[i]["交易金额（必填）"]) == "")
                        {
                            error += "第" + (i + 1) + "行数据“交易金额（必填）”无信息，请补充！\r\n";
                        }
                        else
                        {
                            //导入信息

                            string order_id = "";
                            decimal total_fee = 0;
                            if (dt.Rows[i]["商户订单号（必填）"].ToString().IndexOf('`') > -1)
                            {
                                order_id = Convert.ToString(dt.Rows[i]["商户订单号（必填）"].ToString().Substring(1)).Trim();
                            }
                            else
                            {
                                order_id = Convert.ToString(dt.Rows[i]["商户订单号（必填）"]).Trim();
                            }

                             Convert.ToString(dt.Rows[i]["交易金额（必填）"]);
                             if (dt.Rows[i]["交易金额（必填）"].ToString().IndexOf('`') > -1)
                             {
                                 total_fee = Convert.ToDecimal(dt.Rows[i]["交易金额（必填）"].ToString().Substring(1));
                             }
                             else
                             {
                                 total_fee = Convert.ToDecimal(dt.Rows[i]["交易金额（必填）"].ToString());
                             }

                            tech_temp_batch_account info = new tech_temp_batch_account();
                            info.order_id = order_id;
                            info.total_fee = total_fee;

                            result += tech_temp_batch_accountManager.Instance.Operation(info, "add");
                        }
                    }
                    else
                    {
                        error += "第" + (i + 1) + "行数据“商户订单号（必填）”无信息，请补充！\r\n";
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
    }
}