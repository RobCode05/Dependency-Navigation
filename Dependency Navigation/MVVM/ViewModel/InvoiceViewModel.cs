using CommunityToolkit.Mvvm.Input;
using Dependency_Navigation.MVVM.Model;
using Dependency_Navigation.MVVM.Model.Services;

namespace Dependency_Navigation.MVVM.ViewModel
{
    public partial class InvoiceViewModel : ViewModels
    {
        private INavigationService _navigation;

        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public InvoiceViewModel(INavigationService navService)
        {
            Navigation = navService;
        }

        [RelayCommand]
        public void HomePage()
        {
            Navigation.NavigateTo<HomeViewModel>();
        }
    }
}
