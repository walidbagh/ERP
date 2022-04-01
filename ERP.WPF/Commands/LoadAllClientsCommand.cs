using ERP.Domain.Models;
using ERP.Domain.Services;
using ERP.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.WPF.Commands
{
    public class LoadAllClientsCommand : AsyncCommandBase
    {
        private readonly ListClientViewModel _listClientViewModel;
        private readonly IDataService<Client> _clientService;

        public LoadAllClientsCommand(ListClientViewModel listClientViewModel, IDataService<Client> clientService)
        {
            _listClientViewModel = listClientViewModel;
            _clientService = clientService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            IEnumerable<Client> clients = await _clientService.GetAll();
            _listClientViewModel.UpdateClients(clients);
        }
    }
}
