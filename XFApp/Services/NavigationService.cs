using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFApp.Bootstrap;
using XFApp.Contracts.Services;
using XFApp.ViewModels;
using XFApp.Views;
using Xamarin.Forms;

namespace XFApp.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<Type, Type> _mappings;

        protected Application CurrentApplication => Application.Current;

        public NavigationService()
        {
            _mappings = new Dictionary<Type, Type>();

            CreatePageViewModelMappings();
        }

        public async Task ClearBackStack()
        {
            await CurrentApplication.MainPage.Navigation.PopToRootAsync();
        }

        public async Task NavigateBackAsync()
        {
            await CurrentApplication.MainPage.Navigation.PopAsync();
        }

        public virtual Task RemoveLastFromBackStackAsync()
        {
            if (CurrentApplication.MainPage is MainPage mainPage)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public async Task PopToRootAsync()
        {
            if (CurrentApplication.MainPage is MainPage mainPage)
            {
                await mainPage.Navigation.PopToRootAsync();
            }
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToAsync(Type viewModelType)
        {
            return InternalNavigateToAsync(viewModelType, null);
        }

        public Task NavigateToAsync(Type viewModelType, object parameter)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            var page = CreatePage(viewModelType, parameter);

            if (page is MainPage)
            {
                CurrentApplication.MainPage = page;
            }
            else if (CurrentApplication.MainPage is MainPage)
            {
                var mainPage = CurrentApplication.MainPage as MainPage;

                if (mainPage.CurrentPage is NavigationPage navigationPage)
                {
                    var currentPage = navigationPage.CurrentPage;

                    if (currentPage.GetType() != page.GetType())
                    {
                        await navigationPage.PushAsync(page);
                    }
                }
                else
                {
                    navigationPage = new NavigationPage(page);
                    mainPage.CurrentPage = navigationPage;
                }
            }
            else
            {
                var navigationPage = CurrentApplication.MainPage as NavigationPage;

                if (navigationPage != null)
                {
                    await navigationPage.PushAsync(page);
                }
                else
                {
                    CurrentApplication.MainPage = new NavigationPage(page);
                }
            }

            await (page.BindingContext as BaseViewModel).Initialize(parameter);
        }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }

            var page = Activator.CreateInstance(pageType) as Page;

            var viewModel = AppContainer.Resolve(viewModelType) as BaseViewModel;

            if (parameter != null)
            {
                viewModel.Initialize(parameter);
            }

            page.BindingContext = viewModel;

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(FeedViewModel), typeof(FeedPage));
            _mappings.Add(typeof(MyProfileViewModel), typeof(MyProfilePage));
            _mappings.Add(typeof(MessagesViewModel), typeof(MessagesPage));
            _mappings.Add(typeof(SettingsViewModel), typeof(SettingsPage));
            _mappings.Add(typeof(MainViewModel), typeof(MainPage));
        }

        public Task OpenModal(Type viewModelType)
        {
            return InternalOpenModal(viewModelType, null);
        }

        public Task OpenModal(Type viewModelType, object parameter)
        {
            return InternalOpenModal(viewModelType, parameter);
        }

        public Task OpenModal<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalOpenModal(typeof(TViewModel), null);
        }

        public Task OpenModal<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalOpenModal(typeof(TViewModel), parameter);
        }

        protected virtual async Task InternalOpenModal(Type viewModelType, object parameter)
        {
            var page = CreatePage(viewModelType, parameter);

            await CurrentApplication.MainPage.Navigation.PushModalAsync(new NavigationPage(page));

            await (page.BindingContext as BaseViewModel).Initialize(parameter);
        }

        public Task CloseModal()
        {
            return CurrentApplication.MainPage.Navigation.PopModalAsync();
        }
    }
}
