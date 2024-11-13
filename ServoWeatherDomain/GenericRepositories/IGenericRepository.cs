using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherDomain.GenericRepositories
{
    public interface IGenericRepository
    {
        Task<T?> GetAsync<T>(Uri uri, string authToken = "");

        Task<bool> PostAsync<T>(Uri uri, T data, string authToken = "");

        Task<R> PostAsync<T, R>(Uri uri, T data, string authToken = "");

        Task<bool> PutAsync<T>(Uri uri, T data, string authToken = "");

        Task<bool> DeleteAsync(Uri uri, string authToken = "");
    }
}
