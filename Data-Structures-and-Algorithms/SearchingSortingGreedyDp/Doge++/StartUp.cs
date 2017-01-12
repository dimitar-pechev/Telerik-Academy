using System;
using System.Linq;

namespace DogePlusPlus
{
    public class StartUp
    {
        public static void Main()
        {
            var rowsColsMoves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var enemies = Console.ReadLine().Split(';').ToArray();
            var k = rowsColsMoves[2];

            var matrix = new long[rowsColsMoves[0] + 1, rowsColsMoves[1] + 1];

            for (int i = 0; i < enemies.Length; i++)
            {
                var coords = enemies[i].Split(' ').Select(int.Parse).ToArray();
                matrix[coords[0] + 1, coords[1] + 1] = -1;
            }

            matrix[1, 1] = 1;

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == -1)
                    {
                        continue;
                    }

                    if (matrix[row, col - 1] != -1)
                    {
                        matrix[row, col] += matrix[row, col - 1];
                    }

                    if (matrix[row - 1, col] != -1)
                    {
                        matrix[row, col] += matrix[row -1, col];
                    }
                }
            }

            //PrintMatrix(matrix);
            Console.WriteLine(matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]);
        }

        public static void PrintMatrix(long[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0, 4}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
