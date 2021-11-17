using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Service.ServicesInterfaces
{
    public interface IRoomInventoryService
    {
        public void SetInventoryTransferStrategy(IInventoryTransfer inventoryTransfer);
        public List<RoomInventory> FilterRoomInventoryByName(String name, int roomId);
        public List<RoomInventory> GetAllRoomInventory();
        public List<RoomInventory> GetInventoryInRoom(int roomID);
        public void DeleteRoomInventoryByNameInRoom(RoomInventory roomInventory);
        public void DoTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory);
        public void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory);
        public void CreateRoomInventory(RoomInventory roominventory);
        public void RemoveAllRoomInventoryInRoom(Room room);
        public void SetRoomInventory(RoomInventory roomInventory);
        public List<RoomInventory> FilterRoomInventoryByStatus(int searchInvStatusParam, string selectedRoomId);
        public int GetNumOfBedsById(int id);

    }
}
