using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Domain.Entities;

namespace Tours.Infrastructure
{
    public class ToursDbContext : DbContext
    {
        public ToursDbContext(DbContextOptions<ToursDbContext> options) : base(options)
        {
        }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Mountain> Mountains { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Mountain>().HasKey(x => x.Id);
            modelBuilder.Entity<Tour>().HasOne(x => x.Mountain).WithMany(x => x.Tours).HasForeignKey(x => x.MountainId).IsRequired();
            modelBuilder.Entity<Tour>().OwnsOne(x => x.HikerRange, h =>
            {
                h.Property<int>(hr => hr.MaxNumberOfPeople).HasColumnName("NaxNumberOfPeople");
                h.Property<int>(hr => hr.MinNumberOfPeople).HasColumnName("MinNumberOfPeople");
                h.Property<int>(hr => hr.NumberOfRegisteredPeople).HasColumnName("NumberOfRegisteredPeople");
                h.Property<Guid>("TourId");
            });
        }
    }
}