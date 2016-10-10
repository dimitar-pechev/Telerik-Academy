using System;

class Calculate
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());

        double sum = 1;
        double factoriel = 1;

        for (int i = 1; i <= n; i++)
        {
            factoriel *= i;
            sum += factoriel / Math.Pow(x, i);
        }
        Console.WriteLine("{0:0.00000}", sum);
    }
}