using Castle.Core.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Model
{
    public class PharmacyCommunicationInfo : ValueObject
    {
        public String PharmacyUrl { get; set; }
        public PharmacyCommunicationType PharmacyCommunicationType { get; set; }

        public string PharmacyApiKey { get; set; }

        public string HospitalApiKey { get; set; }

        public PharmacyCommunicationInfo()
        {
        }
        public PharmacyCommunicationInfo(string url, PharmacyCommunicationType type, string pApi, string hApi)
        {
            if (url.IsNullOrEmpty() || pApi.IsNullOrEmpty() || hApi.IsNullOrEmpty() || type.ToString().IsNullOrEmpty())
                throw new ArgumentException("Some of arguments of informations about pharmacy in not set!");
            PharmacyUrl = url;
            PharmacyCommunicationType = type;
            PharmacyApiKey = pApi;
            HospitalApiKey = hApi;
        }

        public PharmacyCommunicationInfo ChangeUrl(string url)
        {
            if (url.IsNullOrEmpty()) throw new ArgumentException("Url can not be empty!");
            return new PharmacyCommunicationInfo(url, this.PharmacyCommunicationType, this.PharmacyApiKey, this.HospitalApiKey);
        }

        public PharmacyCommunicationInfo ChangeComunicationType(PharmacyCommunicationType type)
        {
            if (type.ToString().IsNullOrEmpty()) throw new ArgumentException("Type must be declared!");
            return new PharmacyCommunicationInfo(this.PharmacyUrl, type, this.PharmacyApiKey, this.HospitalApiKey);
        }

        public PharmacyCommunicationInfo ChangePharmacyApi(string pApi)
        {
            if (pApi.IsNullOrEmpty()) throw new ArgumentException("Api can not be empty!");
            return new PharmacyCommunicationInfo(this.PharmacyUrl, this.PharmacyCommunicationType, pApi, this.HospitalApiKey);
        }
        public PharmacyCommunicationInfo ChangeHospitalApi(string api)
        {
            if (api.IsNullOrEmpty()) throw new ArgumentException("Api can not be empty!");
            return new PharmacyCommunicationInfo(this.PharmacyUrl, this.PharmacyCommunicationType, this.PharmacyApiKey, api);
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return PharmacyUrl;
            yield return PharmacyCommunicationType;
            yield return PharmacyApiKey;
            yield return HospitalApiKey;
        }
    }
}
