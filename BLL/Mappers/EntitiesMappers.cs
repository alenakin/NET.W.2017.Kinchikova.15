using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using BLL.Interface.Entities;

namespace BLL.Mappers
{
    public static class EntitiesMappers
    {
        public static AccountDto ToAccountDto(this Account account)
        {
            return new AccountDto()
            {
                Name = account.Name,
                Number = account.Number,
                Balance = account.Balance,
                Email = account.Email,
                Points = account.Points,
                AccountType = (byte)account.GetAccountType()
            };
        }

        public static Account ToAccount(this AccountDto account)
        {
            Account result = null;
            AccountType accountType = (AccountType)account.AccountType;
            switch(accountType)
            {
                case AccountType.Base:
                    result = new BaseAccount(account.Number, account.Name, account.Email, account.Balance, account.Points);
                    break;
                case AccountType.Gold:
                    result = new GoldAccount(account.Number, account.Name, account.Email, account.Balance, account.Points);
                    break;
                case AccountType.Platinum:
                    result = new PlatinumAccount(account.Number, account.Name, account.Email, account.Balance, account.Points);
                    break;
            }
            return result;
        }
    }
}
