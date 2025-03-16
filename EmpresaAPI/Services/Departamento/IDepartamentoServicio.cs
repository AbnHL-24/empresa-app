using EmpresaAPI.Models.Departamento;

namespace EmpresaAPI.Services.Departamento;

public interface IDepartamentoServicio
{
    Task<IEnumerable<DepartamentoModel>> ObtenerDepartamentosAsync();
    Task<DepartamentoModel> ObtenerDepartamentoPorIdAsync(int id);
    Task CrearAsync(DepartamentoModel departamento);
    Task ActualizarAsync(int id, DepartamentoModel departamento);
}