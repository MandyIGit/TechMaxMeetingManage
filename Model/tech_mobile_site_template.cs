using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class tech_mobile_site_template
    {
        private int _id;
        private string _logo;
        private string _main_img_pc;
        private string _main_img_mobile;
        private string _first_content_bg;
        private string _first_content;
        private string _second_content;
        private string _footer_content;
        private string _scend_top_bg;
        private string _web_back_color;
        private int _menu_type;
        private string _mid;
        private int _isdel;
        private DateTime _inputtime;
        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示记录数

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        public DateTime inputtime
        {
            get { return _inputtime; }
            set { _inputtime = value; }
        }

        public int isdel
        {
            get { return _isdel; }
            set { _isdel = value; }
        }

        public string mid
        {
            get { return _mid; }
            set { _mid = value; }
        }

        public int menu_type
        {
            get { return _menu_type; }
            set { _menu_type = value; }
        }

        public string footer_content
        {
            get { return _footer_content; }
            set { _footer_content = value; }
        }

        public string web_back_color
        {
            get { return _web_back_color; }
            set { _web_back_color = value; }
        }

        public string scend_top_bg
        {
            get { return _scend_top_bg; }
            set { _scend_top_bg = value; }
        }

        public string second_content
        {
            get { return _second_content; }
            set { _second_content = value; }
        }

        public string first_content
        {
            get { return _first_content; }
            set { _first_content = value; }
        }

        public string first_content_bg
        {
            get { return _first_content_bg; }
            set { _first_content_bg = value; }
        }

        public string main_img_pc
        {
            get { return _main_img_pc; }
            set { _main_img_pc = value; }
        }

        public string main_img_mobile
        {
            get { return _main_img_mobile; }
            set { _main_img_mobile = value; }
        }

        public string logo
        {
            get { return _logo; }
            set { _logo = value; }
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
