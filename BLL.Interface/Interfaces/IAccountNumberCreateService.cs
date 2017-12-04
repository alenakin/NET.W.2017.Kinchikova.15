using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Interface for service providing logic for creating number.
    /// </summary>
    public interface IAccountNumberCreateService
    {
        /// <summary>
        /// Creates number for account.
        /// </summary>
        /// <param name="number">Integer number of account</param>
        /// <returns>Unique string number for account.</returns>
        string Create(int number);
    }
}
