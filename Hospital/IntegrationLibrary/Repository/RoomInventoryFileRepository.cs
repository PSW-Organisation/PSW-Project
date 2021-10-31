using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
   public class RoomInventoryFileRepository:IRoomInventoryRepository
   {
        public String FileName { get; set; }

        public RoomInventoryFileRepository()
        {
            this.FileName = "../../room_inventory.json";
        }

        public List<RoomInventory> GetAll()
        {
            List<RoomInventory> roomInventories = new List<RoomInventory>();
            List<RoomInventory> storedRoomInventories = ReadFromFile();
            for (int i = 0; i < storedRoomInventories.Count; i++)
            {
                if (storedRoomInventories[i].IsDeleted == false)
                {
                    roomInventories.Add(storedRoomInventories[i]);
                }
            }
            return roomInventories;
        }
      
      public Boolean Save(RoomInventory inventory)
      {
          inventory.Id = GenerateNextId();
          List<RoomInventory> storedRoomInventories = ReadFromFile();
          for (int i = 0; i < storedRoomInventories.Count; i++)
          {
              if (storedRoomInventories[i].Id.Equals(inventory.Id))
                  return false;
          }
          storedRoomInventories.Add(inventory);
          WriteToFile(storedRoomInventories);
          return true;
      }
      
      public Boolean Update(RoomInventory inventory)
      {
          List<RoomInventory> storedRoomInventories = ReadFromFile();
          foreach (RoomInventory roomInventory in storedRoomInventories)
          {
              if (roomInventory.Id.Equals(inventory.Id) && roomInventory.IsDeleted == false)
              {
                  roomInventory.Quantity = inventory.Quantity;
                  roomInventory.equipment = inventory.equipment;
                  roomInventory.room = inventory.room;
                  roomInventory.StartTime = inventory.StartTime;
                  roomInventory.EndTime = inventory.EndTime;
                  roomInventory.NumberUnavailable = inventory.NumberUnavailable;
                  WriteToFile(storedRoomInventories);
                  return true;
              }
          }
          return false;
      }
      
      public RoomInventory GetOne(int id)
      {
            List<RoomInventory> roomInventoryList = GetAll();
            for (int i = 0; i < roomInventoryList.Count; i++)
            {
                if (roomInventoryList[i].Id.Equals(id))
                {
                    return roomInventoryList[i];
                }
            }
            return null;
        }
      
      public Boolean Delete(int id)
      {
          List<RoomInventory> storedRoomInventories = ReadFromFile();
          for (int i = 0; i < storedRoomInventories.Count; i++)
          {
              if (storedRoomInventories[i].Id == id && storedRoomInventories[i].IsDeleted == false)
              {
                  storedRoomInventories[i].IsDeleted = true;
                  WriteToFile(storedRoomInventories);
                  return true;
              }
          }
          return false;
      }
      
      private List<RoomInventory> ReadFromFile()
      {
          try
          {
              String jsonFromFile = File.ReadAllText(this.FileName);
              List<RoomInventory> roomInventories = JsonConvert.DeserializeObject<List<RoomInventory>>(jsonFromFile);
              return roomInventories;
          }
          catch { }
          MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
          return new List<RoomInventory>();
      }

      private void WriteToFile(List<RoomInventory> roomInventories)
      {
          try
          {
              var jsonToFile = JsonConvert.SerializeObject(roomInventories, Formatting.Indented);
              using (StreamWriter writer = new StreamWriter(this.FileName))
              {
                  writer.Write(jsonToFile);
              }
          }
          catch
          {
              MessageBox.Show("Neuspesno pisanje u fajl" + this.FileName + "!");
          }
      }

      private int GenerateNextId()
      {
          List<RoomInventory> list = ReadFromFile();
          return list.Count;
      }
    }
}