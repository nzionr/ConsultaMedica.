using ConsultaMedica.DTOs;
using ConsultaMedica.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ConsultaMedica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;

        public AgendamentoController(IAgendamentoService agendamentoService)
        {
            _agendamentoService = agendamentoService;
        }

        [HttpPost("medicos/{medicoId}/agendamento")]
        public async Task<IActionResult> AgendarConsulta(string medicoId, AgendamentoRequest request)
        {
            var agendamento = await _agendamentoService.AgendarConsulta(medicoId, request);
            return Ok(agendamento);
        }

        [HttpPost("especialidades/{especialidade}/agendamento")]
        public async Task<IActionResult> AgendarConsultaPorEspecialidade(string especialidade, AgendamentoRequest request)
        {
            var agendamento = await _agendamentoService.AgendarConsultaPorEspecialidade(especialidade, request);
            return Ok(agendamento);
        }
    }
}
