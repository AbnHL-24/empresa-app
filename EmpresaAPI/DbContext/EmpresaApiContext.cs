using EmpresaAPI.Models.AumentoSalario;
using EmpresaAPI.Models.Departamento;
using EmpresaAPI.Models.Empleado;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.DbContext;

public class EmpresaApiContext : Microsoft.EntityFrameworkCore.DbContext
{
    private string _strinConection;
    public EmpresaApiContext(DbContextOptions<EmpresaApiContext> options, IConfiguration configuration)
        : base(options)
    {
        _strinConection = configuration.GetConnectionString("DefaultConnection");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        /*#warning To protect potentially sensitive information in your connection string, 
        you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 
        for guidance on storing connection strings.*/
     
            optionsBuilder.UseMySQL(_strinConection);
    }
    
    public DbSet<DepartamentoModel> Departamentos { get; set; }
    public DbSet<EmpleadoModel> Empleados { get; set; }
    public DbSet<AumentoSalarioModel> AumentoSalario { get; set; }
}