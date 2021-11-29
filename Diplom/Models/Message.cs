using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int RoomId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }

    }
}