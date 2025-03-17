using EmpresaAPI.DbContext;
using EmpresaAPI.Models.Departamento;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Repository.Departamento;

public class DepartamentoRepositorio : IDepartamentoRepositorio
{
    private readonly EmpresaApiContext _context;

    public DepartamentoRepositorio(EmpresaApiContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<DepartamentoModel>> ObtenerDepartamentosAsync()
    {
        return await _context.Departamentos.ToListAsync();
    }

    public async Task<DepartamentoModel?> ObtenerDepartamentoPorIdAsync(int id)
    {
        return await _context.Departamentos.FindAsync(id);
    }

    public async Task<DepartamentoModel?> ObtenerDepartamentoPorNombreAsync(string nombre)
    {
        return await _context.Departamentos.FirstOrDefaultAsync(x => x.Nombre == nombre);
    }

    public async Task CrearAsync(DepartamentoModel departamento)
    {
        await _context.Departamentos.AddAsync(departamento);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(DepartamentoModel departamento)
    {
        var departamento2 = await _context.Departamentos.FindAsync(departamento.IdDepartamento);
        departamento2.Nombre = departamento.Nombre;
        departamento2.Presupuesto = departamento.Presupuesto;
        await _context.SaveChangesAsync();
    }
}