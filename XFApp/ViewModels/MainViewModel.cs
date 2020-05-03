using System;
using XFApp.Contracts.Services;

namespace XFApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
