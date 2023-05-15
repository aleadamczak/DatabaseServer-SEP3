using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using EfcDataAccess.DaoInterfaces;
using File = Domain.Models.File;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FileController : ControllerBase
{
    private IFileDao fileDao;

    public FileController(IFileDao fileDao)
    {
        this.fileDao = fileDao; 
    }


    [HttpPost]
    [Route ("uploadFile")]
    public async Task<ActionResult<File>> CreateAsync(FileCreationDto dto)
    {
        Console.WriteLine("File received on the .net server");
        try
        {
           
            Console.WriteLine(dto.Title);
            Console.WriteLine(dto.Description);
            Console.WriteLine(dto.Category);
            Console.WriteLine(dto.UploadedBy.Id);
            var tobeStored = new File()
            {
                Title = dto.Title,
                Description = dto.Description,
                Category = dto.Category,
                UploadedBy = dto.UploadedBy,
                bytes = dto.bytes
            };
            File newFile = await fileDao.CreateAsync(tobeStored);
            return Created($"/file/{newFile.Id}", newFile);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("downloadFile")]
    public async Task<ActionResult<File>> GetAsync([FromQuery] int fileId)
    {
        try
        {
            File getFile = await fileDao.GetAsync(fileId);
            Console.WriteLine("The send file: " + getFile.Title + " " + getFile.Description);

            return getFile;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("getAllFiles")]
    public async Task<ActionResult<IEnumerable<File>>> GetAllFilesAsync()
    {
        Console.WriteLine("Files received from .net server");
        try
        {
            IEnumerable<File> files = await fileDao.GetAllFilesAsync();
            return Ok(files.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("getAllFileDtos")]
    public async Task<ActionResult<IEnumerable<GetAllFilesDto>>> GetAllFileDtosAsync()
    {
        Console.WriteLine("File DTOs received from .net server");
        try
        {
            IEnumerable<GetAllFilesDto> files = await fileDao.GetAllFileDtosAsync();
            return Ok(files.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}