using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_meeting_user_ppt
    {
        private int _puid;                      //主键
        private string _family_name;            //姓氏
        private string _given_name;             //名字
        private string _username;               //用户姓名
        private string _family_name_pinyin;     //姓氏拼音
        private string _given_name_pinyin;      //名字拼音
        private string _title;                  //中文职称
        private string _mobile;                 //手机号
        private string _email;                  //邮箱
        private string _loginpwd;               //登录密码
        private string _en_title;               //英文职称
        private string _education;              //中文学历
        private string _en_education;           //英文学历
        private string _unit;                   //工作单位
        private string _en_unit;                //英文工作单位
        private string _offices;                //科室
        private int _status = 2;                //状态：1为删除 2为正常
        private int _user_type;                 //1中宾　2外宾
        private string _mid;                    //会议编码
        private string _mtype_id;               //会议类型
        private DateTime _inputtime;            //录入时间
        private string _img_urlpath;            //照片
        private string _intro_urlpath;          //简介
        private string _en_intro_urlpath;       //英文简介
        private string _learnpost;              //学会职称
        private string _penintro;               //文字简介
        private string _bankAccountName;        //开户姓名
        private string _bankDeposit;            //开户行
        private string _bankCard;               //银行卡        
        private string _idnumber;               //身份证号
        private string _receive;                //实际领取
        private string _signature;              //专家签字
        private string _province;               //省份
        private int _user_code;

        private int _pageIndex;
        private int _pageSize;

        /// <summary>
        /// pageIndex
        /// </summary>
        public int pageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = value; }
        }

        /// <summary>
        /// pageSize
        /// </summary>
        public int pageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// 主键
        /// </summary>
        public int puid
        {
            set { _puid = value; }
            get { return _puid; }
        }

        /// <summary>
        /// 手机号
        /// </summary>
        public string mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string loginpwd
        {
            get { return _loginpwd; }
            set { _loginpwd = value; }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// 姓氏
        /// </summary>
        public string family_name
        {
            set { _family_name = value; }
            get { return _family_name; }
        }

        /// <summary>
        /// 名字
        /// </summary>
        public string given_name
        {
            set { _given_name = value; }
            get { return _given_name; }
        }

        /// <summary>
        /// 姓氏拼音
        /// </summary>
        public string family_name_pinyin
        {
            set { _family_name_pinyin = value; }
            get { return _family_name_pinyin; }
        }

        /// <summary>
        /// 名字拼音
        /// </summary>
        public string given_name_pinyin
        {
            set { _given_name_pinyin = value; }
            get { return _given_name_pinyin; }
        }

        /// <summary>
        /// 中文职称
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }

        /// <summary>
        /// 英文职称
        /// </summary>
        public string en_title
        {
            set { _en_title = value; }
            get { return _en_title; }
        }

        /// <summary>
        /// 中文学历
        /// </summary>
        public string education
        {
            set { _education = value; }
            get { return _education; }
        }

        /// <summary>
        /// 英文学历
        /// </summary>
        public string en_education
        {
            set { _en_education = value; }
            get { return _en_education; }
        }

        /// <summary>
        /// 工作单位
        /// </summary>
        public string unit
        {
            set { _unit = value; }
            get { return _unit; }
        }

        /// <summary>
        /// 英文工作单位
        /// </summary>
        public string en_unit
        {
            set { _en_unit = value; }
            get { return _en_unit; }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public string offices
        {
            set { _offices = value; }
            get { return _offices; }
        }

        /// <summary>
        /// 状态：1为删除 2为正常
        /// </summary>
        public int status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 1中宾　2外宾
        /// </summary>
        public int user_type
        {
            set { _user_type = value; }
            get { return _user_type; }
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
        /// 会议编码
        /// </summary>
        public string mid
        {
            get { return _mid; }
            set { _mid = value; }
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime inputtime
        {
            set { _inputtime = value; }
            get { return _inputtime; }
        }

        /// <summary>
        /// 照片
        /// </summary>
        public string img_urlpath
        {
            get { return _img_urlpath; }
            set { _img_urlpath = value; }
        }

        /// <summary>
        /// 简介
        /// </summary>
        public string intro_urlpath
        {
            get { return _intro_urlpath; }
            set { _intro_urlpath = value; }
        }

        /// <summary>
        /// 英文简介
        /// </summary>
        public string en_intro_urlpath
        {
            get { return _en_intro_urlpath; }
            set { _en_intro_urlpath = value; }
        }

        /// <summary>
        /// 学会职称
        /// </summary>
        public string learnpost
        {
            get { return _learnpost; }
            set { _learnpost = value; }
        }

        /// <summary>
        /// 文字简介
        /// </summary>
        public string penintro
        {
            get { return _penintro; }
            set { _penintro = value; }
        }

        /// <summary>
        /// 开户姓名
        /// </summary>
        public string bankAccountName
        {
            get { return _bankAccountName; }
            set { _bankAccountName = value; }
        }

        /// <summary>
        /// 开户行
        /// </summary>
        public string bankDeposit
        {
            get { return _bankDeposit; }
            set { _bankDeposit = value; }
        }

        /// <summary>
        /// 银行卡
        /// </summary>
        public string bankCard
        {
            get { return _bankCard; }
            set { _bankCard = value; }
        }

        /// <summary>
        /// 身份证
        /// </summary>
        public string idnumber
        {
            get { return _idnumber; }
            set { _idnumber = value; }
        }

        /// <summary>
        /// 实际领取
        /// </summary>
        public string receive
        {
            get { return _receive; }
            set { _receive = value; }
        }

        /// <summary>
        /// 专家签字
        /// </summary>
        public string signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

        /// <summary>
        /// 省份
        /// </summary>
        public string province
        {
            get { return _province; }
            set { _province = value; }
        }

        /// <summary>
        /// user_code
        /// </summary>
        public int user_code
        {
            get { return _user_code; }
            set { _user_code = value; }
        }
    }
}
