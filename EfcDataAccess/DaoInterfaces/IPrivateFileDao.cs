using Domain.DTOs;
using Domain.Models;

namespace EfcDataAccess.DaoInterfaces;

public interface IPrivateFileDao
{
    Task<PrivateFile> CreateAsync(PrivateFileCreationDto file);
    Task<List<PrivateFileDisplayDto>> GetSharedWithUser(int id);
    Task<FileDownloadDto> GetAsync(int id);
    Task<PrivateFile?> Delete(int id);
}