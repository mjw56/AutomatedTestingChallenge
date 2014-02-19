using System;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApp.Model2
{
    public class Account
    {
        [Key]
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastUpdate { get; set; }

        public Account()
        {
            LastUpdate = DateTime.Now;
        }

        public Account(string acctno, string type, decimal balance, DateTime lastupdate) {
            this.AccountNumber = acctno;
            this.Type = type;
            this.Balance = balance;
            this.LastUpdate = lastupdate;
        }
    }
}