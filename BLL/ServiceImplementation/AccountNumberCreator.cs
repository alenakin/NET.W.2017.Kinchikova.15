using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Class for creating numer for accounts.
    /// </summary>
    public class AccountNumberCreator : IAccountNumberCreateService
    { 
        /// <summary>
        /// Creates number for account.
        /// </summary>
        /// <param name="number">Initial integer number.</param>
        /// <returns>String account number.</returns>
        public string Create(int number)
        {
            Random rnd = new Random(number);
            var result = new StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                result.Append(rnd.Next(0, 10));
            }
            return result.ToString();
        }
    }
}
