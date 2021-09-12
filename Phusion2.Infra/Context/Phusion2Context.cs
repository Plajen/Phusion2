using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Phusion2.Domain.Models;
using Phusion2.Infra.Mappings;
using Phusion2.Infra.Seed;

namespace Phusion2.Infra.Context
{
    public sealed class Phusion2Context : DbContext
    {
        public IHostingEnvironment Environment { get; set; }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Profession> Profession { get; set; }

        public Phusion2Context(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new ProfessionMap());

            modelBuilder.SeedProfession();

            base.OnModelCreating(modelBuilder);
        }
    }
}
