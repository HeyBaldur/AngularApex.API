using AngularApex.Data;
using AngularApex.Data.Models;
using AngularApex.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApex.Services.Services
{
    public class AccountService : IAccount
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<AccountService> _logger;

        public AccountService(
            DataContext dataContext,
            ILogger<AccountService> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public async Task<Account> CreateAsync(Guid id)
        {
            if (!await AccountExistAsync(id))
            {
                var accountToSave = new Account()
                {
                    Identificator = id,
                    Name = "AngularApex Account"
                };

                _logger.LogInformation("Save new account in DB.");
                var accnt = await _dataContext.Accounts.AddAsync(accountToSave);
                await _dataContext.SaveChangesAsync();

                _logger.LogInformation($"New account with the id {accnt.Entity.Id} has been created.");
                return accnt.Entity;
            }
            else
            {
                _logger.LogError($"Account with the Id: {id} already exists");
                return new Account() { Identificator = id };
            }
        }

        private async Task<bool> AccountExistAsync(Guid id) =>
            await _dataContext.Accounts.Where(x => x.Identificator == id).AnyAsync();
    }
}
