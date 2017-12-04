using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Interface for repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets all accounts from repository.
        /// </summary>
        /// <returns>Sequance of accounts.</returns>
        IEnumerable<AccountDto> GetAllAccounts();

        /// <summary>
        /// Adds new account to repository.
        /// </summary>
        /// <param name="account">Account to add</param>
        void Create(AccountDto account);

        /// <summary>
        /// Gets account by number from repository.
        /// </summary>
        /// <param name="account">Number of account to find.</param>
        /// <returns>Account from repository or null if account wasn't found.</returns>
        AccountDto GetByNumber(string account);

        /// <summary>
        /// Updates information about account in repository.
        /// </summary>
        /// <param name="account">Account to update.</param>
        void Update(AccountDto account);
        //etc
    }
}
