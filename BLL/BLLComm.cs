using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Common;
using System.Windows.Forms;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace BLL
{
    public class BLLComm
    {
        public static string GetBbTypeFromConfig()
        {
            return ConfigurationManager.AppSettings["DataType"].ToString();
        }
        public static object GetClassInstance(string className)
        {
            string str = GetBbTypeFromConfig();
            DBManagerCls enumDbManager = GetAllDbManager()[str.ToUpper()];
            string spaceName = GetAllClassSpace()[enumDbManager.ToString()]; //Application.StartupPath 
            string strPath = "";
            try
            {
                strPath = System.Web.HttpContext.Current.Server.MapPath("\\bin\\DAL.dll");
            }
            catch (Exception ex)
            {
                strPath = Application.StartupPath + "\\DAL.dll";
            }
            System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(strPath);
            string path = spaceName + "." + className + "Dal";
            return GetInstance(path, a);
        }
        public static Object GetInstance(string path, System.Reflection.Assembly a)
        {
            Type type = a.GetType(path, false);
            return Activator.CreateInstance(type);
        }
        public static Dictionary<string, string> GetAllClassSpace()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add(DBManagerCls.AccessManager.ToString(), "");
            dic.Add(DBManagerCls.MysqlManager.ToString(), "DAL.MySqlDal");
            dic.Add(DBManagerCls.OracleManager.ToString(), "DAL.OracleDal");
            dic.Add(DBManagerCls.SqliteManager.ToString(), "DAL.SqliteDal");
            dic.Add(DBManagerCls.SqlserverManager.ToString(), "DAL.SqlServerDal");
            return dic;
        }
        public static Dictionary<string, DBManagerCls> GetAllDbManager()
        {
            Dictionary<string, DBManagerCls> dic = new Dictionary<string, DBManagerCls>();
            dic.Add(DBType.ACCESS.ToString(), DBManagerCls.AccessManager);
            dic.Add(DBType.MYSQL.ToString(), DBManagerCls.MysqlManager);
            dic.Add(DBType.ORACLE.ToString(), DBManagerCls.OracleManager);
            dic.Add(DBType.SQLITE.ToString(), DBManagerCls.SqliteManager);
            dic.Add(DBType.SQLSERVER.ToString(), DBManagerCls.SqlserverManager);
            return dic;
        }
    }

    /// <summary>
    ///  数据库类型    
    /// </summary>
    public enum DBType
    {
        /// <summary>
        /// 
        /// </summary>
        SQLSERVER,
        /// <summary>
        /// 
        /// </summary>
        ORACLE,
        /// <summary>
        /// 
        /// </summary>
        MYSQL,
        /// <summary>
        /// 
        /// </summary>
        SQLITE,
        /// <summary>
        /// 
        /// </summary>
        ACCESS
    }

    /// <summary>
    ///  Manager类型
    /// </summary>
    public enum DBManagerCls
    {
        /// <summary>
        /// 
        /// </summary>
        SqlserverManager,
        /// <summary>
        /// 
        /// </summary>
        OracleManager,
        /// <summary>
        /// 
        /// </summary>
        MysqlManager,
        /// <summary>
        /// 
        /// </summary>
        SqliteManager,
        /// <summary>
        /// 
        /// </summary>
        AccessManager
    }
}