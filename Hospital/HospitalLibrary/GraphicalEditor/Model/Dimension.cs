using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System.Collections.Generic;

namespace HospitalLibrary.GraphicalEditor.Model
{
    public class Dimension : BaseValueObject
    {
        public Dimension()
        {
        }

        public Dimension(int width, int height)
        {
            Width = width;
            Height = height;
            Validation();
        }

        private bool Validation()
        {
            return Width > 0 && Height > 0;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Width;
            yield return Height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
    }
}