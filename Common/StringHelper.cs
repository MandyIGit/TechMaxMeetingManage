using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web.Security;
using System.Xml;

namespace Common
{
    /// <summary>
    /// 字符串（靳海云）
    /// </summary>
    public static class StringHelper
    {
        public const string PasswordHashAlgorithmName = "SHA1";

        private static readonly string SQL_CHAR = @"exec |insert |select |delete |update |count\(|truncate|declare|char\(|chr\(|mid\(|substring\(|\(\)";
        private static readonly string HTML_CHAR = @"<.+?>";
        //private static readonly string HTML_CHAR = @"<script[\s\S]+</script *>| href *= *[\s\S]*script *:| no[\s\S]*=|<iframe[\s\S]+</iframe *>|<frameset[\s\S]+</frameset *>";

        #region 字符串转换

        /// <summary>
        /// 转Bool值为字符串
        /// </summary>
        /// <param name="bValue"></param>
        /// <param name="trueValue"></param>
        /// <param name="falseValue"></param>
        /// <returns></returns>
        public static string BoolToString(bool bValue, string trueValue, string falseValue)
        {
            return bValue ? trueValue : falseValue;
        }

        /// <summary>
        /// 转换Bool值为“是”或“否”
        /// </summary>
        /// <param name="bValue"></param>
        /// <returns></returns>
        public static string BoolToString(bool bValue)
        {
            return BoolToString(bValue, "是", "否");
        }

        /// <summary>
        /// 空值转字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string NullToString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
                return str;
        }

        /// <summary>
        /// 去空格，如果是空值，返回空字符串
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string NullToTrimString(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
                return str.Trim();
        }

        #endregion

        #region HTML/URL

        /// <summary>
        /// 将字符转化为HTML编码
        /// </summary>
        /// <param name="Input">输入字符串</param>
        /// <returns>返回编译后的字符串</returns>
        public static string HtmlEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
                return System.Web.HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// 将字符HTML解码
        /// </summary>
        /// <param name="Input">输入字符串</param>
        /// <returns>返回解码后的字符串</returns>
        public static string HtmlDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
                return System.Web.HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// URL地址编码
        /// </summary>
        /// <param name="Input">输入字符串</param>
        /// <returns>返编码后的字符串</returns>
        public static string URLEncode(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
                return System.Web.HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// URL地址解码
        /// </summary>
        /// <param name="Input">输入字符串</param>
        /// <returns>返回解码后的字符串</returns>
        public static string URLDecode(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
                return System.Web.HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// 转换空字符串为HTML空格
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string NullToHTMLBlank(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "&nbsp;";
            else
                return str;
        }

        /// <summary>
        /// HTML过滤
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public static string HtmlFiltrate(string str)
        {
            return HtmlFiltrate(str, true);
        }

        /// <summary>
        /// HTML过滤
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="filtrateQuot">是否过滤引号</param>
        /// <returns></returns>
        public static string HtmlFiltrate(string str, bool filtrateQuot)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;
            else
            {
                str = Regex.Replace(str, HTML_CHAR, " ", RegexOptions.IgnoreCase);
                if (filtrateQuot)
                    return str.Replace("\"", "");
                else
                    return str;
            }
        }

        #endregion

        #region 格式检查

        /// <summary>
        /// 是否为空字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 判断输入是否是整数
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsInteger(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
            {
                return Regex.IsMatch(str, @"^(\+|\-)?\d+$");
            }
        }

        /// <summary>
        /// 判断输入是否是小数
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsDecimal(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
            {
                decimal f;
                return decimal.TryParse(str, out f);
            }
        }

        /// <summary>
        /// 判断输入是否为日期类型
        /// </summary>
        /// <param name="strIn">待检查数据</param>
        /// <returns>返回true或false</returns>
        public static bool IsDate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
            {
                DateTime d;
                return DateTime.TryParse(str, out d);
            }
        }

        /// <summary>
        /// 是否时间格式
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsTime(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
                return Regex.IsMatch(str, @"^[0-2]\d:[0-5]\d$");
        }

        /// <summary>
        /// 是否国内电话号码
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsTelNumber(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
                return Regex.IsMatch(str, @"^(0\d{2,3})?([ -])?\d{7,}$");
        }

        /// <summary>
        /// 是否国内手机号码
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsMobileNumber(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
                return Regex.IsMatch(str, @"^\+?(86)?[1][3458]\d{9}$");
        }

