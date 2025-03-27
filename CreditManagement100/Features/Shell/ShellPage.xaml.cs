using Microsoft.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;
using CreditManagement100.Core.Services;

namespace CreditManagement100.Features.Shell
{
    public sealed partial class ShellPage : Page
    {
        public ShellViewModel ViewModel { get; }

        public ShellPage()
        {
            this.InitializeComponent();

            ViewModel = App.Current.Services.GetService<ShellViewModel>();
            ViewModel.Initialize();

            // Initialize navigation service with content frame
            var navigationService = App.Current.Services.GetService<INavigationService>() as NavigationService;
            navigationService.Initialize(ContentFrame);

            // Set navigation service to view model
            ViewModel.SetNavigationService(navigationService);
        }
    }
}
