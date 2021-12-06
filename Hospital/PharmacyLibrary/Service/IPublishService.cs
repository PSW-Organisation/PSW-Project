using PharmacyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public interface IPublishService
    {
        public bool initConnection();
        public bool SendMedicineBenefit(MedicineBenefit medicineBenefit);
    }
}
