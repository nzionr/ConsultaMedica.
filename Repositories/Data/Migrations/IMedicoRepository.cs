using ConsultaMedica.Models;
using System.Collections.Generic;

namespace ConsultaMedica.Repositories
{
    public interface IMedicoRepository
    {
        Medico GetMedicoById(string id);
        IEnumerable<Medico> GetMedicosByEspecialidade(string especialidade);
    }
}
