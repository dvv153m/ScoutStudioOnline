using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScoutStudioOnline.Core.Auth;
using ScoutStudioOnline.Core.Map;
using ScoutStudioOnline.Core.OnlineData;
using ScoutStudioOnline.Core.Unit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScoutStudioOnline
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddSingleton<MapsService>()
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<OnlineDataService>()
                .AddScoped<UnitService>()
                .AddBlazoredLocalStorage()
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });//из файла appsettings.json

            await builder.Build().RunAsync();
        }
    }

    //amcharts пример без анимаций
    //в солюшене добавить папку Components и в нее добавить AmChartsComponent и LeafletMapComponent
    //d:\Test\Chart\amchart\
    //https://webtest.scout-gps.ru
}
