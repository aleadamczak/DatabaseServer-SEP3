using Domain.DTOs;
using Domain.Models;
using EfcDataAccess;
using EfcDataAccess.DaoInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        Console.WriteLine(file.UploadedBy.Id);
        User? existing = await context.Users.FindAsync(file.UploadedBy.Id);
        if (existing != null) file.UploadedBy = existing;
        Category? existingC = await context.Categories.FindAsync(file.Category.Name);
        if (existingC != null) file.Category = existingC;
        EntityEntry<File> newFile = await context.Files.AddAsync(file);
        await context.SaveChangesAsync();
        return newFile.Entity;
    }

    public async Task<FileDownloadDto> GetAsync(int fileId)
    {
        try
        {
            File getFile = await context.Files.FindAsync(fileId);

            FileDownloadDto downloadFile = new FileDownloadDto(getFile.Title, getFile.bytes, getFile.ContentType);
            return downloadFile;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }

    }
    
    public async Task<List<File>> GetAllFilesAsync()
    {
        return await context.Files.ToListAsync();
    }

    public async Task<List<GetAllFilesDto>> GetAllFileDtosAsync()
    {
        return await context.Files
            .Select(f => new GetAllFilesDto (
                f.Id, f.Title, f.Description, f.Category, f.ContentType,f. UploadedBy))
            .ToListAsync();
    }

    public async Task<File?> Delete(int id)
    {
        File? file = context.Files.FindAsync(id).Result;
        File? toBeDeleted = null;
        if (file != null)
        {
            toBeDeleted = context.Files.Remove(file).Entity;
            await context.SaveChangesAsync();
        }
        return toBeDeleted;
    }
}