using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace vezba.Repository
{
    public interface IMedicineRepository:IGenericRepository<Medicine, int>
    {
        List<Medicine> GetAwaiting();
        List<Medicine> GetApproved();
    }
}
