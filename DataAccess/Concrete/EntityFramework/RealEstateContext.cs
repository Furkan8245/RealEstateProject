using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context:Db tabloları ile proje classlarını bağlamak
    public class RealEstateContext:DbContext
    {
        public RealEstateContext(DbContextOptions<RealEstateContext> options):base(options) 
        {
        }
        public RealEstateContext()
        {
        }

        public DbSet<RealEstate> RealEstates { get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<PropertyType> PropertyTypes{ get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<AreaAnalysis> AreaAnalyses{ get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=ReDatabase;Username=postgres;Password=1905", d => d.UseNetTopologySuite());
            }
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("postgis");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<RealEstate>().ToTable("realestates");
            modelBuilder.Entity<City>().ToTable("cities");
            modelBuilder.Entity<District>().ToTable("districts");
            modelBuilder.Entity<PropertyType>().ToTable("propertytypes");
            modelBuilder.Entity<Neighborhood>().ToTable("neighborhoods");
            modelBuilder.Entity<OperationClaim>().ToTable("operationclaims");
            modelBuilder.Entity<UserOperationClaim>().ToTable("useroperationclaims");
            modelBuilder.Entity<AreaAnalysis>().ToTable("areaanalyses");

            modelBuilder.Entity<User>(entity =>
            {
                
                entity.Property(u => u.PasswordHash).HasColumnType("bytea");
                entity.Property(u => u.PasswordSalt).HasColumnType("bytea");
            });
            modelBuilder.Entity<AreaAnalysis>(entity =>
            {
                entity.ToTable("areaanalyses");
                entity.Property(e => e.Geometry).HasColumnType("geometry(Geometry,4326)");
            }); 

            modelBuilder.Entity<RealEstate>(entity =>
            {
                entity.ToTable("realestates");
                entity.Property(e => e.Location).HasColumnType("geometry(Point,4326)");
            });


        }
    }
}
