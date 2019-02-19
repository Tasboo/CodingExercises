using System;

namespace MinimalTree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("MinimalTree");
            var ints1 = new int[] {1,2,3,4,5,6,7};
            var ints2 = new int[] {8,9,10,11,12,13};
            var t1 = GetTree(ints1);
            var t2 = GetTree(ints2);
            Console.WriteLine($"T1 Root Node: {t1.val}");
            Console.WriteLine($"T1 Root Children: {t1.left.val} {t1.right.val}");
            Console.WriteLine($"T1 Root Children Children: {t1.left.left.val} {t1.left.right.val} {t1.right.left.val} {t1.right.right.val}");
            Console.WriteLine($"T2 Root Node: {t2.val}");
            Console.WriteLine($"T2 Root Children: {t2.left.val} {t2.right.val}");
            // -1 == null for printing purposes;
            Console.WriteLine($"T2 Root Children Children: {(t2.left.left == null ? -1 : -2)} {t2.left.right.val} {t2.right.left.val} {t2.right.right.val}");
        }

        public static TreeNode GetTree(int[] a){
            return GetNodes(a, 0, a.Length -1);
        }

        public static TreeNode GetNodes(int[] a, int s, int e)
        {
            if(s < 0 || s >= a.Length || e < 0 || e >= a.Length){
                return null;
            }
            if(e == s){
                return new TreeNode(a[e]);
            }
            int mid = ((e-s) / 2) + s; 
            var node = new TreeNode(a[mid]);
            node.left = GetNodes(a, s, mid - 1);
            node.right = GetNodes(a, mid + 1, e);
            return node;
        }
    }

    public class TreeNode{
        public int val;
        public TreeNode(int v){
            val = v;
        }
        public TreeNode left;
        public TreeNode right;
    }
}
