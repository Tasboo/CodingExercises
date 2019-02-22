using System;
using System.Numerics;

namespace TripleStep
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Triple Step");
            for(var i = 1; i < 38; i++){
                Console.WriteLine($"Calculated combos for {i} steps: {CalculateCombos(i)}");
            }
        }

        public static BigInteger CalculateCombos(int n){
            int length = n + 1;
            var ways = new BigInteger[length];
            for(var i = 0; i< length; i++){
                ways[i] = (BigInteger)(-1);
            }
            return CalculateFromRemaining(n, ways);
        }
        public static BigInteger CalculateFromRemaining(int r, BigInteger[] ways){
            if(r < 0){
                return (BigInteger)0;
            }
            if(r == 0){
                return (BigInteger)1;
            }
            if(ways[r] > -1){
                return ways[r];
            }
            ways[r] = CalculateFromRemaining(r - 1, ways) + CalculateFromRemaining(r - 2, ways) + CalculateFromRemaining(r - 3, ways);
            return ways[r];
        }
    }
}
