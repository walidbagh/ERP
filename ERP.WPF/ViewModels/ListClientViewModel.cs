using ERP.Domain.Models;
using ERP.Domain.Services;
using ERP.WPF.Commands;
using ERP.WPF.Services;
using ERP.WPF.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ERP.WPF.ViewModels
{
    public class ListClientViewModel : ViewModelBase
    {
        private readonly ObservableCollection<ClientViewModel> _clients;
        public IEnumerable<ClientViewModel> Clients => _clients;
        public ICommand LoadAllClientsCommand { get; }
        public ICommand CreateClientCommand { get; }
        public ListClientViewModel(NavigationStore navigationStore,
            IDataService<Client> clientService,
            INavigationService<CreateClientViewModel> createClientNavigationService)
        {
            _clients = new ObservableCollection<ClientViewModel>();
            LoadAllClientsCommand = new LoadAllClientsCommand(this, clientService);
            CreateClientCommand = new NavigateCommand<CreateClientViewModel>(createClientNavigationService);
        }

        public static ListClientViewModel LoadListClientViewModel(
            NavigationStore navigationStore,
            IDataService<Client> clientService,
            INavigationService<CreateClientViewModel> createClientNavigationService)
        {
            ListClientViewModel listClientViewModel = new ListClientViewModel(navigationStore, clientService, createClientNavigationService);
            listClientViewModel.LoadAllClientsCommand.Execute(null);

            return listClientViewModel;
        }
        public void UpdateClients(IEnumerable<Client> clients)
        {
            _clients.Clear();

            foreach (Client client in clients)
            {
                ClientViewModel clientViewModel = new ClientViewModel(client);
                _clients.Add(clientViewModel);
            }
        }
    }
}
