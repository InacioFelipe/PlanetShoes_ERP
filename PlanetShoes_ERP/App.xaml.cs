using Microsoft.Extensions.DependencyInjection;
using PlanetShoes.Core.Interfaces;
using PlanetShoes.Infrastructure.Repositories;
using PlanetShoes.Views;
using PlanetShoes.ViewModels;
using System.Windows;
using PlanetShoes.Infrastructure.Context;

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
            // Configura o DbContext
            services.AddDbContext<PlanetShoesDbContext>();

            // Registra os repositórios
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IMateriaPrimaRepository, MateriaPrimaRepository>();
            services.AddScoped<IPecaCabedalRepository, PecaCabedalRepository>();

            // Registra os ViewModels
            services.AddTransient<CabedalViewModel>();

            // Registra as views
            services.AddTransient<LoginView>();
            services.AddTransient<MainView>();

            // Registra os ViewModels
            services.AddTransient<MainViewModel>();
            services.AddTransient<MateriaPrimaViewModel>();
        }
    }
}