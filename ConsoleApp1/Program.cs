using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            DateTime dold = DateTime.Now;
            for (int i = 0; i < 8354; i++)
            a= 4 << 1; 
            DateTime bold = DateTime.Now;
            TimeSpan time1 = dold - bold;
            Console.WriteLine(time1);

             dold = DateTime.Now;
            for (int i = 0; i < 8354; i++)
             a=4 * 2; 
             bold = DateTime.Now;
            TimeSpan time2 = dold - bold;
            Console.WriteLine(time2);

            Console.ReadLine();
        }
    }
}
