using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        const double MaxInput = 1e+5;
        static void Main(string[] args)
        {
            bool isCorrect = true;
            int k;
            bool Lose = true;
            double sum = 0;
            do
            {
                Console.WriteLine("Введите целое,положительное число");
                if (int.TryParse(Console.ReadLine(), out k) && k > 0)
                {
                    isCorrect = false;
                }
                else Console.WriteLine("Введены неверные значения");
            } while (isCorrect);

            for (int i = 1; i <= k; i++)
            {
                if((3 * Math.Pow(i, 2) + 5)!=0)
                sum = sum + (i + 0.3) / (3 * Math.Pow(i, 2) + 5);
                else { Console.WriteLine("Знаменатель равен нулю"); i += k; Lose = false; }   
            }
            if (!(sum < MaxInput)) Console.WriteLine("Результат превышает допустимое значение");
            else if (!Lose) Console.WriteLine("Преобразование выполнить не удалось,знаменатель равен нулю");
            else Console.WriteLine(sum);
            Console.WriteLine("{0:F3}",Double.Epsilon);
            Console.ReadLine();
        }
    }
}
