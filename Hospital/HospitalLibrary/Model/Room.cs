using System;
using System.ComponentModel;

namespace ehealthcare.Model
{
    [Serializable]
    public class Room : Entity
    {
        public string Name { get; set; }
        public string Sector { get; set; }
        public int Floor { get; set; }
        public RoomType RoomType { get; set; }
        public bool IsRenovated { get; set; }
        public DateTime IsRenovatedUntill { get; set; }
        public int NumOfTakenBeds { get; set; }

        public Room() : base("undefinedKey") { }

        override public string ToString()
        {
            return "ID Sobe: " + base.Id + " Sektor sobe: " + Sector + " Sprat sobe: " + Floor.ToString() + " Tip sobe: " +
                   RoomType.ToString() + " Da li se soba renovira: " + IsRenovated.ToString();
        }
    }
}