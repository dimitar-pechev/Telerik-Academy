using System;

class BankAccountData
{
    static void Main()
    {
        string holdersName = "Dimitar Vladimirov Pechev";
        decimal balance = 480.53m;
        string bankName = "FIBank";
        string iban = "FINV1000100010001000";
        ulong creditCard1 = 1000100010001000;
        ulong creditCard2 = 1000100010001001;
        ulong creditCard3 = 1000100010001002;

        Console.WriteLine("Holder's Name: {0}\nBalance: {1} BGN\nBank Name: {2}\nIBAN: {3}\nCredit Card Number (1): {4}\nCredit Card Number (2): {5}\nCredit Card Number (3): {6}",
            holdersName, balance, bankName, iban, creditCard1, creditCard2, creditCard3);
    }
}