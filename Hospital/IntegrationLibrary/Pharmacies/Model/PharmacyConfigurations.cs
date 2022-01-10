using IntegrationLibrary.Pharmacies.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Pharmacies.Model
{
   public  class PharmacyConfigurations : IEntityTypeConfiguration<Pharmacy>
    {
        public void Configure(EntityTypeBuilder<Pharmacy> builder)
        {
            builder.ToTable("Pharmacies");
            builder.HasKey(pharmacies => pharmacies.Id);
            builder.OwnsOne(pharmacies => pharmacies.PharmacyAddress);
            builder.OwnsOne(pharmacies => pharmacies.PharmacyComunicationInfo);
        }
    }
}
