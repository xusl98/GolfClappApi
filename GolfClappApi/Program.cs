
using Autofac.Core;
using GolfClapp.DB.Infrastructure;
using GolfClapp.DB.Infrastructure.Mappings;
using GolfClapp.DB.Infrastructure.Repositories;
using GolfClapp.DB.Infrastructure.RepositoryInterfaces;
using GolfClappServiceLibrary.ServiceInterfaces;
using GolfClappServiceLibrary.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ObjectsLibrary.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.


builder.Services.AddDbContext<GolfClappContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=GOLFCLAPP;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False"));
builder.Services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=GOLFCLAPP;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddIdentity<UserEntity, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<AuthenticationContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<JwtService>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IServiceProviderRepository, ServiceProviderRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameUserRepository, GameUserRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddScoped<UserManager<UserEntity>, UserManager<UserEntity>>();




//builder.Services.AddAuthentication(options =>
//{
//options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(options =>
//{
//    options.SaveToken = true;
//    options.RequireHttpsMetadata = false;
//    options.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidAudience = configuration["JWT:ValidAudience"],
//        ValidIssuer = configuration["JWT:ValidIssuer"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
//    };

//});
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidAudience = configuration["Jwt:Audience"],
            ValidIssuer = configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
            )
        };
    });



builder.Services.AddAutoMapper(x =>
{
    x.AddProfile(new MappingsProfile());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
