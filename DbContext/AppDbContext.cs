using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SampleTest
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Code to seed data
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
               optionsBuilder.UseNpgsql("Host=localhost;Database=testSample;Port=5432;Username=postgress;Password=P@ssw0rd!23");//WILL GET IT FROM ENV
        }
      
    }
}
