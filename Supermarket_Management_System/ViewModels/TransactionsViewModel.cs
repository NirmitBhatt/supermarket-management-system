﻿using CoreBusinessEntities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;


namespace Supermarket_Management_System.ViewModels
{
    public class TransactionsViewModel
    {
        [Display(Name = "Cashier's Name")]
        public string? CashierName { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; } = DateTime.Now;   
        //public Transaction? Transaction { get; set; }
        public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();   
    }
}
