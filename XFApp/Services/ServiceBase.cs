using System;
using System.Net.Http;
using Xamarin.Essentials;

namespace XFApp.Services
{
    public class ServiceBase
    {
        protected const string BaseAddress = "http://0.0.0.0:5000";

        protected bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;


        protected readonly HttpClient Client;

        protected ServiceBase()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(BaseAddress);

        }
    }
}
