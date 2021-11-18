using System;
using HospitalLibrary.Model;

namespace ehealthcare.Model
{
    [Serializable]
    public class RoomInventory : EntityDb
    {
        public int Quantity { get; set; }
        public Inventory Inventory { get; set; }
        public int RoomId { get; set; }
        public int TransferAmmount { get; set; }
        public DateTime StaticTransferDate { get; set; }
        public int TransferRoomId { get; set; }

        public RoomInventory()
        {
        }
    }
}