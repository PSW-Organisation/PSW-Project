﻿using System;
using System.Collections.Generic;
using ehealthcare.Model;
using HospitalLibrary.RoomsAndEquipment.Model;

namespace ehealthcare.Service
{
    public interface IRoomInventoryService
    {
        void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory);
        void CreateRoomInventory(RoomInventory roominventory);
        void DeleteRoomInventoryByNameInRoom(RoomInventory roomInventory);
        void DoTransfer(RoomOld srcRoom, RoomOld destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory);
        List<RoomInventory> FilterRoomInventoryByName(string name, string roomId);
        List<RoomInventory> FilterRoomInventoryByStatus(string searchInvStatusParam, string selectedRoomId);
        List<RoomInventory> GetAllRoomInventory();
        List<RoomInventory> GetInventoryInRoom(string roomID);
        int GetNumOfBedsById(int id);
        void RemoveAllRoomInventoryInRoom(RoomOld room);
        void SetInventoryTransferStrategy(IInventoryTransfer inventoryTransfer);
        void SetRoomInventory(RoomInventory roomInventory);
    }
}