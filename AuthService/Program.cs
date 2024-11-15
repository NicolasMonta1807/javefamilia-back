using System.Text.Json.Serialization;
using AuthService.Properties;
using AuthService.Service;

var builder = WebApplication.CreateBuilder(args);

// User secrets
if (builder.Environment.IsDevelopment()) builder.Configuration.AddUserSecrets<Program>();

// Database connection
builder.Services.Configure<UserDatabaseSettings>(
    builder.Configuration.GetSection("UserDatabase")
);

// Enum deserialization
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


// Jwt Settings
var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettingsSection.GetValue<string>("SecretKey");

// Add services to the container.
builder.Services.AddSingleton<AuthControllerService>();

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