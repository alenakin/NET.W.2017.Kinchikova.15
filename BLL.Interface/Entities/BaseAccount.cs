using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class for base account;
    /// </summary>
    public class BaseAccount : Account
    {
        #region Properties
        protected override AccountType AccountType { get; set; } = AccountType.Base;
        protected override int BalanceCost { get; set; } = 50;
        protected override int RefillCost { get; set; } = 60;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new base account using number and owner's name.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        public BaseAccount(string accountNumber, string name, string email) : base(accountNumber, name, email) { }

        /// <summary>
        /// Creates new base account using number, owner's name and balance.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        /// <param name="balance">Balance of the account.</param>
        public BaseAccount(string accountNumber, string name, string email, decimal balance) : 
            base(accountNumber, name, email, balance) { }

        /// <summary>
        /// Creates new base account using number, owner's name, balance and bonus points.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        /// <param name="balance">Balance of the account.</param>
        /// <param name="points">Bonus point of the account.</param>
        public BaseAccount(string accountNumber, string name, string email, decimal balance, int points) :
            base(accountNumber, name, email, balance, points)
        { }
        #endregion

        #region Protected methods
        protected override void AddBonusPoints(decimal sum)
        {
            Points += (int)sum / BalanceCost;
        }

        protected override void DeleteBonusPoints(decimal sum)
        {
            Points -= (int)sum / RefillCost;
        }

        protected override bool AllowNegativeBalance(decimal sum) => false;
        #endregion
    }
}
