
using EfcDataAccess;
using EfcDataAccess.DaoInterfaces;
using EfcDataAccess.DAOs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddScoped<FileContext>();
builder.Services.AddScoped<IUserDao, UserEfcDao>();
builder.Services.AddScoped<IFileDao, FileEfcDao>();
builder.Services.AddScoped<ICategoryDao, CategoryEfcDao>();


// builder.Services.AddScoped<ITodoDao, TodoEfcDao>();
// builder.Services.AddScoped<ITodoLogic, TodoLogic>();

builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();