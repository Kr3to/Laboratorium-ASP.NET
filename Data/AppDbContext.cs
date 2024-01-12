using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; }
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
                new ReservationEntity() { Id = 1, Date = new DateTime(2000, 10, 10), City = "Los Angeles", Address = "Downtown 12t", Room = "Deluxe", Owner = "Angeles INC", Price = "1000$"},
                new ReservationEntity() { Id = 2, Date = new DateTime(2000, 10, 10), City = "Tijuana", Address = "Mexican Boulevard 56st", Room = "Economic", Owner = "New Mexico hotels ", Price = "240$"}
            );
        }
    }
}
