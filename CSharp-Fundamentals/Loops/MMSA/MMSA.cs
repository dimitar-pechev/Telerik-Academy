using System;

class MMSA
{
    static void Main()
    {
        int numLines = int.Parse(Console.ReadLine());
        double min = double.MaxValue;
        double max = double.MinValue;
        double sum = 0;
        double avg;

        for (int i = 0; i < numLines; i++)
        {
            double input = double.Parse(Console.ReadLine());
            sum += input;

            if (input < min)
            {
                min = input;
            }
            if (input > max)
            {
                max = input;
            }
        }
        avg = sum / numLines;

        Console.WriteLine("min={0:0.00}", min);
        Console.WriteLine("max={0:0.00}", max);
        Console.WriteLine("sum={0:0.00}", sum);
        Console.WriteLine("avg={0:0.00}", avg);

    }
}