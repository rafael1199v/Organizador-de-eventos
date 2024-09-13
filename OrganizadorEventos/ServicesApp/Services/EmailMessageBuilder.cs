using MimeKit;
using MimeKit.Text;

namespace OrganizadorEventos.ServicesApp.Models
{
    public class EmailMessageBuilder
    {
        private readonly IConfiguration _config;

        public EmailMessageBuilder(IConfiguration config)
        {
            _config = config;
        }

        public MimeMessage BuildEmailMessage(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));
            email.To.Add(MailboxAddress.Parse(request.Destinatario));
            email.Subject = request.Asunto;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Contenido
            };

            return email;
        }
    }
}
