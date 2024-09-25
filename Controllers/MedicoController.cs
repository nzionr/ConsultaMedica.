using Microsoft.AspNetCore.Mvc;

public class MedicoController : ControllerBase
{
    private AgendamentoService _agendamentoService;

    public MedicoController(AgendamentoService agendamentoService)
    {
        _agendamentoService = agendamentoService;
    }

    [HttpPost("{idMedico}/agendamento")]
    public IActionResult CriarAgendamento(string idMedico, [FromBody] AgendamentoRequest request)
    {
        var agendamento = _agendamentoService.CriarAgendamento(request.IdPaciente, idMedico, request.Data);

        if (agendamento == null)
        {
            return BadRequest("Falha ao criar agendamento.");
        }

        return Ok(agendamento);
    }
}