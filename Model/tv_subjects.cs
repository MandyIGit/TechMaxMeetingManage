using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tv_subjects
    {
        private int v_sid;
        private string v_sname;
        private int status;
        private DateTime inputtime;

        /// <summary>
        /// 学科id
        /// </summary>
        public int v_Sid
        {
            get { return v_sid; }
            set { v_sid = value; }
        }

        /// <summary>
        /// 学科名称
        /// </summary>
        public string v_Sname
        {
            get { return v_sname; }
            set { v_sname = value; }
        }

        /// <summary>
        /// 状态：1删除；2正常
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }
    }
}
