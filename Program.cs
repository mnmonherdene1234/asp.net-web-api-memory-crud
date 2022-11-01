using Microsoft.EntityFrameworkCore;
using EntityFrameworkTest.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
IConfigurationBuilder configurationbuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, true);
IConfigurationRoot configuration = configurationbuilder.Build();
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(configuration.GetConnectionString("Postgres")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
