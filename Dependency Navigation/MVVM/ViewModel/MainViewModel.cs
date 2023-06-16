using CommunityToolkit.Mvvm.Input;
using Dependency_Navigation.MVVM.Model;
using Dependency_Navigation.MVVM.Model.Services;

namespace Dependency_Navigation.MVVM.ViewModel
{
    public partial class MainViewModel : ViewModels
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

        public MainViewModel(INavigationService navService)
        {
            Navigation = navService;
        }

        [RelayCommand]
        public void GoToHome()
        {
            Navigation.NavigateTo<HomeViewModel>();
        }
        [RelayCommand]
        public void GoToInvoice()
        {
            Navigation.NavigateTo<InvoiceViewModel>();
        }
    }
}
