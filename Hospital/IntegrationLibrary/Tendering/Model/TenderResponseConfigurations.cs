using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;


namespace IntegrationLibrary.Tendering.Model
{
    public class TenderResponseConfigurations : IEntityTypeConfiguration<TenderResponse>
    {
        public void Configure(EntityTypeBuilder<TenderResponse> builder)
        {
            builder.ToTable("TenderResponses");
            builder.HasKey(tenderResponses => tenderResponses.Id);
            builder.OwnsOne(tenderResponses => tenderResponses.TotalPrice);
        }
    }
}
