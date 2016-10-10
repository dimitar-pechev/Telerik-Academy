using System;

class FourDigits
{
    static void Main()
    {
        int input = int.Parse(Console.ReadLine());  
        int forthDigit = input % 10;
        int thirdDigit = (input / 10) % 10;
        int secondDigit = (input / 100) % 10;
        int firstDigit = (input / 1000) % 10;

        Console.WriteLine(firstDigit + secondDigit + thirdDigit + forthDigit);
        Console.WriteLine("{0}{1}{2}{3}", forthDigit, thirdDigit, secondDigit, firstDigit);
        Console.WriteLine("{0}{1}{2}{3}", forthDigit, firstDigit, secondDigit, thirdDigit);
        Console.WriteLine("{0}{1}{2}{3}", firstDigit, thirdDigit, secondDigit, forthDigit);
    }
}