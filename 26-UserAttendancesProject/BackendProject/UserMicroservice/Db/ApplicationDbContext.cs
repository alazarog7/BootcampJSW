using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroservice.Entities;

namespace UserMicroservice.Db
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData( new User { 
                Id = 1,
                Nickname = "pedro7",
                Password = "123",
                Name = "Pedro",
                LastName = "Perez",
                TotalAttendance = 0,
                BirthDate = new DateTime(2001,10,1)
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                Nickname = "maria7",
                Password = "123",
                Name = "Maria",
                LastName = "Perez",
                TotalAttendance = 0,
                BirthDate = new DateTime(2001, 12, 1)
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                Nickname = "gabriela7",
                Password = "123",
                Name = "Gabriela",
                LastName = "Perez",
                TotalAttendance = 0,
                BirthDate = new DateTime(2001, 11, 1)
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                Nickname = "galia7",
                Password = "123",
                Name = "Galia",
                LastName = "Perez",
                TotalAttendance = 0,
                BirthDate = new DateTime(2001, 9, 1)
            });
        }

    }
}
