using Domain.DTOs;
using Domain.Models;
using EfcDataAccess;
using File = Domain.Models.File;

namespace UnitTests;

public class FileTests
{
    private DataContext context;
    private FileEfcDao fileEfcDao;
    [SetUp]
    public void Setup()
    {
       context = MockDbContextFactory.Create();
       fileEfcDao = new FileEfcDao(context);
       
       // Clearing File database
       foreach (var file in context.Files)
       {
           context.Files.Remove(file);
       }
       context.SaveChanges();
       
       // Clearing User database
       foreach (var user in context.Users)
       {
           context.Users.Remove(user);
       }
       context.SaveChanges();
    }

    [Test]
    public async Task ZeroGetAllFilesAsyncTest()
    {
        var files = await fileEfcDao.GetAllFilesAsync();
        Assert.IsNotNull(files);
        Assert.AreEqual(0, files.Count);
    }

    [Test]
    public async Task OneCreateAsyncTest()
    {
        var user = new User { Id = 1, Name = "John Doe" , Username = "Johny", Password = "whatever", isAdmin = false};
        var file = new File("TestTitle", "TestDescription", "TestCategory", user, Array.Empty<byte>());
        
        var result = await fileEfcDao.CreateAsync(file);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(file.Id, result.Id);
        Assert.AreEqual(file.Title, result.Title);
        Assert.AreEqual(file.Description, result.Description);
        Assert.AreEqual(file.Category, result.Category);
        Assert.AreEqual(file.bytes, result.bytes);

        Assert.AreEqual(user.Id, result.UploadedBy.Id);
        Assert.AreEqual(user.Name, result.UploadedBy.Name);
        Assert.AreEqual(user.Username, result.UploadedBy.Username);
        Assert.AreEqual(user.Password, result.UploadedBy.Password);
        Assert.AreEqual(user.isAdmin, result.UploadedBy.isAdmin);
        
        Assert.AreEqual(file.UploadedBy, result.UploadedBy);
    }

    [Test]
    public async Task OneGetAllFilesDtoTest()
    {
        OneCreateAsyncTest();
        
        var resultList = await fileEfcDao.GetAllFileDtosAsync();
        Assert.AreEqual(resultList.Count, 1);
        GetAllFilesDto result = resultList[0];
        
        
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("TestTitle", result.Title);
        Assert.AreEqual("TestDescription", result.Description);
        Assert.AreEqual("TestCategory", result.Category);
        
        Assert.AreEqual(result.GetType(), typeof(GetAllFilesDto));
    }

    [Test]
    public async Task GetAsyncTest()
    {
        OneCreateAsyncTest();

        var result = await fileEfcDao.GetAsync(1);
        
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("TestTitle", result.Title);
        Assert.AreEqual("TestDescription", result.Description);
        Assert.AreEqual("TestCategory", result.Category);
        Assert.AreEqual(Array.Empty<byte>(), result.bytes);
    }


}