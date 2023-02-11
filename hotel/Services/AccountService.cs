using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using zlobek.Entities;
using System.Linq;

public class AccountService : IAccountService
{
    private readonly nurseryDbContext _context;

    public AccountService(nurseryDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Account>> GetAllAccounts()
    {
        return await _context.Accounts.ToListAsync();
    }

    public async Task<Account> GetAccountById(int id)
    {
        return await _context.Accounts.FindAsync(id);
    }

    public async Task<Account> CreateAccount(Account account)
    {
        _context.Accounts.Add(account);
        await _context.SaveChangesAsync();

        return account;
    }

    public async Task<Account> UpdateAccount(int id, Account account)
    {
        if (id != account.AccountId)
        {
            throw new ArgumentException("Invalid account ID.");
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
                throw new ArgumentException("Account not found.");
            }
            else
            {
                throw;
            }
        }

        return account;
    }

    public async Task DeleteAccount(int id)
    {
        var account = await _context.Accounts.FindAsync(id);
        if (account == null)
        {
            throw new ArgumentException("Account not found.");
        }

        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }

    private bool AccountExists(int id)
    {
        return _context.Accounts.Any(e => e.AccountId == id);
    }
}
