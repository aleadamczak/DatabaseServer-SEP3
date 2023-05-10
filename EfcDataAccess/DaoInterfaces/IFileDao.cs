namespace EfcDataAccess.DaoInterfaces;
using Domain.Models;
public interface IFileDao
{
    
<<<<<<< HEAD
    Task<File> CreateAsync(File file);
    
=======
    Task<File> CreateAsync(File user);

    Task<File> GetAsync(int fileId);

>>>>>>> master
}