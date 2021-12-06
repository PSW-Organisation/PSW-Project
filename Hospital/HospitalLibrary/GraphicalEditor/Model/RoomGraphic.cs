using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

        public bool CanBeMerged(RoomGraphic rg)
        {
            int numberOfCommonPoints = 0;

            List<Point> points = new List<Point>()
            {
                new Point(X, Y),
                new Point(X + Width, Y),
                new Point(X, Y + Height),
                new Point(X + Width, Y + Height)
            };

            List<Point> rg_points = new List<Point>()
            {
                new Point(rg.X, rg.Y),
                new Point(rg.X + rg.Width, rg.Y),
                new Point(rg.X, rg.Y + rg.Height),
                new Point(rg.X + rg.Width, rg.Y + rg.Height)
            };

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