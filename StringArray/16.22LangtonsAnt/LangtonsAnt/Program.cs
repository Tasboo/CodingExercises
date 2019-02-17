using System;

namespace LangtonsAnt
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Alternate simple solution is to use a HashSet to keep track of blacked squares instead of grid.
            // Using HashSet would reduce the space complexity
            // A more complex solution would be to implement our own resizeable array to reduce space, 
            // though this increaces the complexity of the code quite a bit.
            Console.WriteLine("Langton's Ant");
            int k = 12;
            int gridSize = (12 % 2) > 0 ? k + 1 : k;
            var grid = new bool[gridSize,gridSize];
            Console.WriteLine($"Number of moves: {k}");
            Console.WriteLine("Starting Grid:");
            PrintGrid(grid, gridSize);
            MoveAnt(grid, k, gridSize);
            Console.WriteLine("Moved Ant");
            Console.WriteLine("Resultant Grid:");
            PrintGrid(grid, gridSize);
        }

        public static void MoveAnt(bool[,] grid, int k, int gridSize)
        {
            int middleSquare = gridSize / 2;
            var x = middleSquare + 1;
            var y = middleSquare;
            var movedX = true;
            var movedY = false;
            int move = 1;
            bool currentSquare;
            while(k > 0)
            {
                currentSquare = grid[x,y];
                grid[x,y] = !grid[x,y];
                if(currentSquare)
                {
                    // black
                    // turn left
                    if(movedX)
                    {
                        movedY = true;
                        movedX = false;
                        y += move;
                    }
                    else if(movedY)
                    {
                        movedY = false;
                        movedX = true;
                        move *= -1;
                        x += move;
                    }
                }
                else
                {
                    
                    // white
                    // turn right
                    if(movedX)
                    {
                        movedY = true;
                        movedX = false;
                        move *= -1;
                        y += move;
                    }
                    else if(movedY)
                    {
                        movedY = false;
                        movedX = true;
                        x += move;
                    }
                }
                k--;
            }
        }

        public static void PrintGrid(bool[,] grid, int gridSize)
        {
            Console.WriteLine("~~~~~~~~~~");
            Console.WriteLine(" ");
            var currentRow = new char[gridSize];
            for(var y = gridSize - 1; y >= 0; y--){
                for(var x = 0; x < gridSize; x++){
                    currentRow[x] = grid[x,y] ? '1' : '0';
                }
                Console.WriteLine(new string(currentRow));
            }
            Console.WriteLine(" ");
            Console.WriteLine("~~~~~~~~~~");
        }
    }
}
