using ServoWeatherDomain.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherService.Services.Interfaces
{
    public interface ITelemetryService
    {
        Task<List<Telemetry>> GetItemsAsync();
        Task<Telemetry> GetItemByIdAsync(string id);
        Task SaveItemAsync(Telemetry item, bool isNewItem);
        Task DeleteItemAsync(Telemetry item);
        Task ServoMotor(string input);
    }
}
