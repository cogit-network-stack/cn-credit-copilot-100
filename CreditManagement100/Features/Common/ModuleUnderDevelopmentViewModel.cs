using CommunityToolkit.Mvvm.ComponentModel;

namespace CreditManagement100.Features.Common
{
    public class ModuleUnderDevelopmentViewModel : ObservableObject
    {
        private string _moduleName;

        public string ModuleName
        {
            get => _moduleName;
            set
            {
                SetProperty(ref _moduleName, value);
                OnPropertyChanged(nameof(DevelopmentMessage));
            }
        }

        public string DevelopmentMessage => $"Le module \"{ModuleName}\" sera disponible prochainement.";
    }
}
