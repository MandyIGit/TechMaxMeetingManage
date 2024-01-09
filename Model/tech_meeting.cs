using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_meeting
    {
        private string _mid;
        private string _mtype_id;
        private string _mname;
        private string _address;
        private DateTime _begindate;
        private DateTime _enddate;
        private string _brief;
        private string _mcontactmblie;
        private string _mcontact;
        private int _project_manager_id;
        private string _explains;
        private int _regsize;
        private DateTime _inputtime;
        private int _reguser;
        private DateTime _reguserdate;
        private int _article;
        private DateTime _articledate;
        private int _lodging;
        private DateTime _lodgingdate;
        private int _reviewers = 2;
        private DateTime _reviewersdate;
        private DateTime _meetingcheckin_date;
        private DateTime _regenddate;
        private string _m_img;
        private string _m_website;
        private string _m_level;
        private string _chsecretariat;
        private string _ensecretariat;

        private int _is_live;
        private int _is_playBack;
        private int _is_recommend;
        private int _is_xsh_show;

        private string _zzjzpasswd;
        private int _huiyi_status;

        private int _is_weizhankaitong;

        private int _pageIndex;
        private int _pageSize;

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int pageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        /// <summary>
        /// 会议ID 
        /// </summary>
        public string mid
        {
            set { _mid = value; }
            get { return _mid; }
        }
        /// <summary>
        /// 会议类型 
        /// </summary>
        public string mtype_id
        {
            set { _mtype_id = value; }
            get { return _mtype_id; }
        }
        /// <summary>
        /// 会议名称
        /// </summary>
        public string mname
        {
            set { _mname = value; }
            get { return _mname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime begindate
        {
            set { _begindate = value; }
            get { return _begindate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime enddate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brief
        {
            set { _brief = value; }
            get { return _brief; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcontactmblie
        {
            set { _mcontactmblie = value; }
            get { return _mcontactmblie; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mcontact
        {
            set { _mcontact = value; }
            get { return _mcontact; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int project_manager_id
        {
            set { _project_manager_id = value; }
            get { return _project_manager_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string explains
        {
            set { _explains = value; }
            get { return _explains; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int regsize
        {
            set { _regsize = value; }
            get { return _regsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime inputtime
        {
            set { _inputtime = value; }
            get { return _inputtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int reguser
        {
            set { _reguser = value; }
            get { return _reguser; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime reguserdate
        {
            set { _reguserdate = value; }
            get { return _reguserdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int article
        {
            set { _article = value; }
            get { return _article; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime articledate
        {
            set { _articledate = value; }
            get { return _articledate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int lodging
        {
            set { _lodging = value; }
            get { return _lodging; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime lodgingdate
        {
            set { _lodgingdate = value; }
            get { return _lodgingdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int reviewers
        {
            set { _reviewers = value; }
            get { return _reviewers; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime reviewersdate
        {
            set { _reviewersdate = value; }
            get { return _reviewersdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime meetingcheckin_date
        {
            set { _meetingcheckin_date = value; }
            get { return _meetingcheckin_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime regenddate
        {
            set { _regenddate = value; }
            get { return _regenddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string m_img
        {
            set { _m_img = value; }
            get { return _m_img; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string m_website
        {
            set { _m_website = value; }
            get { return _m_website; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string m_level
        {
            set { _m_level = value; }
            get { return _m_level; }
        }
        /// <summary>
        /// 会议中文秘书处名称
        /// </summary>
        public string chsecretariat
        {
            set { _chsecretariat = value; }
            get { return _chsecretariat; }
        }
        /// <summary>
        /// 会议中文秘书处英文
        /// </summary>
        public string ensecretariat
        {
            set { _ensecretariat = value; }
            get { return _ensecretariat; }
        }

        public int is_live
        {
            set { _is_live = value; }
            get { return _is_live; }
        }

        public int is_playBack
        {
            set { _is_playBack = value; }
            get { return _is_playBack; }
        }

        public int is_recommend
        {
            set { _is_recommend = value; }
            get { return _is_recommend; }
        }

        public int is_xsh_show
        {
            set { _is_xsh_show = value; }
            get { return _is_xsh_show; }
        }

        public string zzjzpasswd
        {
            set { _zzjzpasswd = value; }
            get { return _zzjzpasswd; }
        }

        public int huiyi_status
        {
            set { _huiyi_status = value; }
            get { return _huiyi_status; }
        }

        public int is_weizhankaitong
        {
            set { _is_weizhankaitong = value; }
            get { return _is_weizhankaitong; }
        }
    }
}
