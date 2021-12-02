using ehealthcare.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Repository
{
    public interface RoomInventoryRepository : GenericRepository<RoomInventory>
    {
        public List<RoomInventory> GetFacilityRoomInventory();
        public List<RoomInventory> GetInventoryInRoom(string roomID);
        public void SaveAllRoomInventory(List<RoomInventory> roomInventory);

        public void SaveAllRoomInventory();


        public void DeleteRoomInventoryByNameInRoom(RoomInventory inventoryToDelete);

        public void NewRoomInventory(RoomInventory roominventory);
        public void SetRoomInventory(RoomInventory roominventory);

        public void DeleteRoomInventoryInRoom(RoomOld room);
        public void DeleteRoomInventoryByName(string name);
        public List<RoomInventory> GetInventories();
    }
}
