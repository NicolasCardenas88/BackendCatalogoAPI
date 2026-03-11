using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Implementation;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Implementation;
using BackendCatalogoAXA.Logic.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IServiceLogic, ServiceLogic>();
builder.Services.AddTransient<IGetData, GetData>();
builder.Services.AddTransient<CatalogoServiciosAxaContext, CatalogoServiciosAxaContext>();
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
