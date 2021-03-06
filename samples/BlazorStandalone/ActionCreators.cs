﻿using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using BlazorRedux;

namespace BlazorStandalone
{
    public static class ActionCreators
    {
        public static async Task LoadWeather(Dispatcher<IAction> dispatch, HttpClient http)
        {
            dispatch(new ClearWeatherAction());

            var forecasts = await http.GetJsonAsync<WeatherForecast[]>(
                "/sample-data/weather.json");

            dispatch(new ReceiveWeatherAction
            {
                Forecasts = forecasts
            });
        }
    }
}