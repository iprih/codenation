using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder.HasMany(x => x.Submissions).WithOne(x => x.Challenge).IsRequired();
            builder.HasMany(x => x.Accelerations).WithOne(x => x.Challenge).IsRequired();
        }

    }
}
