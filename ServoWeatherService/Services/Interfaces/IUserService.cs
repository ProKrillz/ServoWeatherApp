using ServoWeatherService.Models;

namespace ServoWeatherService.Services.Interfaces;

public interface IUserService
{
    Task<bool> SaveUserAsync(User user);
    Task<LoginToken> UserLoginAsync(UserLogin user);
}
