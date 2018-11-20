using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//this class is for entity framework instrcutions
namespace ProductCatalogAPI.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<CatalogEventType> CatalogEventTypes {get; set;}
        public DbSet<CatalogEventCategory> CatalogEventCategories  { get; set; }
        public DbSet<CatalogEventLocation> CatalogEventLocations { get; set; }
        public DbSet<CatalogEventItem> CatalogEventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogEventCategory>(ConfigureCatalogEventCategory);
            modelBuilder.Entity<CatalogEventType>(ConfigureCatalogEventType);
            modelBuilder.Entity<CatalogEventLocation>(ConfigureCatalogEventLocation);
            modelBuilder.Entity<CatalogEventItem>(ConfigureCatalogEventItem);
        }

        private void ConfigureCatalogEventType(EntityTypeBuilder<CatalogEventType> builder)
        {
            builder.ToTable("CatalogEventType");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("catalog_type_hilo");
            builder.Property(c => c.Type).IsRequired().HasMaxLength(100);
        }
        private void ConfigureCatalogEventCategory(EntityTypeBuilder<CatalogEventCategory> builder)
        {
            builder.ToTable("CatalogEventCategory");        
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("catalog_category_hilo");
            builder.Property(c => c.Category).IsRequired().HasMaxLength(100);
        }
        private void ConfigureCatalogEventLocation(EntityTypeBuilder<CatalogEventLocation> builder)
        {
            builder.ToTable("CatalogEventLocation");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("catalog_location_hilo");
            builder.Property(c => c.Location).IsRequired().HasMaxLength(100);
        }
        private void ConfigureCatalogEventItem(EntityTypeBuilder<CatalogEventItem> builder)
        {
            builder.ToTable("CatalogEventItem");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("catalog_hilo");
            builder.Property(c => c.Name).IsRequired().HasMaxLength(5000);
            builder.Property(c => c.Schedule).IsRequired();
            builder.Property(c => c.Price).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(5000);
            builder.Property(c => c.PictureUrl).HasMaxLength(100);

            //building relationships
            builder.HasOne(c => c.CatalogEventCategory).WithMany().HasForeignKey(c => c.CatalogCategoryId);
            builder.HasOne(c => c.CatalogEventType).WithMany().HasForeignKey(c => c.CatalogTypeId);
            builder.HasOne(c => c.CatalogEventLocation).WithMany().HasForeignKey(c => c.CatalogLocationId);
            
        }

    }
}
