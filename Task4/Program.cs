using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        const double MaxNum = 9e+13;
        static void Main(string[] args)
        {
            int Sum1 = 2; int Sum2 = 2;
            int N = ReadInt("Введите число N");
            int M = ReadInt("Введите число M");

            int i = 1;


            do
            {
                Sum1 = Sum1 << 1;
                i++;
            } while ((i < N) && Sum1 < MaxNum&&Sum1!=0);

            if (i < N - 1) Console.WriteLine("Превышает границы");
            else
            {

                i = 1;
                do
                {
                    Sum2 = Sum2 << 1;
                    i++;

                } while (i < M && Sum2 < MaxNum&&Sum1+Sum2<MaxNum&&Sum2!=0);
                if (i<M-1||Sum1+Sum2>MaxNum)
                    Console.WriteLine("Введены неверные значения");

                else
                { 
                    Console.WriteLine("{0}  {1}",Sum2,Sum1);
                    Console.WriteLine(Sum1 + Sum2);
                }
            }
                Console.ReadLine();
            
        }


        public static int ReadInt(string  a)
        {
            Console.WriteLine(a);
            bool isCorrect=true;
            int b;
            do
            {
                if (Int32.TryParse(Console.ReadLine(), out b)&&b<MaxNum) isCorrect = false;
                else Console.WriteLine(" Неверно");

            } while (isCorrect);
            return b;
        }
    }
}
