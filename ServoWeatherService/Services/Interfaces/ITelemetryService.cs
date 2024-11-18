using ServoWeatherDomain.API.Entities;

namespace ServoWeatherService.Services.Interfaces
{
    public interface ITelemetryService
    {
        Task<List<Telemetry>> GetItemsAsync(string option);
        Task<Telemetry> GetItemByIdAsync(string id);
        Task SaveItemAsync(Telemetry item, bool isNewItem);
        Task DeleteItemAsync(Telemetry item);
        Task ServoMotor(string input);
    }
}
