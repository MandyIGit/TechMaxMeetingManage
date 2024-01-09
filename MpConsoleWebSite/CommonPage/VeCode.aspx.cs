using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MpConsoleWebSite.CommonPage
{
    public partial class VeCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(110, 50);
            Graphics g = Graphics.FromImage(image);

            Color[] borders = new Color[10] { Color.AliceBlue, Color.Aqua, Color.Black, Color.Brown, Color.DarkRed, Color.SkyBlue, Color.Silver, Color.Tan, Color.Violet, Color.SpringGreen };


            try
            {
                Random random = new Random();
                g.Clear(Color.White);

                //画图片的背景噪音线   
                for (int i = 0; i < 2; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                string str = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
                string[] codes = str.Split(',');
                string serial = string.Empty;
                for (int i = 0; i < 4; i++)
                {
                    serial += codes[random.Next(codes.Length)];
                }

                Font font = new System.Drawing.Font("Verdana", 18, System.Drawing.FontStyle.Bold);
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(serial, font, brush, random.Next(image.Width - 90), random.Next(image.Height - 30));

                //画图片的前景噪音点
                for (int i = 0; i < 50; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线   
                g.DrawRectangle(new Pen(borders[random.Next(borders.Length)]), 0, 0, image.Width - 1, image.Height - 1);


                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ContentType = "image/Gif";
                HttpContext.Current.Response.BinaryWrite(ms.ToArray());
                Session["ValidateCode"] = serial.ToLower();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
    }
}