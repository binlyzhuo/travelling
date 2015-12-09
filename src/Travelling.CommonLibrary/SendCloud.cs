using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Net.Mime;

namespace Travelling.CommonLibrary
{
    public class SendCloud
    {
        private static string apiUser;
        private static string apiKey;
        private static string from;
        private static string sender;

        static SendCloud()
        {
            apiUser = ConfigurationManager.AppSettings["sendcloudapiuser"];
            apiKey = ConfigurationManager.AppSettings["sendcloudapikey"];
            from = "admin@zjkz78.com";
            sender = "admin";
        }

        public static void Send(string subject, string body, List<string> to, List<string> attachments)
        {
            try
            {
                //MailMessage mailMsg = new MailMessage();
                //to.ForEach(u =>
                //{
                //    mailMsg.To.Add(new MailAddress(u));
                //});
                
                //mailMsg.From = new MailAddress(from, sender);
                //mailMsg.Subject = subject;
                //string text = body;
                //string html = "<a>test</a>";
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                //if(attachments!=null&&attachments.Count>0)
                //{
                //    attachments.ForEach(u => {
                //        mailMsg.Attachments.Add(new Attachment(u, MediaTypeNames.Application.Octet));
                //    });
                //}
                //SmtpClient smtpClient = new SmtpClient("smtpcloud.sohu.com", Convert.ToInt32(25));
                //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(apiUser, apiKey);
                //smtpClient.Credentials = credentials;

                //smtpClient.Send(mailMsg);

                MailMessage mailMsg = new MailMessage();

                // 收件人地址，用正确邮件地址替代
                mailMsg.To.Add(new MailAddress("binlyzhuo@outlook.com"));
                // 发信人，用正确邮件地址替代
                mailMsg.From = new MailAddress("from@sohu.com", "fronname");

                // 邮件主题
                mailMsg.Subject = "Smtp C# Smtp Example";

                // 邮件正文内容
                string text = "欢迎使用SendCloud";
                string html = @"欢迎使用<a href=""https://sendcloud.sohu.com"">SendCloud</a>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // 添加附件
                //string file = "C:\\file.pdf ";
                //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                //mailMsg.Attachments.Add(data);

                // 连接到sendcloud服务器
                SmtpClient smtpClient = new SmtpClient("smtpcloud.sohu.com", Convert.ToInt32(25));
                // 使用api_user和api_key进行验证
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(apiUser, apiKey);
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
