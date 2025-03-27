using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;

namespace CreditManagement100
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public static App CurrentApp => (App)Current;
        public IServiceProvider Services => _serviceProvider;

        public App()
        {
            _serviceProvider = ConfigureServices();
            InitializeComponent();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Enregistrement des services
            services.AddSingleton<ShellViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<DashboardViewModel>();
            services.AddTransient<ModuleUnderDevelopmentViewModel>();

            return services.BuildServiceProvider();
        }

        public T GetService<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            base.OnLaunched(args);
        }
    }

    // Extensions utilitaires
    public static class ServiceProviderExtensions
    {
        public static T GetService<T>(this IServiceProvider provider) where T : class
        {
            return provider.GetRequiredService<T>();
        }
    }

    // ViewModels
    public class ShellViewModel
    {
        public int NavigationIndex { get; set; }
    }

    public class ModuleUnderDevelopmentViewModel { }
    public class MainViewModel { }
    public class LoginViewModel { }
    public class DashboardViewModel { }

    // Utilitaire de gestion des couleurs
    public static class ColorHelper
    {
        public static Microsoft.UI.Color ToMicrosoftColor(string hexColor)
        {
            hexColor = hexColor.Replace("#", "");
            return Microsoft.UI.Color.FromArgb(
                255,
                Convert.ToByte(hexColor.Substring(0, 2), 16),
                Convert.ToByte(hexColor.Substring(2, 2), 16),
                Convert.ToByte(hexColor.Substring(4, 2), 16)
            );
        }
    }
}