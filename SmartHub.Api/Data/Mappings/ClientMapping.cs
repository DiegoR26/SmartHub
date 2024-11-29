using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHub.Core.Models;

namespace SmartHub.Api.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            //Mapeamento da Table
            builder.ToTable("Client");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Cod)
                    .IsRequired(true)
                    .HasColumnType("TEXT")
                    .HasMaxLength(10);

            builder.Property(x => x.Name)
                   .IsRequired(true)
                   .HasColumnType("TEXT")
                   .HasMaxLength(60);

            builder.Property(x => x.Taxation)
                   .IsRequired(true)
                   .HasColumnType("TEXT")
                   .HasConversion<string>()
                   .HasMaxLength(20);

            builder.Property(x => x.CNPJ)
                   .IsRequired(true)
                   .HasColumnType("TEXT")
                   .HasMaxLength(14);

            builder.Property(x => x.IM)
                   .HasColumnType("TEXT")
                   .HasMaxLength(20);

            builder.Property(x => x.IE)
                   .HasColumnType("TEXT")
                   .HasMaxLength(20);

            builder.Property(x => x.City)
                   .IsRequired(true)
                   .HasColumnType("TEXT")
                   .HasMaxLength(50);

            builder.Property(x => x.Country)
                   .IsRequired(true)
                   .HasColumnType("TEXT")
                   .HasConversion<string>()
                   .HasMaxLength(50);

            builder.Property(x => x.DecPassword)
                   .HasColumnType("TEXT")
                   .HasMaxLength(30);

            builder.Property(x => x.Observations)
                   .HasColumnType("TEXT")
                   .HasMaxLength(500);

            builder.Property(x => x.SefazAccess)
                   .HasColumnType("TEXT")
                   .HasMaxLength(30);

            builder.Property(x => x.Email)
                   .HasColumnType("TEXT")
                   .HasMaxLength(100);

        }
    }
}


