using FullStackAPI_AI.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullStackAPI_AI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<PersonProfile> PersonProfiles { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<UserTitle> UserTitles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
