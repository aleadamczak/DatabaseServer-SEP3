using System.Net;
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
    public async Task<ActionResult<File>> CreateAsync(File file)
    {
        Console.WriteLine("File received on the .net server");
        try
        {
           
            Console.WriteLine(file.Title);
            Console.WriteLine(file.Description);
            Console.WriteLine(file.Category);
            Console.WriteLine(file.UploadedBy.Id);
            Console.WriteLine(file.ContentType);
            File newFile = await fileDao.CreateAsync(file);
            return Created($"/file/{file.Id}", newFile);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("downloadFile")]
    public async Task<ActionResult<FileDownloadDto>> GetAsync([FromQuery] int fileId)
    {
        try
        {
            FileDownloadDto downloadFile = await fileDao.GetAsync(fileId);
            Console.WriteLine("The send file: " + downloadFile.Title);

            return downloadFile;

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

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<File?>> Delete(int id)
    {
        try
        {
            File? toBeDeleted = await fileDao.Delete(id);
            return Ok(toBeDeleted);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }

    [HttpPut]
    [Route("uncategorize/{id}")]

    public async Task<ActionResult<File?>> Update(int id)
    {
        try
        {
            File? toBeUpdated = await fileDao.UpdateAsync(id);
            return Ok(toBeUpdated);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

}