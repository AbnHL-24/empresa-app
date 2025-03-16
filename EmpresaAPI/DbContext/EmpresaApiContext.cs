using EmpresaAPI.Models.Departamento;
using EmpresaAPI.Models.Empleado;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.DbContext;

public class EmpresaApiContext : Microsoft.EntityFrameworkCore.DbContext
{
    public EmpresaApiContext(DbContextOptions<EmpresaApiContext> options)
        : base(options)
    {
    }
    
    public DbSet<DepartamentoModel> Departamentos { get; set; }
    public DbSet<EmpleadoModel> Empleados { get; set; }
}