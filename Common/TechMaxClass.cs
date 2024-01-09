using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace Common
{
    public class TechMaxClass
    {
        /// <summary>
        /// ����˵������֤DataSet�Ƿ������� ������dataset��Ϊnull,��Ҫ����DAL�����ڷ���DataSetʱʹ��
        /// ��д��Ա��lzchina
        /// �������ڣ�2013-05-27 23:30
        /// </summary>
        /// <param name="ds">The ds.</param>
        public static DataSet DataSetVerify(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                ds = null;
            }
            return ds;
        }

        #region ���ض�̬������ʽ��
        /// <summary>
        /// ����˵�������ض�̬������ʽ��
        /// ������Ա��������
        /// �������ڣ�2013/10/15 16:25
        /// �޸����ڣ�
        /// </summary>
        /// <param name="stylepath">��ʽ·��</param>
        /// <returns>link��ǩ</returns>
        public static string loadStyle(string stylepath)
        {
            string strStryle = "<link href=\"" + stylepath + "\" rel=\"stylesheet\" type=\"text/css\" />";
            return strStryle;
        }
        #endregion

        #region ��xmlת��DataSet���ݼ�
        /// <summary>
        /// ��xmlת��DataSet���ݼ�
        /// </summary>
        /// <param name="strXML"></param>
        /// <returns></returns>
        public static DataSet getDataSetfromXML(string strXML)
        {
            DataSet ds = new DataSet();
            if (strXML == "-1" || strXML == "-")
            {
                ds = null;
            }
            else
            {
                strXML = strXML.Replace("&lt;", "<").Replace("&gt;", ">").Replace("&amp;", "&")
                                   .Replace("&apos;", "'").Replace("&quot;", "\"");
                using (StringReader strReader = new StringReader(strXML))
                {
                    try
                    {
                        ds.ReadXml(strReader);
                    }
                    catch
                    {
                        ds = null;
                    }
                }
            }
            return ds;
        }
        #endregion

        #region  �õ�dataSetת����xml�ַ���
        /// <summary>
        ///  �õ�dataSetת����xml�ַ���
        /// </summary>
        /// <param name="ds">���ݼ�</param>
        /// <returns></returns>
        public static string GetDataSetToXml(DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0) return "";

            StringBuilder sbXml = new StringBuilder("<?xml version='1.0' standalone='yes'?> \r");
            sbXml.Append(" <" + ds.DataSetName.ToLower() + ">\r");
            foreach (DataTable dt in ds.Tables)
            {
                if (dt.Rows.Count <= 0) continue;
                foreach (DataRow dr in dt.Rows)
                {
                    sbXml.Append("  <" + dt.TableName.ToLower() + ">\r");
                    foreach (DataColumn col in dt.Columns)
                    {

                        sbXml.Append("   <" + col.ColumnName.ToLower() + ">");

                        try
                        {
                            if (col.DataType.ToString().EndsWith("Time") && !string.IsNullOrEmpty(dr[col.ColumnName].ToString()))
                                sbXml.Append(Convert.ToDateTime(dr[col.ColumnName].ToString()).ToString("yyyy-MM-dd HH:mm:ss"));
                            //else if (col.DataType != typeof(int) && string.IsNullOrEmpty(dr[col.ColumnName].ToString()))
                            //    sbXml.Append("-");
                            else
                                sbXml.Append(dr[col.ColumnName].ToString().Replace("<", "&lt;").Replace(">", "&gt;").Replace("&", "&amp;")
                                     .Replace("'", "&apos;").Replace("\"", "&quot;"));
                        }
                        catch
                        {
                            //  OlkShare.WriteLog(@"DataSetת��ΪXMLʱ�ֶθ�ʽ����ԭ��Դ���ݱ���ʱ��ʽû����֤�� \n
                            //  �ֶ�����" + col.ColumnName + " �ֶ�ֵ��" + dr[col.ColumnName].ToString() + " �ֶ�����:" + col.DataType.ToString());
                        }

                        sbXml.Append("</" + col.ColumnName.ToLower() + ">\r");
                    }
                    sbXml.Append("  </" + dt.TableName.ToLower() + ">\r");
                }
            }
            sbXml.Append(" </" + ds.DataSetName.ToLower() + ">\r");

            return sbXml.ToString();
        }
        #endregion

        #region ���JSON�ַ���
        /// <summary>
        /// ����˵�������JSON�ַ���
        /// ������Ա��lzchina
        /// �������ڣ�2013-06-05 15:57
        /// �޸����ڣ�
        /// </summary>
        /// <param name="dt">���ݱ�</param>
        public static string GetDataTableToJson(DataTable dt)
        {
            StringBuilder sbContextWrite = new StringBuilder();
            sbContextWrite.Append("{");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string columnname = dt.Columns[i].ColumnName;
                sbContextWrite.Append(string.Format("\"{0}\"", columnname));
                sbContextWrite.Append(":");
                sbContextWrite.Append(string.Format("\"{0}\"", dt.Rows[0][columnname].ToString()));
                sbContextWrite.Append(",");
            }
            sbContextWrite.Remove(sbContextWrite.Length - 1, 1);
            sbContextWrite.Append("}");
            return sbContextWrite.ToString();
        }

        #region �������ʾ����Ϣת����JSON��ʽ,��ǰ̨��ʾ
        /// <summary>
        /// �����ݼ�ת����JSON��ʽ,��ǰ̨��ʾ
        /// </summary>
        /// <param name="ds">���ݼ�</param>
        /// <returns>�����ݼ�ת����JSON��ʽ,��ǰ̨��ʾ</returns>
        public static string  GetDataSetToJson(DataSet ds)
        {
            StringBuilder sbContextWrite = new StringBuilder();
            sbContextWrite.Append("{\"");
            sbContextWrite.Append("root");
            sbContextWrite.Append("\":[");
            for (int k = 0; k < ds.Tables.Count; k++)
            {
                for (int i = 0; i < ds.Tables[k].Rows.Count; i++)
                {
                    
                    for (int j = 0; j < ds.Tables[k].Columns.Count; j++)
                    {
                        string colName = ds.Tables[k].Columns[j].ColumnName.ToLower();
                        string rowName = ds.Tables[k].Rows[i][j].ToString();
                        sbContextWrite.Append("{\"name\":\""+colName+"\",\"value\":\""+rowName+"\"},");
                    }
                    
                }
            }
            sbContextWrite.Remove(sbContextWrite.Length - 1, 1);
            sbContextWrite.Append("]");
            sbContextWrite.Append("}");
            return sbContextWrite.ToString();
        }
        #endregion
        #endregion

        #region ѹ���ַ���
        /// <summary>
        /// ѹ���ַ���
        /// </summary>
        /// <param name="strSource">��Ҫѹ�����ַ���</param>
        /// <returns>����ѹ������ַ���</returns>
        public static string Compress(string strSource)
        {
            //if (strSource == null || strSource.Length > 32 * 1024)
            //    return "";
            if (strSource == null)
                return "";
            System.Text.Encoding encoding = System.Text.Encoding.Unicode;
            byte[] buffer = encoding.GetBytes(strSource);
            //byte[] buffer = Convert.FromBase64String(strSource); //������ַ�����һ����Base64String���ͣ�����д����

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.Compression.DeflateStream stream = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Compress, true);
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();

            buffer = ms.ToArray();
            ms.Close();

            return Convert.ToBase64String(buffer); //��ѹ�����byte[]ת��ΪBase64String
        }
        #endregion

        #region ��ѹ�ַ���
        /// <summary>
        /// ��ѹ�ַ���
        /// </summary>
        /// <param name="strSource">�����ַ���</param>
        /// <returns>���ؽ�ѹ֮����ַ���</returns>
        public static string Decompress(string strSource)
        {
            //System.Text.Encoding encoding = System.Text.Encoding.Unicode;
            //byte[] buffer = encoding.GetBytes(strSource);
            if (string.IsNullOrEmpty(strSource))
                return "";
            byte[] buffer = Convert.FromBase64String(strSource);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            ms.Position = 0;
            System.IO.Compression.DeflateStream stream = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Decompress);
            stream.Flush();

            int nSize = 64 * 2048 + 256; //�ַ������ᳬ��16K
            byte[] decompressBuffer = new byte[nSize];
            int nSizeIncept = stream.Read(decompressBuffer, 0, nSize);
            stream.Close();
            return System.Text.Encoding.Unicode.GetString(decompressBuffer, 0, nSizeIncept);//ת��Ϊ��ͨ���ַ���
        }
        #endregion


        /// <summary>
        /// ͨ��ָ����������ʽ��ȡ�÷���
        /// </summary>
        /// <param name="Html">Ҫƥ����ַ���Դ</param>
        /// <param name="RegStr">ָ����������ʽ</param>
        /// <param name="groupStr">����ָ�����ַ�����</param>
        /// <returns>���ط���</returns>
        public static string[] getRegValue(string Html, string RegStr, string groupStr)
        {
            string str = "";
            string[] strArr = null;
            Regex Reg = new Regex(RegStr);
            foreach (Match m in Reg.Matches(Html))
            {
                str = str + m.Value + groupStr;
            }
            str = RemoveHTML(str, "<.+?>");
            if (str.Length > 1)
                strArr = str.Substring(0, str.Length - 1).Split(new char[] { Convert.ToChar(groupStr) });
            return strArr;
        }

        /// <summary>
        /// ����ָ����ʽ������
        /// </summary>
        /// <param name="Html">Ҫ���˵��ַ���Դ</param>
        /// <param name="RegStr">ָ��Ҫ�������ݣ�������ʽ��</param>
        /// <returns>���ع��˺������</returns>
        public static string RemoveHTML(string Html, string RegStr)
        {
            if (Html.Length <= 0)
                return "";
            Regex Reg = new Regex(RegStr);
            foreach (Match m in Reg.Matches(Html))
            {
                Html = Html.Replace(m.Value, "");
            }
            return Html.Trim();
        }


        /// <summary>
        /// �õ�ÿ�����ֶ�Ӧ����ƴ����ĸ
        /// </summary>
        /// <param name="cnChar"></param>
        /// <returns></returns>
        private static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];

                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };
                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25) max = areacode[i + 1];
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(65 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }
        /// <summary>
        /// ȡ���ĺ����е�ÿ�����ֵ�ƴ����ĸ
        /// </summary>
        /// <param name="strText">���ֺ���</param>
        /// <returns>��дƴ������ĸ</returns>
        public static string GetChsSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += TechMaxClass.getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }

        public static string GetRandomStr()
        {
            string _zimu = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";//Ҫ�������ĸ
            Random _rand = new Random(); //�����
            string _result = "";
            for (int i = 0; i < 6; i++) //ѭ��6�Σ�����6λ���֣�10λ��ѭ��10��
            {
                _result += _zimu[_rand.Next(62)]; //ͨ�������±����
            }
            return _result;
        }
    }

    public class TestReplace
    {
        private TestReplace() { }

        private static string sNR = "\r\n";
        private static string sXiaoYu = "<";
        private static string sDaYu = ">";
        private static IList<Regex> iList = new List<Regex>();

        private static string[] aReplace = new string[]
            {
                "","","","","","","","\"","&","<",">","","\xa1","\xa2","\xa3","\xa9",""
            };

        static TestReplace()
        {
            string[] aPattern = new string[]
                                    {
                                        @"<script.*?</script>",
                                        @"<style.*?</style>",
                                        @"<.*?>",
                                        @"<(.[^>]*)>",
                                        @"([\r\n])[\s]+",
                                        @"-->",
                                        @"<!--.*",
                                        @"&(quot|#34);",
                                        @"&(amp|#38);",
                                        @"&(lt|#60);",
                                        @"&(gt|#62);",
                                        @"&(nbsp|#160);",
                                        @"&(iexcl|#161);",
                                        @"&(cent|#162);",
                                        @"&(pound|#163);",
                                        @"&(copy|#169);",
                                        @"&#(\d+);"
                                    };

            for (int i = 0; i < aPattern.Length; i++)
            {
                iList.Add(new Regex(aPattern[i]));
            }
        }

        /// <summary>
        /// ȥ��HTML���
        /// </summary>
        /// <param name="Htmlstring">����HTML��Դ�� </param>
        /// <returns>�Ѿ�ȥ���������</returns>
        public static string ReplaceHtmlTag(string Htmlstring)
        {
            Htmlstring = Htmlstring.Replace(sNR, string.Empty);
            
            Regex r;
            for (int i = 0; i < iList.Count; i++)
            {
                r = iList[i];
                if (r != null)
                    Htmlstring = r.Replace(Htmlstring, aReplace[i], -1, 0);
            }

            Htmlstring = Htmlstring.Replace(sXiaoYu, string.Empty);
            Htmlstring = Htmlstring.Replace(sDaYu, string.Empty);
            Htmlstring = Htmlstring.Replace(sNR, string.Empty);
           
            Htmlstring = Htmlstring.Replace(";", string.Empty);
            return Htmlstring;
        }

    }
}
