using Api.Data;
using Api.Models;
using Api.Repos;
using Api.Services.SolrServices;
using Microsoft.EntityFrameworkCore;
using SolrNet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStrings = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionStrings,
    sqlServerOptionsAction: sqlAction =>
    {
        sqlAction.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null);
    }));

builder.Services.AddSolrNet("http://localhost:8983/solr/Country");

builder.Services.AddScoped<ICountryRepo, CountryRepo>();
builder.Services.AddScoped<ICountrySearchService, CountrySearchService>();

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
