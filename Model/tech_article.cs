using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 学术论文表实体类
    /// Jacky
    /// 2014-11-11
    /// </summary>
    [Serializable()]
    public class tech_article
    {
        private string article_id;  //学术论文ID
        private int publisher;  //发表者ID
        private string title;  //学术论文题目
        private int type_id;  //学术论文类型ID
        private int p_form;  //发表形式ID
        private string annex_path;  //附件路径
        private string summary;  //摘要
        private int isok;  //是否通过（1-是，2-否）
        private int isdel;  //是否删除（1-是，2-否）
        private string mid;  //大会编码
        private string mtype_id;  //会议类型ID
        private DateTime operatingtime;  //操作时间
        private DateTime inputtime;  //录入时间
        private int isexpert;  //是否专家提交的讲题（1-是，2-否）
        private int nationality;  //是否属于国内（1-是，2-否）
        private string author_name;  //作者姓名
        private int isletter;  //是否发送过确认函（1-是，2-否）
        private string user_name;  //发表人姓名
        private int isconfirm;  //是否定稿（1-是，2-否）
        private int check_state;  //评审状态
        private string purpose;  //目的
        private string methods;  //方法
        private string results;  //结果
        private string conclusions;  //结论
        private string key_word;  //关键字
        private string first_author;  //第一作者ID
        private string other_author;  //其他作者ID
        private string publisher_name;  //发表者姓名
        private string first_author_name;  //第一作者姓名
        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示记录数
        private int isTrial;  //是否被初审分发（1-是，2-否）
        private int isRehear;  //是否被复审分发（1-是，2-否）
        private int isEnrol;  //录取类型（1-口头，2-壁报，3-待定，4-需复审）
        private int pCmtID;   //专业委员ID
        private string corresponding_author;    //通讯作者
        private string corresponding_author_phone;    //通讯作者电话
        private string article_text;    //正文
        
        /// <summary>
        /// 正文
        /// </summary>
        public string Article_text
        {
            get { return article_text; }
            set { article_text = value; }
        }

        /// <summary>
        /// 通讯作者电话
        /// </summary>
        public string Corresponding_author_phone
        {
            get { return corresponding_author_phone; }
            set { corresponding_author_phone = value; }
        }
        /// <summary>
        /// 通讯作者
        /// </summary>
        public string Corresponding_author
        {
            get { return corresponding_author; }
            set { corresponding_author = value; }
        }
        
        /// <summary>
        /// 录取类型（1-口头，2-壁报，3-待定，4-需复审）
        /// </summary>
        public int IsEnrol
        {
            get { return isEnrol; }
            set { isEnrol = value; }
        }

        /// <summary>
        /// 是否被复审分发（1-是，2-否）
        /// </summary>
        public int IsRehear
        {
            get { return isRehear; }
            set { isRehear = value; }
        }

        /// <summary>
        /// 是否被初审分发（1-是，2-否）
        /// </summary>
        public int IsTrial
        {
            get { return isTrial; }
            set { isTrial = value; }
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
        /// 当前页数
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// 第一作者姓名
        /// </summary>
        public string First_author_name
        {
            get { return first_author_name; }
            set { first_author_name = value; }
        }
        
        /// <summary>
        /// 发表者姓名
        /// </summary>
        public string Publisher_name
        {
            get { return publisher_name; }
            set { publisher_name = value; }
        }

        /// <summary>
        /// 其他作者ID
        /// </summary>
        public string Other_author
        {
            get { return other_author; }
            set { other_author = value; }
        }

        /// <summary>
        /// 第一作者ID
        /// </summary>
        public string First_author
        {
            get { return first_author; }
            set { first_author = value; }
        }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Key_word
        {
            get { return key_word; }
            set { key_word = value; }
        }

        /// <summary>
        /// 结论
        /// </summary>
        public string Conclusions
        {
            get { return conclusions; }
            set { conclusions = value; }
        }

        /// <summary>
        /// 结果
        /// </summary>
        public string Results
        {
            get { return results; }
            set { results = value; }
        }

        /// <summary>
        /// 方法
        /// </summary>
        public string Methods
        {
            get { return methods; }
            set { methods = value; }
        }

        /// <summary>
        /// 目的
        /// </summary>
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }

        /// <summary>
        /// 评审状态
        /// </summary>
        public int Check_state
        {
            get { return check_state; }
            set { check_state = value; }
        }

        /// <summary>
        /// 是否定稿（1-是，2-否）
        /// </summary>
        public int Isconfirm
        {
            get { return isconfirm; }
            set { isconfirm = value; }
        }

        /// <summary>
        /// 发表人姓名
        /// </summary>
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        /// <summary>
        /// 是否发送过确认函（1-是，2-否）
        /// </summary>
        public int Isletter
        {
            get { return isletter; }
            set { isletter = value; }
        }

        /// <summary>
        /// 作者姓名
        /// </summary>
        public string Author_name
        {
            get { return author_name; }
            set { author_name = value; }
        }

        /// <summary>
        /// 是否属于国内（1-是，2-否）
        /// </summary>
        public int Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        /// <summary>
        /// 是否专家提交的讲题（1-是，2-否）
        /// </summary>
        public int Isexpert
        {
            get { return isexpert; }
            set { isexpert = value; }
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
        /// 操作时间
        /// </summary>
        public DateTime Operatingtime
        {
            get { return operatingtime; }
            set { operatingtime = value; }
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
        /// 是否删除（1-是，2-否）
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        /// <summary>
        /// 是否通过（1-是，2-否）
        /// </summary>
        public int Isok
        {
            get { return isok; }
            set { isok = value; }
        }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        /// <summary>
        /// 附件路径
        /// </summary>
        public string Annex_path
        {
            get { return annex_path; }
            set { annex_path = value; }
        }

        /// <summary>
        /// 发表形式ID
        /// </summary>
        public int P_form
        {
            get { return p_form; }
            set { p_form = value; }
        }

        /// <summary>
        /// 学术论文类型ID
        /// </summary>
        public int Type_id
        {
            get { return type_id; }
            set { type_id = value; }
        }

        /// <summary>
        /// 学术论文题目
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// 发表者ID
        /// </summary>
        public int Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        /// <summary>
        /// 学术论文ID
        /// </summary>
        public string Article_id
        {
            get { return article_id; }
            set { article_id = value; }
        }

        /// <summary>
        /// 专业委员ID
        /// </summary>
        public int PCmtID
        {
            get { return pCmtID; }
            set { pCmtID = value; }
        }
    }
}
