using EmpresaAPI.Models.Departamento;
using EmpresaAPI.Repository.Departamento;

namespace EmpresaAPI.Services.Departamento;

public class DepartamentoServicio : IDepartamentoServicio
{
    private readonly IDepartamentoRepositorio _departamentoRepositorio;

    public DepartamentoServicio(IDepartamentoRepositorio departamentoRepositorio)
    {
        _departamentoRepositorio = departamentoRepositorio;
    }
    
    public async Task<IEnumerable<DepartamentoModel>> ObtenerDepartamentosAsync()
    {
        return await _departamentoRepositorio.ObtenerDepartamentosAsync();
    }

    public async Task<DepartamentoModel> ObtenerDepartamentoPorIdAsync(int id)
    {
        return await _departamentoRepositorio.ObtenerDepartamentoPorIdAsync(id);
    }

    public async Task CrearAsync(DepartamentoModel departamento)
    {
        var existente = await _departamentoRepositorio.ObtenerDepartamentoPorIdAsync(departamento.IdDepartamento);
        if (existente != null)
        {
            throw new ApplicationException("El departamento ya existe");
        }
        await _departamentoRepositorio.CrearAsync(departamento);
    }

    public async Task ActualizarAsync(int id, DepartamentoModel departamento)
    {
        var existente = await _departamentoRepositorio.ObtenerDepartamentoPorIdAsync(id);
        if (existente == null)
        {
            throw new AggregateException("El departamento no existe");
        }
        var otro = await _departamentoRepositorio.ObtenerDepartamentoPorIdAsync(departamento.IdDepartamento);
        if (otro != null && otro.IdDepartamento != id)
        {
            throw new ApplicationException("El departamento ya existe");
        }
        existente.Nombre = departamento.Nombre;
        existente.Presupuesto = departamento.Presupuesto;
        await _departamentoRepositorio.ActualizarAsync(departamento);
    }
}