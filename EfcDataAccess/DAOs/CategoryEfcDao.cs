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

    public async Task<List<Category>> GetAllAsync()
    {
       
        return await context.Categories.ToListAsync();
    }
    
    public async Task<Category> DeleteAsync(Category category) 
    {
        Category existing = await context.Categories.FindAsync(category.Name);
        Category toBeDeleted = null;

        if (existing != null)
        {
            toBeDeleted = context.Categories.Remove(existing).Entity;
            await context.SaveChangesAsync();
        }

        return toBeDeleted;

    }
    



}