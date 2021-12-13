﻿using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using IntegrationLibrary.Service;
using IntegrationLibrary.Service.ServicesInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace IntegrationAPIIntegrationTests
{
     public class EditPharmacyProfile
    {

       // [Fact]
        public void edit_pharmacy_profile_picture()
        {
            var stubRepositoryPharmacy = new Mock<PharmacyRepository>();
            var pharmacies = new List<Pharmacy>();

            pharmacies.Add(new Pharmacy("http://localhost:29631", "Flos", "Bulevar Oslobodjenja, Novi Sad", "bc56df25-0d34-4801-b76a-931e61b4c752", "108817cf-dc25-40f4-a18f-244c1315840a", "", ""));
            var updatedPharmacy = new Pharmacy("http://localhost:29631", "Flos", "Bulevar Oslobodjenja, Novi Sad", "bc56df25-0d34-4801-b76a-931e61b4c752", "108817cf-dc25-40f4-a18f-244c1315840a", "komentar", "slika.jpg");
            var forUpdate = new Pharmacy("http://localhost:29631", "Flos", "Bulevar Oslobodjenja, Novi Sad", "bc56df25-0d34-4801-b76a-931e61b4c752", "108817cf-dc25-40f4-a18f-244c1315840a", "komentar", "C:\\fakepath\\slika.jpg");
            stubRepositoryPharmacy.Setup(p => p.GetAll()).Returns(pharmacies);
           
            stubRepositoryPharmacy.Setup(p => p.Update(forUpdate)).Returns(updatedPharmacy);
          
            IPharmacyService pharmacyService = new PharmacyService(stubRepositoryPharmacy.Object);
            Pharmacy ret = pharmacyService.Update(forUpdate);
            List<Pharmacy> all = pharmacyService.GetAll();


            Assert.True(ret.Picture.Equals("slika.jpg"));

        }
    }
}