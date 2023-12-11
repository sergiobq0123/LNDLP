using LNDP_API.Dtos;
using LNDP_API.Services;
using Microsoft.AspNetCore.Mvc;
namespace LNDP_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public async Task<ActionResult> PostEmail(EmailDto emailDto)
        {
            _emailService.SendEmail(emailDto);
            return Ok();
        }
    }
}