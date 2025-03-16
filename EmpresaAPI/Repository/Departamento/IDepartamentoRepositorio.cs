using EmpresaAPI.Models.Departamento;

namespace EmpresaAPI.Repository.Departamento;
using System.Threading.Tasks;

public interface IDepartamentoRepositorio
{
    Task<IEnumerable<DepartamentoModel>> ObtenerDepartamentosAsync();
    Task<DepartamentoModel> ObtenerDepartamentoPorIdAsync(int id);
    Task CrearAsync(DepartamentoModel departamento);
    Task ActualizarAsync(DepartamentoModel departamento);
}