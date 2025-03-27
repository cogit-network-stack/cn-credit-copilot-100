using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;

namespace CreditManagement100.Features.Common
{
    public sealed partial class ModuleUnderDevelopmentPage : Page
    {
        public ModuleUnderDevelopmentViewModel ViewModel { get; }

        public ModuleUnderDevelopmentPage()
        {
            this.InitializeComponent();
            ViewModel = App.Current.Services.GetService<ModuleUnderDevelopmentViewModel>();

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
