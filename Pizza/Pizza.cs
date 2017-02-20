using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProblem
{
    class Pizza
    {
        int min, max, rows, cols;
        int[,] pizza;
        public Pizza(int _mi,int _ma,int _r,int _c,int[,] _pi) {
            min = _mi;
            max = _ma;
            rows = _r;
            cols = _c;
            pizza = _pi;
        }
        public override string ToString() {
            string text = "\n";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (pizza[i,j] == (int)Vege.T)
                        text += 'T';
                    else if (pizza[i,j] == (int)Vege.M)
                        text += 'M';
                }
                text += '\n';
            }
            return text;
        }
    }
}
