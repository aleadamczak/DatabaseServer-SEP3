using System.Security.Cryptography.X509Certificates;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using File = Domain.Models.File;

namespace EfcDataAccess;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<PrivateFile> PrivateFiles { get; set; }

    // public DbSet<PrivateFileUser> PrivateFileUsers { get; set; }

    // public DbSet<PublicFile> Files { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/File.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<File>()
            .HasKey(publicFile => publicFile.Id);
        modelBuilder.Entity<File>()
            .HasOne(c => c.Category);
        modelBuilder.Entity<PrivateFile>().HasOne(pf => pf.UploadedBy);
        modelBuilder.Entity<PrivateFile>().HasMany(pf => pf.HaveAccess).WithMany(u =>
            u.SharedWithMe);
    }
}