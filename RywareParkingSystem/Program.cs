using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using RywareParkingSystem.Converter;
using RywareParkingSystem.DAL.Context;
using RywareParkingSystem.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.Converters.Add(new TimeSpanJsonConverter())); 

builder.Services.AddTransient(typeof(IRepository), typeof(Repository));

builder.Services.AddDbContext<ParkingContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSql")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
