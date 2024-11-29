using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHub.Core.Models;

namespace SmartHub.Api.Data.Mappings
{
    public class DeclarationMapping : IEntityTypeConfiguration<Declaration>
    {
        public void Configure(EntityTypeBuilder<Declaration> builder)
        {

            builder.ToTable("Declaration");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                    .IsRequired(true)
                    .HasColumnType("TEXT")
                    .HasConversion<string>()
                    .HasMaxLength(60);

            builder.Property(x => x.Competence)
                   .IsRequired(true)
                   .HasColumnType("DATE");

            builder.Property(x => x.Situation)
                   .IsRequired(true)
                   .HasColumnType("TEXT")
                   .HasMaxLength(20);

            builder.Property(x => x.IsActive)
                   .IsRequired(true)
                   .HasColumnType("BOOLEAN");

            builder.HasOne(d => d.Client)
                   .WithMany(c => c.Declarations)
                   .HasForeignKey(d => d.ClientId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasIndex(d => new { d.ClientId, d.Competence })
                   .IsUnique()
                   .HasDatabaseName("IX_Declaration_Client_Competence");


        }
    }
}


