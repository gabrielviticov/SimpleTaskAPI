using Microsoft.EntityFrameworkCore;
using SimpleTaskAPI.Data;
using SimpleTaskAPI.Entities.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
    Injeções de dependências para funcionamento da WebAPI
*/

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    //AutoMapper - Conversão de Objeto para Objeto

/* 
    Estabelecer a conexão com a base de dados - SQL Server rodando em um container Docker
*/
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DbConnection")
));



//Habilitar a injeção de dependência para a utilização desta classe. 
builder.Services.AddScoped<TaskModel>();


var port = Environment.GetEnvironmentVariable("PORT") ?? "8081";
builder.WebHost.UseUrls($"http://localhost:{port}");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
