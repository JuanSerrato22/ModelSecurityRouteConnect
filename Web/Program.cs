using Business;
using Business.Implements;
using Business.Interfaces;
using Data;
using Data.Implements;
using Data.Interfaces;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Registrar repositorios (Data)
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IChangeLogRepository, ChangeLogRepository>();
builder.Services.AddScoped<IDestinationActivityRepository, DestinationActivityRepository>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IFormModuleRepository, FormModuleRepository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IRolFormPermissionRepository, RolFormPermissionRepository>();
builder.Services.AddScoped<IRolPermissionRepository, RolPermissionRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();
builder.Services.AddScoped<IUserActivityRepository, UserActivityRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRolRepository, UserRolRepository>();


// Registrar servicios (Business)
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddScoped<IChangeLogService, ChangeLogService>();
builder.Services.AddScoped<IDestinationActivityService, DestinationActivityService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<IFormModuleService, FormModuleService>();
builder.Services.AddScoped<IFormService, FormService>();
builder.Services.AddScoped<IModuleService, ModuleService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IRolFormPermissionService, RolFormPermissionService>();
builder.Services.AddScoped<IRolPermissionService, RolPermissionService>();
builder.Services.AddScoped<IRolService, RolService>();
builder.Services.AddScoped<IUserActivityService, UserActivityService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRolService, UserRolService>();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Agregar CORS
var OrigenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(politica =>
    {
        politica.WithOrigins(OrigenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });
});

// Agregar DbContext con MySQL (usando Pomelo)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
    opciones.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

// Agregar DbContext
//builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
//    opciones.UseSqlServer("name=DefaultConnection"));


// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();