namespace EfcDataAccess.DaoInterfaces;
using Domain.Models;
public interface IFileDao
{
    
    Task<File> CreateAsync(File user);

    Task<File> GetAsync(int fileId);

}