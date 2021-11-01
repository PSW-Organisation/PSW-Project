using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.Repository;

namespace vezba.Strategy
{
    class StaticEquipmentStrategy : IStrategy
    {
        public RoomInventoryFileRepository RoomInventoryRepository { get; }
        public StaticEquipmentStrategy()
        {
            RoomInventoryRepository = new RoomInventoryFileRepository();
        }

        public int ChangeEquipmentQuantity(RoomInventory roomInventory, int roomNumber, int inputItemQuantity, DateTime pickedDate)
        {
            var itemFound = false;
            var desiredRoomItemQuantity = -1;

            foreach (RoomInventory inventory in RoomInventoryRepository.GetAll())
            {
                if (inventory.room.RoomNumber == roomNumber && DateTime.Compare(inventory.StartTime, DateTime.Now) <= 0 && DateTime.Compare(inventory.EndTime, DateTime.Now) >= 0 && inventory.equipment.Id == roomInventory.equipment.Id)
                {
                    inventory.EndTime = pickedDate;
                    RoomInventoryRepository.Update(inventory);
                    desiredRoomItemQuantity = inventory.Quantity + inputItemQuantity;
                    itemFound = true;
                }
            }

            if (!itemFound) desiredRoomItemQuantity = inputItemQuantity;
            return desiredRoomItemQuantity;
        }
    }
}