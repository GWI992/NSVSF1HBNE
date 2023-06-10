using Endpoint.Models.Requests;

namespace Endpoint.Services.Interfaces
{
    public interface IAuthManager
    { 
        Task<bool> ValidateUser(LoginDTO loginDTO);
        Task<string> CreateToken();
    }
}
