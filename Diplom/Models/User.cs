﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserPassword { get; set; }
        public bool IsAdmin { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string UserImage { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public User()
        {
            if (UserImage == null) UserImage = "~/Content/Images/User/1.jpg";
        }

    }
}