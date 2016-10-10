using System;

class StringsAndObjects
{
    static void Main()
    {
        string a = "Hello";
        string b = "World";
        object c = a + " " + b;
        string d = (string)c;

        Console.WriteLine(d);
    }
}