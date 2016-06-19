using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace YotzimLilmod.Entities
{
    public class Message
    {
        public int MessageID { get; set; }
        public int MessageFromUserID { get; set; }
        public int MessageToUserID { get; set; }
        public string MessageBody { get; set; }

        public Message() { }
        public Message(DataRow data)
        {
            FillData(data);
        }

        public Message FillData(DataRow data)
        {
            return new Message
            {
                MessageID = Convert.ToInt32(data["MessageID"]),
                MessageFromUserID = Convert.ToInt32(data["MessageFromUserID"]),
                MessageToUserID = Convert.ToInt32(data["MessageToUserID"]),
                MessageBody = Convert.ToString(data["MessageBody"])
            };
        }
    }
}
