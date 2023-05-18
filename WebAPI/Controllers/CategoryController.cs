using Microsoft.AspNetCore.Mvc;
using EfcDataAccess.DaoInterfaces;
using Category = Domain.Models.Category;


namespace WebAPI.Controllers;


[ApiController]
[Route("[controller]")]


public class CategoryController : ControllerBase
{
    
    private ICategoryDao _categoryDao;
    public CategoryController(ICategoryDao categoryDao)
    {
        _categoryDao = categoryDao;
    }
    
    
    [HttpPost]
    [Route("uploadCategory")]
    public async Task<ActionResult<Category>> CreateAsync(Category category)
    {
        Console.WriteLine("Category received on the .net server");

        try
        {
            Category categoryx = await _categoryDao.CreateAsync(category);
            return Created($"/category/{categoryx.Id}", categoryx);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet]
    [Route("getCategories")]
    public async Task<ActionResult<List<Category>>> GetAllAsync()
    {
        Console.WriteLine("Categories received from .net server");
        try
        {
            List<Category> categories = await _categoryDao.GetAllAsync();
            return Ok(categories);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete]
    [Route("deleteCategory")]
    public async Task<ActionResult<Category>> DeleteAsync(Category category)
    {
        Console.WriteLine("Categories received from .net server");
        try
        {
            Category deletedcategory = await _categoryDao.DeleteAsync(category);
            return Ok(deletedcategory);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }


    [HttpDelete]
    [Route("deleteCategory")]

    public async Task<ActionResult<Category>> DeleteAsync(Category category)
    {
        Console.WriteLine("Category delete from .net");
        try
        {
            await _categoryDao.DeleteAsync(category);
            return Ok(category);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
        
        
    }


}