using EventListAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventListAPI.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<EventTopic> EventTopics { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventTopic>(ConfigureEventTopic);
            modelBuilder.Entity<EventType>(ConfigureEventType);
            modelBuilder.Entity<EventItem>(ConfigureEventItem);
        }

        public void ConfigureEventType(EntityTypeBuilder<EventType> builder)
        {
            builder.ToTable("EventType");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_type_hilo");
            builder.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(200);

        }
        public void ConfigureEventTopic(EntityTypeBuilder<EventTopic> builder)
        {
            builder.ToTable("EventTopic");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_topic_hilo");
            builder.Property(c => c.Topic)
                .IsRequired()
                .HasMaxLength(200);

        }

        public void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
            builder.ToTable("Event");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_hilo");
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(c => c.StartDate)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.EndDate)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Price)
                .IsRequired();

            builder.HasOne(c => c.EventType)
                .WithMany()
                .HasForeignKey(c => c.EventTypeId);
            builder.HasOne(c => c.EventTopic)
                .WithMany()
                .HasForeignKey(c => c.EventTopicId);

        }
    }
}
