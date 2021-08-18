using MatrixHeroes.Models.Dtos.Requests;
using MatrixHeroes.Models.Dtos.Responses;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MatrixHeroes.Auth
{
    public interface IAuthRepo
    {
        Task<RegistrationResponse> Register(UserRegistrationDto user);
        Task<RegistrationResponse> Login(UserLoginRequest user);
        string GenerateJwtToken(IdentityUser user);
    }
}
