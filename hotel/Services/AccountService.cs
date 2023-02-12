using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zlobek.Entities;

namespace zlobek.Services
{
    public class AccountService : IAccountService
    {
        private readonly nurseryDbContext _context;
        public AccountService(nurseryDbContext context)
        {
            _context = context;
        }
        public async Task<Account> Login(string email, string password)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email);

            if (account == null)
            {
                return null;
            }

            var passwordHasher = new PasswordHasher<Account>();

            var result = passwordHasher.VerifyHashedPassword(account, account.Password, password);

            return result == PasswordVerificationResult.Success ? account : null;
        }
        public async Task<IEnumerable<Account>> GetAccount()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return null;
            }

            return account;
        }

        public async Task<Account> CreateAccount(Account account)
        {
            try
            {
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();

                return account;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateAccount(int id, Account account)
        {
            if (id != account.AccountId)
            {
                return false;
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return false;
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool AccountExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
