using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBankApp
{
    class SupportedOperation
    {
        int NumberOfTransactionPerHour = 4 ;
        int WithdrawLimitPerHour = 200000 ;
        protected List<Customer> customers = new List<Customer>();
        protected List<Account> accounts = new List<Account>();
        protected List<Transactions> transactions = new List<Transactions>();
        public void Credit()
        {
            Console.WriteLine("Enter your CustomerId");
            var custId = Console.ReadLine();
            Console.WriteLine("Enter  your Account Number : ");
            var accNum = Console.ReadLine();
            Console.WriteLine("Enter the amount to Credit in the given account : ");
            var amt = Convert.ToInt32(Console.ReadLine());
            var tempCarry = customers.First(y=>y.CustId.ToString()==custId).Accounts.First(x => x.AccNum.ToString() == accNum);
            if (amt % 100 == 0)
            {
                if(tempCarry.NumberOfTransactionPerHour > 0)
                {
                    tempCarry.AccBalance += amt;
                    tempCarry.NumberOfTransactionPerHour -= 1;
                    tempCarry.TransactionsAcc.Add(new Transactions()
                    {
                        WithdrawAmt = amt,
                        Balance = tempCarry.AccBalance
                    });
                    Console.WriteLine($"Rs. {amt} has been credited to Account No. {accNum}");
                    Console.WriteLine($"Updated Account Balance is {tempCarry.AccBalance}");
                    
                }
                else
                {
                    Console.WriteLine(" Sorry!! You had crossed your Transaction Limit.");
                }
            }
            else
            {
                Console.WriteLine("Enter the amount as multiple of 100....");
            }
        }
        public void Debit()
        {
            Console.WriteLine("Enter your CustomerId");
            var custId = Console.ReadLine();
            Console.WriteLine("Enter  your Account Number : ");
            var accNum = Console.ReadLine();
            Console.WriteLine("Enter the amount to Debit from the given account : ");
            var amt = Convert.ToInt32(Console.ReadLine());
            var tempCarry = customers.First(y => y.CustId.ToString() == custId).Accounts.First(x => x.AccNum.ToString() == accNum);
            if (amt % 100 == 0)
            {
                if(amt <= 50000)
                {
                    if(tempCarry.NumberOfTransactionPerHour > 0 && tempCarry.WithdrawLimitPerHour > 0)
                    {
                        if( amt > 30000)
                        {
                            tempCarry.AccBalance -= (amt + 30);
                            tempCarry.WithdrawLimitPerHour -= (amt + 30);
                            tempCarry.NumberOfTransactionPerHour -= 1;
                            tempCarry.TransactionsAcc.Add(new Transactions()
                            {
                                WithdrawAmt = amt, Balance = tempCarry.AccBalance
                            });
                            Console.WriteLine($"Rs. {amt} has been debited from the Account num. {accNum}");
                            Console.WriteLine($"The updated Balance of account is {tempCarry.AccBalance}");
                        }
                        else
                        {
                            tempCarry.AccBalance -= amt;
                            tempCarry.WithdrawLimitPerHour -= amt;
                            tempCarry.NumberOfTransactionPerHour -= 1;
                            tempCarry.TransactionsAcc.Add(new Transactions()
                            {
                                WithdrawAmt = amt,
                                Balance = tempCarry.AccBalance
                            });
                            Console.WriteLine($"Rs. {amt} has been debited from the Account num. {accNum}");
                            Console.WriteLine($"The updated Balance of account is {tempCarry.AccBalance}");
                        }
                    }
                    else
                    {
                         Console.WriteLine(" Sorry!! You had crossed your Transaction Limit.");
                    }
                }
                else
                {
                    Console.WriteLine(" Sorry!! The amount excedded Maximum Withdraw Limit.");
                }
            }
            else
            {
                Console.WriteLine("Enter the amount as multiple of 100....");
            }
        }
        public void DisplayBalanceUsingAccNum()
        {
            Console.WriteLine("Enter the your Account Number : ");
            var accNum = Console.ReadLine();
            var tempCarry = customers.Select(y=> y.Accounts.FirstOrDefault(x => x.AccNum.ToString() == accNum));
            if (tempCarry != null)
            {
                foreach (var temp in tempCarry)
                {
                    if (temp != null)
                    {
                        Console.WriteLine($" Balance in Account Number {accNum} is {temp.AccBalance}");
                    }
                }
            }
        }
        public void DisplayBalanceUsingCustId()
        {
            Console.WriteLine("Enter the your Customer ID : ");
            var custid = Console.ReadLine();
            var tempCarry = customers.First(x => x.CustId.ToString() == custid).Accounts;
            if (tempCarry != null)
            {
                foreach (var temp in tempCarry)
                {
                    Console.WriteLine($" Balance in Account Number {temp.AccNum} is {temp.AccBalance}");
                }
            }
        }
        public void AccStatement()
        {
            Console.WriteLine("Enter the your Account Number : ");
            var accNum = Console.ReadLine();
            var tempCarry = customers.Select
                (y => y.Accounts.FirstOrDefault(x => x.AccNum.ToString() == accNum));
            if(tempCarry != null)
            {
                foreach (var temp in tempCarry)
                {
                    if (temp != null)
                    {
                        Console.WriteLine($" Balance in Account Number {temp.AccNum} is {temp.AccBalance}");
                        foreach (var state in temp.TransactionsAcc)
                        {
                            Console.WriteLine($"The amount is {state.WithdrawAmt} and balance is {state.Balance}");
                        }
                    }
                }   
            }
        }
        public void AllEntry()
        {
            customers.Add(new Customer()
            {
                CustId = Guid.NewGuid(),
                CustName = "Jahnavi",
                Accounts=new List<Account>()
                {
                    new Account()
                    {
                        AccType = "Savings",
                        AccNum = Guid.NewGuid(),
                        AccBalance = 987642,
                        WithdrawLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour,
                        LastTransactionDone = DateTime.Now
                    },
                    new Account()
                    {
                        AccType = "Current",
                        AccNum = Guid.NewGuid(),
                        AccBalance = 560000,
                        WithdrawLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour,
                        LastTransactionDone = DateTime.Now
                    }
                }
            });
            customers.Add(new Customer()
            {
                CustId = Guid.NewGuid(),
                CustName = "Jenny",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccType = "Savings",
                        AccNum = Guid.NewGuid(),
                        AccBalance = 650028,
                        WithdrawLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour,
                        LastTransactionDone = DateTime.Now
                    }
                }
            });
            customers.Add(new Customer()
            {
                CustId = Guid.NewGuid(),
                CustName = "Jey",
                Accounts = new List<Account>()
                {
                    new Account()
                    {
                        AccType = "Savings",
                        AccNum = Guid.NewGuid(),
                        AccBalance = 235478,
                        WithdrawLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour,
                        LastTransactionDone = DateTime.Now
                    },
                    new Account()
                    {
                        AccType = "Current",
                        AccNum = Guid.NewGuid(),
                        AccBalance = 5463423,
                        WithdrawLimitPerHour = WithdrawLimitPerHour,
                        NumberOfTransactionPerHour = NumberOfTransactionPerHour,
                        LastTransactionDone = DateTime.Now
                    }
                }
            });
        }
        public void AllDetails()
        {
            foreach(var customer in customers)
            {
                Console.WriteLine();
                Console.WriteLine($"Customer Name : {customer.CustName}");
                Console.WriteLine($"Customer ID : {customer.CustId}");
                foreach (var account in customer.Accounts)
                {
                    Console.WriteLine($"Account Type : {account.AccType}");
                    Console.WriteLine($"Account Number : {account.AccNum}");
                    Console.WriteLine($"Account Balance : {account.AccBalance}");
                }
            }
        }

    }
}
