using Consultorio.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Consultorio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        List<Agendamento> agendamentos = new List<Agendamento>();
        public AgendamentoController()
        {
            agendamentos.Add(new Agendamento()
            {
                Id = 1,
                NomePaciente = "igor",
                Horario = new DateTime(2023, 07, 31)
            });
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(agendamentos);
        }

        [HttpGet("{id}")]
        public IActionResult GetByid(int id)
        {
            var agendamentoSelecionado = agendamentos.FirstOrDefault(a => a.Id == id);
            return agendamentoSelecionado != null
                ? Ok(agendamentoSelecionado)
                : BadRequest("Erro ao buscar o agendamento");
        }
    }
}
