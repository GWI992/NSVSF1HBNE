using FluentValidation;
using Microsoft.EntityFrameworkCore;

using Endpoint.Logic.Classes;
using Endpoint.Logic.Interfaces;
using Endpoint.Models.Data;
using Endpoint.Repositories.Databases;
using Endpoint.Repositories.GenericRepository;
using Endpoint.Repositories.Interfaces;
using Endpoint.Repositories.ModelRepositories;
using Endpoint.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Set dbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

// DI for Logics
builder.Services.AddScoped<ILogic<Table, Table>, TableLogic>();

// DI for Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITableRepository, TableRepository>();

// DI for Validators
builder.Services.AddScoped<IValidator<Table>, TableValidator>();

var app = builder.Build();

app.MapControllers();

app.Run();
