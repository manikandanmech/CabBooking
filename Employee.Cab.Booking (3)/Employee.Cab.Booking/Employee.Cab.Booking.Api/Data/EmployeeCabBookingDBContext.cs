using Employee.Cab.Booking.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee.Cab.Booking.Api.Data
{
    public class EmployeeCabBookingDBContext: DbContext
    {
        public EmployeeCabBookingDBContext(DbContextOptions<EmployeeCabBookingDBContext> options)
               : base(options) { }

           public DbSet<Model.Employee> Employee { get; set; }
           public DbSet<Model.CabAllotment> CabAllotments { get; set; }
           public DbSet<Model.Cab> Cab { get; set; }
          public DbSet<Model.Driver> Driver { get; set; }

        public DbSet<Model.Requests> Requests { get; set; }

        public DbSet<Model.RequestStatus> RequestStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CabAllotment>()
    .HasOne(ca => ca.CabDetail)
    .WithMany(c => c.CabAllotments)
    .HasForeignKey(ca => ca.CabId);

            modelBuilder.Entity<CabAllotment>()
                .HasOne(ca => ca.Request)
                .WithMany() // No navigation property needed here
                .HasForeignKey(ca => ca.RequestId);

            modelBuilder.Entity<Driver>()
                .HasOne(d => d.CabDetail)
                .WithMany(c => c.Drivers)
                .HasForeignKey(d => d.CabId);

            modelBuilder.Entity<Requests>()
                .HasOne(r => r.Employee)
                .WithMany(e => e.Requests)
                .HasForeignKey(r => r.EmpId);

            modelBuilder.Entity<Requests>()
     .HasOne(r => r.RequestStatus)
     .WithMany() // No navigation property needed here
     .HasForeignKey(r => r.RequestStatusId);

            modelBuilder.Entity<Model.Employee>()
    .HasMany(e => e.Requests)
    .WithOne(r => r.Employee)
    .HasForeignKey(r => r.EmpId);
        }
    }
}

