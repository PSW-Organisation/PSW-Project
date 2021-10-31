using Newtonsoft.Json;
using System;

namespace Model
{
    public class Room
    {
        public RoomType RoomType { get; set; }
        public int RoomNumber { get; set; }
        public Floor RoomFloor { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public Room(DateTime startDateTime, int roomNumber, Floor roomFloor, RoomType roomType)
        {
            RoomType = roomType;
            RoomNumber = roomNumber;
            RoomFloor = roomFloor;
            IsDeleted = false;
            EndDateTime = new DateTime(2999, 12, 31);
            StartDateTime = startDateTime;
            renovation = new System.Collections.Generic.List<Renovation>();
        }

        [JsonIgnore]
        public String NumberAndType
        {
            get
            {
                return RoomNumber + " " + TypeSerbian;
            }
        }

        [JsonIgnore]
        public String FloorSerbian
        {
            get
            {
                switch (RoomFloor)
                {
                    case Floor.first:
                        return "Prvi";
                    case Floor.second:
                        return "Drugi";
                    default:
                        return "Treæi";
                }
            }
        }

        [JsonIgnore]
        public String TypeSerbian
        {
            get
            {
                switch (RoomType)
                {
                    case Model.RoomType.examinationRoom:
                        return "Soba za preglede";
                    case Model.RoomType.operatingRoom:
                        return "Operaciona sala";
                    case Model.RoomType.recoveryRoom:
                        return "Soba za odmor";
                    default:
                        return "Magacin";
                }
            }
        }

        public string RoomFloorName
        {
            get
            {
                if (RoomFloor == Floor.first)
                    return "Prvi";
                else if (RoomFloor == Floor.second)
                    return "Drugi";
                else
                    return "Treći";
            }
        }

        public string RoomTypeName
        {
            get
            {
                if (RoomType == RoomType.examinationRoom)
                    return "Ordinacija za preglede";
                else if (RoomType == RoomType.operatingRoom)
                    return "Operaciona sala";
                else if (RoomType == RoomType.recoveryRoom)
                    return "Soba za oporavak";
                else
                    return "Skladiste;";
            }
        }

        public System.Collections.Generic.List<Renovation> renovation;
      
          public System.Collections.Generic.List<Renovation> Renovation
          {
             get
             {
                if (renovation == null)
                   renovation = new System.Collections.Generic.List<Renovation>();
                return renovation;
             }
             set
             {
                RemoveAllRenovation();
                if (value != null)
                {
                   foreach (Renovation oRenovation in value)
                      AddRenovation(oRenovation);
                }
             }
          }
      
          public void AddRenovation(Renovation newRenovation)
          {
             if (newRenovation == null)
                return;
             if (this.renovation == null)
                this.renovation = new System.Collections.Generic.List<Renovation>();
             if (!this.renovation.Contains(newRenovation))
                this.renovation.Add(newRenovation);
          }
      
          public void RemoveRenovation(Renovation oldRenovation)
          {
             if (oldRenovation == null)
                return;
             if (this.renovation != null)
                if (this.renovation.Contains(oldRenovation))
                   this.renovation.Remove(oldRenovation);
          }
     
          public void RemoveAllRenovation()
          {
             if (renovation != null)
                renovation.Clear();
          }

        public override string ToString()
        {
            return this.RoomNumber.ToString();
        }

    }
}