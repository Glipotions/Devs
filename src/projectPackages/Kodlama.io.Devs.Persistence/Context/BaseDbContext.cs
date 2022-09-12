using Kodlama.io.Devs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Kodlama.io.Devs.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }

        #region DbSets
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }
        #endregion

        #region Constructures
        public BaseDbContext()
        {
        }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        #endregion


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LanguageProjectConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(a =>
            {
                a.ToTable("Languages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.LanguageTechnologies);
            });


            modelBuilder.Entity<LanguageTechnology>(a =>
            {
                a.ToTable("Models").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.LanguageId).HasColumnName("LanguageId");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.Language);

            });
        }
    }
}
