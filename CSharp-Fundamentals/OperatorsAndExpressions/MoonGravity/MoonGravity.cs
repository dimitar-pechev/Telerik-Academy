using System;

class MoonGravity
{
    static void Main()
    {
        float weightEarth = float.Parse(Console.ReadLine());
        float weightMoon = weightEarth * 0.17f;

      
        Console.WriteLine("{0:0.000}", weightMoon);

    }
}