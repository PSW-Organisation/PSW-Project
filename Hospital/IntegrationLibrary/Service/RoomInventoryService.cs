using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Service.ServicesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Service
{
    public class RoomInventoryService : IRoomInventoryService
    {
        private RoomInventoryRepository roomInventoryRepository;
        
        public RoomInventoryService(RoomInventoryRepository roomInventoryRepository)
        {
            this.roomInventoryRepository = roomInventoryRepository;
        }

       
        public List<RoomInventory> FilterRoomInventoryByName(String name, int roomId)
        {
            List<RoomInventory> filteredInventoryByName = new List<RoomInventory>();
            if (roomId != -1)
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

        public List<RoomInventory> GetInventoryInRoom(int roomID)
        {
            return roomInventoryRepository.GetInventoryInRoom(roomID);
        }

        public void DeleteRoomInventoryByNameInRoom(RoomInventory roomInventory)
        {
            roomInventoryRepository.DeleteRoomInventoryByNameInRoom(roomInventory);
        }

        public void DoTransferNonStatic(Room srcRoom, Room destRoom, int quantity, RoomInventory trasnferedInventory)
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
                        CreateRoomInventory(roomInventory);
                    }

                }



            }

        }
        public void DoTransferStatic(Room srcRoom, Room destRoom, int quantity, DateTime dueDate, RoomInventory trasnferedInventory)
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

        public List<RoomInventory> FilterRoomInventoryByStatus(int searchInvStatusParam, string selectedRoomId)
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
        public int GetNumOfBedsById(int id)
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


   
    }

