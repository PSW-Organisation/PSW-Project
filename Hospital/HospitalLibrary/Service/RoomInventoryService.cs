using System;
using System.Collections.Generic;
using Model;
using vezba.Repository;
using vezba.Strategy;

namespace Service
{
    public class RoomInventoryService
    {

        private IRoomInventoryRepository RoomInventoryRepository { get; }

        public RoomInventoryService()
        {
            RoomInventoryRepository = new RoomInventoryFileRepository();
        }

        public List<RoomInventory> GetAllRoomInventories(Room selected)
        {
            List<RoomInventory> roomInventoryList = new List<RoomInventory>();
            foreach (RoomInventory roomInventory in RoomInventoryRepository.GetAll())
            {
                if (roomInventory.room.RoomNumber == selected.RoomNumber)
                {
                    if (DateTime.Compare(roomInventory.StartTime, DateTime.Now) <= 0 &&
                        DateTime.Compare(roomInventory.EndTime, DateTime.Now) >= 0)
                    {
                        roomInventoryList.Add(roomInventory);
                    }
                }
            }

            return roomInventoryList;
        }

        public Boolean SaveRoomInventory(RoomInventory newRoomInventory)
        {
            return RoomInventoryRepository.Save(newRoomInventory);
        }

        public Boolean UpdateRoomInventory(RoomInventory updatedRoomInventory)
        {
            return RoomInventoryRepository.Update(updatedRoomInventory);
        }

        public Boolean DeleteRoomInventory(int roomInventoryId)
        {
            return RoomInventoryRepository.Delete(roomInventoryId);
        }

        public int ChangeEquipmentQuantity(IStrategy strategy, RoomInventory roomInventory, int roomNumber, int inputItemQuantity, DateTime pickedDate)
        {
            return strategy.ChangeEquipmentQuantity(roomInventory, roomNumber, inputItemQuantity, pickedDate);
        }
    }
}