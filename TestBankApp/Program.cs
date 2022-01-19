using TestBankApp;

var operationInstance = new SupportedOperation();
operationInstance.AllEntry();
operationInstance.AllDetails();
char charKey1,charKey2;
Console.WriteLine("****************Bank Application****************");
do
{
    Console.WriteLine("Enter 1 to Credit or Debit amount to/from Account");
    Console.WriteLine("Enter 2 to Display Balance of Account using Account Number");
    Console.WriteLine("Enter 3 to Display Balance of Account using Customer ID");
    Console.WriteLine("Enter 4 to get Account Statement using Account Number");
    var numKey = Convert.ToChar(Console.ReadLine());
    switch (numKey)
    {
        case '1':
            do
            {
                Console.WriteLine("Enter C to Credit amount to Account");
                Console.WriteLine("Enter D to Debit amount from Account");
                char charKey = Char.ToUpper(Console.ReadLine()[0]);
                switch (charKey)
                {
                    case 'C':
                        operationInstance.Credit();
                        break;
                    case 'D':
                        operationInstance.Debit();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.WriteLine("If you want to continue again, Enter Y for YES and N for NO");
                charKey1 = Char.ToUpper(Console.ReadLine()[0]);

            } while (charKey1 == 'Y');
            break;

        case '2':
            operationInstance.DisplayBalanceUsingAccNum();
            break;

        case '3':
            operationInstance.DisplayBalanceUsingCustId();
            break;

        case '4':
            operationInstance.AccStatement();
            break;

        default:
            Console.WriteLine("Invalid Input");
            break;
    }
    Console.WriteLine("If you want to continue again, Enter Y for YES and N for NO");
    charKey2 = Char.ToUpper(Console.ReadLine()[0]);
} while (charKey2 == 'Y');