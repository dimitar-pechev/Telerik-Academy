using System;

class BirdsAndFeathers
{
    static void Main()
    {
        int birds = int.Parse(Console.ReadLine());
        int feathers = int.Parse(Console.ReadLine());

        if (birds != 0 && feathers != 0)
        {
            double avarage = (double)feathers / birds;
            double even = 1;
            double odd = 1;
            if (birds % 2 == 0)
            {
                even = avarage * 123123123123.00;
                Console.WriteLine("{0:0.0000}", even);
            }
            else
            {
                odd = (double)avarage / 317.00;
                Console.WriteLine("{0:0.0000}", odd);
            }
        }
        else
        {
            Console.WriteLine("0.0000");
        }
    }
}