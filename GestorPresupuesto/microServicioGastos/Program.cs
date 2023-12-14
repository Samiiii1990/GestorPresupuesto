using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Model;
using microServicioGastos.Services;

var builder = WebApplication.CreateBuilder(args);

// Register services here
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));


builder.Services.AddSingleton<GastosServices>();
// Add controllers
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Gastos", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gastos v1"));

app.UseAuthorization();

app.MapControllers();

app.Run();