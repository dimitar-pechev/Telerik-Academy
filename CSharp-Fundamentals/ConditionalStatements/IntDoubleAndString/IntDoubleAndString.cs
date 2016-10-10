using System;

class IntDoubleAndString
{
    static void Main()
    {
        string input = Console.ReadLine();

        switch (input)
        {
            case "integer":
                {
                    int numInt = int.Parse(Console.ReadLine());
                    Console.WriteLine(numInt + 1);
                }
                break;

            case "real":
                {
                    double numReal = double.Parse(Console.ReadLine());
                    double sum = numReal + 1;
                    Console.WriteLine("{0:0.00}", sum);
                }
                break;

            case "text":
                {
                    string text = Console.ReadLine();
                    Console.WriteLine(text + "*");
                }
                break;
        }
    }
}