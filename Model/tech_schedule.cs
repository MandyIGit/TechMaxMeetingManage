using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_schedule
    {
        private string begintime;
        private string endtime;
        private string holders;
        private DateTime inputtime;
        private string mid;
        private string mtyleid;
        private string reviewers;
        private int sch_id;
        private string sch_name;
        private string sch_timespan;
        private int session_id;
        private string speaker;
        private int status;
        private string transfers;
        private string discussers;
        private string shuzhe;

        /// <summary>
        /// 开始时间
        /// </summary>
        public string Begintime
        {
            get { return this.begintime; }
            set { this.begintime = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public string Endtime
        {
            get { return this.endtime; }
            set { this.endtime = value; }
        }

        /// <summary>
        /// 大会ID
        /// </summary>
        public string Mtyleid
        {
            get { return this.mtyleid; }
            set { this.mtyleid = value; }
        }

        /// <summary>
        /// 会议ID
        /// </summary>
        public string Mid
        {
            get { return this.mid; }
            set { this.mid = value; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public int Sch_id
        {
            get { return sch_id; }
            set { sch_id = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Sch_name
        {
            get { return sch_name; }
            set { sch_name = value; }
        }

        /// <summary>
        /// 单元ID
        /// </summary>
        public int Session_id
        {
            get { return session_id; }
            set { session_id = value; }
        }

        /// <summary>
        /// 主持人
        /// </summary>
        public string Holders
        {
            get { return holders; }
            set { holders = value; }
        }

        /// <summary>
        /// 翻译
        /// </summary>
        public string Transfers
        {
            get { return transfers; }
            set { transfers = value; }
        }

        /// <summary>
        /// 点评专家
        /// </summary>
        public string Reviewers
        {
            get { return reviewers; }
            set { reviewers = value; }
        }

        /// <summary>
        /// 讨论专家
        /// </summary>
        public string Discussers
        {
            get { return discussers; }
            set { discussers = value; }
        }

        /// <summary>
        /// 主讲人
        /// </summary>
        public string Speaker
        {
            get { return speaker; }
            set { speaker = value; }
        }

        public string Shuzhe
        {
            get { return shuzhe; }
            set { shuzhe = value; }
        }

        /// <summary>
        /// 时间段
        /// </summary>
        public string Sch_timespan
        {
            get { return sch_timespan; }
            set { sch_timespan = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }
    }
}
