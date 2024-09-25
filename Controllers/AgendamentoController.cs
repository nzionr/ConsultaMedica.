using Microsoft.AspNetCore.Mvc;

public class AgendamentoController : ControllerBase
{
    private AgendamentoService _agendamentoService;
    private MedicoService _medicoService;

    public AgendamentoController(AgendamentoService agendamentoService, MedicoService medicoService)
    {
        _agendamentoService = agendamentoService;
        _medicoService = medicoService;
    }

    [HttpPost("{nomeEspecialidade}/agendamento")]
    public IActionResult CriarAgendamentoPorEspecialidade(string nomeEspecialidade, [FromBody] AgendamentoRequest request)
    {
        var medico = _medicoService.ObterMedicoPorEspecialidade(nomeEspecialidade);
        if (medico == null)
        {
            return NotFound("Nenhum médico disponível para essa especialidade.");
        }

        var agendamento = _agendamentoService.CriarAgendamento(request.IdPaciente, medico.ID, request.Data);

        if (agendamento == null)
        {
            return BadRequest("Falha ao criar agendamento.");
        }

        return Ok(agendamento);
    }
}