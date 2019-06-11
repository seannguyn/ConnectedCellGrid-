using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace ConnectedCellGrid
{
    /*
     *  Algorithm:
     * 
     *      For each cell in the board, do DFS
     *    
     *      count the number of nodes in each DFS,
     *    
     *      get the maximum 
     * 
     */

    public class Program
    {
        static void Main(string[] args)
        {
            int[][] board = ReadBoard("board0.txt");
            int cluster = Solution.connectedCell(board, board.Length, board[0].Length);
            Console.WriteLine(cluster);
        }

        public static int[][] ReadBoard(string fileName)
        {
            if (!File.Exists(fileName))
            { 
                Console.WriteLine("File not found"); 
                throw new FileNotFoundException(); 
            }

            int[][] list = File.ReadAllLines(fileName)
               .Select(l => l.Split(' ').Select(i => int.Parse(i)).ToArray())
               .ToArray();

            foreach (int[] line in list)
            {
                foreach (int i in line)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            return list;
        }
    }

    public class Solution
    {
        // Complete the connectedCell function below.
        public static int connectedCell(int[][] matrix, int n, int m)
        {
            var visited = new bool[n, m];
            int cluster = 0;
            int max = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    // check if cell is visited
                    if (visited[i,j]) { continue; }

                    // do DFS
                    if (matrix[i][j] == 1) 
                    { 
                        // search
                        int nodes = DFS(matrix, i, j, n, m, visited);
                        if (nodes > max) { max = nodes; }

                        //increase cluster
                        cluster++;
                    }
                }
            }

            return max;
        }

        public static int DFS(int[][] matrix, int current_n, int current_m, int n, int m, bool[,] visited)
        {
            // init count 
            int count = 0;
            count += 1;

            // visited
            visited[current_n, current_m] = true;

            // get neighbor 
            List<KeyValuePair<int, int>> neigh = getNeighbor(current_n, current_m, n, m);

            // if neighbor is not visited, do DFS
            foreach (KeyValuePair<int,int> position in neigh)
            {
                int i = position.Key;
                int j = position.Value;
                if (visited[i,j]) { continue; }
                if (matrix[i][j] == 1) 
                { 
                    count += DFS(matrix, i, j, n, m, visited); 
                }
            }
            return count;
        }

        public static List<KeyValuePair<int, int>> getNeighbor(int current_n, int current_m, int n, int m)
        {
            List<KeyValuePair<int, int>> neighborPosition = new List<KeyValuePair<int, int>>();
            int[] direction = new int[] { -1, 0, 1 };
            foreach(int i in direction)
            {
                foreach(int j in direction)
                {
                    int neighbor_n = current_n + i;
                    int neighbor_m = current_m + j;
                    if (isValid(neighbor_n, neighbor_m, current_n, current_m, n, m)) { 
                        KeyValuePair<int, int> kp = new KeyValuePair<int, int>(neighbor_n, neighbor_m);
                        neighborPosition.Add(kp);
                    }
                }
            }
            return neighborPosition;
        }

        public static bool isValid(int i, int j, int current_n, int current_m, int n, int m)
        {
            if (i >= 0 && i <= n-1 && j >= 0 && j <= m-1 && !(i == current_n && j == current_m)) { return true; }
            return false;
        }
    }
}
