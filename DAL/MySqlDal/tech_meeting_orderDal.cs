using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Model;
using IDAL;
using DBHelper;
using Common;

namespace DAL.MySqlDal
{
    public class tech_meeting_orderDal:Itech_meeting_order
    {

        public DataTable GetTech_meeting_order(string user_code)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT tua.user_code,tua.family_name,tua.given_name,tua.gender_title,tp.province_name,orders.order_id,orders.ying_shou ");
            sb.Append(" ,orders.yi_shou,meeting.mid,meeting.mname,meeting.address,meeting.begindate,meeting.enddate ");
            sb.Append(" FROM tech_meeting_order orders ");
            sb.Append(" INNER JOIN tech_user_all tua ON tua.user_code=orders.user_code ");
            sb.Append(" INNER JOIN tech_meeting meeting ON meeting.mid=orders.mid ");
            sb.Append(" LEFT JOIN tech_provincecode tp ON tp.province_id=tua.provinceid ");
            sb.AppendFormat(" WHERE orders.user_code={0} AND orders.isdel=2 ", user_code);
            return MySQLHelper.ExecuteDataTable(sb.ToString());
        }
    }
}
