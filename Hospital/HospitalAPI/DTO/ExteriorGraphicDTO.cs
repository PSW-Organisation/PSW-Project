using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalAPI.DTO
{
    public class ExteriorGraphicDTO
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string IdElement { get; set; }
    }
}
