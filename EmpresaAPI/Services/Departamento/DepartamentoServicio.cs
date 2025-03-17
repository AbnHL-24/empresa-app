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
        var departamento = await _departamentoRepositorio.ObtenerDepartamentoPorIdAsync(id);
        
        if (departamento is null)
            throw new ApplicationException($"El departamento con {id} no existe");
        
        return departamento;
    }

    public async Task CrearAsync(DepartamentoModel departamento)
    {
        var departamentoDb = await _departamentoRepositorio.ObtenerDepartamentoPorIdAsync(departamento.IdDepartamento);
        if (departamentoDb is not null)
            throw new ApplicationException("El departamento con el id ingresado ya existe");
        
        departamentoDb = await _departamentoRepositorio.ObtenerDepartamentoPorNombreAsync(departamento.Nombre);
        if (departamentoDb is not null)
            throw new ApplicationException("El departamento con el nombre ingresado ya existe");
            
        await _departamentoRepositorio.CrearAsync(departamento);
    }

    public async Task ActualizarAsync(int id, DepartamentoModel departamento)
    {
        var departamentoDb = await _departamentoRepositorio.ObtenerDepartamentoPorIdAsync(id);
        if (departamentoDb == null)
            throw new AggregateException($"El departamento con el id: {id} no existe");

        departamentoDb = await _departamentoRepositorio.ObtenerDepartamentoPorNombreAsync(departamento.Nombre);
        if (departamentoDb is not null && departamentoDb.IdDepartamento != id)
            throw new ApplicationException("Ya existe otro departamento con el nombre ingresado");
        
        await _departamentoRepositorio.ActualizarAsync(departamento);
        /*var exito = await _departamentoRepositorio.ActualizarAsync(departamento);
        Console.WriteLine(exito);*/
    }
}