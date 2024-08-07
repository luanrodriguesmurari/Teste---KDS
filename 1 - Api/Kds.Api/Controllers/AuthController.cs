using Kds.Domain.Applications;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // Aqui você faria a validação do usuário (ex. verificar credenciais no banco de dados)
        if (request.Username == "test" && request.Password == "password") // Exemplo estático
        {
            var token = _authService.GenerateToken(request.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}