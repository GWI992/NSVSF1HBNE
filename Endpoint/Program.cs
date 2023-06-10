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
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Set dbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

// Identity
builder.Services.AddAuthentication();
builder.Services.AddIdentity<ApiUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.User.RequireUniqueEmail = false;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
    );
});

// DI for Logics
builder.Services.AddScoped<ILogic<Table, Table>, TableLogic>();
builder.Services.AddScoped<ILogic<Reservation, Reservation>, ReservationLogic>();

// DI for Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

// DI for Validators
builder.Services.AddScoped<IValidator<Table>, TableValidator>();
builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();

builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WorkManagement API V1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseDefaultFiles();
}
app.UseAuthentication();
app.MapControllers();

app.Run();
