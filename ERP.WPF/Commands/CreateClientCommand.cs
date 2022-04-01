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
    public class CreateClientCommand : CommandBase
    {
        private readonly CreateClientViewModel _createClientViewModel;
        private readonly IDataService<Client> _clientService;

        public CreateClientCommand(CreateClientViewModel createClientViewModel, IDataService<Client> clientService)
        {
            _createClientViewModel = createClientViewModel;
            _clientService = clientService;
        }

        public override async void Execute(object? parameter)
        {
            Client client = new Client()
            {
                Name = _createClientViewModel.Name,
                Address = _createClientViewModel.Address,
                PhoneNumber = _createClientViewModel.PhoneNumber
            };

            await _clientService.Create(client);
        }
    }
}
