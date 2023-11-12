using Microsoft.EntityFrameworkCore;
using TaxCalculator.Models;
using TaxCalculator.Repositories.Contexts;
using TaxCalculator.Repositories.Implementantios;
using TaxCalculator.Repositories.Interfaces;
using TaxCalculator.Services.Implementations;
using TaxCalculator.Services.Implementations.Mocks;
using TaxCalculator.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaxCalculatorContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IRatesRepository, RatesRepository>();
builder.Services.AddTransient<ICalculationTypesRepository, CalculationTypesRepository>();
builder.Services.AddTransient<ITaxCalculationRepository, TaxCalculationRepository>();

builder.Services.AddTransient<ITaxCalculationService, TaxCalculationService>();
builder.Services.AddTransient<IRatesService, RatesService>();
builder.Services.AddTransient<ICalculationTypesService, CalculationTypesService>();

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
