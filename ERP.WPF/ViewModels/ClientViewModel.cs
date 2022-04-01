using ERP.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.WPF.ViewModels
{
    public class ClientViewModel: ViewModelBase
    {
        private readonly Client _client;

        public int Id => _client.Id;
        public string Name => _client.Name;
        public string Address => _client.Address;
        public string PhoneNumber => _client.PhoneNumber;

        public ClientViewModel(Client client)
        {
            _client = client;
        }
    }
}
