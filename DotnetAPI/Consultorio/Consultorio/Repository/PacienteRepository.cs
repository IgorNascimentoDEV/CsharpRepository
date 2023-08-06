using Consultorio.Context;
using Consultorio.Models.Entities;
using Consultorio.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Consultorio.Repository
{
    public class PacienteRepository : BaseRepository, IPacienteRepository
    {
        private readonly ConsultorioContext _context;
        public PacienteRepository(ConsultorioContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Paciente>> GetPacientesAsync() 
        {
            return await _context.Pacientes.Include(x => x.Consultas)
                .ToListAsync();
        }

        public async Task<Paciente> GetPacienteByIdAsync(int id)
        {
            return await _context.Pacientes.Include(x => x.Consultas)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

    }
}
