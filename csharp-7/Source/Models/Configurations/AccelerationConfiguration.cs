using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Challenge.Models.Configurations
{
    public class AccelerationConfiguration : IEntityTypeConfiguration<Acceleration>
    {
        public void Configure(EntityTypeBuilder<Acceleration> builder)
        {
            builder.HasMany(x => x.Candidates).WithOne(x => x.Acceleration).IsRequired();
        }

    }
}
