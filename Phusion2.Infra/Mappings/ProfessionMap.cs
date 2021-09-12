using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phusion2.Domain.Models;

namespace Phusion2.Infra.Mappings
{
    public class ProfessionMap : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
