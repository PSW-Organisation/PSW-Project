using HospitalLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class RoomEquipment : EntityDb
    {
        public int Quantity { get; set; }
        public string Name  { get; set; }
        public string Type { get; set; }
        public int RoomId { get; set; }

        public RoomEquipment()
        {
        }
    }
}
