using System;
using System.Collections.Generic;
using Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vezba.Repository;
using vezba.Service;

namespace vezba.Service
{
    class PatientStayRegulator
    {
        private IRoomInventoryRepository RoomInventoryRepository { get; }

        public PatientStayRegulator()
        {
            RoomInventoryRepository = new RoomInventoryFileRepository();
        }    

        public Boolean TreatPatient(DateTime startDate, int numberOfDays, Room room)
        {
            var endDate = startDate.AddDays(numberOfDays);

            var bedsInSelectedPeriod = GetBedsInRoomInSelectedPeriod(room, startDate, endDate);
            if (bedsInSelectedPeriod.Count == 0)
                return false;
            foreach (var inventory in bedsInSelectedPeriod)
            {
                if (inventory.Quantity <= 0 || inventory.NumberUnavailable >= inventory.Quantity)
                    return false;
            }
            OccupyBed(startDate, endDate, bedsInSelectedPeriod);
            return true;
        }

        private List<RoomInventory> GetBedsInRoomInSelectedPeriod(Room room, DateTime startDate, DateTime endDate)
        {
            var roomInventories = RoomInventoryRepository.GetAll();

            var bedsInSelectedPeriod = new List<RoomInventory>();
            foreach (var inventory in roomInventories)
            {
                if (inventory.room.RoomNumber == room.RoomNumber && inventory.equipment.Name == "Krevet" && IsBefore(startDate, inventory.EndTime) && IsBefore(inventory.StartTime, endDate))
                {
                    bedsInSelectedPeriod.Add(inventory);
                }
            }
            return bedsInSelectedPeriod;
        }

        private Boolean IsBefore(DateTime firstDate, DateTime secondDate)
        {
            return DateTime.Compare(firstDate, secondDate) < 0;
        }

        private void OccupyBed(DateTime startDate, DateTime endDate, List<RoomInventory> inventories)
        {
            foreach (var inventory in inventories)
            {
                if (IsBefore(inventory.StartTime, startDate) &&  IsBefore(endDate, inventory.EndTime))
                {
                    RoomInventoryRepository.Delete(inventory.Id);

                    var beforeTreatment = new RoomInventory(inventory.StartTime, startDate, inventory.Quantity, 0, inventory.equipment, inventory.room);
                    beforeTreatment.NumberUnavailable = inventory.NumberUnavailable;
                    RoomInventoryRepository.Save(beforeTreatment);

                    var duringTreatment = new RoomInventory(startDate, endDate, inventory.Quantity, 0, inventory.equipment, inventory.room);
                    duringTreatment.NumberUnavailable = inventory.NumberUnavailable + 1;
                    RoomInventoryRepository.Save(duringTreatment);

                    var afterTreatment = new RoomInventory(endDate, inventory.EndTime, inventory.Quantity, 0, inventory.equipment, inventory.room);
                    afterTreatment.NumberUnavailable = inventory.NumberUnavailable;
                    RoomInventoryRepository.Save(afterTreatment);
                }
                else if (IsBefore(inventory.StartTime, startDate))
                {
                    RoomInventoryRepository.Delete(inventory.Id);

                    var beforeTreatment = new RoomInventory(inventory.StartTime, startDate, inventory.Quantity, 0, inventory.equipment, inventory.room);
                    beforeTreatment.NumberUnavailable = inventory.NumberUnavailable;
                    RoomInventoryRepository.Save(beforeTreatment);

                    var duringTreatment = new RoomInventory(startDate, inventory.EndTime, inventory.Quantity, 0, inventory.equipment, inventory.room);
                    duringTreatment.NumberUnavailable = inventory.NumberUnavailable + 1;
                    RoomInventoryRepository.Save(duringTreatment);
                }
                else if (IsBefore(endDate, inventory.EndTime))
                {
                    RoomInventoryRepository.Delete(inventory.Id);

                    var duringTreatment = new RoomInventory(inventory.StartTime, endDate, inventory.Quantity, 0, inventory.equipment, inventory.room);
                    duringTreatment.NumberUnavailable = inventory.NumberUnavailable + 1;
                    RoomInventoryRepository.Save(duringTreatment);

                    var afterTreatment = new RoomInventory(endDate, inventory.EndTime, inventory.Quantity, 0, inventory.equipment, inventory.room);
                    afterTreatment.NumberUnavailable = inventory.NumberUnavailable;
                    RoomInventoryRepository.Save(afterTreatment);
                }
                else
                {
                    inventory.NumberUnavailable++;
                    RoomInventoryRepository.Update(inventory);
                }
            }
        }

        public void CancelPatientTreatment(DateTime startDate, int numberOfDays, Room room)
        {
            var roomInventories = RoomInventoryRepository.GetAll();

            var endDate = startDate.AddDays(numberOfDays);

            foreach (var inventory in roomInventories)
            {
                if (inventory.room.RoomNumber == room.RoomNumber && inventory.equipment.Name == "Krevet" && !IsBefore(inventory.StartTime, startDate) && !IsBefore(endDate, inventory.EndTime))
                {
                    inventory.NumberUnavailable--;
                    RoomInventoryRepository.Update(inventory);
                }
            }
            MergeSameStatesInRoom(room, "Krevet");
        }

        private void MergeSameStatesInRoom(Room room, String equipmentName)
        {
            var inventoriesForMerge = GetInventoriesForMerge(room, equipmentName);

            var current = inventoriesForMerge[0];
            foreach (var inventory in inventoriesForMerge.Skip(1))
            {
                if (inventory.Quantity == current.Quantity && inventory.NumberUnavailable == current.NumberUnavailable)
                {
                    current.EndTime = inventory.EndTime;
                    RoomInventoryRepository.Delete(inventory.Id);
                    RoomInventoryRepository.Update(current);
                }
                else
                {
                    current = inventory;
                }
            }
        }

        private List<RoomInventory> GetInventoriesForMerge(Room room, String equipmentName)
        {
            var roomInventories = RoomInventoryRepository.GetAll();
            var inventoriesForMerge = new List<RoomInventory>();
            foreach (var inventory in roomInventories)
            {
                if (inventory.room.RoomNumber == room.RoomNumber && inventory.equipment.Name == equipmentName)
                {
                    inventoriesForMerge.Add(inventory);
                }
            }
            return inventoriesForMerge;
        }
    }
}
