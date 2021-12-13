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
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string DoorPosition { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public RoomGraphic()
        {
        }

        public RoomGraphic(int x, int y, int width, int height, string doorPosition, int roomId, Room room)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
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
                if(pt.X < leftTopPoint.X && pt.Y < leftTopPoint.Y) 
                    leftTopPoint = pt;
                else if (pt.X > rightBottomPoint.X && pt.Y > rightBottomPoint.Y) 
                    rightBottomPoint = pt;
            }

            X = leftTopPoint.X;
            Y = leftTopPoint.Y;
            Width = rightBottomPoint.X - X;
            Height = rightBottomPoint.Y - Y;
        }

        public List<Point> GetPoints()
        {   //  1 2
            //  3 4
            List<Point> points = new List<Point>()
            {
                new Point(X, Y),
                new Point(X + Width, Y),
                new Point(X, Y + Height),
                new Point(X + Width, Y + Height)
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
    }
}