
namespace ConsultaMedica.DTOs
{
    public class AgendamentoRequest
    {
        public string PacienteId { get; set; }
        public DateTime Data { get; set; }
    }
}

public class AgendamentoRequest
{
    public string IdPaciente { get; set; }
    public DateTime DataConsulta { get; set; }
}

