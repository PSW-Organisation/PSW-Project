using System;
using System.Collections.Generic;
using ehealthcare.Model;
using HospitalLibrary.RoomsAndEquipment.Model;

namespace ehealthcare.Service
{
    public interface IInventoryTrasnferStatic
    {
        void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory);
        void DoInventoryTransfer(RoomOld srcRoom, RoomOld destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory);
    }
}