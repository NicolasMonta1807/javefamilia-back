using System.Text;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json");

const string authenticationProviderKey = "BearerAuth";
var key = Encoding.ASCII.GetBytes("SECRET-JWT-KEY");

// JWT Settings
var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettingsSection.GetValue<string>("SecretKey");

builder.Services.AddAuthentication(authenticationProviderKey)
    .AddJwtBearer(authenticationProviderKey, options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidIssuer = "javefamilia.org",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey))
        };
    });

builder.Services.AddOcelot();

var app = builder.Build();

if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseOcelot().Wait();

app.Run();