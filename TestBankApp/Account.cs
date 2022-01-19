using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankApp
{
    class Account
    {
        public Account()
        {
            TransactionsAcc = new List<Transactions>();
        }
        public string AccType { get; set; }
        public Guid AccNum { get; set; }
        public double AccBalance { get; set; }
        public List<Transactions> TransactionsAcc { get; set; }
        public int WithdrawLimitPerHour { get; set; }
        public int NumberOfTransactionPerHour { get; set; }
        public DateTime LastTransactionDone { get; set; }

    }
}
