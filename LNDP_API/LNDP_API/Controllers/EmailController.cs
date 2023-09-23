using LNDP_API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LNDP_API.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase{
        [HttpPost]
        public async Task<ActionResult> PostEmail(EmailDto emailDto)
        {
            // var apiKey = "TU_API_KEY_DE_SENDGRID"; // Reemplaza con tu propia API Key de SendGrid
            // var client = new SendGridClient(apiKey);

            // var fromEmail = new EmailAddress(emailDto.email, emailDto.nombre);
            // var toEmail = new EmailAddress("lndp@gmail.com", "Nombre del destinatario");
            // var subject = "Asunto del correo"; // Puedes personalizar el asunto
            // var plainTextContent = emailDto.mensaje;

            // var msg = MailHelper.CreateSingleEmail(fromEmail, toEmail, subject, plainTextContent, "");
            
            // try
            // {
            //     var response = await client.SendEmailAsync(msg);
            //     Console.WriteLine(response.StatusCode);

            //     return Ok("Correo electrónico enviado con éxito.");
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            //     return StatusCode(500, "Error al enviar el correo electrónico.");
            // }
            return Ok();
        }

    }
}