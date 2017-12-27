using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public int Points { get; set; }
        public byte AccountType { get; set; }

        public int? OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}
