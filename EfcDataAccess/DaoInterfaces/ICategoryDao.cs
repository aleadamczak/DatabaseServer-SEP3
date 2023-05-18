using Domain.Models;
using File = System.IO.File;

namespace EfcDataAccess.DaoInterfaces;

public interface ICategoryDao
{
    Task<Category> CreateAsync(Category category);

    Task<List<Category>> GetAllAsync();

    Task<Category> DeleteAsync(Category category);
}