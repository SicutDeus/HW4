using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = ReadDouble("Введите первый коэф");
            double b = ReadDouble("Введите второй коэф");
            double c = ReadDouble("Введите третий коэф");

            for(double i =1;i<=2;i+=0.05)
            {
                if (i < 1.2) FirstFunc(a, b, c, i);
                else if (i == 1.2) Console.WriteLine("значение x={0}    " +
                    "  значение функции равно={1}", i, (a / i + Math.Sqrt(Math.Pow(i, 2) + 1)));
                else ThirdFunc(a, b, c, i);
                
            }
            Console.ReadLine();
        }

        public static void FirstFunc(double a,double b,double c,double x)
        {
            Console.WriteLine("значение x={0}      значение функции равно={1}", x,( a * Math.Pow(x, 2) + b * x + c));
        }


        public static void ThirdFunc(double a, double b, double c, double x)
        {
            Console.WriteLine("значение x={0}      значение функции равно={1}", x, ((a+b*x)/Math.Sqrt(Math.Pow(x,2)+1)));
        }




        public static double ReadDouble(string a)
        {
            Console.WriteLine(a);
            bool isCorrect = true;
            double x = 0;
            do
            {
                if (double.TryParse(Console.ReadLine(), out x)) isCorrect = false;
                else Console.WriteLine("Введены некорректные данные");
            } while (isCorrect);
            return x;
        }
    }
}
