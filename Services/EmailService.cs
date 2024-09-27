using System.Threading.Tasks;

namespace ConsultaMedica.Services
{
    public class EmailService : IEmailService
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Implementação fictícia de envio de e-mail
            // Você deve substituir isso por uma implementação real
            return Task.CompletedTask;
        }
    }
}
