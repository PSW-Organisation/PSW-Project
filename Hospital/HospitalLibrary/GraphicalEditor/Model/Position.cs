using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System.Collections.Generic;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Position : BaseValueObject
    {
        public Position()
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
            Validation();
        }

        private bool Validation()
        {
            return X > 0 && Y > 0;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}