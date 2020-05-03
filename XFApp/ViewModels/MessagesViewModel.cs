using System;
using XFApp.Contracts.Services;

namespace XFApp.ViewModels
{
    public class MessagesViewModel : BaseViewModel
    {
        public MessagesViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
