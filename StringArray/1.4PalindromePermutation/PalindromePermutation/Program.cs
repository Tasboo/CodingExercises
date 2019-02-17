using System;
using System.Collections.Generic;

namespace PalindromePermutation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string input = "Tact Coa";
            Console.WriteLine($"Input string: \"{input}\"");
            Console.WriteLine($"Is expected to return true.");
            Console.WriteLine($"Actual: {IsPalindromePermutation(input)}");

            Console.WriteLine($" ");
            input = "Tact Coaa";
            Console.WriteLine($"Input string: \"{input}\"");
            Console.WriteLine($"Is expected to return false.");
            Console.WriteLine($"Actual: {IsPalindromePermutation(input)}");
        }

        public static bool IsPalindromePermutation(string input)
        {
            Dictionary<char, bool> dictionary = new Dictionary<char, bool>();
            var ca = input.ToLower().ToCharArray();
            var length = ca.Length;
            for(var i = 0; i < length; i++)
            {
                if(ca[i] != ' ')
                {
                    if(dictionary.ContainsKey(ca[i]))
                    {
                        dictionary[ca[i]] = !dictionary[ca[i]];
                    }
                    else
                    {
                        dictionary.Add(ca[i], true);
                    }
                }
            }
            int oddCount = 0;
            foreach(var d in dictionary)
            {
                if(d.Value) oddCount++;
                if(oddCount > 1)
                    return false;
            }
            return true;
        }
    }
}
