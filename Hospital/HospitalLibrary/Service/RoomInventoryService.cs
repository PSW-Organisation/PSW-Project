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
    public class RoomInventoryService : IRoomInventoryService
    {
        private IRoomInventoryRepository _roomInventoryRepository;
        private IInventoryTransfer _inventoryTransfer;
        private IInventoryTrasnferStatic _staticTranfer;

        public RoomInventoryService(IRoomInventoryRepository roomInventoryRepository, IInventoryTransfer inventoryTransfer, IInventoryTrasnferStatic staticTranfer)
        {
            _roomInventoryRepository = roomInventoryRepository;
            _inventoryTransfer = inventoryTransfer;
            _staticTranfer = staticTranfer;
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
                foreach (RoomInventory ri in _roomInventoryRepository.GetInventoryInRoom(roomId))
                {
                    if (ri.Inventory.Name.Equals(name))
                        filteredInventoryByName.Add(ri);
                }
            }
            else
            {
                foreach (RoomInventory ri in _roomInventoryRepository.GetFacilityRoomInventory())
                {
                    if (ri.Inventory.Name.Equals(name))
                        filteredInventoryByName.Add(ri);
                }
            }

            return filteredInventoryByName;
        }

        public List<RoomInventory> GetAllRoomInventory()
        {
            return _roomInventoryRepository.GetFacilityRoomInventory();
        }

        public List<RoomInventory> GetInventoryInRoom(String roomID)
        {
            return _roomInventoryRepository.GetInventoryInRoom(roomID);
        }

        public void DeleteRoomInventoryByNameInRoom(RoomInventory roomInventory)
        {
            _roomInventoryRepository.DeleteRoomInventoryByNameInRoom(roomInventory);
        }

        public void DoTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            this._inventoryTransfer.DoInventoryTransfer(srcRoom, destRoom, quantity, dueDate, trasnferedInventory);
        }

        public void CheckIfInventoryNeedsTransfer(List<RoomInventory> checkedRoomInventory)
        {
            this._staticTranfer.CheckIfInventoryNeedsTransfer(checkedRoomInventory);
        }
        public void CreateRoomInventory(RoomInventory roominventory)
        {
            _roomInventoryRepository.NewRoomInventory(roominventory);
        }
        public void RemoveAllRoomInventoryInRoom(Room room)
        {
            _roomInventoryRepository.DeleteRoomInventoryInRoom(room);
        }
        public void SetRoomInventory(RoomInventory roomInventory)
        {
            _roomInventoryRepository.SetRoomInventory(roomInventory);
        }

        public List<RoomInventory> FilterRoomInventoryByStatus(string searchInvStatusParam, string selectedRoomId)
        {
            List<RoomInventory> filteredInventoryByStatus = new List<RoomInventory>();
            if (selectedRoomId != null)
            {
                foreach (RoomInventory ri in _roomInventoryRepository.GetInventoryInRoom(searchInvStatusParam))
                {
                    if (ri.Inventory.StatusString.Equals(searchInvStatusParam))
                        filteredInventoryByStatus.Add(ri);
                }
            }
            else
            {
                foreach (RoomInventory ri in _roomInventoryRepository.GetFacilityRoomInventory())
                {
                    if (ri.Inventory.StatusString.Equals(searchInvStatusParam))
                        filteredInventoryByStatus.Add(ri);
                }
            }

            return filteredInventoryByStatus;
        }
        public int GetNumOfBedsById(int id)
        {
            List<RoomInventory> inventories = _roomInventoryRepository.GetInventories();
            foreach (RoomInventory roomInventory in inventories)
            {
                if (roomInventory.RoomId == id && roomInventory.Inventory.Name.Equals("Kreveti"))
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
        private IRoomInventoryRepository _roomInventoryRepository;

        public InventoryTrasnferStatic(IRoomInventoryRepository roomInventoryRepository)
        {
            _roomInventoryRepository = roomInventoryRepository;
        }

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
                        rm.RoomId = checkedRoomInventory[i].TransferRoomId;
                        rm.Quantity = checkedRoomInventory[i].TransferAmmount;
                        rm.Inventory = checkedRoomInventory[i].Inventory;
                        checkedRoomInventory[i].TransferAmmount = 0;
                        _roomInventoryRepository.SaveAllRoomInventory(checkedRoomInventory);
                    }
                    else if (checkedRoomInventory[i].Quantity == 0)
                    {
                        checkedRoomInventory[i].RoomId = checkedRoomInventory[i].TransferRoomId;
                        checkedRoomInventory[i].Quantity = checkedRoomInventory[i].TransferAmmount;
                        checkedRoomInventory[i].TransferAmmount = 0;
                        _roomInventoryRepository.SaveAllRoomInventory(checkedRoomInventory);

                    }
                }
            }
        }

        public void DoInventoryTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            List<RoomInventory> alteredRoomInventory = _roomInventoryRepository.GetFacilityRoomInventory();

            if (trasnferedInventory.Quantity >= quantity)
            {
                for (int i = alteredRoomInventory.Count - 1; i >= 0; i--)
                {
                    if (trasnferedInventory.RoomId == alteredRoomInventory[i].RoomId && trasnferedInventory.Inventory.Name.Equals(alteredRoomInventory[i].Inventory.Name))
                    {
                        alteredRoomInventory[i].TransferRoomId = destRoom.Id;
                        alteredRoomInventory[i].TransferAmmount = quantity;
                        alteredRoomInventory[i].StaticTransferDate = dueDate;
                        _roomInventoryRepository.SaveAllRoomInventory(alteredRoomInventory);

                    }
                }
            }
        }


    }

    class InventoryTrasnferNonStatic : IInventoryTransferNonStatic
    {
        private IRoomInventoryRepository _roomInventoryRepository;
        private IRoomInventoryService _roomInventoryService;

        public InventoryTrasnferNonStatic(IRoomInventoryRepository roomInventoryRepository, IRoomInventoryService roomInventoryService)
        {
            _roomInventoryRepository = roomInventoryRepository;
            _roomInventoryService = roomInventoryService;
        }

        public void DoInventoryTransfer(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
        {
            List<RoomInventory> alteredRoomInventory = _roomInventoryRepository.GetFacilityRoomInventory();
            if (trasnferedInventory.Quantity == quantity)
            {
                for (int i = alteredRoomInventory.Count - 1; i >= 0; i--)
                {
                    if (trasnferedInventory.RoomId == alteredRoomInventory[i].RoomId && trasnferedInventory.Inventory.Name.Equals(alteredRoomInventory[i].Inventory.Name))
                    {
                        alteredRoomInventory[i].RoomId = destRoom.Id;
                        _roomInventoryRepository.SaveAllRoomInventory(alteredRoomInventory);

                    }
                }
            }
            else
            {
                for (int i = alteredRoomInventory.Count - 1; i >= 0; i--)
                {
                    if (trasnferedInventory.RoomId == alteredRoomInventory[i].RoomId && trasnferedInventory.Inventory.Name.Equals(alteredRoomInventory[i].Inventory.Name))
                    {
                        alteredRoomInventory[i].Quantity = trasnferedInventory.Quantity - quantity;
                        Inventory newInventory = new Inventory() { Name = alteredRoomInventory[i].Inventory.Name, Status = alteredRoomInventory[i].Inventory.Status, IsStatic = alteredRoomInventory[i].Inventory.IsStatic };
                        RoomInventory roomInventory = new RoomInventory() { RoomId = destRoom.Id, Quantity = quantity, Inventory = newInventory };
                        _roomInventoryRepository.SaveAllRoomInventory(alteredRoomInventory);
                        _roomInventoryService.CreateRoomInventory(roomInventory);
                    }
                }
            }
        }
    }
}
