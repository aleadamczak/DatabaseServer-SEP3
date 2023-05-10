using Domain.Models;
using EfcDataAccess;
using EfcDataAccess.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using File = Domain.Models.File;



public class FileEfcDao : IFileDao
{
    
    private readonly DataContext context;

    public FileEfcDao(DataContext context)
    {
        this.context = context;
    }
    
    public async Task<File> CreateAsync(File file)
    {
        // var newF = file;
        // newF.bytestream = file.GetBytesFromIBrowserFile(file.file);
        EntityEntry<File> newFile = await context.Files.AddAsync(file);
        await context.SaveChangesAsync();
        return newFile.Entity;
    }

    public async Task<File> GetAsync(int fileId)
    {

        File getFile = await context.Files.FindAsync(fileId);
        return getFile;

    }

    
}