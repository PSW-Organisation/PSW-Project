using System;
using HospitalLibrary.Model;

namespace ehealthcare.Model
{
    [Serializable]
    public class RoomInventory : Entity
    {
        public int Quantity { get; set; }
        public Inventory Inventory { get; set; }
        public string RoomId { get; set; }
        public int TransferAmmount { get; set; }
        public DateTime StaticTransferDate { get; set; }
        public string TransferRoomId { get; set; }

        public RoomInventory() : base("undefinedNumberKey")
        {
        }
    }
}