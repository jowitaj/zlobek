using System.Collections.Generic;
using System.Threading.Tasks;
using zlobek.Entities;

public interface IAccountService
{
    Task<IEnumerable<Account>> GetAllAccounts();
    Task<Account> GetAccountById(int id);
    Task<Account> CreateAccount(Account account);
    Task<Account> UpdateAccount(int id, Account account);
    Task DeleteAccount(int id);
}
