using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using System;

namespace CreditManagement100
{
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();
            InitializeComponent();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Configuration des services
            services.AddSingleton<ShellViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<DashboardViewModel>();

            return services.BuildServiceProvider();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            // Configuration initiale de l'application
            base.OnLaunched(args);
        }
    }

    // Extension pour récupérer facilement les services
    public static class ServiceProviderExtensions
    {
        public static T GetRequiredService<T>(this App app) where T : class
        {
            return app.Services.GetRequiredService<T>();
        }
    }
}