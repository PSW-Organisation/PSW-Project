using System.Threading;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEquipment.Service
{
    public interface IRoomEquipmentRelocator
    {
        public Task RelocateEquipment(CancellationToken cancellationToken);
    }
}
