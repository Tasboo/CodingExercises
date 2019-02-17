using System;
using System.Collections.Generic;

namespace ZeroMatrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Zero Matrix");
            int x = 12;
            int y = 3;
            int[,] matrix = new int[x,y];
            PreFillMatrix(matrix, x, y);
            Console.WriteLine("Matrix Original");
            PrintMatrix(matrix, x, y);
            Zero(matrix, x, y);
            Console.WriteLine("Matrix Zeroed");
            PrintMatrix(matrix, x, y);
        }

        public static void Zero(int[,] matrix, int x, int y)
        {
            // there is a way to store these values in the matrix itself to reduce the amount of memory used, but this is simpler to understand
            HashSet<int> rows = new HashSet<int>();
            HashSet<int> columns = new HashSet<int>();

            for(var i = 0; i < x; i++)
            {
                for(var j = 0; j < y; j++)
                {
                    if(matrix[i,j] == 0)
                    {
                        rows.Add(i);
                        columns.Add(j);
                    }
                } 
            }

            foreach(int row in rows)
            {
                for(var j = 0; j < y; j++)
                {
                    matrix[row,j] = 0;
                } 
            } 
            foreach(int column in columns)
            {
                for(var j = 0; j < x; j++)
                {
                    matrix[j,column] = 0;
                } 
            } 
            
        }

        public static void PreFillMatrix(int[,] matrix, int x, int y)
        {
            // set everything to 1
            for(var i = 0; i < x; i++)
            {
                for(var j = 0; j < y; j++)
                {
                    matrix[i,j] = 1;
                } 
            }

            //set random elements to 0
            int target = Math.Min(x, y);
            target = target / 2;
            Random rnd = new Random();
            int[,] points = new int[target, 2];
            for(var i = 0; i < target; i++)
            {
                points[i,0] = rnd.Next(0, x);
                points[i,1] = rnd.Next(0, y);
                matrix[rnd.Next(0, x), rnd.Next(0, y)] = 0;
            }
        }

        public static void PrintMatrix(int[,] matrix, int x, int y)
        {
            Console.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"  ");
            char[] line = new char[x];
            for(var i = y - 1; i >= 0; i--)
            {
                for(var j = 0; j < x; j++)
                {
                    line[j] = matrix[j,i].ToString()[0];
                }
                Console.WriteLine(new string(line));
            }
            Console.WriteLine($"  ");
            Console.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
