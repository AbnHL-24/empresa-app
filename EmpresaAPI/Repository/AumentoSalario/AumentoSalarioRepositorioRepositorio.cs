using EmpresaAPI.DbContext;
using EmpresaAPI.Models.AumentoSalario;
using Microsoft.EntityFrameworkCore;

namespace EmpresaAPI.Repository.AumentoSalario;

public class AumentoSalarioRepositorioRepositorio : IAumentoSalarioRepositorio
{
    private readonly EmpresaApiContext _context;

    public AumentoSalarioRepositorioRepositorio(EmpresaApiContext context)
    {
        _context = context;
    }

    public async Task CrearAumentoSalario(AumentoSalarioModel aumentoSalario)
    {
        await _context.AumentoSalario.AddAsync(aumentoSalario);
        await _context.SaveChangesAsync();
    }
}