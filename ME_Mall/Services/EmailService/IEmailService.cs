using ME_Mall.Models;

namespace ME_Mall.Services.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDto request);
    }
}
