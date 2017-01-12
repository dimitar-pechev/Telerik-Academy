using System;
using System.Collections.Generic;
using System.Linq;

namespace Guards
{
    public class StartUp
    {
        private static ISet<int> results;

        public static void Main()
        {
            var matrixSize = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var matrix = new char[matrixSize[0], matrixSize[1]];
            var guardsNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < guardsNum; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();
                matrix[int.Parse(line[0]), int.Parse(line[1])] = line[2][0];
            }

            if (matrix[matrixSize[0] - 1, matrixSize[1] - 1] != '\0')
            {
                Console.WriteLine("Meow");
                return;
            }

            matrix[matrixSize[0] - 1, matrixSize[1] - 1] = 'e';

            results = new HashSet<int>();
            var seconds = 0;

            // PopulateMatrix(matrix);
            PrintMatrix(matrix);

            FindAllPaths(matrix, 0, 0, seconds);

            if (results.Count != 0)
            {
                Console.WriteLine(results.Min());
            }
            else
            {
                Console.WriteLine("Meow");
            }
        }

        private static void PopulateMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (char.IsLetter(matrix[row, col]))
                    {
                        continue;
                    }
                    if (row > 0 && matrix[row - 1, col] == 'D')
                    {
                        matrix[row, col] = '3';
                    }
                    else if (row < matrix.GetLength(0) - 1 && matrix[row + 1, col] == 'U')
                    {
                        matrix[row, col] = '3';
                    }
                    else if (col > 0 && matrix[row, col - 1] == 'R')
                    {
                        matrix[row, col] = '3';
                    }
                    else if (col < matrix.GetLength(1) - 1 && matrix[row, col + 1] == 'L')
                    {
                        matrix[row, col] = '3';
                    }
                    else
                    {
                        matrix[row, col] = '1';
                    }
                }
            }
        }

        private static void FindAllPaths(char[,] matrix, int row, int col, int seconds)
        {
            // check if inside the bounderies of the matrix
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                seconds += 1; // guard just above the exit?
                results.Add(seconds);
                return;
            }

            // has the algorithm already checked the cell
            if (matrix[row, col] != '\0')
            {
                return;
            }

            matrix[row, col] = 'x';

            // two or more guards around the same cell?
            if (row > 0 && matrix[row - 1, col] == 'D')
            {
                seconds += 3;
            }
            else if (row < matrix.GetLength(0) - 1 && matrix[row + 1, col] == 'U')
            {
                seconds += 3;
            }
            else if (col > 0 && matrix[row, col - 1] == 'R')
            {
                seconds += 3;
            }
            else if (col < matrix.GetLength(1) - 1 && matrix[row, col + 1] == 'L')
            {
                seconds += 3;
            }
            else
            {
                seconds += 1;
            }
            
            FindAllPaths(matrix, row, col + 1, seconds); // right
            FindAllPaths(matrix, row + 1, col, seconds); // down

            matrix[row, col] = '\0';
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(" {0} |", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
