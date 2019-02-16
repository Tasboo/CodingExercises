using System;

namespace RotateMatrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Strings and Arrays 1.7: Rotate matrix");
            int n = 10;
            bool[,] arr = new bool[n,n];
            preFillMatrix(arr,n);
            Console.WriteLine($"Matrix original: ");
            printMatrix(arr,n);
            Rotate(arr,n);
            Console.WriteLine($"Matrix rotated 90 degrees: ");
            printMatrix(arr,n);
        }

        public static void Rotate(bool[,] matrix, int n)
        {
            // 1
            int maxX = n - 1;
            int maxY = maxX;
            int minX = 0;
            int minY = 0;
            int[] tlc = new int[2];
            int[] trc = new int[2];
            int[] brc = new int[2];
            int[] blc = new int[2];
            bool topLeft, topRight, bottomRight, bottomLeft, temp1, temp2;
            while(maxX > minX)
            {
                // 2
                SetCoordXY(tlc, minX, maxY);
                SetCoordXY(trc, maxX, maxY);
                SetCoordXY(brc, maxX, minY);
                SetCoordXY(blc, minX, minY);
                while(tlc[0] < maxX)
                {
                    // 3
                    topLeft = matrix[tlc[0],tlc[1]];
                    topRight = matrix[trc[0],trc[1]];
                    bottomRight = matrix[brc[0],brc[1]];
                    bottomLeft = matrix[blc[0],blc[1]];

                    // 4
                    temp1 = GetMatrixVal(matrix, tlc);
                    SetMatrixVal(matrix, tlc, GetMatrixVal(matrix, blc));
                    temp2 = GetMatrixVal(matrix, trc);
                    SetMatrixVal(matrix, trc, temp1);
                    temp1 = GetMatrixVal(matrix, brc);
                    SetMatrixVal(matrix, brc, temp2);
                    SetMatrixVal(matrix, blc, temp1);

                    // 5
                    tlc[0]++;
                    trc[1]--;
                    brc[0]--;
                    blc[1]++;
                }
                // 6
                maxX--;
                maxY--;
                minX++;
                minY++;
            }
        }

        public static bool GetMatrixVal(bool[,] matrix, int[] coord)
        {
            return matrix[coord[0], coord[1]];
        }

        public static void SetMatrixVal(bool[,] matrix, int[] coord, bool val)
        {
            matrix[coord[0], coord[1]] = val;
        }

        public static void SetCoordXY(int[] coord, int x, int y)
        {
                coord[0] = x;
                coord[1] = y;
        }

        public static void preFillMatrix(bool[,] matrix, int n)
        {
            int y = 0;
            for(var x = 0; x < n; x++){
                matrix[x,0] = true;
                matrix[x,y] = true;
                y++;
            }
        }

        public static void printMatrix(bool[,] matrix, int n)
        {
            Console.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"  ");
            char[] line = new char[n];
            for(var y = n - 1; y >= 0; y--)
            {
                for(var x = 0; x < n; x++)
                {
                    line[x] = matrix[x,y] ? '1' : '0';
                }
                Console.WriteLine(new string(line));
            }
            Console.WriteLine($"  ");
            Console.WriteLine($"~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
