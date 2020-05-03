using System;
using System.Windows.Input;
using XFApp.Contracts.Services;
using XFApp.Models;
using Xamarin.Forms;

namespace XFApp.ViewModels
{
    public class MyProfileViewModel : BaseViewModel
    {
        public MyProfileViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

    }
}
