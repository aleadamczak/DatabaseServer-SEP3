﻿using Microsoft.AspNetCore.Mvc;
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

}