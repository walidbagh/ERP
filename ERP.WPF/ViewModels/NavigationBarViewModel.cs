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
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateListClientCommand { get; }

        public NavigationBarViewModel(INavigationService<HomeViewModel> homeNavigationService, INavigationService<ListClientViewModel> listClientNavigationService)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateListClientCommand = new NavigateCommand<ListClientViewModel>(listClientNavigationService);
        }
    }
}
