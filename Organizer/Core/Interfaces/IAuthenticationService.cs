using Core.DTOs.Authentication;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IAuthenticationService
    {
        Task RegisterAsync(
            RegistrationDTO data, string CallbackUrl);
    }
}
