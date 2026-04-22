using BackendCatalogoAXA.Data.Context;
using BackendCatalogoAXA.Data.Repository.Implementation;
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
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// -------------------- LOGIC --------------------
builder.Services.AddTransient<IServiceLogic, ServiceLogic>();
builder.Services.AddTransient<IRegisterLogic, RegisterLogic>();

// Validation
builder.Services.AddScoped<IValidadationService, ValidationService>();
builder.Services.AddValidatorsFromAssemblyContaining<ValidatorCreateFramework>();

// -------------------- DATA --------------------
builder.Services.AddTransient<IGetData, GetData>();
builder.Services.AddTransient<IRegisterData, RegisterData>();

builder.Services.AddScoped<IAmbienteData, AmbienteData>();
builder.Services.AddScoped<IApiManagerData, ApiManagerData>();
builder.Services.AddScoped<IAplicacionData, AplicacionData>();
builder.Services.AddScoped<IEntornoData, EntornoData>();
builder.Services.AddScoped<IEstadoData, EstadoData>();
builder.Services.AddScoped<IFrameworkData, FrameworkData>();
builder.Services.AddScoped<ILogData, LogData>();
builder.Services.AddScoped<IMetodoHttpData, MetodoHttpData>();

// -------------------- LOGIC (Scoped) --------------------
builder.Services.AddScoped<IAmbienteLogic, AmbienteLogic>();
builder.Services.AddScoped<IApiManagerLogic, ApiManagerLogic>();
builder.Services.AddScoped<IAplicacionLogic, AplicacionLogic>();
builder.Services.AddScoped<IEntornoLogic, EntornoLogic>();
builder.Services.AddScoped<IEstadoLogic, EstadoLogic>();
builder.Services.AddScoped<IFrameworkLogic, FrameworkLogic>();
builder.Services.AddScoped<ILogLogic, LogLogic>();
builder.Services.AddScoped<IMetodoHttpLogic, MetodoHttpLogic>();

// -------------------- DB CONTEXT --------------------
builder.Services.AddDbContext<CatalogoServiciosAxaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// -------------------- AUTOMAPPER --------------------
builder.Services.AddAutoMapper(cfg => { }, AppDomain.CurrentDomain.GetAssemblies());

// -------------------- APP --------------------
var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Custom middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();