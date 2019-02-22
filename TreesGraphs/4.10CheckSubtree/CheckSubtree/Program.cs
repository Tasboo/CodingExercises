using System;

namespace CheckSubtree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Check Subtree");
            var T1 = SetupT1();
            var T2 = SetupT2();
            var T3 = SetupT3();
            var T4 = SetupT4();
            var T5 = SetupT5();

            Console.WriteLine($"Expect T2 to be a subtree of T1: {CheckSubtree(T1,T2)}");
            Console.WriteLine($"Expect T3 to NOT be a subtree of T1: {CheckSubtree(T1,T3)}");
            Console.WriteLine($"Expect T4 to NOT be a subtree of T1: {CheckSubtree(T1,T4)}");
            Console.WriteLine($"Expect T5 to be a subtree of T1: {CheckSubtree(T1,T5)}");
        }

        public static bool CheckSubtree(TreeNode T1, TreeNode T2){
            if(T1 == null && T2 == null)
                return true;
            if(T1 != null){
                if(T1.val == T2.val && TestMatch(T1, T2)){
                    return true;
                }
                if(CheckSubtree(T1.left, T2) || CheckSubtree(T1.right, T2)){
                    return true;
                }
            }
            return false;
        }
        public static bool TestMatch(TreeNode T1, TreeNode T2){
            if(T1 == null && T2 == null)
                return true;
            if((T1 != null && T2 == null) || (T1 == null && T2 != null))
                return false;
            if(T1.val != T2.val)
                return false;
            if(!TestMatch(T1.left, T2.left) || !TestMatch(T1.right, T2.right))
                return false;
            return true;
        }

        public static TreeNode SetupT1(){
            var T1 = new TreeNode(8);
            var T4 = new TreeNode(4);
            var T2 = new TreeNode(2);
            var T7 = new TreeNode(7);
            var T12 = new TreeNode(12);
            var T11 = new TreeNode(11);
            var T10 = new TreeNode(10);
            var T13 = new TreeNode(13);
            var T14 = new TreeNode(14);
            T1.left = T4;
            T1.right = T12;
            T4.left = T2;
            T4.right = T7;
            T12.left = T11;
            T11.left = T10;
            T12.right = T13;
            T13.right = T14;
            return T1;
        }

        public static TreeNode SetupT2(){
            var T11 = new TreeNode(11);
            var T10 = new TreeNode(10);
            T11.left = T10;
            return T11;
        }

        public static TreeNode SetupT3(){
            var T11 = new TreeNode(11);
            var T10 = new TreeNode(10);
            var T9 = new TreeNode(9);
            T11.left = T10;
            T10.left = T9;
            return T11;
        }

        public static TreeNode SetupT4(){
            var T11 = new TreeNode(11);
            return T11;
        }
        public static TreeNode SetupT5(){
            var T4 = new TreeNode(4);
            var T2 = new TreeNode(2);
            var T7 = new TreeNode(7);
            T4.left = T2;
            T4.right = T7;
            return T4;
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
