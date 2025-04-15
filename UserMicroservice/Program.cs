using UserMicroservice.Application;
using UserMicroservice.Application.Services;
using UserMicroservice.Application.Services.Interfaces;
using UserMicroservice.Core.Configuration;
using UserMicroservice.Presentation.Apis;

var builder = WebApplication.CreateBuilder(args);

// Register Options
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddProblemDetails();

builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseStatusCodePages();

// Register APIs
app.AddAuthApi();
app.AddUserApi();

app.Run();
