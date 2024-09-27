using ConsultaMedica.Models;
using ConsultaMedica.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ConsultaMedica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet("{id}")]
        public ActionResult<Medico> GetMedicoById(string id)
        {
            var medico = _medicoService.GetMedicoById(id);
            return Ok(medico);
        }

        [HttpGet("especialidades/{especialidade}")]
        public ActionResult<IEnumerable<Medico>> GetMedicosByEspecialidade(string especialidade)
        {
            var medicos = _medicoService.GetMedicosByEspecialidade(especialidade);
            return Ok(medicos);
        }
    }
}
