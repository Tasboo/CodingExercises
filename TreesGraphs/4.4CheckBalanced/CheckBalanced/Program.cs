using System;

namespace CheckBalanced
{
    public class Program
    {
        public static int minHeight;
        public static bool isMinHeightSet;
        public static int maxHeight;
        public static void Main(string[] args)
        {
            Console.WriteLine("Check balanced");
            var n0 = new TreeNode(0);
            var n1 = new TreeNode(1);
            var n2 = new TreeNode(2);
            var n3 = new TreeNode(3);
            var n4 = new TreeNode(4);
            var n5 = new TreeNode(5);

            n0.left = n1;
            n0.right = n2;
            n1.left = n3;
            n1.right = n4;

            
            Console.WriteLine($"Expect First Tree IsBalanced == true: {IsBalanced(n0)}");
            Console.WriteLine($"Min: {minHeight} Max: {maxHeight}");
            n4.left = n5;
            Console.WriteLine($"Expect First Tree IsBalanced == false: {IsBalanced(n0)}");
            Console.WriteLine($"Min: {minHeight} Max: {maxHeight}");

        }

        public static void DetermineMinMaxHeight(TreeNode n, int currentHeight)
        {
            if(n != null){
                Console.WriteLine($"val: {n.val} currentHeight: {currentHeight} Min: {minHeight} Max: {maxHeight}");
                currentHeight++;
                DetermineMinMaxHeight(n.left, currentHeight);
                DetermineMinMaxHeight(n.right, currentHeight);
            } else {
                if(!isMinHeightSet){
                    isMinHeightSet = true;
                    minHeight = currentHeight;
                }
                else{
                    minHeight = Math.Min(currentHeight, minHeight);
                }
                maxHeight = Math.Max(currentHeight, maxHeight);
            }
        }
        public static bool IsBalanced(TreeNode n){
            minHeight = 0;
            maxHeight = 0;
            isMinHeightSet = false;
            DetermineMinMaxHeight(n, 0);
            return (maxHeight - minHeight <= 1);
        }
    }

    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int v){
            val = v;
        }
    }
}
