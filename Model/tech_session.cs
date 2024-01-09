using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_session
    {
        private int session_id;
        private string session_name;
        private DateTime session_date;
        private int hall_id;
        private string hallname;
        private DateTime session_btime;
        private DateTime session_etime;
        private string holders;
        private string transfers;
        private string reviewers;
        private string discussers;
        private string meetingusers;
        private string mtype_id;
        private string mid;
        private int status;
        private DateTime inputtime;

        private string _zhuxi;
        private string _zhixingzhuxi;
        private string _huiyizhuxi;
        private string _teyaodianpingjiabin;
        private string _pingwei;
        private string _dianpingtaolun;
        private string _shuzhe;
        private string _shoushuzhuchi;
        private string _dianpingjiabin;

        /// <summary>
        /// 主键
        /// </summary>
        public int Session_id
        {
            get { return session_id; }
            set { session_id = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Session_name
        {
            get { return session_name; }
            set { session_name = value; }
        }

        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Session_date
        {
            get { return session_date; }
            set { session_date = value; }
        }

        /// <summary>
        /// 会议厅
        /// </summary>
        public int Hall_id
        {
            get { return hall_id; }
            set { hall_id = value; }
        }

        public string Hallname
        {
            get { return hallname; }
            set { hallname = value; }
        }

        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime Session_btime
        {
            get { return session_btime; }
            set { session_btime = value; }
        }

        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime Session_etime
        {
            get { return session_etime; }
            set { session_etime = value; }
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
        /// 参会
        /// </summary>
        public string Meetingusers
        {
            get { return meetingusers; }
            set { meetingusers = value; }
        }

        public string Mtype_id
        {
            get { return mtype_id; }
            set { mtype_id = value; }
        }


        public string Mid
        {
            get { return mid; }
            set { mid = value; }
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

        public string dianpingjiabin
        {
            get { return _dianpingjiabin; }
            set { _dianpingjiabin = value; }
        }
        public string shoushuzhuchi
        {
            get { return _shoushuzhuchi; }
            set { _shoushuzhuchi = value; }
        }
        public string shuzhe
        {
            get { return _shuzhe; }
            set { _shuzhe = value; }
        }
        public string dianpingtaolun
        {
            get { return _dianpingtaolun; }
            set { _dianpingtaolun = value; }
        }
        public string pingwei
        {
            get { return _pingwei; }
            set { _pingwei = value; }
        }
        public string teyaodianpingjiabin
        {
            get { return _teyaodianpingjiabin; }
            set { _teyaodianpingjiabin = value; }
        }
        public string huiyizhuxi
        {
            get { return _huiyizhuxi; }
            set { _huiyizhuxi = value; }
        }
        public string zhixingzhuxi
        {
            get { return _zhixingzhuxi; }
            set { _zhixingzhuxi = value; }
        }
        public string zhuxi
        {
            get { return _zhuxi; }
            set { _zhuxi = value; }
        }
    }
}
