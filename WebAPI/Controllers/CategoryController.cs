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


}