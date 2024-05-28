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

builder.Services.AddControllers();

builder.Services.AddDbContext<KspEvalBookDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("stringSQL"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(EditorialFile));

builder.Services.AddScoped<IGenericService<EditorialDto, Guid>, EditorialService>();
builder.Services.AddScoped<IGenericReposiory<CbCatEditorial,Guid>, EditorialRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