        /// <summary>
        /// 判断是否是电子邮件
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsEmail(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
                return Regex.IsMatch(str, @"^([\w\-\.]+)@((\[\d{1,3}\.\d{1,3}\.\d{1,3}\.)|(([a-zA-Z\d\-]+\.)+))([a-zA-Z]{2,4}|\d{1,3})(\]?)$");
        }

        /// <summary>
        /// 判断是否为邮政编码
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsZipCode(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
                return Regex.IsMatch(str, @"^[1-9]\d{5}$");
        }

        /// <summary>
        /// 判断是否为身份证号码
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        //public static bool IsIDNumber(string str)
        //{
        //    return IDCardHelper.IsIDNumber(str);
        //}

        /// <summary>
        /// 判断是否为URL地址
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsURL(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
                return Regex.IsMatch(str, @"^[Hh][Tt]{2}[Pp]([Ss])?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$");
        }

        /// <summary>
        /// 判断是否为GUID
        /// </summary>
        /// <param name="strIn">输入字符串</param>
        /// <returns>返回true或false</returns>
        public static bool IsGuid(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            else
                return Regex.IsMatch(str, @"^([\dA-F]{8}(-[\dA-F]{4}){3}-[\dA-F]{12})|([\dA-F]{32})$", RegexOptions.IgnoreCase);
        }

        #endregion

        #region 字符串处理

