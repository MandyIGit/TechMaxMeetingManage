using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_meeting_role
    {
        private int rid;  //编号
        private string userid;  //所属会员ID
        private int meetingid;  //所属会议ID
        private int rname;  //角色名称(1-主持人,2-翻译,3-点评专家)
        private DateTime inputtime;  //录入时间

        private string full_name;  //角色全名
        private int _user_class;

        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示的记录数

        private string mid;  //会议ID
        private string mtype_id;  //会议类型ID

        private char az;  //讲者ID集
        private int role_type;  //角色类型（1-主持人，2-点评专家，3-讲者，4-翻译）
        private int user_code;  //用户编码
        private int session_id;  //会议单元ID
        private int agenda_id;  //详细日程ID
        private DateTime session_date;  //Session日期
        private int roleid;
        private string session_place_ch;
        private string unitname;    //单位
        private string agenda_name_ch;  //题目
        private string key_word;    //关键词

        private int _look_count;
        private int _shoucang_count;
        private int _dianzan_count;
        private int _msg_count;

        private string _looksort;
        private string _shoucangsort;
        private string _dianzansort;
        private string _msgsort;

        private DateTime Begin_time;  //起始时间
        private DateTime End_time;      //结束时间
        private int user_type;  //用户类型（1-中宾，2-外宾）
        private string preside_array;  //主持人ID集合
        private string guests_array;  //点评嘉宾ID集合
        private string speaker_array;  //讲者ID集

        private int isAccept;  //0：未选择；1：接受；2：不接受
        private int noAcceptInfo;     //不接受的原因
        private string remark;     //备注
        private string _video_url;  //视频路径 

        /// <summary>
        /// 视频路径
        /// </summary>
        public string video_url
        {
            get { return _video_url; }
            set { _video_url = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// 不接受的原因
        /// </summary>
        public int NoAcceptInfo
        {
            get { return noAcceptInfo; }
            set { noAcceptInfo = value; }
        }


        /// <summary>
        /// 0：未选择；1：接受；2：不接受
        /// </summary>
        public int IsAccept
        {
            get { return isAccept; }
            set { isAccept = value; }
        }


        /// <summary>
        /// 讲者ID集
        /// </summary>
        public string Speaker_array
        {
            get { return speaker_array; }
            set { speaker_array = value; }
        }

        /// <summary>
        /// 点评嘉宾ID集合
        /// </summary>
        public string Guests_array
        {
            get { return guests_array; }
            set { guests_array = value; }
        }

        /// <summary>
        /// 主持人ID集合
        /// </summary>
        public string Preside_array
        {
            get { return preside_array; }
            set { preside_array = value; }
        }

        /// <summary>
        /// 用户类型（1-中宾，2-外宾）
        /// </summary>
        public int User_type
        {
            get { return user_type; }
            set { user_type = value; }
        }

        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime Begin_Time
        {
            get { return Begin_time; }
            set { Begin_time = value; }
        }

        public string msgsort
        {
            get { return _msgsort; }
            set { _msgsort = value; }
        }
        public string shoucangsort
        {
            get { return _shoucangsort; }
            set { _shoucangsort = value; }
        }
        public string dianzansort
        {
            get { return _dianzansort; }
            set { _dianzansort = value; }
        }
        public string looksort
        {
            get { return _looksort; }
            set { _looksort = value; }
        }
        /// <summary>
        /// 留言数
        /// </summary>
        public int msg_count
        {
            get { return _msg_count; }
            set { _msg_count = value; }
        }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int dianzan_count
        {
            get { return _dianzan_count; }
            set { _dianzan_count = value; }
        }
        /// <summary>
        /// 收藏数
        /// </summary>
        public int shoucang_count
        {
            get { return _shoucang_count; }
            set { _shoucang_count = value; }
        }
        /// <summary>
        /// 浏览数
        /// </summary>
        public int look_count
        {
            get { return _look_count; }
            set { _look_count = value; }
        }

        public string Key_word
        {
            get { return key_word; }
            set { key_word = value; }
        }

        public string Agenda_name_ch
        {
            get { return agenda_name_ch; }
            set { agenda_name_ch = value; }
        }

        public string Unitname
        {
            get { return unitname; }
            set { unitname = value; }
        }


        public string Session_place_ch
        {
            get { return session_place_ch; }
            set { session_place_ch = value; }
        }

        /// <summary>
        /// Roleid
        /// </summary>
        public int Roleid
        {
            get { return roleid; }
            set { roleid = value; }
        }

        /// <summary>
        /// Session日期
        /// </summary>
        public DateTime Session_date
        {
            get { return session_date; }
            set { session_date = value; }
        }

        /// <summary>
        /// 详细日程ID
        /// </summary>
        public int Agenda_id
        {
            get { return agenda_id; }
            set { agenda_id = value; }
        }

        /// <summary>
        /// 会议单元ID
        /// </summary>
        public int Session_id
        {
            get { return session_id; }
            set { session_id = value; }
        }

        /// <summary>
        /// 用户编码
        /// </summary>
        public int User_code
        {
            get { return user_code; }
            set { user_code = value; }
        }

        /// <summary>
        /// 角色类型（1-主持人，2-点评专家，3-讲者，4-翻译，5-讨论专家）
        /// </summary>
        public int Role_type
        {
            get { return role_type; }
            set { role_type = value; }
        }

        /// <summary>
        /// 讲者ID集
        /// </summary>
        public char AZ
        {
            get { return az; }
            set { az = value; }
        }

        /// <summary>
        /// 会议类型ID
        /// </summary>
        public string Mtype_id
        {
            get { return mtype_id; }
            set { mtype_id = value; }
        }

        /// <summary>
        /// 会议ID
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        /// <summary>
        /// 每页显示的记录数
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        public int user_class
        {
            get { return _user_class; }
            set { _user_class = value; }
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }
        /// <summary>
        /// 角色名称(1-主持人,2-翻译,3-点评专家)
        /// </summary>
        public int Rname
        {
            get { return rname; }
            set { rname = value; }
        }
        /// <summary>
        /// 所属会议ID
        /// </summary>
        public int Meetingid
        {
            get { return meetingid; }
            set { meetingid = value; }
        }
        /// <summary>
        /// 所属会员ID
        /// </summary>
        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public int Rid
        {
            get { return rid; }
            set { rid = value; }
        }
        private string username;
        /// <summary>
        /// 角色的姓名
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string company;
        /// <summary>
        /// 公司
        /// </summary>
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        /// <summary>
        /// 角色全名
        /// </summary>
        public string Full_name
        {
            get { return full_name; }
            set { full_name = value; }
        }

    }

    public class tech_meeting_rola_news
    {
        #region Model
        private int _roleid;
        private string _user_code;
        private int _user_type;
        private int _meetingid;
        private int _role_type;
        private string _mid;
        private string _mtype_id;
        private int _is_del;
        private DateTime _input_time;
        /// <summary>
        /// 角色ID
        /// </summary>
        public int roleid
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 用户编码
        /// </summary>
        public string user_code
        {
            set { _user_code = value; }
            get { return _user_code; }
        }
        /// <summary>
        /// 用户类型1中宾个人2外宾个人3中宾主席团4个宾主席团5中宾非主席团
        /// </summary>
        public int user_type
        {
            set { _user_type = value; }
            get { return _user_type; }
        }
        /// <summary>
        /// 会议单元ID
        /// </summary>
        public int meetingid
        {
            set { _meetingid = value; }
            get { return _meetingid; }
        }
        /// <summary>
        /// 角色类型 1主持人 2翻译 3点评专家 4主讲人
        /// </summary>
        public int role_type
        {
            set { _role_type = value; }
            get { return _role_type; }
        }
        /// <summary>
        /// 会议ID
        /// </summary>
        public string mid
        {
            get { return _mid; }
            set { _mid = value; }
        }
        /// <summary>
        /// 会议类型
        /// </summary>
        public string mtype_id
        {
            get { return _mtype_id; }
            set { _mtype_id = value; }
        }
        /// <summary>
        /// 删除状态 1删除 2未删除
        /// </summary>
        public int is_del
        {
            set { _is_del = value; }
            get { return _is_del; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime input_time
        {
            set { _input_time = value; }
            get { return _input_time; }
        }
        #endregion Model
    }
}
