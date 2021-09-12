using Microsoft.EntityFrameworkCore;
using Phusion2.Domain.Models;

namespace Phusion2.Infra.Seed
{
    public static class ProfessionSeed
    {
        public static void SeedProfession(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profession>().HasData(
                new Profession(1, "Programmer"),
                new Profession(2, "Analyst"),
                new Profession(3, "Manager"),
                new Profession(4, "Intern"),
                new Profession(5, "QA"));
        }
    }
}
