using AuthApi.Data;
using AuthApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DotNetEnv;
using Microsoft.OpenApi.Models;
using System.Security.Cryptography.X509Certificates;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables from .env file
Env.Load();

// Configure database context
var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("DB_CONNECTION_STRING environment variable is not set.");
}
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Read the JWT key from environment variables
var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
if (string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("JWT_KEY environment variable is not set.");
}
var key = Encoding.ASCII.GetBytes(jwtKey);

// Get the current directory and build the path to the certificate
var currentDirectory = Directory.GetCurrentDirectory();
var certificatePath = Path.Combine(currentDirectory, "aspnetcore.pfx"); // Utilisation du chemin relatif
var certificatePassword = "password"; // Utilisez le mot de passe simple "password"
if (!File.Exists(certificatePath))
{
    throw new FileNotFoundException($"Certificate file not found: {certificatePath}");
}
var certificate = new X509Certificate2(certificatePath, certificatePassword);

// Configure Kestrel to listen on ports 5000 (HTTP) and 5001 (HTTPS)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenAnyIP(5000); // HTTP
    serverOptions.ListenAnyIP(5001, listenOptions =>
    {
        listenOptions.UseHttps(httpsOptions =>
        {
            httpsOptions.ServerCertificate = certificate;
        });
    });
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAuthorization();
builder.Services.AddScoped<IAuthService, AuthService>();

// Configure Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// Configure Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    options.RoutePrefix = string.Empty; // Pour mettre Swagger UI à la racine de l'application
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
