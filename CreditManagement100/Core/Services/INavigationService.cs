using System;

namespace CreditManagement100.Core.Services
{
    public interface INavigationService
    {
        void Navigate(Type pageType);
        void Navigate(Type pageType, object parameter);
        void GoBack();
        bool CanGoBack { get; }
    }
}
