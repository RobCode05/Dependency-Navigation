using Dependency_Navigation.MVVM.Model;
using Dependency_Navigation.MVVM.Model.Services;
using Dependency_Navigation.MVVM.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Dependency_Navigation
{
   
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            services.AddTransient<MainViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<InvoiceViewModel>();
            services.AddTransient<INavigationService,  NavigationService>();

            services.AddSingleton<Func<Type, ViewModels>>(serviceProvider => viewModelType
            => (ViewModels)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
