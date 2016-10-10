using System;

class NullValuesArithmetic
{
    static void Main()
    {
        int? a = null;
        double? b = null;

        Console.WriteLine("{0}{1}", a, b);

        a = 7;
        Console.WriteLine(a.GetValueOrDefault());
    }
}