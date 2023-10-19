using CriandoApi6.Application.aluno;
using CriandoApi6.Repository;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CriandoApi6Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoBanco")));

builder.Services.AddScoped<IAlunoService, AlunosService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
