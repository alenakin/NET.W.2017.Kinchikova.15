using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using DAL.EF.Models;
using DAL.EF.Mappers;

namespace DAL.EF
{
    public class AccountDBRepository : IRepository
    {
        public void Create(AccountDto account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} can't be null");
            }

            Console.WriteLine(account.Name);
            
            Owner owner = account.ToOwner();
            Console.WriteLine($"Owner name: {owner.Name}");
            Account addedAccount = account.ToAccount(owner);
            Console.WriteLine($"In account owner name: {addedAccount.Owner.Name}");

            using (var db = new AccountContext())
            {
                db.Owners.Add(owner);
                db.Accounts.Add(addedAccount);
                db.SaveChanges();
            }
        }

        public IEnumerable<AccountDto> GetAllAccounts()
        {
            var accounts = new List<AccountDto>();
            using (var db = new AccountContext())
            {
                foreach(var account in db.Accounts)
                {
                    accounts.Add(account.ToAccountDto());
                }
            }

            return accounts;
        }

        public AccountDto GetByNumber(string account)
        {
            if (string.IsNullOrEmpty(account))
            {
                throw new ArgumentNullException($"{nameof(account)} can't be null or empty");
            }

            using (var db = new AccountContext())
            {
                return db.Accounts.First(x => x.Number == account).ToAccountDto();
            }
        }

        public void Update(AccountDto account)
        {
            if (account == null)
            {
                throw new ArgumentNullException($"{nameof(account)} can't be null");
            }

            using (var db = new AccountContext())
            {
                Account a = db.Accounts.FirstOrDefault(x => x.Number == account.Number);

                if (a == null)
                {
                    return;
                }

                a = account.ToAccount();
                db.SaveChanges();
            }
        }
    }
}
