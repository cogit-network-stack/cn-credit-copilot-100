using Microsoft.UI.Xaml;
using Microsoft.Extensions.DependencyInjection;
using CreditManagement100.Core.Services;
using CreditManagement100.Features.Shell;
using CreditManagement100.Features.Login;
using CreditManagement100.Infrastructure.Data;
using CreditManagement100.Features.Common;

namespace CreditManagement100
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; }

        /// <summary>
        /// Initializes the singleton application object.
        /// </summary>
        public App()
        {
            this.InitializeComponent();

            Services = ConfigureServices();
        }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register core services
            services.AddSingleton<INavigationService, NavigationService>();

            // Register ViewModels
            services.AddTransient<ShellViewModel>();
            services.AddTransient<ModuleUnderDevelopmentViewModel>();

            // Register views
            services.AddTransient<ShellPage>();
            services.AddTransient<ModuleUnderDevelopmentPage>();

            return services.BuildServiceProvider();
        }

        /// <summary>
        /// Invoked when the application is launched.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            m_window = new MainWindow();
            m_window.Activate();
        }

        private Window m_window;
    }
}
