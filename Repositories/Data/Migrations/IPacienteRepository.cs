using ConsultaMedica.Models;

namespace ConsultaMedica.Repositories
{
    public interface IPacienteRepository
    {
        Paciente GetPacienteById(string id);
    }
}
