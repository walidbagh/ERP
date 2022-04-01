using ERP.Domain.Models;
using ERP.Domain.Services;
using ERP.EntityFramework.Services;
using ERP.WPF.Services;
using ERP.WPF.Stores;
using ERP.WPF.ViewModels;
using System.Windows;

namespace ERP.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;
        private readonly IDataService<Client> _clientService;

        public App()
        {
            _navigationStore = new NavigationStore();
            _clientService = new GenericDataService<Client>(new EntityFramework.ERPDbContextFactory());

        }

        protected override void OnStartup(StartupEventArgs e)
        {

            INavigationService<HomeViewModel> homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();

            Window window = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            window.Show();

            base.OnStartup(e);
        }

        private INavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(
                _navigationStore, 
                () => new HomeViewModel(CreateListClientNavigationService()),
                CreateNavigationBarViewModel);
        }

        private INavigationService<ListClientViewModel> CreateListClientNavigationService()
        {
            return new LayoutNavigationService<ListClientViewModel>(
                _navigationStore, 
                () => ListClientViewModel.LoadListClientViewModel(_navigationStore, _clientService, CreateCreateClientNavigationService()),
                CreateNavigationBarViewModel);
        }

        private INavigationService<CreateClientViewModel> CreateCreateClientNavigationService()
        {
            return new NavigationService<CreateClientViewModel>(
                _navigationStore,
                () => new CreateClientViewModel(CreateListClientNavigationService())
                );
        }
        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                CreateHomeNavigationService(),
                CreateListClientNavigationService()
                );
        }
    }
}
