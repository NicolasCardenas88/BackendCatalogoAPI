using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Implementation;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Validator;
using BackendCatalogoAXA.Middleware;
using BackendCatalogoAXA.Model.Repository.Implementation;
using BackendCatalogoAXA.Model.Repository.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IServiceLogic, ServiceLogic>();
builder.Services.AddTransient<IRegisterLogic, RegisterLogic>();
builder.Services.AddScoped<IValidadationService, ValidationService>();
builder.Services.AddTransient<IGetData, GetData>();
builder.Services.AddTransient<IRegisterData, RegisterData>();
builder.Services.AddTransient<CatalogoServiciosAxaContext, CatalogoServiciosAxaContext>();
builder.Services.AddDbContext<CatalogoServiciosAxaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies()); 
builder.Services.AddValidatorsFromAssemblyContaining<ValidatorCreateFramework>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();