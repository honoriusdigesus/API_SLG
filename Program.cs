using Application.Exceptions;
using Application.Mappers;
using Application.Services;
using Application.Utils;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar el filtro de excepciones personalizado
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorHandler>();
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectamos la dependencias asociadas a la Zone
builder.Services.AddScoped<IZoneServices, ZoneService>();
builder.Services.AddScoped<IZoneReporitory, ZoneRepository>();
builder.Services.AddScoped<ZoneMapper>();

//Inyectamos la dependencias asociadas a la Employee
builder.Services.AddScoped<IEmployeeServices, EmployeeService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<EmployeeMapper>();


builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<LoginMapper>();



builder.Services.AddScoped<UtilsJwt>();

//Inyectamos la dependencia de la base de datos de Postgres
builder.Services.AddDbContext<SlgGottaContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


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
