﻿using Domain.DTOs;

namespace EfcDataAccess.DaoInterfaces;
using Domain.Models;
public interface IFileDao
{
    

    Task<File> CreateAsync(File file);
    

    Task<File> GetAsync(int fileId);
    
    Task<List<File>> GetAllFilesAsync();

    Task<List<GetAllFilesDto>> GetAllFileDtosAsync();
}