        /// <summary>
        /// 截取字符串函数
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="num">要截取的字节数</param>
        /// <param name="pad">超出长度后添加的字符串</param>
        /// <returns></returns>
        public static string FirstString(string str, int num, string pad)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            string outstr = string.Empty;
            int n = 0;
            foreach (char ch in str)
            {
                n += System.Text.Encoding.Default.GetByteCount(ch.ToString());
                if (n > num)
                {
                    if (!string.IsNullOrEmpty(pad))
                        outstr = outstr.Substring(0, outstr.Length - 1) + pad;
                    break;
                }
                else
                    outstr += ch;
            }
            return outstr;
        }

        /// <summary>
        /// 二进制数组按照指定格式转为字符串
        /// </summary>
        /// <param name="s">二进制数组</param>
        /// <returns></returns>
        public static string ByteToStr(byte[] s, string format)
        {
            string str = "";
            for (int i = 0; i < s.Length; i++)
            {
                str += s[i].ToString(format);
            }
            return str;
        }

        /// <summary>
        /// 数据流转字符串
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string StreamToString(Stream stream)
        {
            int size = 0;
            byte[] writeData = new byte[1024];
            StringBuilder sb = new StringBuilder(writeData.Length);

            while (true)
            {
                size = stream.Read(writeData, 0, writeData.Length);
                if (size > 0)
                    sb.Append(System.Text.Encoding.UTF8.GetString(writeData, 0, size));
                else
                    break;
            }

            return sb.ToString();
        }

        /// <summary>
        /// 反转字符串
        /// </summary>
        /// <param name="str">要反转的字符串</param>
        /// <returns></returns>
        public static string Reverse(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        /// <summary>
        /// 重复连接字符串
        /// </summary>
        /// <param name="str">要重复的字符串</param>
        /// <param name="count">重复次数</param>
        /// <returns></returns>
        public static string Repeat(string str, int count)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            StringBuilder sbStr = new StringBuilder("");

            for (int i = 0; i < count; i++)
                sbStr.Append(str);

            return sbStr.ToString();
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <returns></returns>
        public static string RandomString()
        {
            return RandomString(32);
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">字符串长度(最大32)</param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            if (length == 0 || length > 32)
                length = 32;

            string str = Guid.NewGuid().ToString("N");
            if (length >= str.Length)
                return str;
            else
                return str.Substring(0, length);
        }

        /// <summary>
        /// 隐藏部分字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string HidePartofChar(string str, int left, int right, char c)
        {
            if (left < 0 || right < 0 || string.IsNullOrEmpty(str) || str.Length < left + right)
                return str;
            else
            {

                string strLeft = str.Substring(0, left);
                string strRight = string.Empty;
                if (right > 0)
                    strRight = str.Substring(str.Length - right);
                int hideLen = str.Length - left - right;

                return string.Format("{0}{1}{2}", strLeft, string.Empty.PadLeft(hideLen, c), strRight);
            }
        }

        /// <summary>
        /// 获取流逝时间信息
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetTimeSpanString(DateTime time)
        {
            string strTimeSpan = string.Empty;

            if (time == DateTime.MinValue || time == DateTime.MaxValue)
                return strTimeSpan;

            TimeSpan ts = DateTime.Now - time;
            if (ts.TotalSeconds < 60)
                strTimeSpan = "刚刚";
            else if (ts.TotalMinutes < 60)
                strTimeSpan = string.Format("{0:F0}分钟前", ts.TotalMinutes);
            else if (ts.TotalHours < 24)
                strTimeSpan = string.Format("{0:F0}小时前", ts.TotalHours);
            else if (ts.TotalDays < 30)
                strTimeSpan = string.Format("{0:F0}天前", ts.TotalDays);
            else if (ts.TotalDays < 365)
                strTimeSpan = string.Format("{0:F0}个月前", ts.TotalDays / 30);
            else
                strTimeSpan = string.Format("{0:F0}年前", ts.TotalDays / 365);

            return strTimeSpan;
        }

        #endregion

        #region 加密解密

        /// <summary>
        /// MD5加密字符串
        /// </summary>
        /// <param name="str">要加密的字符串</param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToLower();
            //MD5 md5 =System.Security.Cryptography.MD5.Create();
            //byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            //string md5String = ByteToStr(s, "X");
            //return md5String;
        }

        /// <summary>
        /// MD5加密字符串验证
        /// </summary>
        /// <param name="md5Code">密码</param>
        /// <param name="str">原文</param>
        /// <returns></returns>
        public static bool MD5Check(string md5Code, string str)
        {
            return string.Equals(md5Code, MD5(str), StringComparison.CurrentCultureIgnoreCase);
        }

        /// <summary>
        /// 生成散列随机数
        /// </summary>
        /// <returns></returns>
        public static string GenerateSalt()
        {
            byte[] data = new byte[0x10];
            new RNGCryptoServiceProvider().GetBytes(data);
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// 散列加密
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public static string HashEncrypt(string str, string salt)
        {
            byte[] src = Encoding.Unicode.GetBytes(str);
            byte[] saltbuf = Convert.FromBase64String(salt);
            byte[] dst = new byte[saltbuf.Length + src.Length];
            byte[] inArray = null;
            Buffer.BlockCopy(saltbuf, 0, dst, 0, saltbuf.Length);
            Buffer.BlockCopy(src, 0, dst, saltbuf.Length, src.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create(PasswordHashAlgorithmName);
            inArray = algorithm.ComputeHash(dst);

            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// 加密验证
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="encodePassword"></param>
        /// <returns></returns>
        public static bool CheckPassword(string password, string salt, string encryptedCode)
        {
            return encryptedCode.Equals(HashEncrypt(password, salt));
        }

        #endregion

        #region SQL

        /// <summary>
        /// SQL防注入处理
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public static string SqlFiltrate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            else
                return Regex.Replace(str, SQL_CHAR, " ", RegexOptions.IgnoreCase).Replace("'", " ").Replace("\"", " ").Trim();
        }

        /// <summary>
        /// SQL字符串处理，如果为空字符串则转为null
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string SqlEmptyStringToNull(string str)
        {
            if (string.IsNullOrEmpty(str))
                return "null";
            else
                return string.Format("'{0}'", str);
        }
        /// <summary>
        /// 判断字符串是否为Null,是的话输出
        /// </summary>
        /// <returns></returns>
        public static string NullOutPutString(string instr, string outstr)
        {
            if (string.IsNullOrEmpty(instr)) { instr = outstr; }
            return instr;

        }

        #endregion

        #region xml文件解析
        /// <summary>
        /// 方法说明：充值方式读取
        /// 创建人员：靳海云
        /// 创建日期：2013/6/5 9:38
        /// 修改日期：
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        public static string GetXml(string paytype)
        {
            string xml = System.Web.HttpContext.Current.Server.MapPath("/js/chargetype.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);
            string result = "";
            XmlNodeList xnl = doc.SelectSingleNode("chargelist").ChildNodes;
            foreach (XmlNode item in xnl)
            {
                if (item.SelectSingleNode("id").InnerText == paytype) { result = item.SelectSingleNode("name").InnerText; }
            }

            return result;
        }
        #endregion
    }
}
