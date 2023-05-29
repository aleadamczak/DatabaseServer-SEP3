using Domain.DTOs;
using Domain.Models;
using EfcDataAccess.DaoInterfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using File = System.IO.File;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PrivateFileController : ControllerBase
{
    private readonly IPrivateFileDao _privateFileDao;

    public PrivateFileController(IPrivateFileDao privateFileDao)
    {
        _privateFileDao= privateFileDao;
    }
    
    [HttpPost]
    [Route ("uploadFile")]
    public async Task<ActionResult<PrivateFile>> CreateAsync(PrivateFileCreationDto file)
    {
        Console.WriteLine("File received on the .net server");
        try
        {
            PrivateFile newFile = await _privateFileDao.CreateAsync(file);
            return Created($"/file/{newFile.Id}", newFile);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("getSharedWithMe/{id}")]

    public async Task<ActionResult<List<PrivateFileDisplayDto>>> GetSharedWithAsync(int id)
    {
        
        try
        {
            List<PrivateFileDisplayDto> privateFiles = await _privateFileDao.GetSharedWithUser(id);
            return Ok(privateFiles);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
        
    }
    
    [HttpGet]
    [Route("downloadPrivateFile")]
    public async Task<ActionResult<FileDownloadDto>> GetAsync([FromQuery] int fileId)
    {
        try
        {
            FileDownloadDto downloadFile = await _privateFileDao.GetAsync(fileId);
            Console.WriteLine("The send file: " + downloadFile.Title);

            return downloadFile;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<PrivateFile?>> Delete(int id)
    {
        try
        {
            PrivateFile? toBeDeleted = await _privateFileDao.Delete(id);
            return Ok(toBeDeleted);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }

}