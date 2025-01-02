using Microsoft.Extensions.DependencyInjection;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Data;
using PlanetShoes.Infrastructure.Repositories;
using PlanetShoes.Views;
using System;
using System.Windows;

namespace PlanetShoes
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            _serviceProvider = serviceCollection.BuildServiceProvider();

            // Instancia a LoginView usando o contêiner de DI
            var loginView = _serviceProvider.GetRequiredService<LoginView>();
            loginView.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Configura o DbContext e o repositório
            services.AddDbContext<PlanetShoesDbContext>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Registra as views
            services.AddTransient<LoginView>();
            services.AddTransient<MainView>();
        }
    }
}