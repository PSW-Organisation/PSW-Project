using IntegrationLibrary.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Model
{
    public class Pharmacy : Entity
    {
        private string pharmacyUrl;
        private string pharmacyName;
        private string pharmacyAddress;
        private string pharmacyApiKey;
        private string hospitalApiKey;
        private string comment;
        private string picture;

        public string PharmacyUrl { get => pharmacyUrl; set => pharmacyUrl = value; }
        public string PharmacyName { get => pharmacyName; set => pharmacyName = value; }
        public string PharmacyAddress { get => pharmacyAddress; set => pharmacyAddress = value; }
        public string PharmacyApiKey { get => pharmacyApiKey; set => pharmacyApiKey = value; }
        public string HospitalApiKey { get => hospitalApiKey; set => hospitalApiKey = value; }
        public string Comment { get => comment; set => comment = value; }
        public string Picture { get => picture; set => picture = value; }

        public Pharmacy() : base(-1) { }
        public Pharmacy(string pharmacyUrl, string pharmacyName, string pharmacyAddress, string pharmacyApiKey, string hospitalApiKey, string comment, string picture) : base(-1)
        {
            this.pharmacyUrl = pharmacyUrl;
            this.pharmacyName = pharmacyName;
            this.pharmacyAddress = pharmacyAddress;
            this.pharmacyApiKey = pharmacyApiKey;
            this.hospitalApiKey = hospitalApiKey;
            this.comment = comment;
            this.picture = picture;
        }
    }
}
