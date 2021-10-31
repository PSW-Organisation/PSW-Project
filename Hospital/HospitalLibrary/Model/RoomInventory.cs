using System;
using Newtonsoft.Json;

namespace Model
{
   public class RoomInventory
   {

        public RoomInventory(DateTime startTime, DateTime endTime, int quantity, int id, Equipment equipment, Room room, int numberUnavailable=0)
        {
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.equipment = equipment;
            this.room = room;
            this.Quantity = quantity;
            this.IsDeleted = false;
            this.Id = id;
            NumberUnavailable = numberUnavailable;
        }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Quantity { get; set; }
        public int Id { get; set; }
        public Boolean IsDeleted { get; set; }

        public Equipment equipment;

        public Room room;

        public int NumberUnavailable { get; set; }

        [JsonIgnore]
        public String EquipmentName
        {
            get
            {
                if (equipment != null)
                    return (equipment.Name);
                else
                    return "";
            }
        }
        [JsonIgnore]
        public String EquipmentId
        {
            get
            {
                if (equipment != null)
                    return ("" + equipment.Id);
                else
                    return "";
            }
        }

        [JsonIgnore]
        public String TypeEquipmentSerbian
        {
            get
            {
                switch (equipment.Type)
                {
                    case EquipmentType.dinamical:
                        return "Dinamièki";
                    default:
                        return "Statièki";
                }
            }
        }
    }
}