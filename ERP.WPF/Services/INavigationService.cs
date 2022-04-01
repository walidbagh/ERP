using ERP.WPF.ViewModels;

namespace ERP.WPF.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}