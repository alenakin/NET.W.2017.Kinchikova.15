using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using BLL.Interface;
using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Class for account service.
    /// </summary>
    public class AccountService : IAccountService
    {
        #region Fields
        private IRepository repository;
        private int accountNum;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates new account service using specified repository.
        /// </summary>
        /// <param name="repository">Repository for account service.</param>
        public AccountService(IRepository repository)
        {
            this.repository = repository;
            this.accountNum = repository.GetAllAccounts().Count();
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Adds money for specified account.
        /// </summary>
        /// <param name="accountNumber">Number of account on which to add.</param>
        /// <param name="amount">Amount of money.</param>
        public void DepositAccount(string accountNumber, decimal amount)
        {
            Account account = repository.GetByNumber(accountNumber).ToAccount();
            account.Deposit(amount);
            repository.Update(account.ToAccountDto());
        }

        /// <summary>
        /// Gets all accounts.
        /// </summary>
        /// <returns>Sequance of accounts.</returns>
        public IEnumerable<Account> GetAllAccounts()
        {
            foreach (var account in repository.GetAllAccounts())
            {
                yield return account.ToAccount();
            }
        }

        /// <summary>
        /// Creates new account.
        /// </summary>
        /// <param name="name">Name of account's owner.</param>
        /// <param name="accountType">Type of account.</param>
        /// <param name="creator">Service for creating number of account.</param>
        public void OpenAccount(string name, string email, AccountType accountType, IAccountNumberCreateService creator)
        {
            Account account = null;
            switch(accountType)
            {
                case AccountType.Base:
                    account = new BaseAccount(creator.Create(accountNum++), name, email);
                    break;
                case AccountType.Gold:
                    account = new GoldAccount(creator.Create(accountNum++), name, email);
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount(creator.Create(accountNum++), name, email);
                    break;
            }
            repository.Create(account.ToAccountDto());
        }

        /// <summary>
        /// Withdraws money from specified account.
        /// </summary>
        /// <param name="accountNumber">Number of account from which to withdraw.</param>
        /// <param name="amount">Amount of money to withdraw.</param>
        public void WithdrawAccount(string accountNumber, decimal amount)
        {
            Account account = repository.GetByNumber(accountNumber).ToAccount();
            account.Withdraw(amount);
            repository.Update(account.ToAccountDto());
        }
        #endregion
    }
}
