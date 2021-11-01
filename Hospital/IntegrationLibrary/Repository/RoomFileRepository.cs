using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using Model;
using Newtonsoft.Json;

namespace vezba.Repository
{
    public class RoomFileRepository:IRoomRepository
    {
        public String FileName { get; set; }

        public RoomFileRepository()
        {
            this.FileName = "../../sobe.json";
        }

        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            List<Room> storedRooms = ReadFromFile();
            for (int i = 0; i < storedRooms.Count; i++)
            {
                if (storedRooms[i].IsDeleted == false)
                {
                    rooms.Add(storedRooms[i]);
                }
            }
            return rooms;
        }

        public Boolean Save(Room room)
        {
            List<Room> storedRooms = ReadFromFile();
            for (int i = 0; i < storedRooms.Count; i++)
            {
                if (storedRooms[i].RoomNumber.Equals(room.RoomNumber))
                    return false;
            }
            storedRooms.Add(room);
            WriteToFile(storedRooms);
            return true;
        }

        public Boolean Update(Room editedRoom)
        {

            List<Room> storedRooms = ReadFromFile();
            foreach (Room room in storedRooms)
            {
                if (room.RoomNumber.Equals(editedRoom.RoomNumber) && room.IsDeleted == false)
                {
                    room.RoomFloor = editedRoom.RoomFloor;
                    room.RoomType = editedRoom.RoomType;
                    room.renovation = editedRoom.renovation;
                    room.EndDateTime = editedRoom.EndDateTime;
                    room.StartDateTime = editedRoom.StartDateTime;
                    WriteToFile(storedRooms);
                    return true;
                }
            }
            return false;
        }

        public Room GetOne(int number)
        {
            List<Room> rooms = GetAll();
            for(int i=0; i<rooms.Count; i++)
            {
                if(rooms[i].RoomNumber.Equals(number))
                {
                    return rooms[i];
                }
            }
            return null;
        }

        public Boolean Delete(int number)
        {
            List<Room> storedRooms = ReadFromFile();
            for (int i = 0; i < storedRooms.Count; i++)
            {
                if (storedRooms[i].RoomNumber == number && storedRooms[i].IsDeleted == false)
                {
                    storedRooms[i].IsDeleted = true;
                    WriteToFile(storedRooms);
                    return true;
                }
            }
            return false;
        }

        private List<Room> ReadFromFile()
        {
            try
            {
                String jsonFromFile = File.ReadAllText(this.FileName);
                List<Room> rooms = JsonConvert.DeserializeObject<List<Room>>(jsonFromFile);
                return rooms;
            }
            catch { }
            MessageBox.Show("Neuspesno ucitavanje iz fajla " + this.FileName + "!");
            return new List<Room>();
        }
        private void WriteToFile(List<Room> rooms)
        {
            try
            {
                var jsonToFile = JsonConvert.SerializeObject(rooms, Formatting.Indented);
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
            List<Room> list = ReadFromFile();
            return list.Count;
        }
    }
}