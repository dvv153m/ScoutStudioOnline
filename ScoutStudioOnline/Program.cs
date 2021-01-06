using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
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
using System.Security.Claims;
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
                .AddOptions()
                .AddAuthorizationCore()
                .AddScoped<AuthenticationStateProvider, TokenAuthenticationStateProvider>()
                .AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });//из файла appsettings.json

            await builder.Build().RunAsync();
        }
    }

    public class TokenAuthenticationStateProvider : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var anonymousIdentity = new ClaimsIdentity();
            var anonymousPrincipal = new ClaimsPrincipal(anonymousIdentity);

            return new AuthenticationState(anonymousPrincipal);
        }
    }

    //@attribute [Authorize]         @using Microsoft.AspNetCore.Authorization
    //amcharts пример без анимаций
    //в солюшене добавить папку Components и в нее добавить AmChartsComponent и LeafletMapComponent
    //d:\Test\Chart\amchart\
    //https://webtest.scout-gps.ru
}
