using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Zonorai.MudBlazorComponents.Interop;
using Zonorai.Sandbox.Pages;

namespace Zonorai.Sandbox
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddMudServices();
            builder.Services.AddTransient<GoogleQueryAutocomplete>();
            builder.Services.AddMediatR(typeof(Model).Assembly);
            builder.Services.AddValidatorsFromAssembly(typeof(Model).Assembly);
            await builder.Build().RunAsync();
        }
    }
}
