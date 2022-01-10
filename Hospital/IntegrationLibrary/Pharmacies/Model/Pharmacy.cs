using IntegrationLibrary.Model;
using IntegrationLibrary.SharedModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Model
{
    public class Pharmacy : Entity
    {
     
        private string pharmacyName;
        private Address pharmacyAddress;
        private PharmacyCommunicationInfo pharmacyCommunicationInfo;
        private string comment;
        private string picture;

        public PharmacyCommunicationInfo PharmacyComunicationInfo { get => PharmacyComunicationInfo; set => pharmacyCommunicationInfo = value; }
        public string PharmacyName { get => pharmacyName; set => pharmacyName = value; }
        public Address PharmacyAddress { get => pharmacyAddress; set => pharmacyAddress = value; }
        public string Comment { get => comment; set => comment = value; }
        public string Picture { get => picture; set => picture = value; }
     

        public Pharmacy() : base(-1) { }
        public Pharmacy(string pharmacyUrl, string pharmacyName, Address pharmacyAddress, string pharmacyApiKey, string hospitalApiKey, string comment, string picture, PharmacyCommunicationType communicationType) : base(-1)
        {
            this.pharmacyCommunicationInfo.PharmacyUrl = pharmacyUrl;
            this.pharmacyName = pharmacyName;
            this.pharmacyAddress = pharmacyAddress;
            this.pharmacyCommunicationInfo.PharmacyApiKey = pharmacyApiKey;
            this.pharmacyCommunicationInfo.HospitalApiKey = hospitalApiKey;
            this.comment = comment;
            this.picture = picture;
            this.pharmacyCommunicationInfo.PharmacyCommunicationType = communicationType;
        }
    }
}
