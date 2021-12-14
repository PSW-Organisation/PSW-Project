using IntegrationLibrary.Service.ServicesInterfaces;
using IntegrationLibrary.Model;
using IntegrationLibrary.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Controller
{
	public class RoomInventoryController
	{
		private IRoomInventoryService roomInventoryService;

		public RoomInventoryController(IRoomInventoryService roomInventoryService)
		{
            this.roomInventoryService = roomInventoryService;
		}

       

        public List<RoomInventory> GetAllRoomInventory()
        {
            return roomInventoryService.GetAllRoomInventory();
        }
        public List<RoomInventory> GetInventoryInRoom(int roomID)
        {
            return roomInventoryService.GetInventoryInRoom(roomID);
        }

        public void DeleteRoomInventoryByNameInRoom(RoomInventory roomInventory)
        {
            roomInventoryService.DeleteRoomInventoryByNameInRoom(roomInventory);
        }

        public void CreateRoomInventory(RoomInventory roominventory)
        {
            roomInventoryService.CreateRoomInventory(roominventory);
        }
        public void RemoveAllRoomInventoryInRoom(Room room)
        {
            roomInventoryService.RemoveAllRoomInventoryInRoom(room);
        }
        public void SetRoomInventory(RoomInventory roomInventory)
        {
            roomInventoryService.SetRoomInventory(roomInventory);
        }

        public int GetNumOfBedsById(int id)
        {
            return roomInventoryService.GetNumOfBedsById(id);
        }
        public void DoTransferStatic(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            roomInventoryService.DoTransferStatic(srcRoom, destRoom, quantity, dueDate, trasnferedInventory);
        }
        public void DoTransferNonStatic(Room srcRoom, Room destRoom, int quantity, RoomInventory trasnferedInventory)
        {
            roomInventoryService.DoTransferNonStatic(srcRoom, destRoom, quantity, trasnferedInventory);

        }
        public void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory)
        {
            //roomInventoryService.CheckIfInventoryNeedsTransfer(checkedRoomInventory);
        }

    }
}