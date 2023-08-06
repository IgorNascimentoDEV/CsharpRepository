using Consultorio.Repository.Interfaces;
using Consultorio.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteController(IPacienteRepository repository)
        {
            _pacienteRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pacientes = await _pacienteRepository.GetPacientesAsync();

            return pacientes.Any()
                ? Ok(pacientes)
                : BadRequest("Pacientes não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _pacienteRepository.GetPacienteByIdAsync(id);
            return paciente != null
                ? Ok(paciente)
                : BadRequest("paciente não encontrado");
        }
    }
}
