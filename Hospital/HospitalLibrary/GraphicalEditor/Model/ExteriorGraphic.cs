﻿using ehealthcare.Model;
using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class ExteriorGraphic : EntityDb
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int IdElement { get; set; }


        public ExteriorGraphic()
        {
        }
    }
}
