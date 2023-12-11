using LNDP_API.Dtos;

namespace LNDP_API.Services
{
    public abstract class IEmailService
    {
        public abstract void SendEmail(EmailDto emailDto);
    }
}