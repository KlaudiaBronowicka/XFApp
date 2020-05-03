using System;
using System.Threading.Tasks;
using XFApp.ViewModels;

namespace XFApp.Contracts.Services
{
    public interface INavigationService
    {
        Task OpenModal(Type viewModelType);

        Task OpenModal(Type viewModelType, object parameter);

        Task OpenModal<TViewModel>() where TViewModel : BaseViewModel;

        Task OpenModal<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task CloseModal();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateToAsync(Type viewModelType);

        Task ClearBackStack();

        Task NavigateToAsync(Type viewModelType, object parameter);

        Task NavigateBackAsync();

        Task RemoveLastFromBackStackAsync();

        Task PopToRootAsync();
    }
}
