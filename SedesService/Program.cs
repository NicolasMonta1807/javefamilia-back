using System.Text;
using System.Text.Json.Serialization;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.IdentityModel.Tokens;
using SedesService.Properties;
using SedesService.Service;

var builder = WebApplication.CreateBuilder(args);

// KeyVault Load
var keyvaultUrl = builder.Configuration.GetSection("KeyVault:KeyVaultUrl");
var keyvaultClientId = builder.Configuration.GetSection("KeyVault:ClientId");
var keyvaultClientSecret = builder.Configuration.GetSection("KeyVault:ClientSecret");
var keyvaultDirectoryId = builder.Configuration.GetSection("KeyVault:DirectoryId");

var credential =
    new ClientSecretCredential(keyvaultDirectoryId.Value!, keyvaultClientId.Value!, keyvaultClientSecret.Value!);

builder.Configuration.AddAzureKeyVault(keyvaultUrl.Value!, keyvaultClientId.Value!, keyvaultClientSecret.Value!,
    new DefaultKeyVaultSecretManager());

var secretClient = new SecretClient(new Uri(keyvaultUrl.Value!), credential);

// Database connection
KeyVaultSecret dbConnectionStringSecret = secretClient.GetSecret("SedesDatabase--ConnectionString");
KeyVaultSecret dbConnectionDatabaseName = secretClient.GetSecret("SedesDatabase--DatabaseName");
KeyVaultSecret dbConnectionCollectionName = secretClient.GetSecret("SedesDatabase--CollectionName");

builder.Services.Configure<SedesDatabaseSettings>(options =>
{
    options.ConnectionString = dbConnectionStringSecret.Value;
    options.DatabaseName = dbConnectionDatabaseName.Value;
    options.CollectionName = dbConnectionCollectionName.Value;
});

// Enum deserialization
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Jwt Settings
KeyVaultSecret jwtSecret = secretClient.GetSecret("JwtSettings--SecretKey");

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "javefamilia.org",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret.Value))
        };
    });

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