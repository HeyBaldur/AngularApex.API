using AngularApex.Data.Models;
using System;
using System.Threading.Tasks;

namespace AngularApex.Services.Interfaces
{
    public interface IAccount
    {
        Task<Account> CreateAsync(Guid id);
    }
}
