using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class Rank
    {
        [Key]
        public int RankId { get; set; }
        public string RankName { get; set; }
    }
}