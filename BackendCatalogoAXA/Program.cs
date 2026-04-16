using BackendCatalogoAXA.Model.Mapper.MapperService;
using BackendCatalogoAXA.Model.Repository.Implementation;
using BackendCatalogoAXA.Model.Repository.Interfaces;
using BackendCatalogoAXA.Logic.Repository.Implementation;
using BackendCatalogoAXA.Logic.Repository.Interfaces;
using BackendCatalogoAXA.Middleware;
using Microsoft.EntityFrameworkCore;
using BackendCatalogoAXA.Data.Repository.Interfaces;
using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Implementation;

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

builder.Services.AddScoped<IAmbienteData, AmbienteData>();
builder.Services.AddScoped<IAmbienteLogic, AmbienteLogic>();

builder.Services.AddScoped<IApiManagerData, ApiManagerData>();
builder.Services.AddScoped<IApiManagerLogic, ApiManagerLogic>();

builder.Services.AddScoped<IAplicacionData, AplicacionData>();
builder.Services.AddScoped<IAplicacionLogic, AplicacionLogic>();

builder.Services.AddScoped<IEntornoData, EntornoData>();
builder.Services.AddScoped<IEntornoLogic, EntornoLogic>();

builder.Services.AddScoped<IEstadoData, EstadoData>();
builder.Services.AddScoped<IEstadoLogic, EstadoLogic>();

builder.Services.AddScoped<IFrameworkData, FrameworkData>();
builder.Services.AddScoped<IFrameworkLogic, FrameworkLogic>();

builder.Services.AddScoped<ILogData, LogData>();
builder.Services.AddScoped<ILogLogic, LogLogic>();

builder.Services.AddScoped<IMetodoHttpData, MetodoHttpData>();
builder.Services.AddScoped<IMetodoHttpLogic, MetodoHttpLogic>();

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

app.UseHttpsRedirection();

app.Run();