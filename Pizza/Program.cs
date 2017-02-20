using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProblem
{
    enum Vege { T = 84, M = 77 }

    class Program
    {
        static void Main(string[] args)
        {
            Pizza mypizza = Parse();
            Console.Write(mypizza);
            Console.ReadKey();
        }

        static Pizza Parse() {
            Console.Write("Type the filename here: ");
            string filename = Console.ReadLine();

            string input = File.ReadAllText(filename);
            string firstline = input.Substring(0,input.IndexOf('\n'));
            input = input.Remove(0,firstline.Length+1);
            string[] vals = firstline.Split(' ');
            int x = int.Parse(vals[0]);
            int y = int.Parse(vals[1]);
            int min = int.Parse(vals[2]);
            int max = int.Parse(vals[3]);
            int[,] result = new int[x,y];
            int i = 0; int j = 0;
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var ch in row)
                {
                    result[i,j] = ch;
                    j++;
                }
                i++;
            }
            return new Pizza(min,max,x,y,result);
        }
    }
}
