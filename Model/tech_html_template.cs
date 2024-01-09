using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_html_template
    {
        private int t_id;
        private string tm_id;  //模板编号
        private string mid;  //所属大会编号
        private string first_content;  //一级页面内容信息
        private string en_first_content;  //一级页面英文内容信息        
        private string second_content;  //二级页面内容信息
        private string en_second_content;  //二级页面内英文容信息
        private string third_content;  //三级页面内容信息
        private string en_third_content;  //三级页面英文内容信息
        private string _person_content;  //会员中心中文模板
        private string _en_person_content;  //会员中心英文模板        
        private int isdel;  //是否删除
        private DateTime inputtime;  //录入时间
        private string tm_name;  //模板名称
        private string tm_img;  //模板缩略图地址
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
        /// 一级页面英文内容信息
        /// </summary>
        public string En_first_content
        {
            get { return en_first_content; }
            set { en_first_content = value; }
        }
        /// <summary>
        ///三级页面英文内容信息
        /// </summary>
        public string En_third_content
        {
            get { return en_third_content; }
            set { en_third_content = value; }
        }
        /// <summary>
        /// 二级页面内英文容信息
        /// </summary>
        public string En_second_content
        {
            get { return en_second_content; }
            set { en_second_content = value; }
        }
        /// <summary>
        /// 模板缩略图地址
        /// </summary>
        public string Tm_img
        {
            get { return tm_img; }
            set { tm_img = value; }
        }

        /// <summary>
        /// 模板名称
        /// </summary>
        public string Tm_name
        {
            get { return tm_name; }
            set { tm_name = value; }
        }

        /// <summary>
        /// 三级页面内容信息
        /// </summary>
        public string Third_content
        {
            get { return third_content; }
            set { third_content = value; }
        }

        /// <summary>
        /// 二级页面内容信息
        /// </summary>
        public string Second_content
        {
            get { return second_content; }
            set { second_content = value; }
        }

        /// <summary>
        /// 是否删除
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
        /// 一级页面内容信息
        /// </summary>
        public string First_content
        {
            get { return first_content; }
            set { first_content = value; }
        }

        /// <summary>
        /// 所属大会编号
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        /// <summary>
        /// 模板编号
        /// </summary>
        public string Tm_id
        {
            get { return tm_id; }
            set { tm_id = value; }
        }
        public int T_id
        {
            get { return t_id; }
            set { t_id = value; }
        }        /// <summary>
        /// 会员中心中文模板
        /// </summary>
        public string Person_content
        {
            get { return _person_content; }
            set { _person_content = value; }
        }
        
        /// <summary>
        /// 会员中心英文模板
        /// </summary>
        public string En_person_content
        {
            get { return _en_person_content; }
            set { _en_person_content = value; }
        }
    }
}
