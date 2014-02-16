using System;
using System.ComponentModel.DataAnnotations;

namespace DemoWebApp.Model
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
    }
}