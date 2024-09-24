using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using CryptoTest.Services.Interfaces;
using CryptoTest.Services;

namespace CryptoTest
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ICryptoService, CryptoService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider Services => _serviceProvider;
    }
}
