using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom.Models
{
    public class ProjectPart
    {
        public int ProjectPartId { get; set; }
        public int ProjectId { get; set; }
        public int EquipmentId { get; set; }
        public int ProjectPartAmount { get; set; }
    }
}