using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tours.Domain.Entities;
using Tours.Domain.ValueObjects;

namespace Tours.Infrastructure
{
    public class ToursDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Tour> Tours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tour>().HasKey(x => x.TourId);
            modelBuilder.Entity<Tour>().HasOne(x => x.Mountain).WithMany(x => x.Tours).HasForeignKey(x => x.TourId).HasPrincipalKey(x => x.Id);
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
