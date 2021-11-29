using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class UsersRanks
    {
        [Key]
        public int UsersRanksId { get; set; }
        public int UserId { get; set; }
        public int RankId { get; set; }
    }
}