using Microsoft.UI.Xaml.Controls;
using System;

namespace CreditManagement100.Core.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;

        public void Initialize(Frame frame)
        {
            _frame = frame;
        }

        public bool CanGoBack => _frame != null && _frame.CanGoBack;

        public void GoBack()
        {
            if (CanGoBack)
            {
                _frame.GoBack();
            }
        }

        public void Navigate(Type pageType)
        {
            if (_frame != null)
            {
                _frame.Navigate(pageType);
            }
        }

        public void Navigate(Type pageType, object parameter)
        {
            if (_frame != null)
            {
                _frame.Navigate(pageType, parameter);
            }
        }
    }
}
