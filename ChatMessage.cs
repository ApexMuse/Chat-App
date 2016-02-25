using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatApp.Models
{
    public class ChatMessage
    {

        private Int32 msgID;
        private string msg;
        private string sent;
        private DateTime sentDate;

        public Int32 MessageID
        {
            get { return msgID; }
            set { this.msgID = value; }
        }

        public string MessageText
        {
            get { return msg; }
            set { this.msg = value; }
        }

        public string SentBy
        {
            get { return sent; }
            set { this.sent = value; }
        }

        public DateTime SentDateTime
        {
            get { return sentDate; }
            set { this.sentDate = value; }
        }

    }

}