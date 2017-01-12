using System;
using System.Collections.Generic;
using System.Linq;

namespace Diameter
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var neighbours = new List<Tuple<int, int>>[n];
            for (int i = 0; i < n - 1; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var a = line[0];
                var b = line[1];
                var length = line[2];

                if (neighbours[a] == null)
                {
                    neighbours[a] = new List<Tuple<int, int>>();
                }

                neighbours[a].Add(new Tuple<int, int>(b, length));

                if (neighbours[b] == null)
                {
                    neighbours[b] = new List<Tuple<int, int>>();
                }

                neighbours[b].Add(new Tuple<int, int>(a, length));
            }
            
            var path = new int[n];
            var isVisited = new bool[n];
            Dfs(0, path, isVisited, neighbours);

            var maxPath = 0;
            var maxPathIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (path[i] > maxPath)
                {
                    maxPath = path[i];
                    maxPathIndex = i;
                }
            }
            
            path = new int[n];
            isVisited = new bool[n];
            Dfs(maxPathIndex, path, isVisited, neighbours);
            maxPath = path.Max();
            Console.WriteLine(maxPath);
        }

        private static void Dfs(int node, int[] path, bool[] isVisited, List<Tuple<int, int>>[] neighbours)
        {
            isVisited[node] = true;

            foreach (var n in neighbours[node])
            {
                if (!isVisited[n.Item1])
                {
                    path[n.Item1] = n.Item2 + path[node];
                    Dfs(n.Item1, path, isVisited, neighbours);
                }
            }
        }
    }
}