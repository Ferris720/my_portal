using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class Compability
    {
        public int CompabilityId { get; set; }
        public int EquipmentId1 { get; set; }
        public int EquipmentId2 { get; set; }
        public int IsCompatible  { get; set; }
    }
}