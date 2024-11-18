﻿using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ServoWeatherDomain.GenericRepositories
{
    public class GenericRepository : IGenericRepository
    {
        readonly HttpClient _client;
        readonly JsonSerializerOptions _serializerOptions;

        public GenericRepository()
        {
            _client = new HttpClient();

            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }


        #region GET
        public async Task<T?> GetAsync<T>(Uri uri, string authToken = "")
        {
            ConfigureHttpClient(authToken);

            T? result = default;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<T>(content, _serializerOptions);
                    Debug.WriteLine(@"+++++ Item(s) successfully received.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"----- ERROR {0}", ex.Message);
            }
            return result;
        }
        #endregion

        #region POST
        public async Task<bool> PostAsync<T>(Uri uri, T data, string authToken = "")
        {
            ConfigureHttpClient(authToken);

            try
            {
                string json = JsonSerializer.Serialize<T>(data, _serializerOptions);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage? response = null;
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"+++++ Item successfully created.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"----- ERROR {0}", ex.Message);
            }
            return false;
        }

        public async Task<R> PostAsync<T, R>(Uri uri, T data, string authToken = "")
        {

            ConfigureHttpClient(authToken);

            R result = default;

            try
            {
                string json = JsonSerializer.Serialize<T>(data, _serializerOptions);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"+++++ Item successfully created.");
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<R>(jsonResult, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"----- ERROR {0}", ex.Message);
            }
            return result;
        }
        #endregion

        #region PUT
        public async Task<bool> PutAsync<T>(Uri uri, T data, string authToken = "")
        {
            ConfigureHttpClient(authToken);

            try
            {
                string json = JsonSerializer.Serialize<T>(data, _serializerOptions);
                StringContent content = new(json, Encoding.UTF8, "application/json");

                HttpResponseMessage? response = null;
                response = await _client.PutAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"+++++ Item successfully updated.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"----- ERROR {0}", ex.Message);
            }
            Debug.WriteLine(@"----- Item NOT updated!");
            return false;
        }
        #endregion

        #region DELETE
        public async Task<bool> DeleteAsync(Uri uri, string authToken = "")
        {
            try
            {
                HttpResponseMessage response = await _client.DeleteAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"+++++ TodoItem successfully deleted.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"----- ERROR {0}", ex.Message);
            }
            Debug.WriteLine(@"----- Item NOT deleted!");
            return false;
        }
        #endregion

        #region HELPER
        private void ConfigureHttpClient(string authToken)
        {
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (!string.IsNullOrEmpty(authToken))
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }
            else
            {
                _client.DefaultRequestHeaders.Authorization = null;
            }
        }
        #endregion
    }
}
