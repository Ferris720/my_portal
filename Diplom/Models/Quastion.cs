using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Quastion
    {
        public int QuastionId { get; set; }
        public string QuastionText { get; set; }
        public int TestId { get; set; }
    }
}