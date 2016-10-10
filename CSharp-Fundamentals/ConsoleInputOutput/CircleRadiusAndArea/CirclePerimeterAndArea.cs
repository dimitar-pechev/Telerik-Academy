using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        var radius = double.Parse(Console.ReadLine());

        var area = Math.PI * radius * radius;
        var perimeter = Math.PI * radius * 2;

        Console.WriteLine($"{perimeter:F2} {area:F2}");
    }
}