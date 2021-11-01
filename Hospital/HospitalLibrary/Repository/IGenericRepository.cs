using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba.Repository
{
    public interface IGenericRepository<T, M> where T:class
    {
        List<T> GetAll();
        T GetOne(M id);
        Boolean Save(T newObject);
        Boolean Update(T editedObject);
        Boolean Delete(M id);
    }
}
