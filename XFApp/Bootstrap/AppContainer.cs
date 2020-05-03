using System;
using Autofac;
using XFApp.Contracts;
using XFApp.Contracts.Services;
using XFApp.Services;
using XFApp.ViewModels;

namespace XFApp.Bootstrap
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //services - general
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<UserService>().As<IUserService>();

            //ViewModels
            builder.RegisterType<PeopleViewModel>();
            builder.RegisterType<FeedViewModel>();
            builder.RegisterType<MyProfileViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<SettingsViewModel>();

            

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
