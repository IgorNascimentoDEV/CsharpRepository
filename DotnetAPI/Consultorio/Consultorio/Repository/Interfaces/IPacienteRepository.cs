using Consultorio.Models.Entities;
using System.Collections.Generic;

namespace Consultorio.Repository.Interfaces
{
    public interface IPacienteRepository : IBaseRepository
    {
        Task<IEnumerable<Paciente>> GetPacientesAsync();
        Task<Paciente> GetPacienteByIdAsync(int id);
    }
}
