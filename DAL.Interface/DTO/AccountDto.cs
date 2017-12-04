using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Entities;

namespace DAL.Interface.DTO
{
    /// <summary>
    /// Data transfer object for account.
    /// </summary>
    public class AccountDto
    {
        /// <summary>
        /// Name of owner of the account.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Number of the account.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Balance of the account.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Points of the account.
        /// </summary>
        public int Points { get; set; }

        /// <summary>
        /// Type of the account.
        /// </summary>
        public AccountType AccountType { get; set; }
    }
}
