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
        public IActionResult Get()
        {
            var pacientes = _pacienteRepository.GetPacientes();

            return pacientes.Any()
                ? Ok(pacientes)
                : BadRequest("Pacientes não encontrados");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var paciente = _pacienteRepository.GetPacienteById(id);
            return paciente != null
                ? Ok(paciente)
                : BadRequest("paciente não encontrado");
        }
    }
}
