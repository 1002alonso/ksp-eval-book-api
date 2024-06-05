using KspEvalBook.Application.DTOs;
using KspEvalBook.Application.Interfaces;
using KspEvalBook.Application.Mapper;
using KspEvalBook.Application.Services;
using KspEvalBook.Domain.Entities;
using KspEvalBook.Domain.Interfaces.Repositories;
using KspEvalBook.Infrastructure.Data;
using KspEvalBook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("*")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();

builder.Services.AddDbContext<KspEvalBookDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("stringSQL"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(EditorialFile));

builder.Services.AddScoped<IGenericService<EditorialDto, Guid>, EditorialService>();
builder.Services.AddScoped<IGenericReposiory<CbCatEditorial,Guid>, EditorialRepository>();

builder.Services.AddScoped<IGenericService<LibroUsuarioDto, Guid>, LibroUsuarioService>();
builder.Services.AddScoped<IGenericReposiory<CbTabLibroUsuario, Guid>, LibroUsuarioRepository>();

builder.Services.AddScoped<IGenericService<LibroDto, Guid>, LibroService>();
builder.Services.AddScoped<IGenericReposiory<CbTabLibro, Guid>, LibroRepository>();

builder.Services.AddScoped<ILibroPrestamoService<LibroPrestamoDto, Guid>, LibroPrestamoService>();
builder.Services.AddScoped<IPrestamoLibroRepository<CbTabLibroPrestamo, Guid,Guid>, LibroPrestamoRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
