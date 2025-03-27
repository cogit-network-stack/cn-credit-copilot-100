using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media;
using System;
using Windows.UI;

namespace CreditManagement100
{
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

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

    // ViewModels
    public class ShellViewModel
    {
        // Supprimer _selectedNavigationIndex ou l'utiliser
        public int SelectedNavigationIndex { get; set; }
    }

    public class ModuleUnderDevelopmentViewModel { }
    public class MainViewModel { }
    public class LoginViewModel { }
    public class DashboardViewModel { }

    // Extensions utilitaires
    public static class ServiceProviderExtensions
    {
        public static T GetRequiredService<T>(this IServiceProvider provider) where T : class
        {
            return provider.GetRequiredService<T>();
        }
    }

    // Ajout des extensions de couleurs
    public static class ColorExtensions
    {
        public static Color ToColor(this string hexColor)
        {
            hexColor = hexColor.Replace("#", "");
            return Color.FromArgb(
                Convert.ToByte(hexColor.Substring(0, 2), 16),
                Convert.ToByte(hexColor.Substring(2, 2), 16),
                Convert.ToByte(hexColor.Substring(4, 2), 16),
                255
            );
        }
    }
}