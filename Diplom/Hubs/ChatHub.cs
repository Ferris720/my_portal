using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;
using Microsoft.AspNet.SignalR;

namespace Diplom.Hubs
{
    public class ChatHub : Hub
    {
        private readonly EquipmentContext equipmentContext = Global.equipmentContext;

        public void Send(int userId, string message, int roomId)
        {
            var messageContract = new Message()
            {
                RoomId = roomId,
                UserId = userId,
                Text = message,
            };
            equipmentContext.Messages.Add(messageContract);
            equipmentContext.SaveChanges();

            Clients.All.broadcastMessage(GetUserName(userId), message);
        }

        public void StartChating(int userId, int roomId)
        {
            var room = equipmentContext.Rooms.First(r => r.RoomId == roomId);
            var messages = equipmentContext.Messages.Where(m => m.RoomId == roomId);
            foreach(var message in messages)
                Clients.Caller.broadcastMessage(GetUserName(message.UserId), message.Text);
        }

        private string GetUserName(int userId)
        {
            var user = equipmentContext.Users.Single(u => u.UserId == userId);
            return $"{user.FirstName} {user.LastName}";
        }
    }
}