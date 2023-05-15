using Domain.Models;
using EfcDataAccess;
using Microsoft.EntityFrameworkCore;
using File = Domain.Models.File;

public class MockDataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<File> Files { get; set; }
    public DbSet<Category> Categories { get; set; }

    public MockDataContext(DbContextOptions<MockDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<File>().HasKey(publicFile => publicFile.Id);
        modelBuilder.Entity<Category>().HasKey(category => category.Id);
    }
}

public class InMemoryDataContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("MockDb");
    }
}

public static class MockDbContextFactory
{
    public static InMemoryDataContext Create()
    {
        var context = new InMemoryDataContext();
        context.Database.EnsureCreated();

        return context;
    }
}