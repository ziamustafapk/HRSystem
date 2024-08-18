using HRSystem.Server.DataTransferObjects.Admin;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace HRSystem.Server.Services.Admin
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserForRegistrationDto userForRegistration);
        Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
        Task<TokenDto> CreateToken(bool populateExp);

        Task<TokenDto> RefreshToken(TokenDto tokenDto);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
