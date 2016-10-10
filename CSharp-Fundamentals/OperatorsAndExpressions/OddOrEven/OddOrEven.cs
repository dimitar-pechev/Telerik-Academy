using System;

class OddOrEven
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
       
        if (num % 2 == 0)
        {
            Console.WriteLine("even " + num);
        }
        else
        {
            Console.WriteLine("odd " + num);
        }
    }
}