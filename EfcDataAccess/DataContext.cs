using Domain.Models;
using Microsoft.EntityFrameworkCore;
using File = Domain.Models.File;

namespace EfcDataAccess;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<File> Files { get; set; }
    
    public DbSet<Category> Categories { get; set; }

    // public DbSet<PublicFile> Files { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/File.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<User>().HasKey(user => user.Id);
        // modelBuilder.Entity<PublicFile>().HasKey(publicFile => publicFile.Id);
    }
}