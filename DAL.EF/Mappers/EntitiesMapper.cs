using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.EF.Models;
using DAL.Interface.DTO;

namespace DAL.EF.Mappers
{
    public static class EntitiesMapper
    {
        public static AccountDto ToAccountDto(this Account account)
        {
            if (account.Owner == null)
                Console.WriteLine("pampaaam");
            return new AccountDto()
            {
                Name = account.Owner.Name,
                Number = account.Number,
                Email = account.Owner.Email,
                Balance = account.Balance,
                Points = account.Points,
                AccountType = account.AccountType
            };
        }

        public static Owner ToOwner(this AccountDto accountDto)
        {
            return new Owner()
            {
                Name = accountDto.Name,
                Email = accountDto.Email,
            };
        }

        public static Account ToAccount(this AccountDto accountDto, Owner owner)
        {
            return new Account()
            {
                Number = accountDto.Number,
                Balance = accountDto.Balance,
                Points = accountDto.Points,
                AccountType = accountDto.AccountType,
                Owner = owner
            };
        }

        public static Account ToAccount(this AccountDto accountDto)
        {
            var owner = ToOwner(accountDto);
            return new Account()
            {
                Number = accountDto.Number,
                Balance = accountDto.Balance,
                Points = accountDto.Points,
                AccountType = accountDto.AccountType,
                Owner = owner
            };
        }
    }
}
