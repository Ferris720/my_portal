using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class Answer
    {
        [Key]
        public int AnswerId { get; set; }
        public int QuastionId { get; set; }
        public string AnswerText{ get; set; }
        public bool IsCorrect { get; set; }
    }
}