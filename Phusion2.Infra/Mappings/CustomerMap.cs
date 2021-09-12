using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phusion2.Domain.Models;

namespace Phusion2.Infra.Mappings
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.CPF)
                .HasColumnType("varchar(11)")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(c => c.DateOfBirth)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Age)
                .IsRequired();

            builder.Property(c => c.ProfessionId);

            // References

            builder.HasOne(c => c.Profession)
                .WithMany()
                .HasForeignKey(c => c.ProfessionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
