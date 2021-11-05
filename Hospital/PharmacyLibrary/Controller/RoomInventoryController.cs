﻿using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
    public class RoomInventoryController
    {
        private RoomInventoryService roomInventoryService;

        public RoomInventoryController()
        {
            roomInventoryService = new RoomInventoryService();
        }



        public List<RoomInventory> GetAllRoomInventory()
        {
            return roomInventoryService.GetAllRoomInventory();
        }
        public List<RoomInventory> GetInventoryInRoom(String roomID)
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

        public int GetNumOfBedsById(String id)
        {
            return roomInventoryService.GetNumOfBedsById(id);
        }
        public void DoTransferStatic(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            roomInventoryService.SetInventoryTransferStrategy(new InventoryTrasnferStatic());
            roomInventoryService.DoTransfer(srcRoom, destRoom, quantity, dueDate, trasnferedInventory);
        }
        public void DoTransferNonStatic(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            roomInventoryService.SetInventoryTransferStrategy(new InventoryTrasnferNonStatic());
            roomInventoryService.DoTransfer(srcRoom, destRoom, quantity, dueDate, trasnferedInventory);

        }
        public void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory)
        {
            roomInventoryService.CheckIfInventoryNeedsTransfer(checkedRoomInventory);
        }

    }
}