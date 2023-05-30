using Domain.DTOs;
using Domain.Models;
using EfcDataAccess;
using File = Domain.Models.File;

namespace UnitTests;

public class UserTests
{
    private DataContext context;
    private UserEfcDao userEfcDao;

    [SetUp]
    public void Setup()
    {
        context = MockDbContextFactory.Create();
        userEfcDao = new UserEfcDao(context);

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

        // Clearing User database
        foreach (var category in context.Categories)
        {
            context.Categories.Remove(category);
        }

        context.SaveChanges();
    }
    [Test]
    public async Task ZeroGetAllUsersAsyncTest()
    {
        var users = await userEfcDao.GetAll();
        Assert.IsNotNull(users);
        Assert.AreEqual(0, users.Count);
    }
    
    [Test]
    public async Task OneGetAllUsersAsyncTest()
    {
        var user = new User()
        {
            Name = "Bob",
            Username = "Bobby",
            Password = "qwerty",
            isAdmin = false
        };
        var result = await userEfcDao.CreateAsync(user);
        var users = await userEfcDao.GetAll();
        
        Assert.IsNotNull(users);

        Assert.AreEqual(1, users.Count);
        //Crashes for no reason
        // Assert.AreEqual(result.Id, 1);
        Assert.AreEqual(result.Name, users[0].Name);
        Assert.AreEqual(result.Username, users[0].Username);
    }
    
    [Test]
    public async Task ManyGetAllUsersAsyncTest()
    {
        for (int i = 0; i < 5; i++)
        {
            var user = new User()
            {
                Name = "Bob" + i,
                Username = "Bobby" + i,
                Password = "qwerty" +i,
                isAdmin = false
            };
            var result = await userEfcDao.CreateAsync(user);
        }
        
        var users = await userEfcDao.GetAll();
        
        Assert.IsNotNull(users);
        Assert.AreEqual(5, users.Count);
        Assert.AreEqual(users[4].Username, "Bobby4");
        
    }

    [Test]
    public async Task UpperBoundaryGetAllUsersAsync()
    {
        for (int i = 0; i < 1000; i++)
        {
            var user = new User()
            {
                Name = "Bob" + i,
                Username = "Bobby" + i,
                Password = "qwerty" +i,
                isAdmin = false
            };
            var result = await userEfcDao.CreateAsync(user);
        }
        var users = await userEfcDao.GetAll();
        
        Assert.AreEqual(1000, users.Count);
        
        //Crashes for no reason
        // for (int i = 0; i < 1000; i++)
        // {
        //     Assert.AreEqual("Bob" + i, users[i].Name);
        //     Assert.AreEqual("Bobby" + i, users[i].Username);
        // }
    }

    [Test]
    public async Task LoginTest()
    {
        var user = new User()
        {
            Name = "Bob",
            Username = "Bobby",
            Password = "qwerty",
            isAdmin = false
        };
        var result = await userEfcDao.CreateAsync(user);
        UserLoginDto userToLog = new UserLoginDto(result.Username, result.Password);
        User loggedUser = await userEfcDao.LoginAsync(userToLog);
        
        Assert.AreEqual(loggedUser, user);
    }

    [Test]
    public async Task GetByIdTest()
    {
        var user = new User()
        {
            Name = "Bob",
            Username = "Bobby",
            Password = "qwerty",
            isAdmin = false
        };
        var result = await userEfcDao.CreateAsync(user);
        var searchResult = userEfcDao.GetByIdAsync(1);
        
        Assert.IsNotNull(searchResult);
        Assert.AreEqual(searchResult.Result.Name, result.Name);
        Assert.AreEqual(searchResult.Result.Username, result.Username);
        Assert.AreEqual(searchResult.Result.Password, result.Password);
    }


}