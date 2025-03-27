using CreditManagement100.Features.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace CreditManagement100.Features.Common
{
    public sealed partial class ModuleUnderDevelopmentPage : Page
    {
        public ModuleUnderDevelopmentViewModel ViewModel { get; }

        public ModuleUnderDevelopmentPage()
        {
            this.InitializeComponent();
            ViewModel = ((App)Application.Current).GetService<ModuleUnderDevelopmentViewModel>();

            // Start animations when page loads
            this.Loaded += ModuleUnderDevelopmentPage_Loaded;
        }

        private void ModuleUnderDevelopmentPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Start gear rotation animation
            RotateGearStoryboard.Begin();

            // Start bouncing dots animation
            BounceDotsStoryboard.Begin();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // If we received a parameter (module name), set it in the view model
            if (e.Parameter is string moduleName)
            {
                ViewModel.ModuleName = moduleName;
            }
        }
    }
}

internal class App : Application
{
    public IServiceProvider Services { get; private set; }

    public App()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        Services = serviceCollection.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ModuleUnderDevelopmentViewModel>();
    }
}
