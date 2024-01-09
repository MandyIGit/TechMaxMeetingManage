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
    public class tech_forbidden_wordDal : Itech_forbidden_word
    {

        public int Operation(object obj, string type)
        {
            int result = 0;
            StringBuilder sb = new StringBuilder();
            tech_forbidden_word info = (tech_forbidden_word)obj;
            switch (type)
            {
                case "add":
                    #region add
                    sb.Append("INSERT INTO tech_forbidden_word(word,inputtime) ");
                    sb.Append(" VALUES( ");
                    if (!string.IsNullOrEmpty(info.word))
                    {
                        sb.AppendFormat(" \"{0}\" ", info.word);
                    }

                    sb.AppendFormat(" ,\"{0}\" ); ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "edit":
                    #region edit
                    sb.AppendFormat("UPDATE tech_forbidden_word SET operatingtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    if (!string.IsNullOrEmpty(info.word))
                    {
                        sb.AppendFormat(" ,word=\"{0}\" ", info.word);
                    }
                    sb.AppendFormat(" WHERE id={0} ", info.id);

                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "del":
                    #region del
                    sb.AppendFormat("UPDATE tech_forbidden_word SET isdel=1, operatingtime=\"{0}\" ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    sb.AppendFormat(" WHERE id={0} ", info.id);
                    result = MySQLHelper.ExecuteNonQuery(sb.ToString());
                    #endregion
                    break;

                case "GetWordCount":
                    #region del
                    sb.Append("SELECT COUNT(1) FROM tech_forbidden_word WHERE isdel=2 ");
                    if (!string.IsNullOrEmpty(info.word))
                    {
                        sb.AppendFormat(" AND word LIKE \"%{0}%\" ", info.word);
                    }
                    result = Convert.ToInt32(MySQLHelper.ExecuteScalar(sb.ToString()));
                    #endregion
                    break;
            }
            return result;
        }

        public DataTable GetWord(tech_forbidden_word info)
        {
            DataTable dt = null;
            StringBuilder sb = new StringBuilder();

            sb.Append("SELECT * FROM tech_forbidden_word WHERE isdel=2 ");
            if (!string.IsNullOrEmpty(info.word))
            {
                sb.AppendFormat(" AND word LIKE \"%{0}%\" ", info.word);
            }
            sb.Append(" ORDER BY id DESC ");
            int index = info.PageIndex;
            if (index <= 0)
            {
                index = 1;
            }
            sb.AppendFormat(" LIMIT {0},{1}; ", (index - 1) * info.PageSize, info.PageSize);
            dt = MySQLHelper.ExecuteDataTable(sb.ToString());

            return dt;
        }

        public tech_forbidden_word GetWordByID(string id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM tech_forbidden_word");
            sb.AppendFormat(" WHERE id={0}", id);
            tech_forbidden_word model = new tech_forbidden_word();
            DataTable dt = MySQLHelper.ExecuteDataTable(sb.ToString());
            model = MySQLHelper.ConvertTableToObject<tech_forbidden_word>(dt)[0];
            return model;
        }


    }
}
