using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP_Parcial
{
    class TareasDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=tpparcial.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("User");
                u.Property(p => p.Id).HasColumnName("Id");
                u.Property(p => p.Name).HasColumnName("Name").HasColumnType("varchar(50)");
                u.Property(p => p.LastName).HasColumnName("Lastname").HasColumnType("varchar(50)");
                u.Property(p => p.Password).HasColumnName("Password").HasColumnType("varchar(20)");

            });


            modelBuilder.Entity<Task>(t =>
            {
                t.ToTable("Task");
                t.Property(p => p.Id).HasColumnName("Id");
                t.Property(p => p.Title).HasColumnName("Name").HasColumnType("varchar(50)");
                t.Property(p => p.Expiration).HasColumnName("Expiration").HasColumnType("datetime");
                t.Property(p => p.Estimate).HasColumnName("Estimate").HasColumnType("varchar(20)");
                t.Property(p => p.State).HasColumnName("State").HasColumnType("varchar(20)");
                //t.Property(p => p.Liable).HasColumnName("ResourceId").HasColumnType("integer");


            });

            modelBuilder.Entity<Resource>(r =>
            {
                r.ToTable("Resource");
                r.Property(p => p.Id).HasColumnName("Id");
                r.Property(p => p.Name).HasColumnName("Name").HasColumnType("varchar(50)");
                //r.Property(p => p.user).HasColumnName("UserId").HasColumnType("integer");

            });

            modelBuilder.Entity<Detail>(r =>
            {
                r.ToTable("Detail");
                r.Property(p => p.Id).HasColumnName("Id");
                r.Property(p => p.Date).HasColumnName("Date").HasColumnType("datetime");
                r.Property(p => p.Time).HasColumnName("time").HasColumnType("integer");
                //r.Property(p => p.Resource).HasColumnName("ResourceId").HasColumnType("integer");
                //r.Property(p => p.Task).HasColumnName("TaskId").HasColumnType("integer");
            });



        }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Detail> Details { get; set; }
    }
}
