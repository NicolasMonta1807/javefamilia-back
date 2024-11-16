using System.Text;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

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

builder.Configuration.AddJsonFile("ocelot.json");

// JWT Settings
const string authenticationProviderKey = "BearerAuth";
KeyVaultSecret jwtSecret = secretClient.GetSecret("JwtSettings--SecretKey");

builder.Services.AddAuthentication(authenticationProviderKey)
    .AddJwtBearer(authenticationProviderKey, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidIssuer = "javefamilia.org",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret.Value))
        };
    });

builder.Services.AddOcelot();

// Swagger Ocelot
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerForOcelot(builder.Configuration);
var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerForOcelotUI();
app.UseOcelot().Wait();

app.Run();