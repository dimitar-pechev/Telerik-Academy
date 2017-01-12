﻿using System;

namespace Pattern
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string figure = DrawFigure(n, 'u', 'r', 'd', 'l');

            Console.WriteLine(figure);
        }

        public static string DrawFigure(int n, char u, char r, char d, char l)
        {
            if (n == 0)
            {
                return "";
            }

            return DrawFigure(n - 1, r, u, l, d)
                + u + DrawFigure(n - 1, u, r, d, l)
                + r + DrawFigure(n - 1, u, r, d, l)
                + d + DrawFigure(n - 1, l, d, r, u);
        }
    }
}
