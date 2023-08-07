using Consultorio.Models.Entities;

namespace Consultorio.Models.Dtos
{
    public class PacienteDetalhesDto
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Cpf { get; set; }
        public List<Consulta> Consultas { get; set; }
    }
}
