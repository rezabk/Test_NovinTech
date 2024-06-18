using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test_NovinTech;
using Mapper = Shared.Mapepr.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddMediatR(typeof(CreateItemCommand));
builder.Services.AddMediatR(typeof(GetItemsQueryHandler));

builder.Services.AddScoped<Mapper>();


var connectionString = "Server=localhost;Database=db1;Uid=webapi;Pwd=12345678";

var serverVersion = new MariaDbServerVersion(new Version(11, 4, 2));

builder.Services.AddDbContext<Db1Context>(
    dbCotextOptions => dbCotextOptions
        .UseMySql(connectionString, serverVersion)
    );

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
