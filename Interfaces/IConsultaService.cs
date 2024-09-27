using ConsultaMedica.Models;
using System.Collections.Generic;

namespace ConsultaMedica.Services
{
    public interface IConsultaService
    {
        IEnumerable<Agendamento> ObterConsultasPorPaciente(string pacienteId);
        IEnumerable<Agendamento> ObterConsultasPorMedico(string medicoId);
        void CancelarConsulta(string agendamentoId);
    }
}
