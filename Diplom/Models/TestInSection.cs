using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Diplom.Models
{
    public class TestInSection
    {
        [Key]
        public int TestInSectionId { get; set; }
        public int TestId { get; set; }
        public int SectionId { get; set; }
    }
}