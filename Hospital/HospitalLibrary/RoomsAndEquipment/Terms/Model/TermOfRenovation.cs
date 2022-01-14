using HospitalLibrary.Model;
using HospitalLibrary.RoomsAndEquipment.Model;
using HospitalLibrary.RoomsAndEquipment.Terms.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.RoomsAndEquipment.Terms.Model
{
    public class TermOfRenovation : EntityDb
    {
        public virtual TimeInterval TimeInterval { get; set; }
        public int DurationInMinutes { get; set; }
        private StateOfTerm stateOfRenovation;
        public StateOfTerm StateOfRenovation 
        {
            get { return stateOfRenovation; }
            set
            {
                if (stateOfRenovation == StateOfTerm.PENDING)
                {
                    stateOfRenovation = value;
                }
            }
        }

        public TypeOfRenovation TypeOfRenovation { get; set; }
        public int IdRoomA { get; set; }
        public int IdRoomB { get; set; }    /* if needed */
        public EquipmentLogic EquipmentLogic { get; set; }
        public string NewNameForRoomA { get; set; }
        public string NewSectorForRoomA { get; set; }
        public RoomType NewRoomTypeForRoomA { get; set; }
        public string NewNameForRoomB { get; set; }         /* if needed */
        public string NewSectorForRoomB { get; set; }       /* if needed */
        public RoomType NewRoomTypeForRoomB { get; set; }   /* if needed */

        public TermOfRenovation()
        {
        }

    }
}
