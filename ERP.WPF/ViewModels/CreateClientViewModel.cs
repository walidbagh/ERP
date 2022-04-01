using ERP.Domain.Models;
using ERP.EntityFramework.Services;
using ERP.WPF.Commands;
using ERP.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERP.WPF.ViewModels
{
    public class CreateClientViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public ICommand SubmitCommand { get; } 
        public ICommand CancelCommand { get; }

        public CreateClientViewModel(INavigationService<ListClientViewModel> listClientNavigationService)
        {
            SubmitCommand = new CreateClientCommand(
                this, 
                new GenericDataService<Client>(new EntityFramework.ERPDbContextFactory())
                );
            CancelCommand = new NavigateCommand<ListClientViewModel>(listClientNavigationService);
        }
    }
}
