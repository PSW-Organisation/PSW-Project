using System;
using System.Collections.Generic;
using System.Text;
using ehealthcare.Model;
using ehealthcare.Repository;
using IntegrationLibrary.Model;
namespace IntegrationLibrary.Repository.DatabaseRepository
{
    public class RoomInventoryDbRepository : GenericDatabaseRepository<RoomInventory>, RoomInventoryRepository
    {
        public RoomInventoryDbRepository(IntegrationDbContext dbContext) : base(dbContext) { }

        public void DeleteRoomInventoryByName(string name)
        {
            foreach (RoomInventory roominv in base.GetAll())

            {
                if (roominv.Inventory.Name.Equals(name))
                {
                    base.GetAll().Remove(roominv);
                    SaveAllRoomInventory();
                }
            }
        }

        public void DeleteRoomInventoryByNameInRoom(RoomInventory inventoryToDelete)
        {
            for (int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].RoomID == inventoryToDelete.RoomID && base.GetAll()[i].Inventory.Name.Equals(inventoryToDelete.Inventory.Name))
                {
                    base.GetAll().Remove(base.GetAll()[i]);
                }
            }
            base.SaveAll();

        }

        public void DeleteRoomInventoryInRoom(Room room)
        {
            for (int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].RoomID == room.Id)
                {
                    base.GetAll().Remove(base.GetAll()[i]);
                }
            }
            SaveAllRoomInventory();
        }

        public List<RoomInventory> GetFacilityRoomInventory()
        {
            return base.GetAll();

        }

        public List<RoomInventory> GetInventories()
        {
            return base.GetAll();

        }

        public List<RoomInventory> GetInventoryInRoom(int roomID)
        {
            List<RoomInventory> InventoryInRoom = new List<RoomInventory>();
            for (int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].RoomID == roomID)
                {
                    InventoryInRoom.Add(base.GetAll()[i]);
                }
            }
            return InventoryInRoom;
        }

        public void NewRoomInventory(RoomInventory roominventory)
        {
            base.Save(roominventory);

        }

        public void SaveAllRoomInventory(List<RoomInventory> roomInventory)
        {
            throw new NotImplementedException();
        }

        public void SaveAllRoomInventory()
        {
            base.SaveAll();
        }

        public void SetRoomInventory(RoomInventory roominventory)
        {
            for(int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].Inventory.Name == roominventory.Inventory.Name)
                {
                    base.GetAll().RemoveAt(i);
                    base.GetAll().Insert(i, roominventory);
                    break;
                }
            }
            SaveAllRoomInventory();
        }
    }
}
