using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Common;
using ThoughtWorks.QRCode.Codec;
using System.Drawing;

namespace DIY.HYManager.mobile_menu
{
    public partial class menu_content_edit : MeetingUserPage
    {
        public string mid = string.Empty, menuid = string.Empty, imagePath = string.Empty, mname = string.Empty, m_website = string.Empty;

        public int mc_id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            mid = Request.Cookies[WebCommon.MEETING_KEY].Values["mid"];

            tech_meeting meeting = tech_meetingManager.Instance.GetModelByMId(mid);
            if (!string.IsNullOrEmpty(meeting.m_website))
            {
                m_website = meeting.m_website;
                mname = meeting.mname;
            }

            if (Request.QueryString["menuid"] != null)
            {
                menuid = Request.QueryString["menuid"].ToString();

                DataTable dt = tech_mobile_menu_contentManager.Instance.GetTech_mobile_menu_content(new tech_mobile_menu_content { menu_id = int.Parse(menuid) }, "select_mobile_menu_content");
                if (dt != null && dt.Rows.Count > 0)
                {
                    mc_id = Convert.ToInt32(dt.Rows[0]["mc_id"]);
                }

                tech_meeting tm = tech_meetingManager.Instance.GetModelByMId(mid);
                imagePath = "/QRCode/" + QRCode(tm.m_website.ToString() + "/two_pages.aspx?menu_id=" + menuid);
            }
        }

        #region 生成二维码
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        private static string QRCode(string uri)
        {
            System.Drawing.Bitmap bt;
            string enCodeString = uri;

            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;//编码方式(注意：BYTE能支持中文，ALPHA_NUMERIC扫描出来的都是数字)
            qrCodeEncoder.QRCodeScale = 4;//大小(值越大生成的二维码图片像素越高)
            qrCodeEncoder.QRCodeVersion = 0;//版本(注意：设置为0主要是防止编码的字符串太长时发生错误)
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;//错误效验、错误更正(有4个等级)
            qrCodeEncoder.QRCodeBackgroundColor = Color.White;//背景色
            qrCodeEncoder.QRCodeForegroundColor = Color.Black;//前景色

            bt = qrCodeEncoder.Encode(enCodeString, Encoding.UTF8);

            string filename = "code";
            string file_path = AppDomain.CurrentDomain.BaseDirectory + "QRCode\\";
            string codeUrl = file_path + filename + ".jpg";

            //根据文件名称，自动建立对应目录
            if (!System.IO.Directory.Exists(file_path))
                System.IO.Directory.CreateDirectory(file_path);

            bt.Save(codeUrl);//保存图片
            return filename + ".jpg";
        }
        #endregion
    }
}