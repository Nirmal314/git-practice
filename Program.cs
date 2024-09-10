using Exploration.Interfaces;
using Exploration.Models;
using Exploration.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddDbContext<ExamContext>(options =>
//            options.UseSqlServer("Server=192.168.1.145,1435;Database=Exam;User Id=yash;Password=Sit@321#;TrustServerCertificate=True;MultipleActiveResultSets=True;"));

builder.Services.AddSingleton<IDbConnection>((sp) =>
        new SqlConnection("Server=192.168.1.145,1435;Database=Exam;User Id=yash;Password=Sit@321#;TrustServerCertificate=True;MultipleActiveResultSets=True;"));

builder.Services.AddSingleton<MongoDbContext>(sp =>
    new MongoDbContext("mongodb+srv://nirmal:Q3neO0T12BvYG2VS@cluster0.0pi0r.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0",
    "sample_mflix"));

builder.Services.AddScoped<IUsers, UserService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
