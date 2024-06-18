using OrganizadorEventos.ServicesApp.Models;

public interface IEmailService
{
    void SendEmail(EmailDTO request);
}