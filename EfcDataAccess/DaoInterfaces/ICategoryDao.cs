using Domain.Models;
using File = System.IO.File;

namespace EfcDataAccess.DaoInterfaces;

public interface ICategoryDao
{
    Task<Category> CreateAsync(Category category);
}