using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class UserInRoom
    {
        public int UserInRoomId { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
    }
}