using ConsultaMedica.Models;
using System.Collections.Generic;

namespace ConsultaMedica.Services
{
    public interface IMedicoService
    {
        Medico GetMedicoById(string id);
        IEnumerable<Medico> GetMedicosByEspecialidade(string especialidade);
    }
}
