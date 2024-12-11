using Insfrastructure.Dal;
using Insfrastructure.Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DrugsBotDbContext>((serviceProvider, options) =>
{
    var databaseSettings = serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;

    options.UseNpgsql(databaseSettings.ConnectionString, npgsqlOptions =>
    {
        npgsqlOptions.CommandTimeout(databaseSettings.CommandTimeout);
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();