using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// ѧ�����ı�ʵ����
    /// Jacky
    /// 2014-11-11
    /// </summary>
    [Serializable()]
    public class tech_article
    {
        private string article_id;  //ѧ������ID
        private int publisher;  //������ID
        private string title;  //ѧ��������Ŀ
        private int type_id;  //ѧ����������ID
        private int p_form;  //������ʽID
        private string annex_path;  //����·��
        private string summary;  //ժҪ
        private int isok;  //�Ƿ�ͨ����1-�ǣ�2-��
        private int isdel;  //�Ƿ�ɾ����1-�ǣ�2-��
        private string mid;  //������
        private string mtype_id;  //��������ID
        private DateTime operatingtime;  //����ʱ��
        private DateTime inputtime;  //¼��ʱ��
        private int isexpert;  //�Ƿ�ר���ύ�Ľ��⣨1-�ǣ�2-��
        private int nationality;  //�Ƿ����ڹ��ڣ�1-�ǣ�2-��
        private string author_name;  //��������
        private int isletter;  //�Ƿ��͹�ȷ�Ϻ���1-�ǣ�2-��
        private string user_name;  //����������
        private int isconfirm;  //�Ƿ񶨸壨1-�ǣ�2-��
        private int check_state;  //����״̬
        private string purpose;  //Ŀ��
        private string methods;  //����
        private string results;  //���
        private string conclusions;  //����
        private string key_word;  //�ؼ���
        private string first_author;  //��һ����ID
        private string other_author;  //��������ID
        private string publisher_name;  //����������
        private string first_author_name;  //��һ��������
        private int pageIndex;  //��ǰҳ��
        private int pageSize;  //ÿҳ��ʾ��¼��
        private int isTrial;  //�Ƿ񱻳���ַ���1-�ǣ�2-��
        private int isRehear;  //�Ƿ񱻸���ַ���1-�ǣ�2-��
        private int isEnrol;  //¼ȡ���ͣ�1-��ͷ��2-�ڱ���3-������4-�踴��
        private int pCmtID;   //רҵίԱID
        private string corresponding_author;    //ͨѶ����
        private string corresponding_author_phone;    //ͨѶ���ߵ绰
        private string article_text;    //����
        
        /// <summary>
        /// ����
        /// </summary>
        public string Article_text
        {
            get { return article_text; }
            set { article_text = value; }
        }

        /// <summary>
        /// ͨѶ���ߵ绰
        /// </summary>
        public string Corresponding_author_phone
        {
            get { return corresponding_author_phone; }
            set { corresponding_author_phone = value; }
        }
        /// <summary>
        /// ͨѶ����
        /// </summary>
        public string Corresponding_author
        {
            get { return corresponding_author; }
            set { corresponding_author = value; }
        }
        
        /// <summary>
        /// ¼ȡ���ͣ�1-��ͷ��2-�ڱ���3-������4-�踴��
        /// </summary>
        public int IsEnrol
        {
            get { return isEnrol; }
            set { isEnrol = value; }
        }

        /// <summary>
        /// �Ƿ񱻸���ַ���1-�ǣ�2-��
        /// </summary>
        public int IsRehear
        {
            get { return isRehear; }
            set { isRehear = value; }
        }

        /// <summary>
        /// �Ƿ񱻳���ַ���1-�ǣ�2-��
        /// </summary>
        public int IsTrial
        {
            get { return isTrial; }
            set { isTrial = value; }
        }

        /// <summary>
        /// ÿҳ��ʾ��¼��
        /// </summary>
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        /// <summary>
        /// ��ǰҳ��
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// ��һ��������
        /// </summary>
        public string First_author_name
        {
            get { return first_author_name; }
            set { first_author_name = value; }
        }
        
        /// <summary>
        /// ����������
        /// </summary>
        public string Publisher_name
        {
            get { return publisher_name; }
            set { publisher_name = value; }
        }

        /// <summary>
        /// ��������ID
        /// </summary>
        public string Other_author
        {
            get { return other_author; }
            set { other_author = value; }
        }

        /// <summary>
        /// ��һ����ID
        /// </summary>
        public string First_author
        {
            get { return first_author; }
            set { first_author = value; }
        }

        /// <summary>
        /// �ؼ���
        /// </summary>
        public string Key_word
        {
            get { return key_word; }
            set { key_word = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Conclusions
        {
            get { return conclusions; }
            set { conclusions = value; }
        }

        /// <summary>
        /// ���
        /// </summary>
        public string Results
        {
            get { return results; }
            set { results = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Methods
        {
            get { return methods; }
            set { methods = value; }
        }

        /// <summary>
        /// Ŀ��
        /// </summary>
        public string Purpose
        {
            get { return purpose; }
            set { purpose = value; }
        }

        /// <summary>
        /// ����״̬
        /// </summary>
        public int Check_state
        {
            get { return check_state; }
            set { check_state = value; }
        }

        /// <summary>
        /// �Ƿ񶨸壨1-�ǣ�2-��
        /// </summary>
        public int Isconfirm
        {
            get { return isconfirm; }
            set { isconfirm = value; }
        }

        /// <summary>
        /// ����������
        /// </summary>
        public string User_name
        {
            get { return user_name; }
            set { user_name = value; }
        }

        /// <summary>
        /// �Ƿ��͹�ȷ�Ϻ���1-�ǣ�2-��
        /// </summary>
        public int Isletter
        {
            get { return isletter; }
            set { isletter = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string Author_name
        {
            get { return author_name; }
            set { author_name = value; }
        }

        /// <summary>
        /// �Ƿ����ڹ��ڣ�1-�ǣ�2-��
        /// </summary>
        public int Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        /// <summary>
        /// �Ƿ�ר���ύ�Ľ��⣨1-�ǣ�2-��
        /// </summary>
        public int Isexpert
        {
            get { return isexpert; }
            set { isexpert = value; }
        }

        /// <summary>
        /// ¼��ʱ��
        /// </summary>
        public DateTime Inputtime
        {
            get { return inputtime; }
            set { inputtime = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime Operatingtime
        {
            get { return operatingtime; }
            set { operatingtime = value; }
        }

        /// <summary>
        /// ��������ID
        /// </summary>
        public string Mtype_id
        {
            get { return mtype_id; }
            set { mtype_id = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string Mid
        {
            get { return mid; }
            set { mid = value; }
        }

        /// <summary>
        /// �Ƿ�ɾ����1-�ǣ�2-��
        /// </summary>
        public int Isdel
        {
            get { return isdel; }
            set { isdel = value; }
        }

        /// <summary>
        /// �Ƿ�ͨ����1-�ǣ�2-��
        /// </summary>
        public int Isok
        {
            get { return isok; }
            set { isok = value; }
        }

        /// <summary>
        /// ժҪ
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        /// <summary>
        /// ����·��
        /// </summary>
        public string Annex_path
        {
            get { return annex_path; }
            set { annex_path = value; }
        }

        /// <summary>
        /// ������ʽID
        /// </summary>
        public int P_form
        {
            get { return p_form; }
            set { p_form = value; }
        }

        /// <summary>
        /// ѧ����������ID
        /// </summary>
        public int Type_id
        {
            get { return type_id; }
            set { type_id = value; }
        }

        /// <summary>
        /// ѧ��������Ŀ
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// ������ID
        /// </summary>
        public int Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

        /// <summary>
        /// ѧ������ID
        /// </summary>
        public string Article_id
        {
            get { return article_id; }
            set { article_id = value; }
        }

        /// <summary>
        /// רҵίԱID
        /// </summary>
        public int PCmtID
        {
            get { return pCmtID; }
            set { pCmtID = value; }
        }
    }
}
