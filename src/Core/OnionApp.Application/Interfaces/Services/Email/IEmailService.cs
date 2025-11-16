using OnionApp.Application.Models.Email;

namespace OnionApp.Application.Interfaces.Services.Email
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest emailRequest);
    }
}
