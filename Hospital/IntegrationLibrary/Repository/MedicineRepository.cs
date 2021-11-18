using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Repository
{
    public interface MedicineRepository : GenericRepository<Medicine>
    {
        public Medicine GetMedicineByName(string name);
    }
}
