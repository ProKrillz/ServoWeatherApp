﻿using Apache.Arrow;
using Grpc.Core;
using Microsoft.VisualBasic;
using ServoWeatherDomain.API.Entities;
using ServoWeatherDomain.GenericRepositories;
using ServoWeatherService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServoWeatherService.Services
{
    public class TelemetryService(IGenericRepository _service) : ITelemetryService
    {
        private readonly IGenericRepository _service = _service;

        #region TELEMETRY CRUD

        public async Task<List<Telemetry>> GetItemsAsync()
        {
            UriBuilder builder = new(Constants.Constants.BaseUrl) { Path = Constants.Constants.Endpoint };
            return await _service.GetAsync<List<Telemetry>>(builder.Uri);
        }

        public async Task<Telemetry> GetItemByIdAsync(string id)
        {
            UriBuilder builder = new(Constants.Constants.BaseUrl) { Path = $"{Constants.Constants.Endpoint}/{id}" };
            return await _service.GetAsync<Telemetry>(builder.Uri);
        }

        public async Task SaveItemAsync(Telemetry item, bool isNewItem = false)
        {
            if (isNewItem)
            {
                UriBuilder builder = new(Constants.Constants.BaseUrl) { Path = Constants.Constants.Endpoint };
                await _service.PostAsync(builder.Uri, item);
            }
            else
            {
                UriBuilder builder = new(Constants.Constants.BaseUrl) { Path = $"{Constants.Constants.Endpoint}/{item.Id}" };
                await _service.PutAsync(builder.Uri, item);
            }
        }

        public async Task DeleteItemAsync(Telemetry item)
        {
            UriBuilder builder = new(Constants.Constants.BaseUrl) { Path = $"{Constants.Constants.Endpoint}/{item.Id}" };
            bool result = await _service.DeleteAsync(builder.Uri);
        }

        #endregion

        #region ServoMotor

        public async Task ServoMotor(string input)
        {
            UriBuilder builder = new(Constants.Constants.BaseUrl) { Path = $"{Constants.Constants.Endpoint}" };
            await _service.PostAsync(builder.Uri, input);

        }

        #endregion
    }
}