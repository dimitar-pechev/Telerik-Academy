using System;

class ExchangeVariableValues
{
    static void Main()
    {
        byte a = 5;
        byte b = 10;

        Console.WriteLine("Before the exchange:\n{0},\n{1}", a, b);

        byte c = a;
        a = b;
        b = c;

        Console.WriteLine("After the exchange:\n{0},\n{1}", a, b);        
    }
}
