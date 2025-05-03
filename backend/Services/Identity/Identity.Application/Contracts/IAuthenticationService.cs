using Identity.Application.DTOs;
using Identity.Domain.Entities;

namespace Identity.Application.Contracts
{
    public interface IAuthenticationService
    {
        Task<User> ValidateUser(UserCredentialsDTO userCredentials);
        Task<AuthenticationModel> CreateAuthenticationModel(User user);
        Task RemoveRefreshToken(User user, string refreshToken);
    }
}
