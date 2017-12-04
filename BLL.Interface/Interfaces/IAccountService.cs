using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Interface for service for working with account.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>Sequance of accounts.</returns>
        IEnumerable<Account> GetAllAccounts();

        /// <summary>
        /// Creates new account.
        /// </summary>
        /// <param name="name">Name of account's owner.</param>
        /// <param name="accountType">Type of account.</param>
        /// <param name="creator">Service for creating number of account.</param>
        void OpenAccount(string name, AccountType accountType, IAccountNumberCreateService creator);

        /// <summary>
        /// Adds money for specified account.
        /// </summary>
        /// <param name="accountNumber">Number of account on which to add.</param>
        /// <param name="amount">Amount of money.</param>
        void DepositAccount(string accountNumber, decimal amount);

        /// <summary>
        /// Withdraws money from specified account.
        /// </summary>
        /// <param name="accountNumber">Number of account from which to withdraw.</param>
        /// <param name="amount">Amount of money to withdraw.</param>
        void WithdrawAccount(string accountNumber, decimal amount);
    }
}
