using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

using Endpoint.Logic.Classes;
using Endpoint.Logic.Interfaces;
using Endpoint.Models.Data;
using Endpoint.Repositories.Databases;
using Endpoint.Repositories.GenericRepository;
using Endpoint.Repositories.Interfaces;
using Endpoint.Repositories.ModelRepositories;
using Endpoint.Services.Interfaces;
using Endpoint.Services.Classes;
using Endpoint.Validators;

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
    options.User.RequireUniqueEmail = true;
    options.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

// JWT
var issuer = builder.Configuration.GetSection("JwtConfig:Issuer").Value;
var key = builder.Configuration.GetSection("JwtConfig:Secret").Value;
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = issuer,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        ValidateLifetime = true,
    };
});

// Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
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

// DI for Validators
builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization
            Enter 'Bearer' [space] TOKEN
            Example: 'Bearer 123abc'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.SwaggerDoc("v1", new OpenApiInfo { Title = "TableReservation", Version = "v1" });
});
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

app.UseCors("AllowAll");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
