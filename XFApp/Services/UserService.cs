using System;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XFApp.Contracts.Services;
using XFApp.Models;
using Newtonsoft.Json;

namespace XFApp.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService()
        {
        }

        public async Task<User> GetUser(string id = null)
        {
            return null;
        }
    }
}
