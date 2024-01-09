using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class tech_mobile_template
    {
        private int _mtemplate_id;
        private int _mtype_id;
        private int _version_id;
        private string _mtemplate_name;
        private string _mtemplate_css;
        private string _mtemplate_thumbnail;
        private string _mtemplate_memo;
        private string _first_content;
        private string _second_content;
        private string _footer_content;
        private int _menu_type;
        private int _isdel;
        private DateTime _inputtime;

        private int pageIndex;  //当前页数
        private int pageSize;  //每页显示记录数

        public int mtemplate_id
        {
            get { return _mtemplate_id; }
            set { _mtemplate_id = value; }
        }

        public int version_id
        {
            get { return _version_id; }
            set { _version_id = value; }
        }

        public int mtype_id
        {
            get { return _mtype_id; }
            set { _mtype_id = value; }
        }

        public string mtemplate_name
        {
            get { return _mtemplate_name; }
            set { _mtemplate_name = value; }
        }

        public string mtemplate_css
        {
            get { return _mtemplate_css; }
            set { _mtemplate_css = value; }
        }

        public string mtemplate_thumbnail
        {
            get { return _mtemplate_thumbnail; }
            set { _mtemplate_thumbnail = value; }
        }

        public string mtemplate_memo
        {
            get { return _mtemplate_memo; }
            set { _mtemplate_memo = value; }
        }

        public string first_content
        {
            get { return _first_content; }
            set { _first_content = value; }
        }

        public string second_content
        {
            get { return _second_content; }
            set { _second_content = value; }
        }

        public string footer_content
        {
            get { return _footer_content; }
            set { _footer_content = value; }
        }

        public int menu_type
        {
            get { return _menu_type; }
            set { _menu_type = value; }
        }

        public int isdel
        {
            get { return _isdel; }
            set { _isdel = value; }
        }

        public DateTime inputtime
        {
            get { return _inputtime; }
            set { _inputtime = value; }
        }        

        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }        

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

    }
}
