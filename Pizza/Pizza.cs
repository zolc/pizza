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

        bool[,] leftPizza;
        public List<Rectangle> prostokaty;

        public Pizza(int _mi,int _ma,int _r,int _c,int[,] _pi,bool[,] _b)
        {
            min = _mi;
            max = _ma;
            rows = _r;
            cols = _c;
            pizza = _pi;
            leftPizza = _b;
            prostokaty = new List<Rectangle>();
        }
        public override string ToString()
        {
            string text = "\nmin: " + min + "\nmax: " + max + "\n\n";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (leftPizza[i,j])
                        text += '*';
                    else
                        text += ' ';
                }
                text += '\n';
            }
            return text;
        }

        public void SearchHorizontal()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <= cols - 2 * min; j++)
                {
                    int tCount = 0;
                    int mCount = 0;
                    for (int q = 0; q < 2 * min; q++)
                    {
                        if (pizza[i,j + q] == 'T') tCount++;
                        else if (pizza[i,j + q] == 'M') mCount++;
                    }
                    if(tCount >= min && mCount >= min)
                    {
                        Rectangle tmp = new Rectangle(i,j,1,2 * min);
                        if (IsFreeAndCorrect(tmp))
                        {
                            ReserveSpace(tmp);
                            prostokaty.Add(tmp);
                        }
                        j += 2 * min - 1;
                    }
                }

            }
        }

        public void SearchVertical()
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j <= rows - 2 * min; j++)
                {
                    int tCount = 0;
                    int mCount = 0;
                    for (int q = 0; q < 2 * min; q++)
                    {
                        if (!leftPizza[j + q,i]) break;
                        if (pizza[j + q,i] == 'T') tCount++;
                        else if (pizza[j + q,i] == 'M') mCount++;
                    }
                    if (tCount >= min && mCount >= min)
                    {
                        Rectangle tmp = new Rectangle(j,i,2 * min,1);
                        if (IsFreeAndCorrect(tmp))
                        {
                            ReserveSpace(tmp);
                            prostokaty.Add(tmp);
                        }
                        j += 2 * min - 1;
                    }
                }

            }
        }
        public void Union(ref Rectangle Base, Rectangle Extension)
        {
            if (Base.Size + Extension.Size > max)
                return;
            ReserveSpace(Extension);
            if (Base.x != Extension.x)
            {
                if (Base.x > Extension.x)
                    Base.x = Extension.x;
                Base.height += Extension.height;
            }
            if (Base.y != Extension.y)
            {
                if (Base.y > Extension.y)
                    Base.y = Extension.y;
                Base.length += Extension.length;
            }
        }
        public void Expand(Rectangle rec)
        {
            if(rec.height==1)
            {
                while (true)
                {
                    Rectangle Extension = new Rectangle(rec.x + rec.height, rec.y, 1, rec.length);
                    if (Extension.Size + rec.Size > max)
                        break;
                    if (IsFreeAndCorrect(Extension))
                        Union(ref rec, Extension);
                    else break;
                }
                while (true)
                {
                    Rectangle Extension = new Rectangle(rec.x -1, rec.y, 1, rec.length);
                    if (Extension.Size + rec.Size > max)
                        break;
                    if (IsFreeAndCorrect(Extension))
                        Union(ref rec, Extension);
                    else break;
                }
                while (true)
                {
                    Rectangle Extension = new Rectangle(rec.x , rec.y+rec.length, rec.height, 1);
                    if (Extension.Size + rec.Size > max)
                        break;
                    if (IsFreeAndCorrect(Extension))
                        Union(ref rec, Extension);
                    else break;
                }
                while (true)
                {
                    Rectangle Extension = new Rectangle(rec.x, rec.y-1, rec.height, 1);
                    if (Extension.Size + rec.Size > max)
                        break;
                    if (IsFreeAndCorrect(Extension))
                        Union(ref rec, Extension);
                    else break;
                }
            }
            else
            {
                while (true)
                {
                    Rectangle Extension = new Rectangle(rec.x, rec.y + rec.length, rec.height, 1);
                    if (IsFreeAndCorrect(Extension))
                        Union(ref rec, Extension);
                    else break;
                }
                while (true)
                {
                    Rectangle Extension = new Rectangle(rec.x, rec.y - 1, rec.height, 1);
                    if (IsFreeAndCorrect(Extension))
                        Union(ref rec, Extension);
                    else break;
                }
                while (true)
                {
                    Rectangle Extension = new Rectangle(rec.x + rec.height, rec.y, 1, rec.length);
                    if (IsFreeAndCorrect(Extension))
                        Union(ref rec, Extension);
                    else break;
                }
                while (true)
                {
                    Rectangle Extension = new Rectangle(rec.x - 1, rec.y, 1, rec.length);
                    if (IsFreeAndCorrect(Extension))
                        Union(ref rec, Extension);
                    else break;
                }
            }



        }
        public bool IsFreeAndCorrect(Rectangle rec)
        {
            if (rec.x < 0 || rec.y < 0||rec.x+rec.height>rows||rec.y+rec.length>cols)
                return false;
            for (int i = 0; i < rec.length; i++)
                for (int j = 0; j < rec.height; j++)
                    if (!leftPizza[rec.x + j, rec.y + i])
                        return false;
            return true;
        }
        public void ReserveSpace(Rectangle rec)
        {
            for (int i = 0; i < rec.length; i++)
                for (int j = 0; j < rec.height; j++)
                    leftPizza[rec.x + j,rec.y + i] = false;
        }

         
    }

}



