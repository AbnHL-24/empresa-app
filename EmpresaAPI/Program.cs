using EmpresaAPI.DbContext;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
using EmpresaAPI.Models.Departamento;
using EmpresaAPI.Repository.AumentoSalario;
using EmpresaAPI.Repository.Departamento;
using EmpresaAPI.Repository.Empleado;
using EmpresaAPI.Services.Departamento;
using EmpresaAPI.Services.Empleado;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<EmpresaApiContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Regostro de servicios (en builkder.Service).
builder.Services.AddScoped<IDepartamentoRepositorio, DepartamentoRepositorio>();
builder.Services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();
builder.Services.AddScoped<IDepartamentoServicio, DepartamentoServicio>();
builder.Services.AddScoped<IEmpleadoServicio, EmpleadoServicio>();
builder.Services.AddScoped<IAumentoSalarioRepositorio, AumentoSalarioRepositorioRepositorio>();
/*builder.Services.AddTransient<IDepartamentoServicio, DepartamentoServicio>();
builder.Services.AddTransient<IEmpleadoServicio, EmpleadoServicio>();*/

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