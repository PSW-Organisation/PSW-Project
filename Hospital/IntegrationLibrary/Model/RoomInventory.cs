using System;

namespace IntegrationLibrary.Model
{
    [Serializable]
    public class RoomInventory : Entity
    {
        private int quantity;
        private Inventory inventory;
        private string roomId;
        private int transferAmmount;
        private DateTime staticTransferDate;
        private string transferRoomId;

        public RoomInventory() : base("undefinedNumberKey") { }

        public RoomInventory(Inventory inventory, string roomId, int quantity) : base("undefinedNumberKey")
        {
            this.inventory = inventory;
            this.roomId = roomId;
            this.quantity = quantity;
            transferAmmount = 0;
        }


        public string TransferRoomId
        {
            get { return transferRoomId; }
            set
            {
                if (value != transferRoomId)
                {
                    transferRoomId = value;
                }
            }
        }

        public DateTime StaticTransferDate
        {
            get { return staticTransferDate; }
            set
            {
                if (value != staticTransferDate)
                {
                    staticTransferDate = value;
                }
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value != quantity)
                {
                    quantity = value;
                }
            }
        }

        public int TransferAmmount
        {
            get { return transferAmmount; }
            set
            {
                if (value != transferAmmount)
                {
                    transferAmmount = value;
                }
            }
        }

        public string RoomID
        {
            get { return roomId; }
            set
            {
                if (value != roomId)
                {
                    roomId = value;
                }
            }
        }

        public Inventory Inventory
        {
            get { return inventory; }
            set
            {
                if (value != inventory)
                {
                    inventory = value;
                }
            }
        }
    }
}