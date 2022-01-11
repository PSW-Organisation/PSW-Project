using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using ehealthcare.Model;
using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Model;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class RoomGraphic : EntityDb
    {
        public virtual Position Position { get; set; }
        public virtual Dimension Dimension { get; set; }
        public string DoorPosition { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int FloorGraphicId { get; set; }
        public virtual FloorGraphic FloorGraphic { get; set; }
        

        public RoomGraphic()
        {
        }

        public RoomGraphic(int x, int y, int width, int height, string doorPosition, int roomId, Room room)
        {
            Position = new Position(x, y);
            Dimension = new Dimension(width, height);
            DoorPosition = doorPosition;
            RoomId = roomId;
            Room = room;
        }

        public RoomGraphic(RoomGraphic roomGraphicA, RoomGraphic roomGraphicB, Room room)
        {
            DoorPosition = roomGraphicA.DoorPosition;
            RoomId = room.Id;
            Room = room;
            
            List<Point> unionPoints = new List<Point>();
            unionPoints.AddRange(roomGraphicA.GetPoints());
            unionPoints.AddRange(roomGraphicB.GetPoints());

            Point leftTopPoint = new Point(1000000, 1000000);
            Point rightBottomPoint = new Point(0,0);

            foreach (Point pt in unionPoints)
            {
                if(pt.X <= leftTopPoint.X && pt.Y <= leftTopPoint.Y) 
                    leftTopPoint = pt;
                else if (pt.X >= rightBottomPoint.X && pt.Y >= rightBottomPoint.Y) 
                    rightBottomPoint = pt;
            }

            Position = new Position(leftTopPoint.X, leftTopPoint.Y);
            Dimension = new Dimension(rightBottomPoint.X - Position.X, rightBottomPoint.Y - Position.Y);
        }

        public List<Point> GetPoints()
        {   //  1 2
            //  3 4
            List<Point> points = new List<Point>()
            {
                new Point(Position.X, Position.Y),
                new Point(Position.X + Dimension.Width, Position.Y),
                new Point(Position.X, Position.Y + Dimension.Height),
                new Point(Position.X + Dimension.Width, Position.Y + Dimension.Height)
            };
            return points;
        }

        public bool CanBeMerged(RoomGraphic rg)
        {
            int numberOfCommonPoints = 0;

            List<Point> points = GetPoints();

            List<Point> rg_points = rg.GetPoints();

            foreach(Point point in points)
            {
                foreach(Point rg_point in rg_points)
                {
                    if (point == rg_point)
                        numberOfCommonPoints++;
                }
            }

            return numberOfCommonPoints == 2;
        }

        public override string ToString()
        {
            return "ID " + Id + " X:" + Position.X + " Y:" + Position.Y + " Width:" + Dimension.Width + " Height:" + Dimension.Height;
        }
    }
}