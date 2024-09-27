using ConsultaMedica.DTOs;
using ConsultaMedica.Models;
using System.Threading.Tasks;

namespace ConsultaMedica.Services
{
    public interface IAgendamentoService
    {
        Task<Agendamento> AgendarConsulta(string idMedico, AgendamentoRequest request);
        Task<Agendamento> AgendarConsultaPorEspecialidade(string nomeEspecialidade, AgendamentoRequest request);
    }
}
