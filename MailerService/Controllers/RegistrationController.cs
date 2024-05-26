using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly EmailService _emailService;

    public RegistrationController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> ConfirmRegistration([FromBody] RegistrationRequest request)
    {
        var subject = "Confirm your registration";
        var body = $"Hello {request.Name},\n\nPlease confirm your registration by clicking the link below:\n\n{request.ConfirmationLink}";

        await _emailService.SendEmailAsync(request.Email, subject, body);
        return Ok(new { message = "Confirmation email sent successfully" });
    }
}

public class RegistrationRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string ConfirmationLink { get; set; }
}
