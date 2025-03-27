using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.UI.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CreditManagement100.Core.Services;
using CreditManagement100.Features.Common;

namespace CreditManagement100.Features.Shell
{
    public class ShellViewModel : ObservableObject
    {
        private INavigationService _navigationService;
        private bool _isSidePanelExpanded = true;
        private bool _hasNotifications = true;
        private int _selectedNavigationIndex = 0;

        // Navigation items collection
        public ObservableCollection<NavigationItem> NavigationItems { get; } = new ObservableCollection<NavigationItem>();

        // Side panel state properties
        public bool IsSidePanelExpanded
        {
            get => _isSidePanelExpanded;
            set
            {
                SetProperty(ref _isSidePanelExpanded, value);
                OnPropertyChanged(nameof(SidePanelWidth));
                OnPropertyChanged(nameof(SidePanelToggleIcon));
                OnPropertyChanged(nameof(SidePanelToggleButtonAlignment));
            }
        }

        public double SidePanelWidth => IsSidePanelExpanded ? 250 : 60;
        public string SidePanelToggleIcon => IsSidePanelExpanded ? "\uE010" : "\uE011"; // Left or Right arrow
        public HorizontalAlignment SidePanelToggleButtonAlignment => IsSidePanelExpanded ? HorizontalAlignment.Right : HorizontalAlignment.Center;

        // Notification indicator
        public bool HasNotifications
        {
            get => _hasNotifications;
            set => SetProperty(ref _hasNotifications, value);
        }

        // Commands
        public ICommand ToggleSidePanelCommand { get; }
        public ICommand NavigateToModuleCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ShowAboutDialogCommand { get; }

        public ShellViewModel()
        {
            // Initialize commands
            ToggleSidePanelCommand = new RelayCommand(() => IsSidePanelExpanded = !IsSidePanelExpanded);
            NavigateToModuleCommand = new RelayCommand<string>(NavigateToModule);
            LogoutCommand = new RelayCommand(Logout);
            ShowAboutDialogCommand = new RelayCommand(ShowAboutDialog);
        }

        public void Initialize()
        {
            // Populate navigation items
            NavigationItems.Clear();
            NavigationItems.Add(new NavigationItem { Label = "Tableau de bord", Icon = "\uE80F", Module = "Dashboard", IsSelected = true });
            NavigationItems.Add(new NavigationItem { Label = "Sociétés", Icon = "\uE731", Module = "Companies" });
            NavigationItems.Add(new NavigationItem { Label = "Emprunts", Icon = "\uE8C0", Module = "Loans" });
            NavigationItems.Add(new NavigationItem { Label = "Comptabilisation", Icon = "\uE94C", Module = "Accounting" });
            NavigationItems.Add(new NavigationItem { Label = "États", Icon = "\uE932", Module = "Reports" });
            NavigationItems.Add(new NavigationItem { Label = "Utilisateurs", Icon = "\uE716", Module = "Users" });
            NavigationItems.Add(new NavigationItem { Label = "Paramètres", Icon = "\uE713", Module = "Settings" });

            // Setup command for each navigation item
            foreach (var item in NavigationItems)
            {
                item.Command = new RelayCommand(() => SelectNavigationItem(item));
            }

            // Navigate to default module
            NavigateToModule("Dashboard");
        }

        public void SetNavigationService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private void SelectNavigationItem(NavigationItem selectedItem)
        {
            // Update selection state
            foreach (var item in NavigationItems)
            {
                item.IsSelected = item == selectedItem;
            }

            // Navigate to the selected module
            NavigateToModule(selectedItem.Module);
        }

        private void NavigateToModule(string moduleName)
        {
            if (_navigationService != null)
            {
                // Currently all modules except Dashboard will show the "Under development" page
                if (moduleName == "Dashboard")
                {
                    _navigationService.Navigate(typeof(ModuleUnderDevelopmentPage), "Tableau de bord");
                }
                else
                {
                    _navigationService.Navigate(typeof(ModuleUnderDevelopmentPage), moduleName);
                }
            }
        }

        private void Logout()
        {
            // TODO: Implement logout logic
        }

        private void ShowAboutDialog()
        {
            // TODO: Implement about dialog logic
        }
    }

    // Navigation item class
    public class NavigationItem : ObservableObject
    {
        private bool _isSelected;

        public string Label { get; set; }
        public string Icon { get; set; }
        public string Module { get; set; }
        public ICommand Command { get; set; }

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }
    }
}
