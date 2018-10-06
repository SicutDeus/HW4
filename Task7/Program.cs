using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int Otstan = 0;
            for (int i = 1;i<21;i++)
                for(int j=1;j<21;j++)
                    for(int k=1;k<21;k++)
                        if(Math.Pow(i,2)+Math.Pow(j,2)==Math.Pow(k,2))
                        {
                            Otstan++;
                            Console.WriteLine("{0}  {1}   {2}", i, j, k);
                        }
            Console.WriteLine("Всего таких пар = {0}", Otstan);
            Console.ReadLine();
        }
    }
}
