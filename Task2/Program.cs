using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        const double MaxSum = 1e+5;
        static void Main(string[] args)
        {
            
            bool isCorrect = true;
            double a;
            do
            {
                if (double.TryParse(Console.ReadLine(), out a)) isCorrect = false;
                else Console.WriteLine("Введены неверные значения");
            } while (isCorrect);
            Console.WriteLine(Sum1(a));
            Console.ReadLine();

        }

        public static double Sum1(double x)
        {
            double k1 = 0;
            double k2;
            double sum=0;
            int i = 3;
            int j = 5;
            do
            {
                k1 = -(Math.Pow(2, i) * Math.Pow(x, i + 1) / Factorial((i + 1)));
                k2 = Math.Pow(2, j) * Math.Pow(x, j + 1) / Factorial((j + 1));
                sum = sum + Math.Pow(x, 2) + k1 + k2;
                i = i + 4;
                j = j + 4;
                Console.WriteLine(sum);
            } while (k1+k2>double.Epsilon);
            return sum;
        }

        public static int Factorial(int a)
        {
            int fact = 1;
            for (int i = 2; i <= a; i++)
                fact = fact * i;
            return a;
        }
    }
}
