using api.DTOs.Auth;

namespace api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);

        Task<string?> LoginAsync(LoginDto dto);
    }
}