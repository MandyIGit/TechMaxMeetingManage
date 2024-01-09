using System;
using System.Collections.Generic;
using System.Text;

using IDAL;
using System.Data;
using Model;

namespace BLL
{
    /// <summary>
    /// ѧ�����ı�ҵ���߼���
    /// Jacky
    /// 2014-11-11
    /// </summary>
    public class tech_articleManager
    {
        private Itech_article dal = null;

        /// <summary>
        /// ȡ��ʵ��
        /// </summary>
        public tech_articleManager()
        {
            dal = BLLComm.GetClassInstance("tech_article") as Itech_article;
        }

        static readonly private tech_articleManager _instance = new tech_articleManager();

        /// <summary>
        /// ȡ��ʵ��
        /// </summary>
        public static tech_articleManager Instance
        {
            get { return _instance; }
        }

        #region �������õ�ѧ��������Ϣ����ҳ��ʾ
        /// <summary>
        /// ����˵�����������õ�ѧ��������Ϣ����ҳ��ʾ
        /// ������Ա��Jacky
        /// �������ڣ�2014/11/11 13:30
        /// �޸����ڣ�
        /// </summary>
        /// <param name="info">������Ϣ</param>
        /// <param name="pageIndex">��ǰҳ��</param>
        /// <param name="pageSize">ÿҳ��ʾ��¼��</param>
        /// <returns>ѧ��������Ϣ</returns>
        public DataTable GetTech_article(tech_article info, int pageIndex, int pageSize)
        {
            return dal.GetTech_article(info, pageIndex, pageSize);
        }
        #endregion

        #region �������õ�ѧ��������Ϣ
        /// <summary>
        /// ����˵�����������õ�ѧ��������Ϣ
        /// ������Ա��Jacky
        /// �������ڣ�2014/11/11 15:09
        /// �޸����ڣ�
        /// </summary>
        /// <param name="info">������Ϣ</param>
        /// <returns>ѧ��������Ϣ</returns>
        public DataTable GetTech_article(tech_article info)
        {
            return dal.GetTech_article(info);
        }
        #endregion

        #region ������������������֪ͨ
        /// <summary>
        /// ����˵����������������������֪ͨ
        /// ������Ա����
        /// �������ڣ�2015/12/25
        /// �޸����ڣ�
        /// </summary>
        /// <param name="info">����</param>
        public DataTable GetTech_article(string info)
        {
            return dal.GetTech_article(info);
        }
        #endregion

        #region �������õ�ѧ��������Ϣ��
        /// <summary>
        /// ����˵�����������õ�ѧ��������Ϣ��
        /// ������Ա��Jacky
        /// �������ڣ�2014/11/11 15:10
        /// �޸����ڣ�
        /// </summary>
        /// <param name="info">������Ϣ</param>
        /// <returns>ѧ��������Ϣ��</returns>
        public int GetTech_article_count(tech_article info)
        {
            return dal.GetTech_article_count(info);
        }
        #endregion

    }
}
