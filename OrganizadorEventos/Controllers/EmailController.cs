using Microsoft.AspNetCore.Mvc;
using OrganizadorEventos.ServicesApp;
[ApiController]
[Route("[controller]")]

public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public IActionResult SendEmail(EmailDTO request)
    {
        _emailService.SendEmail(request);
        return Ok();
    }
}

