using SedesService.Properties;
using SedesService.Service;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Database connection
builder.Services.Configure<SedesDatabaseSettings>(
    builder.Configuration.GetSection("SedeDatabase")); 

// Add services to the container.
builder.Services.AddSingleton<SedesServiceImp>();

// Add Controllers
builder.Services.AddControllers();

// Add Swagger Endpoints (For development)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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