using Airbnb.Core.Domain.Common;
using Airbnb.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Airbnb.Infrastructure.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Airbnbs> Airbnbs { get; set; }

        public DbSet<Tipo> Tipos { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreateBy = "The young king";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = DateTime.Now;
                        entry.Entity.LastModifiedBy = "The young king 007";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables
            modelBuilder.Entity<Airbnbs>()
                .ToTable("Airbnbs");

            modelBuilder.Entity<Tipo>()
                .ToTable("Tipos");

            #endregion


            #region Primary Key
            modelBuilder.Entity<Airbnbs>()
                .HasKey(airbnb => airbnb.Id);

            modelBuilder.Entity<Tipo>()
                .HasKey(tipo => tipo.Id);

            #endregion


            #region "Relationships"

            modelBuilder.Entity<Tipo>()
                .HasMany<Airbnbs>(tipo => tipo.Airbnb)
                .WithOne(airbnb => airbnb.Tipo)
                .HasForeignKey(airbnb => airbnb.TipoId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region "Property Configuration"

            #region "Product"
            modelBuilder.Entity<Airbnbs>()
                .Property(airbnb => airbnb.Name)
                .IsRequired();

            modelBuilder.Entity<Airbnbs>()
                .Property(airbnb => airbnb.Description)
                .IsRequired();

            modelBuilder.Entity<Airbnbs>()
                .Property(airbnb => airbnb.Ubication)
                .IsRequired();

            modelBuilder.Entity<Airbnbs>()
                .Property(airbnb => airbnb.UrlImg)
                .IsRequired();

            modelBuilder.Entity<Airbnbs>()
                .Property(airbnb => airbnb.UrlImg)
                .IsRequired();

            #endregion

            #region "Category"
            modelBuilder.Entity<Tipo>()
                .Property(tipo => tipo.Name)
                .IsRequired();

            modelBuilder.Entity<Tipo>()
                .Property(tipo => tipo.Description)
                .IsRequired();

            #endregion


            #endregion

        }
    }
}
