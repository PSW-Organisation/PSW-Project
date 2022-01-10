using IntegrationLibrary.Model;
using IntegrationLibrary.SharedModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Model
{
    public class Pharmacy : Entity
    {
       
        private PharmacyCommunicationInfo pharmacyComunicationInfo;
        private string pharmacyName;
        private Address pharmacyAddress;
        private string comment;
        private string picture;


      
        public string PharmacyName { get => pharmacyName; set => pharmacyName = value; }
        public Address PharmacyAddress { get => pharmacyAddress; set => pharmacyAddress = value; }
        public PharmacyCommunicationInfo PharmacyComunicationInfo { get; set; }
        public string Comment { get => comment; set => comment = value; }
        public string Picture { get => picture; set => picture = value; }
 

        public Pharmacy() : base(-1) { }
        public Pharmacy(string pharmacyUrl, string pharmacyName, Address address, string pharmacyApiKey, string hospitalApiKey, string comment, string picture, PharmacyCommunicationType communicationType) : base(-1)
        {
            this.pharmacyComunicationInfo.PharmacyUrl = pharmacyUrl;
            this.pharmacyName = pharmacyName;
            this.pharmacyAddress = address;
            this.pharmacyComunicationInfo.PharmacyApiKey = pharmacyApiKey;
            this.pharmacyComunicationInfo.HospitalApiKey = hospitalApiKey;
            this.comment = comment;
            this.picture = picture;
            this.pharmacyComunicationInfo.PharmacyCommunicationType = communicationType;
        }
    }
}
