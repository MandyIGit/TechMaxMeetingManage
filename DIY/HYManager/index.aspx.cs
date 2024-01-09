using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;

namespace DIY.HYManager
{
    public partial class index : MeetingUserPage
    {
        public tech_meeting tm = null;
        public string imagePath, timestamp;
        public int isShengcheng = 0;
        public int isKaitong = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Common.WebCommon.MEETING_KEY != null)
            {
                string mid = Request.Cookies[Common.WebCommon.MEETING_KEY].Values["mid"];
                tm = tech_meetingManager.Instance.GetModelByMId(mid);
                if (tm != null && !string.IsNullOrEmpty(tm.m_website))
                    imagePath = "/QRCode/" + QRCode(tm.m_website.ToString());

                timestamp = TimeStamp.GetTimeStamp();

                Page.Title = tm.mname;

                int i = tech_mobile_site_templateManager.Instance.Operation(new tech_mobile_site_template { mid = mid }, "select_mobile_site_template_count");
                int j = int.Parse(tm.is_weizhankaitong.ToString());

                if (i > 0)
                {
                    isShengcheng = 1;
                }
                if (j > 0)
                {
                    isKaitong = j;
                }
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