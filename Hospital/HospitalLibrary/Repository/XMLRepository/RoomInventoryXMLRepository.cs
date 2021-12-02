using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository.XMLRepository
{
	public class RoomInventoryXMLRepository : GenericXMLRepository<RoomInventory>, RoomInventoryRepository
	{
		public RoomInventoryXMLRepository() : base("roomInventory.xml") { }

        public List<RoomInventory> GetFacilityRoomInventory()
        {
            return base.GetAll();
        }
        public List<RoomInventory> GetInventoryInRoom(string roomID)
        {
            List<RoomInventory> InventoryInRoom = new List<RoomInventory>();
            for (int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].RoomId == roomID)
                {
                    InventoryInRoom.Add(base.GetAll()[i]);
                }
            }
            return InventoryInRoom;
        }
        public void SaveAllRoomInventory(List<RoomInventory> roomInventory)
        {
            DataIO dataIO = new DataIO();
            dataIO.SerializeObject(base.GetAll(), "roomInventory.xml");
        }

        public void SaveAllRoomInventory()
        {
            DataIO dataIO = new DataIO();
            dataIO.SerializeObject(base.GetAll(), "roomInventory.xml");
        }

       

        public void DeleteRoomInventoryByNameInRoom(RoomInventory inventoryToDelete)
        {
            for (int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].RoomId == inventoryToDelete.RoomId && base.GetAll()[i].Inventory.Name.Equals(inventoryToDelete.Inventory.Name))
                {
                    base.GetAll().Remove(base.GetAll()[i]);
                }
            }
            SaveAllRoomInventory();

        }

        public void NewRoomInventory(RoomInventory roominventory)
        {
            base.Save(roominventory);
        }

        public void SetRoomInventory(RoomInventory roominventory)
        {
            for (int i = base.GetAll().Count - 1; i >= 0; i--)
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

        public void DeleteRoomInventoryInRoom(RoomOld room)
        {

            for (int i = base.GetAll().Count - 1; i >= 0; i--)
            {
                if (base.GetAll()[i].RoomId == room.Id)
                {
                    base.GetAll().Remove(base.GetAll()[i]);
                }
            }
            SaveAllRoomInventory();

        }
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


        public List<RoomInventory> GetInventories()
        {
            return base.GetAll();
        }

    }
}
