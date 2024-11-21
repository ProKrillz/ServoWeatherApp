using Azure;
using ServoWeatherService.Models;
using ServoWeatherService.Services.Interfaces;
using System.Net.Http.Json;
using System.Text.Json;

namespace ServoWeatherService.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService()
    {
        
        _httpClient = new() { BaseAddress = new Uri("https://localhost:7260") } ;

    }

    public async Task<bool> SaveUserAsync(User user)
    {
        var result = await _httpClient.PostAsJsonAsync(
            "register", new
            {
                user.Email,
                user.Password
            });
        if (result.IsSuccessStatusCode)
            return true;

        else
            return false;
    }
    public async Task<LoginToken> UserLoginAsync(UserLogin user)
    {
        LoginToken loginToken = new();
        var result = await _httpClient.PostAsJsonAsync(
            "login", new
            {
                user.Email,
                user.Password
            });
        
        if (result.IsSuccessStatusCode)
        {
            string content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LoginToken>(content);
        }
        else
            return loginToken;
    }
}
