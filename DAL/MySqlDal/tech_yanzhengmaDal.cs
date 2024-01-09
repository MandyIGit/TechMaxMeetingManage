using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using Model;
using IDAL;
using DBHelper;
using Common;
using System.Data;

namespace DAL.MySqlDal
{
    public class tech_yanzhengmaDal : Itech_yanzhengma
    {
        private string mid = Common.ConfigHelper.GetConfigString("Mcode");
        private string mtype_id = Common.ConfigHelper.GetConfigString("MType");

        public int Operation(tech_yanzhengma info, string type)
        {
            StringBuilder sb = new StringBuilder();
            int result = 0;
            switch (type)
            {
                case "add_yanzhengma":
                    sb.Append("INSERT INTO tech_yanzhengma(mobile,yanzhengma,mid,mtype_id,inputtime,operatingtime)");
                    sb.Append(" VALUES( ");

                    //手机
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.mobile);
                    }
                    else
                    {
                        sb.Append(" DEFAULT ");
                    }

                    //验证码
                    if (info.yanzhengma > 0)
                    {
                        sb.AppendFormat(" ,{0} ", info.yanzhengma);
                    }
                    else
                    {
                        sb.Append(" ,DEFAULT ");
                    }

                    sb.AppendFormat(" ,\"{0}\",\"{1}\" ", mid, mtype_id);
                    //录入时间
                    sb.Append(" ,NOW() ");
                    //操作时间
                    sb.Append(" ,NOW() ");

                    sb.Append(" ); ");
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    break;

                case "del_yanzhengma":

                    sb.AppendFormat(" UPDATE tech_yanzhengma SET operatingtime=NOW(),isdel=1 WHERE mid=\"{0}\" AND mtype_id=\"{1}\" ", mid, mtype_id);
                    if (!string.IsNullOrEmpty(info.mobile))
                    {
                        sb.AppendFormat(" AND mobile='{0}' ", info.mobile);
                    }
                    if (info.yanzhengma > 0)
                    {
                        sb.AppendFormat(" AND yanzhengma={0} ", info.yanzhengma);
                    }
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());

                    break;
            }
            return result;
        }

        public DataTable GetTech_yanzhengma(tech_yanzhengma info)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM tech_yanzhengma ");
            sb.AppendFormat(" WHERE isdel=2 AND mobile=\"{0}\" AND mid=\"{1}\" AND mtype_id=\"{2}\" ", info.mobile, mid, mtype_id);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }

        public tech_yanzhengma getModel(string mobile, int yanzhengma)
        {
            tech_yanzhengma model = new tech_yanzhengma();
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT * FROM tech_yanzhengma ");
            sb.AppendFormat(" WHERE isdel=2 AND mobile=\"{0}\" AND yanzhengma={1} AND mid=\"{2}\" AND mtype_id=\"{3}\" LIMIT 0,1 ", mobile, yanzhengma, mid, mtype_id);
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            return MySQLHelper.ConvertTableToObject<tech_yanzhengma>(dt).Count > 0 ? MySQLHelper.ConvertTableToObject<tech_yanzhengma>(dt)[0] : model;
        }
    }
}
