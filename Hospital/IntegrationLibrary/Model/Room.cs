using System;
using System.ComponentModel;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class Room : Entity
    {
        private String sector;
        private int floor;
        private RoomType roomType;
        private bool isRenovated;
        private DateTime isRenovatedUntil;
        private int numOfTakenBeds;

        public Room() : base("undefinedKey") { }

        public Room(String roomId, int roomFloor, String roomSector, RoomType roomType) : base(roomId)
        {
            sector = roomSector;
            floor = roomFloor;
            this.roomType = roomType;
        }


        public DateTime IsRenovatedUntill
        {
            get { return isRenovatedUntil; }
            set { isRenovatedUntil = value; }
        }

        public String Sector
        {
            get { return sector; }
            set
            {
                if (value != sector)
                {
                    sector = value;
                }
            }
        }

        public bool IsRenovated
        {
            get { return isRenovated; }
            set
            {
                if (value != isRenovated)
                {
                    isRenovated = value;
                }
            }
        }

        public int Floor
        {
            get { return floor; }
            set
            {
                if (value != floor)
                {
                    floor = value;
                }
            }
        }


        public RoomType RoomType
        {
            get { return roomType; }
            set
            {
                if (value != roomType)
                {
                    roomType = value;
                }
            }
        }

        public int NumOfTakenBeds
        {
            get { return numOfTakenBeds; }
            set
            {
                numOfTakenBeds = value;
            }
        }

        override
            public string ToString()
        {
            return "ID Sobe: " + base.Id + " Sektor sobe: " + sector + " Sprat sobe: " + floor.ToString() + " Tip sobe: " +
                   roomType.ToString() + " Da li se soba renovira: " + isRenovated.ToString();
        }
    }
}