using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Abstract class for account.
    /// </summary>
    public abstract class Account
    {
        #region Fields
        protected string number;
        protected string name;
        protected decimal balance;
        protected int points;
        protected string email;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new account using number and owner's name.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        public Account(string accountNumber, string name, string email)
        {
            Number = accountNumber;
            Name = name;
            Email = email;
            Balance = 0;
        }

        /// <summary>
        /// Creates new account using number, owner's name and balance.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        /// <param name="balance">Balance of the account.</param>
        public Account(string accountNumber, string name, string email, decimal balance) : this(accountNumber, name, email)
        {
            Balance = balance;
        }

        /// <summary>
        /// Creates new account using number, owner's name, balance and bonus points.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        /// <param name="balance">Balance of the account.</param>
        /// <param name="points">Bonus point of the account.</param>
        public Account(string accountNumber, string name, string email, decimal balance, int points) : 
            this(accountNumber, name, email, balance)
        {
            Points = points;
        }
        #endregion

        #region Properties
        #region Protected properties
        protected abstract int BalanceCost { get; set; }
        protected abstract int RefillCost { get; set; }
        protected abstract AccountType AccountType { get; set; }
        #endregion

        #region Public properties

        /// <summary>
        /// Name of account's owner.
        /// </summary>
        public string Name
        {
            get => name;

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(value)} can't be null or empty");
                }

                name = value;
            }
        }

        /// <summary>
        /// Email of account's owner.
        /// </summary>
        public string Email
        {
            get => email;

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(value)} can't be null or empty");
                }

                email = value;
            }
        }

        /// <summary>
        /// Number of account.
        /// </summary>
        public string Number
        {
            get => number;

            protected set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(value)} can't be null or empty");
                }

                number = value;
            }
        }

        /// <summary>
        /// Balance of the account.
        /// </summary>
        public decimal Balance
        {
            get => balance;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance cant't be less than 0");
                }

                balance = value;
            }
        }

        /// <summary>
        /// Points of the account.
        /// </summary>
        public int Points
        {
            get => points;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Balance cant't be less than 0");
                }
                points = value;
            }
        }
        #endregion
        #endregion

        #region Public methods
        /// <summary>
        /// Adds money to account.
        /// </summary>
        /// <param name="sum">Sum of deposit.</param>
        /// <exception cref="ArgumentOutOfRangeException">sum < 0</exception>
        public void Deposit(decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentOutOfRangeException("Sum must be greater than 0.");
            }

            Balance += sum;
            AddBonusPoints(sum);
        }

        /// <summary>
        /// Withdraws money from account.
        /// </summary>
        /// <param name="sum">Sum of money to withdraw.</param>
        /// <exception cref="ArgumentOutOfRangeException">sum < 0</exception>
        public void Withdraw(decimal sum)
        {
            if (sum < 0)
            {
                throw new ArgumentOutOfRangeException("Sum must be greater than 0.");
            }

            if (sum > Balance && !AllowNegativeBalance(sum))
            {
                throw new ArgumentOutOfRangeException("Sum of withdraw greater than balance.");
            }

            Balance -= sum;
            DeleteBonusPoints(sum);
        }

        /// <summary>
        /// Gets type of the account.
        /// </summary>
        /// <returns>Type of the account.</returns>
        public AccountType GetAccountType() => AccountType;

        public override string ToString()
        {
            string result = string.Empty;
            result += $"{AccountType} {Number}: balance - {Balance}, owner name - {Name}, bonus points - {Points}";
            return result;
        }
        #endregion

        #region Protected methods
        protected abstract void AddBonusPoints(decimal sum);

        protected abstract void DeleteBonusPoints(decimal sum);

        protected abstract bool AllowNegativeBalance(decimal sum);
        #endregion
    }
}
