using System;

namespace ContiguousSequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Continous Subsequence");
            var a = new int[] {2, -8, 3, -2, 4, -10};
            Console.WriteLine("Input array:");
            PrintArray(a);
            int highestSubSequence = Recurse(a, 0, null);
            Console.WriteLine($"Highest Continous Subsequence Sum: {highestSubSequence}");
            a = new int[] {2, 3, -8, -1, 2, 4, -2, 3};
            Console.WriteLine("Input array:");
            PrintArray(a);
            highestSubSequence = Recurse(a, 0, null);
            Console.WriteLine($"Highest Continous Subsequence Sum: {highestSubSequence}");
        }

        public static int Recurse(int[] a, int i, int? ps)
        {
            int cv = a[i];
            int highest = cv;
            if(ps != null){
                highest = Math.Max(highest, cv + ps.Value);
            }
            if(++i < a.Length){
                int rv = Recurse(a, i, highest);
                highest = Math.Max(highest, rv);
            }
            return highest;
        }

        public static void PrintArray(int[] a)
        {
            string line = "";
            foreach(int i in a)
            {
                if(line != ""){
                    line += ", ";
                }
                line += i.ToString();
            }
            Console.WriteLine(line);
        }
    }
}
