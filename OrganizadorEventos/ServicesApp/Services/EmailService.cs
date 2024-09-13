namespace OrganizadorEventos.ServicesApp.Models
{
    public class EmailService : IEmailService
    {
        private readonly EmailMessageBuilder _emailMessageBuilder;
        private readonly EmailSender _emailSender;

        public EmailService(IConfiguration config)
        {
            _emailMessageBuilder = new EmailMessageBuilder(config);
            _emailSender = new EmailSender(config);
        }

        public void SendEmail(EmailDTO request)
        {
            var email = _emailMessageBuilder.BuildEmailMessage(request);
            _emailSender.SendEmail(email);
        }
    }
}
