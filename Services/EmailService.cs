using System.Threading.Tasks;

namespace ConsultaMedica.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Implementa��o fict�cia de envio de e-mail
            // Voc� deve substituir isso por uma implementa��o real
            return Task.CompletedTask;
        }
    }
}
