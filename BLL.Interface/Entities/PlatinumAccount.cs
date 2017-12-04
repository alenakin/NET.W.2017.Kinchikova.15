using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class for platinum account;
    /// </summary>
    public class PlatinumAccount : Account
    {
        #region Properties
        protected override AccountType AccountType { get; set; } = AccountType.Platinum;
        protected override int BalanceCost { get; set; } = 20;
        protected override int RefillCost { get; set; } = 30;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new platinum account using number and owner's name.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        public PlatinumAccount(string accountNumber, string name) : base(accountNumber, name) { }

        /// <summary>
        /// Creates new platinum account using number, owner's name and balance.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        /// <param name="balance">Balance of the account.</param>
        public PlatinumAccount(string accountNumber, string name, decimal balance) : base(accountNumber, name, balance) { }

        /// <summary>
        /// Creates new platinum account using number, owner's name, balance and bonus points.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        /// <param name="balance">Balance of the account.</param>
        /// <param name="points">Bonus point of the account.</param>
        public PlatinumAccount(string accountNumber, string name, decimal balance, int points) :
            base(accountNumber, name, balance, points)
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

        protected override bool AllowNegativeBalance(decimal sum) => true;
        #endregion
    }
}
