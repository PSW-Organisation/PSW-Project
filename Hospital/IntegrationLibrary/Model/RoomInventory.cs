using System;

namespace ehealthcare.Model
{
    [Serializable]
    public class RoomInventory : Entity
    {
        private int quantity;
        private Inventory inventory;
        private int roomId;
        private int transferAmmount;
        private DateTime staticTransferDate;
        private int transferRoomId;

        public RoomInventory() : base(-1) { }

        public RoomInventory(Inventory inventory, int roomId, int quantity) : base(-1)
        {
            this.inventory = inventory;
            this.roomId = roomId;
            this.quantity = quantity;
            transferAmmount = 0;
        }


        public int TransferRoomId
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

        public int RoomID
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