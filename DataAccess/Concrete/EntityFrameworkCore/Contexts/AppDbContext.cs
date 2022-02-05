using Core.EntityLayer.Concrete.AuthorizationEntities;
using DataAccess.Configurations;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StockApiDb;Trusted_Connection=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.Entity<ProductMovement>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<ProductMovement>().HasKey(x => x.Id);

            modelBuilder.Entity<OperationClaim>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<OperationClaim>().HasKey(x => x.Id);
        }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MovementType> MovementTypes { get; set; }
        public DbSet<ProductMovement> ProductMovements { get; set; }
        public DbSet<User>  Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}
