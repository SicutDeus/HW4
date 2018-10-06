using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class Program
    {
        const double MaxNum = 1e+5;
        static void Main(string[] args)
        {
            int sum=0;int K = 0;
            do
            {
                int a = ReadInt("");
                if (a < 0) sum=sum=a; K++;
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape&&sum<1000);
            Console.WriteLine(sum / K);
            Console.ReadKey();
        }


        public static int ReadInt(string a)
        {
            bool isCorrect = true;
            int b = 0;
            do {
                if (Int32.TryParse(Console.ReadLine(), out b) && b < MaxNum) isCorrect = false;
                else Console.Write("Введены неправильные значения");
                    } while (isCorrect);
            return b;
        }
    }
}
