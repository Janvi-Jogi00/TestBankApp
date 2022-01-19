using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankApp
{
    class Customer
    {
        public string CustName { get; set; }
        public Guid CustId { get; set; }
        public List<Account> Accounts { get; set; }

    }
}
