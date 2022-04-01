using ERP.WPF.Commands;
using ERP.WPF.Services;
using ERP.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ERP.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigateListClientCommand { get; }
        public HomeViewModel(INavigationService<ListClientViewModel> listClientNavigationService)
        {
            NavigateListClientCommand = new NavigateCommand<ListClientViewModel>(listClientNavigationService);
        }
    }
}
