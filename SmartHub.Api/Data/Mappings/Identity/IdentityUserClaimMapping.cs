﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartHub.Api.Data.Mappings.Identity
{
    public class IdentityUserClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> builder)
        {
            builder.ToTable("IdentityUserClaim");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ClaimType).HasMaxLength(255);
            builder.Property(x => x.ClaimValue).HasMaxLength(255);
        }
    }
}
