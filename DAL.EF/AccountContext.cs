using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.EF.Models;

namespace DAL.EF
{
    public class AccountContext : DbContext
    {
        public AccountContext() : base("AccountDB") { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
