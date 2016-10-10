using System;

class Age
{
    static void Main()
    {
        Console.WriteLine("Enter your date of birth:");
        DateTime birthday = DateTime.ParseExact(Console.ReadLine(), "MM.dd.yyyy", null);
        DateTime today = DateTime.Now;
        int age = today.Year - birthday.Year;

        Console.WriteLine(age);
        Console.WriteLine(age + 10);
    }
}