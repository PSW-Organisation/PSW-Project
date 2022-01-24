using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalLibrary.Events.Model
{
    public enum EventClass
    {
        EnterForm,
        CancelForm, 
        AppointmentSchedulingStart,
        AppointmentSchedulingComplete,
        AppointmentSchedulingFirstStep,
        AppointmentSchedulingSecondStep,
        AppointmentSchedulingThirdStep,
        AppointmentSchedulingFourthStep
    }
}
