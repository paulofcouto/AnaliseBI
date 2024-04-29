using AnaliseBI.Application.Services;
using AnaliseBI.Infrastructure.MySql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<SaleService>();
builder.Services.AddScoped<SaleRepository>();

//Injetando configuração do MySql
builder.Services.AddDbContextPool<StageDbContext>(options =>
{
    var connetionString = builder.Configuration.GetConnectionString("MySql");
    options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
});

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
