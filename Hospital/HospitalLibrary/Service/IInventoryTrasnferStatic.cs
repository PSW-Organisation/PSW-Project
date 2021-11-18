using System;
using System.Collections.Generic;
using ehealthcare.Model;

namespace ehealthcare.Service
{
    public interface IInventoryTrasnferStatic
    {
        void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory);
        void DoInventoryTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory);
    }
}