using Microsoft.Extensions.Options;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;

namespace CrudCoreOklab.Servicios
{
    public class ServicioEmail
    {
        private readonly ConfiguracionEmail _configuracionEmail;

        public ServicioEmail(IOptions<ConfiguracionEmail> configuracionEmail)
        {
            _configuracionEmail = configuracionEmail.Value;

        }

        public async Task EnviarEmailAsync(string paraEmail, string asunto, string mensaje)
        {
            var mensajeEmail = new MimeMessage();
            mensajeEmail.From.Add(new MailboxAddress("OKLAB", _configuracionEmail.Username));
            mensajeEmail.To.Add(new MailboxAddress("", paraEmail));
            mensajeEmail.Subject = asunto;
            mensajeEmail.Body = new TextPart("html") { Text = mensaje };

            using (var cliente = new MailKit.Net.Smtp.SmtpClient())
            {
                await cliente.ConnectAsync(_configuracionEmail.Host, _configuracionEmail.Port, SecureSocketOptions.StartTls);
                await cliente.AuthenticateAsync(_configuracionEmail.Username, _configuracionEmail.Password);
                await cliente.SendAsync(mensajeEmail);
                await cliente.DisconnectAsync(true);
            }
        }
    }
}
