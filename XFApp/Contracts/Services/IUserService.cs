using System;
using System.Threading.Tasks;
using XFApp.Models;

namespace XFApp.Contracts.Services
{
    public interface IUserService
    {
        Task<User> GetUser(string id = null);
    }
}
