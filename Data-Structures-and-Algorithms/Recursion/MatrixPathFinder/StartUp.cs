using System;

namespace MatrixPathFinder
{
    public class StartUp
    {
        private const char UNPASSABLE = 'x';
        private const char OCCUPIED = 'o';
        private const char EXIT = 'e';

        private static bool foundPath = false;

        public static void Main()
        {
            var matrix = new char[,]
        {
            {' ', ' ', ' ', 'x', ' ', ' ', ' '},
            {'x', 'x', ' ', 'x', ' ', 'x', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', 'x', 'x', 'x', 'x', 'x', ' '},
            {' ', ' ', ' ', 'e', ' ', ' ', ' '}
        };
            FindAllPaths(matrix, 0, 0);
            CheckIfPathExists(matrix, 0, 0);
        }

        private static void CheckIfPathExists(char[,] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }
            
            if (matrix[row, col] == UNPASSABLE || matrix[row, col] == OCCUPIED)
            {
                return;
            }

            if (matrix[row, col] == EXIT)
            {
                foundPath = true;
                PrintPath(matrix);
                return;
            }

            matrix[row, col] = OCCUPIED;

            if (!foundPath)
            {
                CheckIfPathExists(matrix, row - 1, col); // up
            }

            if (!foundPath)
            {
                CheckIfPathExists(matrix, row, col + 1); // right
            }

            if (!foundPath)
            {
                CheckIfPathExists(matrix, row + 1, col); // down
            }

            if (!foundPath)
            {
                CheckIfPathExists(matrix, row, col - 1); // left
            }

            matrix[row, col] = ' ';
        }

        private static void FindAllPaths(char[,] matrix, int row, int col)
        {
            // check if inside the bounderies of the matrix
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            // has the algorithm already checked the cell
            if (matrix[row, col] == UNPASSABLE || matrix[row, col] == OCCUPIED)
            {
                return;
            }

            if (matrix[row, col] == EXIT)
            {
                PrintPath(matrix);
                return;
            }

            matrix[row, col] = OCCUPIED;

            FindAllPaths(matrix, row - 1, col); // up
            FindAllPaths(matrix, row, col + 1); // right
            FindAllPaths(matrix, row + 1, col); // down
            FindAllPaths(matrix, row, col - 1); // left

            matrix[row, col] = ' ';
        }

        private static void PrintPath(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($" {matrix[row, col]} |");
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
