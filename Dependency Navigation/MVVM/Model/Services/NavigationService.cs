

using System;

namespace Dependency_Navigation.MVVM.Model.Services
{
    public interface INavigationService
    {
        ViewModels CurrentView { get; }
        void NavigateTo<T>() where T : ViewModels;
    }
    public class NavigationService : ViewModels, INavigationService
    {
        private readonly Func<Type, ViewModels> _viewModelFactory;
        private ViewModels _currentView;
        public ViewModels CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            } 
        }
        
        public NavigationService(Func<Type, ViewModels> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<TViewModels>() where TViewModels : ViewModels
        {
            ViewModels viewmodel = _viewModelFactory.Invoke(typeof(TViewModels));
            CurrentView = viewmodel;
        }
    }
}
