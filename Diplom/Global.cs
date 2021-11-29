using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Diplom.Models;

namespace Diplom
{
    public class Global
    {
        public static HttpCookie cookie = new HttpCookie("name", "password");
        public static int currentSection = 0;
        public static EquipmentContext equipmentContext = new EquipmentContext();
    }
}