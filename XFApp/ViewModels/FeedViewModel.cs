using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XFApp.Models;
using XFApp.Contracts.Services;

namespace XFApp.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        public FeedViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}