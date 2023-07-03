using EmployeeManagement.Application;
using EmployeeManagement.Common;
using EmployeeManagement.Context.Database;
using EmployeeManagement.Context.Employee;
using EmployeeManagement.Repository;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

var logger = new LoggerConfiguration()
  .ReadFrom.Configuration(builder.Configuration)
  .Enrich.FromLogContext()
  .CreateLogger();
// Add services to the container.

builder.Logging.AddConsole();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

FlavorConfig.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

builder.Services.AddScoped<IDatabaseManager, DatabaseManagerImpl>();
builder.Services.AddScoped<IEmployeeService, EmployeeServiceImpl>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoryImpl>();

var app = builder.Build();

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
