using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Travelling.CommonLibrary
{
    public class Message
    {
        private string from;
        private string sender;
        private string subject;
        private string body;
        private List<string> to;
        private List<string> attachments;

        public List<string> To
        {
            get
            {
                return this.to;
            }
        }

        public List<string> Attachments
        {
            get
            {
                return this.attachments;
            }
        }

        public Message()
        {

        }

        public Message(string subject, string body, List<string> to, List<string> attachments)
        {
            this.from = "admin@zjkz78.com";
            this.sender = "admin";

            this.subject = subject;
            this.body = body;
            this.to = to;
            this.attachments = attachments;
        }

        public string Subject
        {
            get
            {
                return this.subject;
            }
        }
        public string Body
        {
            get { return this.body; }

        }
        public string Html { set; get; }

        public string From
        {
            get
            {
                return this.from;
            }
        }

        public string Sender
        {
            get
            {
                return this.sender;
            }
        }
    }
}
