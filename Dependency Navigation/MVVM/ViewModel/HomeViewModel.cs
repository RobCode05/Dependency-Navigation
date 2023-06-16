using CommunityToolkit.Mvvm.Input;
using Dependency_Navigation.MVVM.Model;
using Dependency_Navigation.MVVM.Model.Services;

namespace Dependency_Navigation.MVVM.ViewModel
{
    public partial class HomeViewModel : ViewModels
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

        public HomeViewModel(INavigationService navService)
        {
            Navigation = navService;
        }
        [RelayCommand]
        public void InvoicePage()
        {
            Navigation.NavigateTo<InvoiceViewModel>();
        }
    }
}
