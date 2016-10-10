using System;
using System.Text;

class IsoscelesTriangle
{
    static void Main()
    {
        char a = '\u00A9';

        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("   {0}\n  {0} {0}\n {0}   {0}\n{0} {0} {0} {0}", a);
    }
}
