using System;
using System.Configuration;
using System.Net.Mail;


namespace Common
{
    public static class EmailHelper
    {
        private static string email = string.Empty;
        private static string emailPassword = string.Empty;
        private static string smtpServer = string.Empty;
        private static int smtpPort = 25;

        static EmailHelper()
        {
            string cfgEmail = ConfigurationManager.AppSettings["Email"];
            if (!string.IsNullOrEmpty(cfgEmail))
                email = cfgEmail;

            string cfgEmailPassword = ConfigurationManager.AppSettings["EmailPassword"];
            if (!string.IsNullOrEmpty(cfgEmailPassword))
                emailPassword = cfgEmailPassword;

            string cfgSmtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            if (!string.IsNullOrEmpty(cfgSmtpServer))
                smtpServer = cfgSmtpServer;

            string cfgSmtpPort = ConfigurationManager.AppSettings["SmtpPort"];
            if (!string.IsNullOrEmpty(cfgSmtpPort))
                int.TryParse(cfgSmtpPort, out smtpPort);
        }

        /// <summary>
        /// ���͵����ʼ��������ƣ�
        /// </summary>
        /// <param name="sSubject">�ʼ�����</param>
        /// <param name="sMessage">�ʼ�����</param>
        /// <param name="toAddress">��������</param>
        /// <returns></returns>
        public static bool SendMail(string sender, string subject, string body, string[] toAddress)
        {
            bool result = false;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email, sender);
            foreach (string str in toAddress)
            {
                mail.To.Add(new MailAddress(str));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = smtpServer;
            smtp.Port = smtpPort;
            smtp.EnableSsl = smtpPort != 25;
            smtp.Credentials = new System.Net.NetworkCredential(email, emailPassword);

            try
            {
                smtp.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        /// <summary>
        /// ����˵����
        /// ������Ա��������
        /// �������ڣ�2013/5/31 13:37
        /// �޸����ڣ�
        /// </summary>
        /// <param name="MailTitle">The mail title.</param>
        /// <param name="MailBody">The mail body.</param>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public static bool SendEmail(string MailTitle, string MailBody, string Email)
        {
            return EmailHelper.SendMail("iConference", MailTitle, MailBody, new string[] { Email });

        }

        public static bool SendEmail(string MailName, string MailTitle, string MailBody, string Email)
        {
            return EmailHelper.SendMail(MailName, MailTitle, MailBody, new string[] { Email });

        }
    }
}
