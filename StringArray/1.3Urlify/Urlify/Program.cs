using System;

namespace Urlify
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Strings and Arrays 1.3: Urlify");
            var testString = "The cat had a hat        ";
            var charArray = testString.ToCharArray();
            Console.WriteLine($"input url: {testString}");
            UrlifyChar(charArray);
            Console.WriteLine($"finished url: {new string(charArray)}");
        }

        public static void UrlifyChar(char[] url)
        {
            Console.WriteLine($"char array length: {url.Length}");
            int r = url.Length - 1;
            Console.WriteLine($"r: {r}");
            int s = r - 2;
            Console.WriteLine($"s: {s}");
            while(url[s] == ' '){
                s--;
            }
            while(s >= 0)
            {
                if(url[s] != ' ')
                {
                    url[r--] = url[s];
                    Console.WriteLine($"swapped char: {new string(url)}");
                }
                else
                {
                    url[r--] = '0';
                    url[r--] = '2';
                    url[r--] = '%';
                    Console.WriteLine($"replaced space: {new string(url)}");
                }
                s--;
            }
        }
    }
}
