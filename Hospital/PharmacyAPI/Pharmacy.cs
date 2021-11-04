using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyAPI
{
    public class Pharmacy
    {
        private long pharmacyId;
        private string pharmacyUrl;
        private string pharmacyName;
        private string pharmacyAddress;
        private string pharmacyApiKey;

        public long PharmacyId { get => pharmacyId; set => pharmacyId = value; }
        public string PharmacyUrl { get => pharmacyUrl; set => pharmacyUrl = value; }
        public string PharmacyName { get => pharmacyName; set => pharmacyName = value; }
        public string PharmacyAddress { get => pharmacyAddress; set => pharmacyAddress = value; }
        public string PharmacyApiKey { get => pharmacyApiKey; set => pharmacyApiKey = value; }

        public Pharmacy() { }
        public Pharmacy(long pharmacyId, string pharmacyUrl, string pharmacyName, string pharmacyAddress, string pharmacyApiKey)
        {
            this.pharmacyId = pharmacyId;
            this.pharmacyUrl = pharmacyUrl;
            this.pharmacyName = pharmacyName;
            this.pharmacyAddress = pharmacyAddress;
            this.pharmacyApiKey = pharmacyApiKey;
        }
    }
}
