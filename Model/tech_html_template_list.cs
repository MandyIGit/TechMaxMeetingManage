using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_html_template_list
    {
        private string _tm_id;
        private string _tm_name;
        private string _tm_img;
        private string first_content;  //一级页面内容信息
        private string en_first_content;  //一级页面英文内容信息
        private string second_content;  //二级页面内容信息
        private string en_second_content;  //二级页面内英文容信息
        private string third_content;  //三级页面内容信息
        private string en_third_content;  //三级页面英文内容信息
        private string _person_content;  //会员中心中文模板
        private string _en_person_content;  //会员中心英文模板
        private int isdel;  //是否删除
        private string _mid;
        private string tm_type; //模板类型
        private string tm_css;  //模板类式路径
        private DateTime inputtime;  //录入时间
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
        /// 模板编号
        /// </summary>
        public string Tm_id
        {
            get { return _tm_id; }
            set { _tm_id = value; }
        }
        
        /// <summary>
        /// 模板名称
        /// </summary>
        public string Tm_name
        {
            get { return _tm_name; }
            set { _tm_name = value; }
        }
        
        /// <summary>
        /// 模板图片缩略图路径
        /// </summary>
        public string Tm_img
        {
            get { return _tm_img; }
            set { _tm_img = value; }
        }
        
        /// <summary>
        /// 模板类式路径
        /// </summary>
        public string Tm_css
        {
            get { return tm_css; }
            set { tm_css = value; }
        }
        /// <summary>
        /// 模板类型
        /// </summary>
        public string Tm_type
        {
            get { return tm_type; }
            set { tm_type = value; }
        }
        public string Mid
        {
            get { return _mid; }
            set { _mid = value; }
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
