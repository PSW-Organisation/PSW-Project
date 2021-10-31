using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.Repository;

namespace vezba.Strategy
{
    class DinamicEquipmentStrategy : IStrategy
    {
        public RoomInventoryFileRepository RoomInventoryRepository { get; }
        public DinamicEquipmentStrategy()
        {
            RoomInventoryRepository = new RoomInventoryFileRepository();
        }
        public int ChangeEquipmentQuantity(RoomInventory roomInventory, int roomNumber, int inputItemQuantity, DateTime pickedDate)
        {
            var itemFound = false;
            var desiredRoomItemQuantity = -1;

            foreach (RoomInventory inventory in RoomInventoryRepository.GetAll())
            {
                if (inventory.room.RoomNumber == roomNumber && inventory.equipment.Id == roomInventory.equipment.Id)
                {
                    inventory.Quantity += inputItemQuantity;
                    RoomInventoryRepository.Update(inventory);
                    itemFound = true;
                }
            }

            if (!itemFound) desiredRoomItemQuantity = inputItemQuantity;

            return desiredRoomItemQuantity;
        }
    }
}