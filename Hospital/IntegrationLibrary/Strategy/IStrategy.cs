using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezba.Strategy
{
    public interface IStrategy
    {
        int ChangeEquipmentQuantity(RoomInventory roomInventory, int roomNumber, int inputItemQuantity, DateTime pickedDate);
    }
}
