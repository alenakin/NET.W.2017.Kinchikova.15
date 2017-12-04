using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Repositories
{
    /// <summary>
    /// Class for fake repository.
    /// </summary>
    public class FakeRepository : IRepository
    {
        #region Fields
        private List<AccountDto> accounts = new List<AccountDto>();
        #endregion

        #region Public methods
        /// <summary>
        /// Adds new account to repository.
        /// </summary>
        /// <param name="account">Account to add</param>
        /// <exception cref="ArgumentNullException">Account is null.</exception>
        public void Create(AccountDto account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} can't be null");
            }

            accounts.Add(account);
        }

        /// <summary>
        /// Gets all accounts from repository.
        /// </summary>
        /// <returns>Sequance of accounts.</returns>
        public IEnumerable<AccountDto> GetAllAccounts() => accounts;

        /// <summary>
        /// Gets account by number from repository.
        /// </summary>
        /// <param name="account">Number of account to find.</param>
        /// <returns>Account from repository or null if account wasn't found.</returns>
        /// <exception cref="ArgumentNullException">account is null or empty</exception>
        public AccountDto GetByNumber(string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new ArgumentNullException($"{nameof(account)} can't be null or empty");
            }

            return accounts.Find(x => x.Number == account);
        }

        /// <summary>
        /// Updates information about account in repository.
        /// </summary>
        /// <param name="account">Account to update.</param>
        /// <exception cref="ArgumentNullException">Account is null.</exception>
        public void Update(AccountDto account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} can't be null");
            }

            int i = accounts.FindIndex(x => x.Number == account.Number);
            if (i == -1)
            {
                return;
            }

            accounts[i] = account;
        }
        #endregion
    }
}
