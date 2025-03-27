using Microsoft.UI.Xaml;
using CreditManagement100.Features.Shell;

namespace CreditManagement100
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            Title = "Credit Management 100";

            // Navigate to shell page
            RootFrame.Navigate(typeof(ShellPage));
        }
    }
}
