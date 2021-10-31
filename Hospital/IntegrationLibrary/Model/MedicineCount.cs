using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class MedicineCount
    {
        public Medicine Medicine { get; set; }
        public int Count { get; set; }

        public MedicineCount(Medicine medicine, int count) {
            Medicine = medicine;
            Count = count;
        }
    }
}
