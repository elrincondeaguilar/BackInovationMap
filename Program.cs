using BackInovationMap.Data;
using BackInovationMap.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar la conexión a la base de datos PostgreSQL o Supabase
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Habilitar controladores
builder.Services.AddControllers();

// Configurar JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey not configured");

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
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

// Registrar servicios
builder.Services.AddScoped<IJwtService, JwtService>();

// Habilitar Swagger para pruebas
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo 
    { 
        Title = "BackInovationMap API", 
        Version = "v1",
        Description = "API REST para gestión de empresas y convocatorias de innovación"
    });

    // Configurar autenticación JWT en Swagger
    c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Ingrese 'Bearer' seguido de su JWT token. Ejemplo: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Habilitar CORS para el frontend Next.js
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:3000",  // Next.js desarrollo
                "http://localhost:3001",  // Next.js puerto alternativo
                "https://localhost:3000", // Next.js con HTTPS
                "https://innovation-map-frontend.vercel.app" // Frontend en producción
              )
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
    });
});

var app = builder.Build();

// Configurar el puerto dinámico para Render (solo en producción)
if (!app.Environment.IsDevelopment())
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
    app.Urls.Add($"http://0.0.0.0:{port}");
}
// En desarrollo, usa los puertos configurados en launchSettings.json

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackInovationMap API v1");
        c.DocumentTitle = "BackInovationMap API - Documentación";
        c.DefaultModelsExpandDepth(-1); // Ocultar esquemas por defecto
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None); // Contraer operaciones por defecto
    });
}
else
{
    // Habilitar Swagger también en producción para Render
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackInovationMap API v1");
        c.DocumentTitle = "BackInovationMap API - Producción";
        c.DefaultModelsExpandDepth(-1);
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
    });
}

// No usar HTTPS redirect en Render (Render maneja SSL)
// app.UseHttpsRedirection();
app.UseCors("AllowFrontend");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); // Esto activa tus endpoints de API

app.Run();
