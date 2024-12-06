using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartHub.Core.Models;

namespace SmartHub.Api.Data.Mappings
{
    public class AssociationMapping : IEntityTypeConfiguration<Association>
    {
        public void Configure(EntityTypeBuilder<Association> builder)
        {

            builder.ToTable("Association");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                    .IsRequired(true)
                    .HasColumnType("TEXT")
                    .HasConversion<string>()
                    .HasMaxLength(60);

            builder.HasOne(d => d.Client)
                   .WithMany(c => c.Associations)
                   .HasForeignKey(d => d.ClientId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => new { x.ClientId, x.Type })
                   .IsUnique()
                   .HasDatabaseName("IX_DeclarationTemplate_Client_Type");

        }
    }
}


