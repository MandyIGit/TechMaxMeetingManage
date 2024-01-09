using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户信息表实体类
    /// Jacky
    /// 2014-10-28
    /// </summary>
    [Serializable()]
    public class tech_user_all
    {
        private int user_code;  //ID(主键)
        private string family_name;  //姓氏
        private string given_name;  //名字
        private string family_name_pinyin;  //姓氏拼音
        private string given_name_pinyin;  //名字拼音
        private string mail;  //邮箱
        private string gender_title;  //中宾性别（男，女）或外宾TITLE（Dr.Mr.）
        private string mobile;  //手机号码
        private string datebirth;  //出生日期
        private string loginpwd;  //密码
        private DateTime inputtime;  //录入时间
        private int isdel;  //状态：1：已删除 2正常
        private int user_type;  //会员类型 1中宾信息 2外宾信息
        private DateTime operatingtime;  //操作时间
        private string zip;  //邮编
        private string address;  //地址
        private string tel;  //座机号码
        private string fax;  //传真
        private string offices;  //中宾所属科室或外宾技术领域
        private int unitid;  //所属单位ID（外键）,与tech_unit表的unitid列关联
        private string unit_name;  //工作单位名称
        private int provinceid;  //所在省ID
        private int cityid;  //所在市ID
        private string idnumber;  //身份证号
        private int education;  //学历(1-博士,2-硕士,3-研究生,4-本科,5-专科)
        private string hoslevel;  //医院等级
        private string post;  //职务
        private string jobtitle;  //职称
        private string learnpost;  //学会职称
        private string penintro;  //个人简历(需要在数据库将其类型修改为text)
        private string picture_url;  //照片路径
        private string area_code;  //区号
        private int country;  //国家ID
        private string city;  //所在城市
        private string company;  //所在公司
        private string other_email;  //其他邮箱
        private string passport;  //护照号
        private string passport_country;  //护照所属国籍
        private string passport_name;  //护照上的名字
        private string p_birth;  //护照上的出生日期
        private string p_gender;  //护照上的性别
        private string discipline;  //学科
        private string agency;  //学术机构
        private string resume_url;  //简历路径
        private string degree;  //学位
        private string nation;  //民族
        private string in_position;  //学会职务
        private string po_scape;  //政治面貌
        private string full_name;  //全名
        private string mid;  //大会编码
        private string mtype_id;  //会议类型ID
        private int ischeck;  //是否报到（1-是，2-否）
        private int is_meeting_letter;  //是否发送过缴费确认函（1-是，2-否）
        private int is_hotel_letter;  //是否发送酒店确认函（1-是，2-否）
        private int is_sch_email;  //是否发送过日程提醒（1-是，2-否）
        private int isinvite;  //是否需要邀请函（1-是，2-否）
        private string order_id;  //参会订单ID
        private string departments;//科室
        private string _Province_name;//省市名字
        private string _City_name;//城市名字
        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示记录数
        private int _nationality;//1中宾个人，2外宾个人 3中宾主席团 4外宾主席团 
        private string _education_name;//学历名称
        private int is_accept;//主席团是否接受日程安排
        private int mt_type;//主席团参会状态
        private int en_nationality;  //国籍ID
        private string user_code_array;  //用户ID集
        private string work_background;
        private string physi_no;
        private string professional_role;  //职业角色
        private int isCheck;  //报到状态（1-是，2-否）
        private int isCanjuan;  //是否已领餐券（1-是，2-否）
        private int isCredit;  //学分领取状态（1-已领，2-未领）
        private string zige_no;  //医师资格证书编号
        private int isMeeting;  //是否参会注册（1-是，2-否）
        private int isFaculty;  //是否属于主席团成员（1-是，2-否）
        private string brief_introduction;  //个人简介
        private int ispay; //是否缴费
        private string invoice_title;  //发票抬头
        private int pay_type;//缴费方式
        private int msg_type;//注册类型
        private string cart_order_id;//商户订单号
        private int _ppt_user_code;//试片用户ID

        public int roleid { get; set; }

        private string bankCard;    //银行卡
        private string bankDeposit; //开户行

        public string BankDeposit
        {
            get { return bankDeposit; }
            set { bankDeposit = value; }
        }

        public string BankCard
        {
            get { return bankCard; }
            set { bankCard = value; }
        }

        public int ppt_user_code
        {
            get { return _ppt_user_code; }
            set { _ppt_user_code = value; }
        }

        public decimal ying_shou { get; set; }  //应收
        public decimal yi_shou { get; set; }    //已收

        public int is_live_surgery { get; set; }    //是否需要手术直播（1-是，2-否）
        public int is_gala_dinner { get; set; }     //是否需要晚宴（1-是，2-否）

        public int faculty_type { get; set; }       //主席团类型
        public string faculty_remark { get; set; }  //主席团备注



        /// <summary>
        /// 购物车
        /// </summary>
        public string Cart_order_id
        {
            get { return cart_order_id; }
            set { cart_order_id = value; }
        }

        /// <summary>
        /// 缴费方式
        /// </summary>
        public int Pay_type
        {
            get { return pay_type; }
            set { pay_type = value; }
        }

        /// <summary>
        /// 注册类型
        /// </summary>
        public int Msg_type
        {
            get { return msg_type; }
            set { msg_type = value; }
        }

        /// <summary>
        /// 发票抬头
        /// </summary>
        public string Invoice_title
        {
            get { return invoice_title; }
            set { invoice_title = value; }
        }

        /// <summary>
        /// 是否缴费
        /// </summary>
        public int Ispay
        {
            get { return ispay; }
            set { ispay = value; }
        }

        /// <summary>
        /// 个人简介
        /// </summary>
        public string Brief_introduction
        {
            get { return brief_introduction; }
            set { brief_introduction = value; }
        }

        /// <summary>
        /// 是否属于主席团成员（1-是，2-否）
        /// </summary>
        public int IsFaculty
        {
            get { return isFaculty; }
            set { isFaculty = value; }
        }

        /// <summary>
        /// 是否参会注册（1-是，2-否）
        /// </summary>
        public int IsMeeting
        {
            get { return isMeeting; }
            set { isMeeting = value; }
        }

        /// <summary>
        /// 医师资格证书编号
        /// </summary>
        public string Zige_no
        {
            get { return zige_no; }
            set { zige_no = value; }
        }

        /// <summary>
        /// 学分领取状态（1-已领，2-未领）
        /// </summary>
        public int IsCredit
        {
            get { return isCredit; }
            set { isCredit = value; }
        }

        /// <summary>
        /// 是否已领餐券（1-是，2-否）
        /// </summary>
        public int IsCanjuan
        {
            get { return isCanjuan; }
            set { isCanjuan = value; }
        }

        /// <summary>
        /// 报到状态（1-是，2-否）
        /// </summary>
        public int IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; }
        }


        /// <summary>
        /// 职业角色
        /// </summary>
        public string Professional_role
        {
            get { return professional_role; }
            set { professional_role = value; }
        }


        /// <summary>
        /// 医师职业编号
        /// </summary>
        public string Physi_no
        {
            get { return physi_no; }
            set { physi_no = value; }
        }


        /// <summary>
        /// 工作背景
        /// </summary>
        public string Work_background
        {
            get { return work_background; }
            set { work_background = value; }
        }

        /// <summary>
        /// 用户ID集
        /// </summary>
        public string User_code_array
        {
            get { return user_code_array; }
            set { user_code_array = value; }
        }

        /// <summary>
        /// 国籍ID
        /// </summary>
        public int En_nationality
        {
            get { return en_nationality; }
            set { en_nationality = value; }
        }

        public int Mt_type
        {
            get { return mt_type; }
            set { mt_type = value; }
        }
        public int Is_accept
        {
            get { return is_accept; }
            set { is_accept = value; }
        }

        /// <summary>
        /// 学历名称
        /// </summary>
        public string education_name
        {
            get { return _education_name; }
            set { _education_name = value; }
        }

        /// <summary>
        /// 1中宾个人，2外宾个人 3中宾主席团 4外宾主席团 
        /// </summary>
        public int nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 每页显示记录数
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        
        /// <summary>
        /// 城市名字
        /// </summary>
        public string City_name
        {
            get { return _City_name; }
            set { _City_name = value; }
        }
        /// <summary>
        /// 省市名字
        /// </summary>
        public string Province_name
        {
            get { return _Province_name; }
            set { _Province_name = value; }
        }
        /// <summary>
        /// 科室
        /// </summary>
        public string Departments
        {
            get { return departments; }
            set { departments = value; }
        }

        /// <summary>
        /// 参会订单ID
        /// </summary>
        public string Order_id
        {
            get { return order_id; }
            set { order_id = value; }
        }

        /// <summary>
        /// 是否需要邀请函（1-是，2-否）
        /// </summary>
        public int Isinvite
        {
            get { return isinvite; }
            set { isinvite = value; }
        }

        /// <summary>
        /// 是否发送过日程提醒（1-是，2-否）
        /// </summary>
        public int Is_sch_email
        {
            get { return is_sch_email; }
            set { is_sch_email = value; }
        }

        /// <summary>
        /// 是否发送酒店确认函（1-是，2-否）
        /// </summary>
        public int Is_hotel_letter
        {
            get { return is_hotel_letter; }
            set { is_hotel_letter = value; }
        }

        /// <summary>
        /// 是否发送过缴费确认函（1-是，2-否）
        /// </summary>
        public int Is_meeting_letter
        {
            get { return is_meeting_letter; }
            set { is_meeting_letter = value; }
        }

        /// <summary>
        /// 是否报到（1-是，2-否）
        /// </summary>
        public int Ischeck
        {
            get { return ischeck; }
            set { ischeck = value; }
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
        /// 大会编码
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        /// <summary>
        /// 全名
        /// </summary>
        public string Full_name
        {
            get { return full_name; }
            set { full_name = value; }
        }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Po_scape
        {
            get { return po_scape; }
            set { po_scape = value; }
        }

        /// <summary>
        /// 学会职务
        /// </summary>
        public string In_position
        {
            get { return in_position; }
            set { in_position = value; }
        }  

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation
        {
            get { return nation; }
            set { nation = value; }
        }

        /// <summary>
        /// 学位
        /// </summary>
        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        /// <summary>
        /// 简历路径
        /// </summary>
        public string Resume_url
        {
            get { return resume_url; }
            set { resume_url = value; }
        }

        /// <summary>
        /// 学术机构
        /// </summary>
        public string Agency
        {
            get { return agency; }
            set { agency = value; }
        }

        /// <summary>
        /// 学科
        /// </summary>
        public string Discipline
        {
            get { return discipline; }
            set { discipline = value; }
        }

        /// <summary>
        /// 护照上的性别
        /// </summary>
        public string P_gender
        {
            get { return p_gender; }
            set { p_gender = value; }
        }

        /// <summary>
        /// 护照上的出生日期
        /// </summary>
        public string P_birth
        {
            get { return p_birth; }
            set { p_birth = value; }
        }

        /// <summary>
        /// 护照上的名字
        /// </summary>
        public string Passport_name
        {
            get { return passport_name; }
            set { passport_name = value; }
        }

        /// <summary>
        /// 护照所属国籍
        /// </summary>
        public string Passport_country
        {
            get { return passport_country; }
            set { passport_country = value; }
        }

        /// <summary>
        /// 护照号
        /// </summary>
        public string Passport
        {
            get { return passport; }
            set { passport = value; }
        }

        /// <summary>
        /// 其他邮箱
        /// </summary>
        public string Other_email
        {
            get { return other_email; }
            set { other_email = value; }
        }

        /// <summary>
        /// 所在公司
        /// </summary>
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        /// <summary>
        /// 所在城市
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        /// <summary>
        /// 国籍ID
        /// </summary>
        public int Country
        {
            get { return country; }
            set { country = value; }
        }

        /// <summary>
        /// 区号
        /// </summary>
        public string Area_code
        {
            get { return area_code; }
            set { area_code = value; }
        }

        /// <summary>
        /// 照片路径
        /// </summary>
        public string Picture_url
        {
            get { return picture_url; }
            set { picture_url = value; }
        }

        /// <summary>
        /// 个人简历(需要在数据库将其类型修改为text)
        /// </summary>
        public string Penintro
        {
            get { return penintro; }
            set { penintro = value; }
        }

        /// <summary>
        /// 学会职称
        /// </summary>
        public string Learnpost
        {
            get { return learnpost; }
            set { learnpost = value; }
        }

        /// <summary>
        /// 职称
        /// </summary>
        public string Jobtitle
        {
            get { return jobtitle; }
            set { jobtitle = value; }
        }

        /// <summary>
        /// 职务
        /// </summary>
        public string Post
        {
            get { return post; }
            set { post = value; }
        }

        /// <summary>
        /// 医院等级
        /// </summary>
        public string Hoslevel
        {
            get { return hoslevel; }
            set { hoslevel = value; }
        }

        /// <summary>
        /// 学历(1-博士,2-硕士,3-研究生,4-本科,5-专科)
        /// </summary>
        public int Education
        {
            get { return education; }
            set { education = value; }
        }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idnumber
        {
            get { return idnumber; }
            set { idnumber = value; }
        }

        /// <summary>
        /// 所在市ID
        /// </summary>
        public int Cityid
        {
            get { return cityid; }
            set { cityid = value; }
        }

        /// <summary>
        /// 所在省ID
        /// </summary>
        public int Provinceid
        {
            get { return provinceid; }
            set { provinceid = value; }
        }

        /// <summary>
        /// 工作单位名称
        /// </summary>
        public string Unit_name
        {
            get { return unit_name; }
            set { unit_name = value; }
        }

        /// <summary>
        /// 所属单位ID（外键）,与tech_unit表的unitid列关联
        /// </summary>
        public int Unitid
        {
            get { return unitid; }
            set { unitid = value; }
        }

        /// <summary>
        /// 中宾所属科室或外宾技术领域
        /// </summary>
        public string Offices
        {
            get { return offices; }
            set { offices = value; }
        }

        /// <summary>
        /// 传真
        /// </summary>
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        /// <summary>
        /// 座机号码
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// 邮编
        /// </summary>
        public string Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime Operatingtime
        {
            get { return operatingtime; }
            set { operatingtime = value; }
        }

        /// <summary>
        /// 会员类型 1中宾信息 2外宾信息
        /// </summary>
        public int User_type
        {
            get { return user_type; }
            set { user_type = value; }
        }

        /// <summary>
        /// 状态：1：已删除 2正常
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
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
        /// 密码
        /// </summary>
        public string Loginpwd
        {
            get { return loginpwd; }
            set { loginpwd = value; }
        }  

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Datebirth
        {
            get { return datebirth; }
            set { datebirth = value; }
        }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        /// <summary>
        /// 中宾性别（男，女）或外宾TITLE（Dr.Mr.）
        /// </summary>
        public string Gender_title
        {
            get { return gender_title; }
            set { gender_title = value; }
        }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        /// <summary>
        /// 名字拼音
        /// </summary>
        public string Given_name_pinyin
        {
            get { return given_name_pinyin; }
            set { given_name_pinyin = value; }
        }

        /// <summary>
        /// 姓氏拼音
        /// </summary>
        public string Family_name_pinyin
        {
            get { return family_name_pinyin; }
            set { family_name_pinyin = value; }
        }

        /// <summary>
        /// 名字
        /// </summary>
        public string Given_name
        {
            get { return given_name; }
            set { given_name = value; }
        }

        /// <summary>
        /// 姓氏
        /// </summary>
        public string Family_name
        {
            get { return family_name; }
            set { family_name = value; }
        }

        /// <summary>
        /// ID(主键)
        /// </summary>
        public int User_code
        {
            get { return user_code; }
            set { user_code = value; }
        }
    }
}
