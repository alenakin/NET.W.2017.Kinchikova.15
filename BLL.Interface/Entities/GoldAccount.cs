using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Class for gold account;
    /// </summary>
    public class GoldAccount : Account
    {
        #region Field
        private const decimal allowedMinus = -10000;
        #endregion

        #region Properties
        protected override AccountType AccountType { get; set; } = AccountType.Gold;
        protected override int BalanceCost { get; set; } = 30;
        protected override int RefillCost { get; set; } = 40;
        #endregion

        #region Constructors
        /// <summary>
        /// Creates new gold account using number and owner's name.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        public GoldAccount(string accountNumber, string name) : base(accountNumber, name) { }

        /// <summary>
        /// Creates new gold account using number, owner's name and balance.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        /// <param name="balance">Balance of the account.</param>
        public GoldAccount(string accountNumber, string name, decimal balance) : base(accountNumber, name, balance) { }

        /// <summary>
        /// Creates new gold account using number, owner's name, balance and bonus points.
        /// </summary>
        /// <param name="accountNumber">Number of account.</param>
        /// <param name="name">Name of owner of the account.</param>
        /// <param name="balance">Balance of the account.</param>
        /// <param name="points">Bonus point of the account.</param>
        public GoldAccount(string accountNumber, string name, decimal balance, int points) :
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

        protected override bool AllowNegativeBalance(decimal sum)
        {
            return Balance - sum > allowedMinus ? true : false;
        }
        #endregion
    }
}
