using Consultorio.Models.Dtos;
using Consultorio.Models.Entities;
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

            List<PacienteDto> pacientesRetorno = new List<PacienteDto>();

            foreach(var paciente in pacientes)
            {
                pacientesRetorno.Add(new PacienteDto { Id = paciente.Id, Nome = paciente.Nome });
            }

            return pacientesRetorno.Any()
                ? Ok(pacientesRetorno)
                : BadRequest("Pacientes não encontrados");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _pacienteRepository.GetPacienteByIdAsync(id);

            var PacienteRetorno = new PacienteDetalhesDto
            {
                id = paciente.Id,
                Nome = paciente.Nome,
                Celular = paciente.Celular,
                Email = paciente.Email,
                Consultas = new List<Consulta>()
            };

            return PacienteRetorno != null
                ? Ok(PacienteRetorno)
                : BadRequest("paciente não encontrado");
        }
    }
}
