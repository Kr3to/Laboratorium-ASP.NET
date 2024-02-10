using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    { 
        public DbSet<ReservationEntity> Reservations { get; set; }
        private string DbPath { get; set; } 
        public AppDbContext() 
        { 
            var folder = Environment.SpecialFolder.LocalApplicationData; 
            var path = Environment.GetFolderPath(folder); 
            DbPath = System.IO.Path.Join(path, "reservations.db"); 
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationEntity>().HasData(
                new ReservationEntity() { Id = 1, Date=new DateTime(2015, 11, 21), City="New York", Address="Brooklyn 43 avenue", Room="Standard", Owner="Rooms inc", Price="1200"},
                new ReservationEntity() { Id = 2, Date=new DateTime(2016, 11, 21), City="San Francisco", Address="Twin Peaks 4 ", Room="Deluxe", Owner="Rooms inc", Price="1650"}
            );
            base.OnModelCreating(modelBuilder);
            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();

            // dodanie roli administratora
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });

            // Dodanie roli użytkownika
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = USER_ROLE_ID,
                Name = "user",
                NormalizedName = "USER",
                ConcurrencyStamp = USER_ROLE_ID
            });

            // haszowanie hasła
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

            // utworzenie administratora jako użytkownika
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "admin@example.com",
                EmailConfirmed = true,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                PasswordHash = ph.HashPassword(null, "1234Abcd!"),
            };


            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);
            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });

            // Dodanie drugiego użytkownika
            var user = new IdentityUser
            {
                Id = USER_ID,
                Email = "user@example.com",
                EmailConfirmed = true,
                UserName = "userexample",
                NormalizedUserName = "USEREXAMPLE",
                NormalizedEmail = "USER@EXAMPLE.COM",
                PasswordHash = ph.HashPassword(null, "user123PASSW!@#")
            };

            modelBuilder.Entity<IdentityUser>().HasData(user);

            // Przypisanie roli USER drugiemu użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = USER_ID
            });

        }
    } 
}
