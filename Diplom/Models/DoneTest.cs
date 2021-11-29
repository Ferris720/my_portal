using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class DoneTest
    {
        public int DoneTestId { get; set; }
        public int UserId { get; set; }
        public int TestId { get; set; }
        public double MaxResult { get; set; }
    }
}