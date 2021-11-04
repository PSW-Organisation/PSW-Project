using ehealthcare.Model;
using ehealthcare.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ehealthcare.Controller
{
	public class RoomController
	{
		private RoomService roomService;
        private VisitService visitService = new VisitService();
        private IRenovateStrategy _renovateStrategy;
        public RoomController()
		{
			roomService = new RoomService();
		}

        public void SetStrategy(IRenovateStrategy renovateStrategy)
        {
            this._renovateStrategy = renovateStrategy;
        }

        public void RenovateRoom(Room selectedRoom, DateTime renovateDateTime, Room roomForMerge)
        {
            this._renovateStrategy.DoRenovation(selectedRoom, renovateDateTime, roomForMerge);
        }
        public Room GetRoomById(String id)
        {
            return roomService.GetRoomById(id);
        }

        public List<Room> GetAllRooms()
        {
            return roomService.GetAllRooms();
        }

        public void DeleteRoom(string id)
        {
            roomService.DeleteRoom(id);
        }
        public List<Room> GetAllNonRenovatedRooms(DateTime now)
        {
            return roomService.GetAllNonRenovatedRooms(now);
        }

        public void CreateRoom(Room room)
        {
            roomService.CreateRoom(room);
        }

        public void SetRoom(Room room)
        {
            roomService.SetRoom(room);
        }

        public List<Room> GetRoomsForHospitalization()
        {
            return roomService.GetRoomsForHospitalization();
        }

        public void CheckIfRoomIsRenovated(ObservableCollection<Room> rooms)
        {
            roomService.CheckIfRoomIsRenovated(rooms);
        }

        public void SplitRoom(Room room)
        {
            roomService.SplitRoom(room);
        }
        public void MergeRooms(Room firstRoom, Room secondRoom)
        {
            roomService.MergeRooms(firstRoom, secondRoom);
        }
        public void CancelVisitsForRenovation(Room selectedRoom, DateTime renovateDateTime)
        {

            List<Visit> canceledVisits = visitService.GetAllVisits();
            DateTime Now = DateTime.Now;
            foreach (Visit v in canceledVisits.ToList())
            {
                if (v.VisitStatus.Equals(VisitStatus.forthcoming) && v.VisitTime.Overlaps(Now, renovateDateTime) && selectedRoom.Id.Equals(v.RoomId))
                {
                    visitService.CancelVisit(v);
                }
            }
            foreach(Visit vv in visitService.GetAllVisits())
            {
                Console.WriteLine(vv.Id);
                Console.WriteLine(vv.VisitStatus);
            }
        }


    }
    
    public interface IRenovateStrategy
    {
        void DoRenovation(Room selectedRoom, DateTime renovateDateTime, Room roomToMerge);
    }

    class DoSplitRenovation : IRenovateStrategy
    {
        public void DoRenovation(Room selectedRoom, DateTime renovateDateTime, Room roomToMerge)
        {
            DoctorController doctorController = new DoctorController();
            RoomController roomController = new RoomController();
            roomController.CancelVisitsForRenovation(selectedRoom, renovateDateTime);
            List<Room> nonRenovatedRooms = roomController.GetAllNonRenovatedRooms(renovateDateTime);
            Room renovatedRoom = new Room() { Id = selectedRoom.Id, Floor = selectedRoom.Floor, Sector = selectedRoom.Sector, IsRenovated = true, RoomType = selectedRoom.RoomType, IsRenovatedUntill = renovateDateTime, NumOfTakenBeds = selectedRoom.NumOfTakenBeds };
            doctorController.ChangeDoctorRoom(nonRenovatedRooms[0], selectedRoom);
            roomController.SplitRoom(renovatedRoom);
        }

       
    }

    class DoMergeRenovation : IRenovateStrategy
    {
        public void DoRenovation(Room selectedRoom, DateTime renovateDateTime, Room roomToMerge)
        {
            DoctorController doctorController = new DoctorController();
            RoomController roomController = new RoomController();
            roomController.CancelVisitsForRenovation(selectedRoom, renovateDateTime);
            roomController.CancelVisitsForRenovation(roomToMerge, renovateDateTime);
            List<Room> nonRenovatedRooms = roomController.GetAllNonRenovatedRooms(renovateDateTime);
            Room renovatedRoom = new Room() { Id = selectedRoom.Id, Floor = selectedRoom.Floor, Sector = selectedRoom.Sector, IsRenovated = true, RoomType = selectedRoom.RoomType, IsRenovatedUntill = renovateDateTime, NumOfTakenBeds = selectedRoom.NumOfTakenBeds };
            doctorController.ChangeDoctorRoom(nonRenovatedRooms[0], selectedRoom);
            roomController.MergeRooms(renovatedRoom, roomToMerge);
        }
    }
    class DoNormalRenovation : IRenovateStrategy
    {
        public void DoRenovation(Room selectedRoom, DateTime renovateDateTime, Room roomToMerge)
        {
            DoctorController doctorController = new DoctorController();
            RoomController roomController = new RoomController();
            roomController.CancelVisitsForRenovation(selectedRoom, renovateDateTime);
            List<Room> nonRenovatedRooms = roomController.GetAllNonRenovatedRooms(renovateDateTime);
            Room renovatedRoom = new Room() { Id = selectedRoom.Id, Floor = selectedRoom.Floor, Sector = selectedRoom.Sector, IsRenovated = true, RoomType = selectedRoom.RoomType, IsRenovatedUntill = renovateDateTime, NumOfTakenBeds = selectedRoom.NumOfTakenBeds };
            doctorController.ChangeDoctorRoom(nonRenovatedRooms[0], selectedRoom);
            roomController.SetRoom(renovatedRoom);
        }
    }
}
