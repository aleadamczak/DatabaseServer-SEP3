using System.Diagnostics;
using Domain.DTOs;
using Domain.Models;
using EfcDataAccess.DaoInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using File = Domain.Models.File;

namespace EfcDataAccess.DAOs;

public class PrivateFileEfcDao : IPrivateFileDao
{
    
    private readonly DataContext context;

    public PrivateFileEfcDao(DataContext context)
    {
        this.context = context;
    }
    
    
    public async Task<PrivateFile> CreateAsync(PrivateFileCreationDto file)
    {
        User? existing = await context.Users.FindAsync(file.UploadedBy.Id);
        if (existing != null) file.UploadedBy = existing;
        List<User> haveAccessFromClient = file.HaveAccess;
        List<User> HaveAccessFromDatabase = new List<User>();
        foreach (var us in haveAccessFromClient)
        {
            HaveAccessFromDatabase.Add(await context.Users.FindAsync(us.Id));
        }

        file.HaveAccess = HaveAccessFromDatabase;
        var privateFile = new PrivateFile()
        {
            Title = file.Title,
            UploadedBy = file.UploadedBy,
            bytes = file.bytes,
            HaveAccess = file.HaveAccess,
            ContentType = file.ContentType

        };
        EntityEntry<PrivateFile> newFile = await context.PrivateFiles.AddAsync(privateFile);
        await context.SaveChangesAsync();
        // foreach (User variablUser in file.HaveAccess)
        // {
        //     PrivateFileUser privateFileUser = new PrivateFileUser()
        //     {
        //         HaveAccessId = variablUser.Id,
        //         SharedWithMeId = newFile.Entity.Id
        //     };
        //     EntityEntry<PrivateFileUser> entry = await context.PrivateFileUsers.AddAsync(privateFileUser);
        //     await context.SaveChangesAsync();
        // }
        return newFile.Entity;
    }

    public async Task<List<PrivateFileDisplayDto>> GetSharedWithUser(int id)
    {
       List<PrivateFile> privateFiles =  await context.Users
            .Where(u => u.Id == id)
            .SelectMany(u => u.SharedWithMe)
            .ToListAsync();

       List<PrivateFileDisplayDto> privateFileDisplayDtos = new List<PrivateFileDisplayDto>();
       foreach (PrivateFile pf in privateFiles)
       {
           privateFileDisplayDtos.Add(new PrivateFileDisplayDto()
           {
               Title = pf.Title,
               ContentType = pf.ContentType,
               id =pf.Id,
           });
       }

       return privateFileDisplayDtos;

    }
}