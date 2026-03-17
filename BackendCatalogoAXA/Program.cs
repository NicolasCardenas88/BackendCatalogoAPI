using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Mapper.MapperService;
using BackendCatalogoAXA.Data.Repository.Implementation;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Implementation;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IServiceLogic, ServiceLogic>();
builder.Services.AddTransient<IRegisterLogic, RegisterLogic>();
builder.Services.AddTransient<IGetData, GetData>();
builder.Services.AddTransient<IRegisterData, RegisterData>();
builder.Services.AddTransient<CatalogoServiciosAxaContext, CatalogoServiciosAxaContext>();
builder.Services.AddDbContext<CatalogoServiciosAxaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddAutoMapper(typeof(ServicioProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
