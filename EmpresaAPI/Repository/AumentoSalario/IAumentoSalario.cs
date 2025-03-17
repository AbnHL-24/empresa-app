using EmpresaAPI.Models.AumentoSalario;

namespace EmpresaAPI.Repository.AumentoSalario;

public interface IAumentoSalario
{
    Task CrearAumentoSalario(AumentoSalarioModel aumentoSalario);
}