using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "API de Usuarios activa. Accede a '/api/users' para consultar los endpoints del controlador.");

app.MapControllers();

await app.RunAsync();

[ExcludeFromCodeCoverage]
public partial class Program { }


