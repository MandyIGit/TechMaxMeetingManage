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
    public class tech_temp_batch_accountDal : Itech_temp_batch_account
    {

        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();            
            
            switch (type)
            {
                case "add":
                    tech_temp_batch_account info = (tech_temp_batch_account)obj;
                    sb.Append("INSERT INTO tech_temp_batch_account(order_id,total_fee,input_time)");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.order_id))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.order_id);
                    }
                    if (info.total_fee > 0)
                    {
                        sb.AppendFormat(" ,\"{0}\" ", info.total_fee);
                    }
                    sb.AppendFormat(" ,\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.Append(" ); ");
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    break;

                case "edit":
                    tech_cart cart = (tech_cart)obj;
                    sb.AppendFormat("UPDATE tech_temp_batch_account SET input_time=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (cart.Pay_type > 0)
                    {
                        sb.AppendFormat(" ,pay_type=\"{0}\" ", cart.Pay_type);
                    }
                    if (!string.IsNullOrEmpty(cart.Children_ids))
                    {
                        sb.AppendFormat(" ,children_ids=\"{0}\" ", cart.Children_ids);
                    }
                    sb.AppendFormat(" WHERE order_id=\"{0}\" ", cart.Order_id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    break;

                case "delAll":
                    sb.AppendFormat("TRUNCATE TABLE tech_temp_batch_account");
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    break;
            }
            return result;
        }

        public List<tech_temp_batch_account> GetTechTempBatchAccount()
        {
            List<tech_temp_batch_account> list = new List<tech_temp_batch_account>();
            string strSQL = string.Format("SELECT * FROM tech_temp_batch_account ORDER BY order_id DESC");
            MySqlDataReader reader = MySQLHelper.ExecuteReader(strSQL);
            while (reader.Read())
            {
                tech_temp_batch_account info = new tech_temp_batch_account();
                info.children_ids = reader["children_ids"].ToString();
                info.input_time = DateTime.Parse(reader["input_time"].ToString());
                info.order_id = reader["order_id"].ToString();
                info.pay_type = int.Parse(reader["pay_type"].ToString());
                info.total_fee = decimal.Parse(reader["total_fee"].ToString());

                list.Add(info);
            }
            reader.Close();
            return list;
        }

        public tech_temp_batch_account GetModelByOrderId(string order_id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("SELECT * FROM tech_temp_batch_account WHERE order_id={0}", order_id);
            tech_temp_batch_account model = new tech_temp_batch_account();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_temp_batch_account>(dt)[0];
            return model;
        }
    }
}
