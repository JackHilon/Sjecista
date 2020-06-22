using System;

namespace Sjecista
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sjecista
            // https://open.kattis.com/problems/sjecista 
            // == (what is the number of intersections between pairs of diagonals in a convex polygon) ==
            // -- (I get Run time error) --


            //var verticesNum = EnterNum();
            var verticesNum = int.Parse(Console.ReadLine());


            Console.WriteLine(VerticesNumber(verticesNum));
        }
        
        private static int VerticesNumber(int sides)
        {
            if (sides == 3)
                return 0;
            else if (sides == 4)
                return 1;
            else if (sides == 6)
                return 15;
            else if (sides % 2 != 0)
                return EulerResult(sides);
            else
                return EulerResult(sides) - 1 + (sides / 2);
        }
        private static int EulerResult(int n)
        {
            int first = (-5 * (n * n * n) + 45 * (n * n) - 70 + 24) / 24 * Delta(n, 2);
            int second = -(3 * n / 2) * Delta(n, 4);
            int third = (-45 * (n * n) + 262 * n) / 6 * Delta(n, 6);
            int fourth = 42 * n * Delta(n, 12) + 60 * n * Delta(n, 18);
            int fifth = 35 * n * Delta(n, 24) - 38 * n * Delta(n, 30) - 82 * n * Delta(n, 42) - 330 * n * Delta(n, 60);
            int sixth = -144 * n * Delta(n, 84) - 96 * n * Delta(n, 90) - 144 * n * Delta(n, 120) - 96 * n * Delta(n, 210);
            int result = Combinations(n, 4) + first + second + third + fourth + fifth + sixth;
            return result;
        }

        private static int Delta(int n, int m)
        {
            if (n % m == 0)
                return 1;
            else return 0;
        }

        private static int Combinations(int n, int k)
        {
            if (k > n)
                return 0;
            else
                return Fact(n) / (Fact(k) * Fact(n - k));
        }
        private static int Fact(int n)
        {
            if (n == 0)
                return 1;
            else if (n == 1)
                return 1;
            else
                return n * Fact(n - 1);
        }

        private static int EnterNum()
        {
            int a = 0;
            try
            {
                a = int.Parse(Console.ReadLine());
                if (a < 3 || a > 100)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterNum();
            }
            return a;
        }
    }
}
