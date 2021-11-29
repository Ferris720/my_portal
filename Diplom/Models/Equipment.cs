using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public int InputInterface { get; set; }
        public int SignalRate { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
    }
}