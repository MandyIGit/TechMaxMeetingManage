using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public sealed class ConfigHelper
    {
        public static string GetConfigString(string key)
        {
            try
            {
                object objModel = System.Configuration.ConfigurationManager.AppSettings[key];
                if (objModel == null)
                    return "";
                return objModel.ToString();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 得到AppSettings中的配置int信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetConfigInt(string key)
        {
            int result = 0;
            string cfgVal = GetConfigString(key);
            if (null != cfgVal && string.Empty != cfgVal)
            {
                try
                {
                    result = int.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    return 0;
                }
            }

            return result;
        }
    }
}
