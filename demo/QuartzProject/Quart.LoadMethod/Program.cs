using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Net.Mail;
using System.Net.Mime;

namespace Quart.LoadMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            //Assembly assembly= Assembly.LoadFrom("Travelling.JobSchedule.dll");
            //var types = assembly.GetTypes();
            //string quartInterface = "Quartz.IJob";
            //foreach(Type t in types)
            //{
            //    foreach(var il in t.GetInterfaces())
            //    {
            //        if (il.FullName == quartInterface)
            //        {
            //            Console.WriteLine(t.FullName);

            //        }
                    
            //    }
            //    //Console.WriteLine(t.FullName);
            //}
            //Type type = typeof(Person);
            //StringBuilder selectSql = new StringBuilder("select ");
            //foreach(var f in type.GetProperties())
            //{
            //    //Console.WriteLine(f.Name);
            //    selectSql.AppendFormat("{0},", f.Name);
            //}
            //Console.WriteLine(selectSql.ToString().TrimEnd(','));
            Send();
            Console.Read();
        }

        static void Send()
        { 
            try
            {
                MailMessage mailMsg = new MailMessage();
                mailMsg.To.Add(new MailAddress("binlyzhuo@outlook.com"));
                mailMsg.From = new MailAddress("admin@zjkz78.com", "fronname");
                mailMsg.Subject = "来自SendCloud的第一封邮件！";
                string text = "你太棒了！你已成功的从SendCloud发送了一封测试邮件，接下来快登录前台去完善账户信息吧！";
                //string html = @"欢迎使用<a href=""https://sendcloud.sohu.com"">SendCloud</a>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // 添加附件
                //string file = "C:\\file.pdf ";
                //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                //mailMsg.Attachments.Add(data);
                // 连接到sendcloud服务器
                SmtpClient smtpClient = new SmtpClient("smtpcloud.sohu.com", Convert.ToInt32(25));

                // 使用api_user和api_key进行验证
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("zjkz78", "xLFzK4hBhUW3l9RI");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
                Console.WriteLine("send ok!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        

    }

    public class Person
    {
        public string Name { set; get; }
        public string Age { set; get; }
    }

   
}
