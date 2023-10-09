using LNDP_API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mail;
namespace LNDP_API.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase{
        [HttpPost]
        public async Task<ActionResult> PostEmail(EmailDto emailDto)
        {
            string correoUsuario = emailDto.Email;
            string asunto = emailDto.Nombre;
            string mensaje = emailDto.Mensaje;

             MailMessage mensajeCorreo = new MailMessage
            {
                From = new MailAddress(correoUsuario), 
                Subject = asunto,
                Body = mensaje
            };
            mensajeCorreo.To.Add("ssanchezp9@gmail.com ");
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"); 
            try
            {
                smtpClient.Send(mensajeCorreo);
                return Ok(new { Message = "Enviado con exito"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "No se ha podido enviar" + ex.Message });
            }
            finally
            {
                mensajeCorreo.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}