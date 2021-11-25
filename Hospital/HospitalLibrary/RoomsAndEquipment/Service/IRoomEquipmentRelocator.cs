using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public interface IRoomEquipmentRelocator
    {
     public  Task RelocateEquipment(CancellationToken cancellationToken);
    }
}
