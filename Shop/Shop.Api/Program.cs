using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Common.Application;
using Shop.Config;
using System.Reflection;
using MediatR;
using Shop.Application.Productes.Create;
using FluentValidation;
using Common.Asp.NetCore.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")  ??
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
;

builder.Services.RegisterShopDependency(connectionString);
CommonBootstrapper.Init(builder.Services);
builder.Services.AddTransient<IFileService, FileService>();

var app = builder.Build();


// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();


app.UseAuthorization();
app.UseApiCustomExceptionHandler();
app.MapControllers();

app.Run();
