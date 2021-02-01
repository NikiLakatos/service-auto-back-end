using Microsoft.EntityFrameworkCore;
using ServiceAutoApp.Models;


namespace ServiceAutoApp.DataRepo
{
    public class ServiceAutoContext : DbContext
    {

  
        public ServiceAutoContext(DbContextOptions<ServiceAutoContext> options) : base(options)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<VisitModel> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SA");

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.Property(u => u.Id).ValueGeneratedOnAdd()
                        .UseIdentityColumn().IsUnicode().IsRequired();
                entity.Property(u => u.UserName).IsRequired();
                entity.Property(u => u.Password).IsRequired();
                entity.Property(u => u.UserRole).IsRequired();
            });
            modelBuilder.Entity<ClientModel>()
                .HasOne(c => c.User)
                .WithMany(c => c.Clients)
                .HasForeignKey(c => c.UserId).IsRequired();

            modelBuilder.Entity<ClientModel>(entity =>
            {
                entity.Property(cl => cl.Id).ValueGeneratedOnAdd()
                       .UseIdentityColumn().IsUnicode().IsRequired();
                entity.Property(cl => cl.ClientName).IsRequired();
                entity.Property(cl => cl.Cnp).IsRequired();
                entity.Property(cl => cl.DateOfBirth).IsRequired();
                entity.Property(cl => cl.PhoneNumber).IsRequired();
                entity.Property(cl => cl.Address).IsRequired();
                entity.Property(cl => cl.UserId).IsRequired();


            });

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.Property(c => c.Id).ValueGeneratedOnAdd()
                        .UseIdentityColumn().IsUnicode().IsRequired();
                entity.Property(c => c.Brand).IsRequired();
                entity.Property(c => c.Model).IsRequired();
                entity.Property(c => c.DateOfBirthCar).IsRequired();
                entity.Property(c => c.FuelType).IsRequired();
                entity.Property(c => c.HorsesPower).IsRequired();
                entity.Property(c => c.ClientId).IsRequired();

            });

            modelBuilder.Entity<CarModel>().HasOne(c => c.Client)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.ClientId).IsRequired();

            modelBuilder.Entity<VisitModel>(entity =>
            {
                entity.Property(v => v.Id).ValueGeneratedOnAdd()
                           .UseIdentityColumn().IsUnicode().IsRequired();
                entity.Property(v => v.Cost).IsRequired().HasColumnType<decimal>("decimal(5,2)");
                entity.Property(v => v.DateOfVisit).IsRequired();
                entity.Property(v => v.Issues).IsRequired();
                entity.Property(v => v.CarId).IsRequired();
                entity.Property(v => v.ClientId).IsRequired(); 

            });
            modelBuilder.Entity<VisitModel>().HasOne(v => v.Car).WithMany(v => v.Visits).HasForeignKey(v => v.CarId).IsRequired();
            modelBuilder.Entity<VisitModel>().HasOne(v => v.Client).WithMany(v => v.Visits).HasForeignKey(v => v.ClientId).OnDelete(DeleteBehavior.NoAction).IsRequired();

        }
        
    }
}
