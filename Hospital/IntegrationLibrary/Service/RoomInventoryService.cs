using ehealthcare.Model;
using ehealthcare.Repository;
using ehealthcare.Repository.XMLRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
    public class RoomInventoryService
    {
        private RoomInventoryRepository roomInventoryRepository;
        private IInventoryTransfer _inventoryTransfer;
        private InventoryTrasnferStatic staticTranfer = new InventoryTrasnferStatic();
        public RoomInventoryService()
        {
            roomInventoryRepository = new RoomInventoryXMLRepository();
        }

        public void SetInventoryTransferStrategy(IInventoryTransfer inventoryTransfer)
        {
            this._inventoryTransfer = inventoryTransfer;
        }
        public List<RoomInventory> FilterRoomInventoryByName(String name, string roomId)
        {
            List<RoomInventory> filteredInventoryByName = new List<RoomInventory>();
            if (roomId != null)
            {
                foreach (RoomInventory ri in roomInventoryRepository.GetInventoryInRoom(roomId))
                {
                    if (ri.Inventory.Name.Equals(name))
                        filteredInventoryByName.Add(ri);
                }
            }
            else
            {
                foreach (RoomInventory ri in roomInventoryRepository.GetFacilityRoomInventory())
                {
                    if (ri.Inventory.Name.Equals(name))
                        filteredInventoryByName.Add(ri);
                }
            }

            return filteredInventoryByName;
        }

        public List<RoomInventory> GetAllRoomInventory()
        {
            return roomInventoryRepository.GetFacilityRoomInventory();
        }

        public List<RoomInventory> GetInventoryInRoom(String roomID)
        {
            return roomInventoryRepository.GetInventoryInRoom(roomID);
        }

        public void DeleteRoomInventoryByNameInRoom(RoomInventory roomInventory)
        {
            roomInventoryRepository.DeleteRoomInventoryByNameInRoom(roomInventory);
        }

        public void DoTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            this._inventoryTransfer.DoInventoryTransfer( srcRoom,  destRoom,  quantity,  dueDate,  trasnferedInventory);
        }
        
        public void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory)
        {
            this.staticTranfer.CheckIfInventoryNeedsTransfer(checkedRoomInventory);
        }
        public void CreateRoomInventory(RoomInventory roominventory)
        {
            roomInventoryRepository.NewRoomInventory(roominventory);
        }
        public void RemoveAllRoomInventoryInRoom(Room room)
        {
            roomInventoryRepository.DeleteRoomInventoryInRoom(room);
        }
        public void SetRoomInventory(RoomInventory roomInventory)
        {
            roomInventoryRepository.SetRoomInventory(roomInventory);
        }

        public List<RoomInventory> FilterRoomInventoryByStatus(string searchInvStatusParam, string selectedRoomId)
        {
            List<RoomInventory> filteredInventoryByStatus = new List<RoomInventory>();
            if (selectedRoomId != null)
            {
                foreach (RoomInventory ri in roomInventoryRepository.GetInventoryInRoom(searchInvStatusParam))
                {
                    if (ri.Inventory.StatusString.Equals(searchInvStatusParam))
                        filteredInventoryByStatus.Add(ri);
                }
            }
            else
            {
                foreach (RoomInventory ri in roomInventoryRepository.GetFacilityRoomInventory())
                {
                    if (ri.Inventory.StatusString.Equals(searchInvStatusParam))
                        filteredInventoryByStatus.Add(ri);
                }
            }

            return filteredInventoryByStatus;
        }
        public int GetNumOfBedsById(String id)
        {
            List<RoomInventory> inventories = roomInventoryRepository.GetInventories();
            foreach (RoomInventory roomInventory in inventories)
            {
                if (roomInventory.RoomID == id && roomInventory.Inventory.Name.Equals("Kreveti"))
                {
                    return roomInventory.Quantity;
                }
            }
            return 0;
        }
    }


    public interface IInventoryTransfer
    {
        public void DoInventoryTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory);

    }

    public interface IInventoryTransferStatic : IInventoryTransfer
    {
        public void DoInventoryTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory);
        public void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory);


    }
    public interface IInventoryTransferNonStatic : IInventoryTransfer
    {
        public void DoInventoryTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory);

    }

    class InventoryTrasnferStatic : IInventoryTransferStatic
    {
        private RoomInventoryRepository roomInventoryRepository = new RoomInventoryXMLRepository();
        public void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory)
        {
            for (int i = checkedRoomInventory.Count - 1; i >= 0; i--)
            {
                if (checkedRoomInventory[i].Inventory.IsStatic == true && checkedRoomInventory[i].StaticTransferDate >= DateTime.Now)
                {
                    checkedRoomInventory[i].Quantity -= checkedRoomInventory[i].TransferAmmount;
                    checkedRoomInventory[i].StaticTransferDate = new DateTime(3000, 01, 01);
                    if (checkedRoomInventory[i].Quantity > 0)
                    {
                        RoomInventory rm = new RoomInventory();
                        rm.RoomID = checkedRoomInventory[i].TransferRoomId;
                        rm.Quantity = checkedRoomInventory[i].TransferAmmount;
                        rm.Inventory = checkedRoomInventory[i].Inventory;
                        checkedRoomInventory[i].TransferAmmount = 0;
                        roomInventoryRepository.SaveAllRoomInventory(checkedRoomInventory);
                    }
                    else if (checkedRoomInventory[i].Quantity == 0)
                    {
                        checkedRoomInventory[i].RoomID = checkedRoomInventory[i].TransferRoomId;
                        checkedRoomInventory[i].Quantity = checkedRoomInventory[i].TransferAmmount;
                        checkedRoomInventory[i].TransferAmmount = 0;
                        roomInventoryRepository.SaveAllRoomInventory(checkedRoomInventory);

                    }
                }
            }
        }

        public void DoInventoryTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            List<RoomInventory> alteredRoomInventory = roomInventoryRepository.GetFacilityRoomInventory();

            if (trasnferedInventory.Quantity >= quantity)
            {
                for (int i = alteredRoomInventory.Count - 1; i >= 0; i--)
                {
                    if (trasnferedInventory.RoomID == alteredRoomInventory[i].RoomID && trasnferedInventory.Inventory.Name.Equals(alteredRoomInventory[i].Inventory.Name))
                    {
                        alteredRoomInventory[i].TransferRoomId = destRoom.Id;
                        alteredRoomInventory[i].TransferAmmount = quantity;
                        alteredRoomInventory[i].StaticTransferDate = dueDate;
                        roomInventoryRepository.SaveAllRoomInventory(alteredRoomInventory);

                    }
                }
            }
        }


    }

    class InventoryTrasnferNonStatic : IInventoryTransferNonStatic
    {
        private RoomInventoryRepository roomInventoryRepository = new RoomInventoryXMLRepository();
        private RoomInventoryService roomInventoryService = new RoomInventoryService();
        public void DoInventoryTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            List<RoomInventory> alteredRoomInventory = roomInventoryRepository.GetFacilityRoomInventory();
            if (trasnferedInventory.Quantity == quantity)
            {
                for (int i = alteredRoomInventory.Count - 1; i >= 0; i--)
                {
                    if (trasnferedInventory.RoomID == alteredRoomInventory[i].RoomID && trasnferedInventory.Inventory.Name.Equals(alteredRoomInventory[i].Inventory.Name))
                    {
                        alteredRoomInventory[i].RoomID = destRoom.Id;
                        roomInventoryRepository.SaveAllRoomInventory(alteredRoomInventory);

                    }
                }
            }
            else
            {
                for (int i = alteredRoomInventory.Count - 1; i >= 0; i--)
                {
                    if (trasnferedInventory.RoomID == alteredRoomInventory[i].RoomID && trasnferedInventory.Inventory.Name.Equals(alteredRoomInventory[i].Inventory.Name))
                    {
                        alteredRoomInventory[i].Quantity = trasnferedInventory.Quantity - quantity;
                        Inventory newInventory = new Inventory() { Name = alteredRoomInventory[i].Inventory.Name, Status = alteredRoomInventory[i].Inventory.Status, IsStatic = alteredRoomInventory[i].Inventory.IsStatic };
                        RoomInventory roomInventory = new RoomInventory() { RoomID = destRoom.Id, Quantity = quantity, Inventory = newInventory };
                        roomInventoryRepository.SaveAllRoomInventory(alteredRoomInventory);
                        roomInventoryService.CreateRoomInventory(roomInventory);
                    }
                }
            }
        }
    }
}
