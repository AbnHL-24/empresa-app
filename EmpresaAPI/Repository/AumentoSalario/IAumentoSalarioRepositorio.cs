using EmpresaAPI.Models.AumentoSalario;

namespace EmpresaAPI.Repository.AumentoSalario;

public interface IAumentoSalarioRepositorio
{
    Task CrearAumentoSalario(AumentoSalarioModel aumentoSalario);
}