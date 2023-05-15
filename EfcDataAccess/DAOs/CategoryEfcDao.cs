using EfcDataAccess.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Category = Domain.Models.Category;

namespace EfcDataAccess.DAOs;

public class CategoryEfcDao : ICategoryDao
{
    
    private readonly DataContext context;

    public CategoryEfcDao(DataContext context)
    {
        this.context = context;
    }
    
    public async Task<Category> CreateAsync(Category category)
    {
        
        EntityEntry<Category> newcategory = await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
        return newcategory.Entity;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await context.Categories.ToListAsync();
    }

}