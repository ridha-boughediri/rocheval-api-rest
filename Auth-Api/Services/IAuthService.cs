using AuthApi.Models;

namespace AuthApi.Services
{
    public interface IAuthService
    {
        string Authenticate(UserLogin userLogin);
        User Register(User user);
    }
}
